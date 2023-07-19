using Business.Interfaces.ServiceInterface.TripServiceInterface;
using Business.Model.ServiceModel.TripServiceModel.CommomServiceModels;
using Business.Model.ServiceModel.TripServiceModel.TripReservationService.RequestModel;
using Business.Model.ServiceModel.TripServiceModel.TripReservationService.ResponseModel;
using Common;
using Domain.Entity;
using Domain.Repository.Interfaces;

namespace Business.Services.TripService
{
    /// <summary>
    /// This class designed to make reservation progress for passanger who selected the trip
    /// </summary>
    public class TripReservationService : ITripReservationService
    {
        readonly ITripRepository _tripRepository;
        readonly ITripDetailRepository _tripDetailRepository;
        readonly IPassangerRepository _passangerRepository;

        public TripReservationService(ITripDetailRepository tripDetailRepository, IPassangerRepository passangerRepository, ITripRepository tripRepository)
        {
            _tripDetailRepository = tripDetailRepository;
            _passangerRepository = passangerRepository;
            _tripRepository = tripRepository;
        }

        public ServiceResult<TripReservationServiceResponseModel> TripReservation(TripReservationServiceRequestModel reservationToSelectedTripViewModel)
        {
            try
            {
                var tripInfo = GetTripInfoOnDb(reservationToSelectedTripViewModel);
                if (tripInfo == null)
                {
                    return ServiceResult<TripReservationServiceResponseModel>.FailResponse("There isnt any trip for the given token. Please check your token validation");
                }

                #region Bu bölge UnitOfWork & Generic Repo üzerinden single bir transiction  ile hata durumunda RollBack yaptırılmalı
                var getReservationTokenForThisPassanger = SavePassengerAndGetReservationToken(tripInfo.TripFK, reservationToSelectedTripViewModel.PassangerNameAndSurname);
                UpdateTripTablePassangersCount(tripInfo);
                UpdateTripDetailTablePassangersCount(tripInfo);
                #endregion

                var getLatestInfoForThisTrip = GetLatestInfoForThisTrip(reservationToSelectedTripViewModel.TripToken);

                return GenerateResult(getLatestInfoForThisTrip, getReservationTokenForThisPassanger);
            }
            catch (Exception exp)
            {
                return ServiceResult<TripReservationServiceResponseModel>.FailResponse("Unexpected error occured.");
            }
        }

        private TripDetail GetTripInfoOnDb(TripReservationServiceRequestModel reservationToSelectedTripViewMode)
        {
            var foundedTrip = _tripDetailRepository.FindTripDetailByToken(reservationToSelectedTripViewMode.TripToken);

            if (foundedTrip != null && foundedTrip.Trip.CurrentPassangerCount < foundedTrip.Trip.AllowedMaxPassagerCount)
            {
                return foundedTrip;
            }
            else
            {
                return null;
            }
        }

        private string SavePassengerAndGetReservationToken(int tripDetailId, string passangerNameAndSurname)
        {
            var passenger = new Passanger();
            passenger.PassangerName = passangerNameAndSurname;// reservationToSelectedTripViewModel.PassangerNameAndSurname;
            passenger.TripDetailFk = tripDetailId;//tripDetail.Id;
            passenger.TokenForThisReservation = Guid.NewGuid().ToString();
            _passangerRepository.SavePassanger(passenger);
            return passenger.TokenForThisReservation;
        }

        private void UpdateTripTablePassangersCount(TripDetail tripDetail)
        {
            var trip = _tripRepository.FindTripById(tripDetail.Trip.Id);
            trip.CurrentPassangerCount = trip.CurrentPassangerCount + 1;
            _tripRepository.UpdateTrip(trip);
        }

        private void UpdateTripDetailTablePassangersCount(TripDetail tripDetail)
        {
            var trip = _tripDetailRepository.FindTripDetailById(tripDetail.Id);
            trip.PassengerCountForThisDistance = trip.PassengerCountForThisDistance + 1;
            _tripDetailRepository.UpdateTripDetail(tripDetail);
        }

        private TripDetailCommonServiceModel GetLatestInfoForThisTrip(string tripToken)
        {
            var suitableTrip = _tripDetailRepository.FindTripDetailByToken(tripToken);
            var newFoundedTripList = new TripDetailCommonServiceModel();
            newFoundedTripList.ReservationKey = "";
            newFoundedTripList.ExpForReservationKey = "";
            newFoundedTripList.DriverName = suitableTrip.Trip.DriverName;
            newFoundedTripList.Explanation = suitableTrip.Trip.Explanation;
            newFoundedTripList.EstimatedDistanceForPassangerSearchRouteAsKm = suitableTrip.Distance.ToString() + " KM";
            newFoundedTripList.FullTripRoute = suitableTrip.Trip.Routate;
            newFoundedTripList.YourRoute = suitableTrip.Route;
            newFoundedTripList.CarMaxPassangerCount = suitableTrip.Trip.AllowedMaxPassagerCount;
            newFoundedTripList.EmptySeatsInTheCar = suitableTrip.Trip.AllowedMaxPassagerCount - suitableTrip.Trip.CurrentPassangerCount;
            newFoundedTripList.TotalPassangerCountInYourRotate = suitableTrip.PassengerCountForThisDistance;
            return newFoundedTripList;
        }

        private ServiceResult<TripReservationServiceResponseModel> GenerateResult(TripDetailCommonServiceModel foundedTripViewModel, string tokenForThisReservation)
        {
            var resultForThisReservation = new TripReservationServiceResponseModel();
            resultForThisReservation.Explanation = "Your reservation was created as successfull. Your reservation token is " + tokenForThisReservation;
            resultForThisReservation.tripInfo = foundedTripViewModel;
            resultForThisReservation.Token = tokenForThisReservation;
            return ServiceResult<TripReservationServiceResponseModel>.SuccessResponse(resultForThisReservation);
        }
    }
}
