using Business.Interfaces;
using Business.Models.FindTripService.RequestModels;
using Business.Models.FindTripService.ResponseModels;
using Common;
using Domain.Repository.Interfaces;

namespace Business.Services
{
    /// <summary>
    /// This class designed to find suitable trip for passanger search
    /// </summary>
    public class FindTripService:IFindTripService
    {
        readonly ITripDetailRepository _tripDetailRepository;
        public FindTripService(ITripDetailRepository tripRepository)
        {
            _tripDetailRepository = tripRepository;
        }

        public ServiceResult<List<FindTripServiceResponseModel>> Execute(FindTripServiceRequestModel findTripViewModel)
        {
            try
            {
                return SearchTripInDb(findTripViewModel);
            }
            catch (Exception exp)
            {
                return ServiceResult<List<FindTripServiceResponseModel>>.FailResponse("Unexpected error occured.");
            }
        }

        private ServiceResult<List<FindTripServiceResponseModel>> SearchTripInDb(FindTripServiceRequestModel findTripViewModel)
        {
            var suitableTrip = _tripDetailRepository.SearchTripWithDetailInDb(findTripViewModel.Routate, findTripViewModel.TripDate);

            if (suitableTrip.Count==0)
            {
                return ServiceResult<List<FindTripServiceResponseModel>>.FailResponse("There isnt any suitable trip found for your search criteria");
            }
            var foundedTripList = new List<FindTripServiceResponseModel>();
            foreach (var eachSuitableTrip in suitableTrip)
            {
                var newFoundedTripList = new FindTripServiceResponseModel();
                newFoundedTripList.ReservationKey = eachSuitableTrip.TripDetailToken;
                newFoundedTripList.ExpForReservationKey = "Use this key at ReservationToSelectedTrip API  for the reservation that is " + eachSuitableTrip.TripDetailToken;
                newFoundedTripList.DriverName = eachSuitableTrip.Trip.DriverName;
                newFoundedTripList.Explanation = eachSuitableTrip.Trip.Explanation;
                newFoundedTripList.EstimatedDistanceForPassangerSearchRouteAsKm = eachSuitableTrip.Distance.ToString() + " KM";
                newFoundedTripList.FullTripRoute = eachSuitableTrip.Trip.Routate;
                newFoundedTripList.YourRoute = eachSuitableTrip.Route;
                newFoundedTripList.CarMaxPassangerCount = eachSuitableTrip.Trip.AllowedMaxPassagerCount;
                newFoundedTripList.EmptySeatsInTheCar = eachSuitableTrip.Trip.AllowedMaxPassagerCount - eachSuitableTrip.Trip.CurrentPassangerCount;
                newFoundedTripList.TotalPassangerCountInYourRotate = eachSuitableTrip.PassengerCountForThisDistance;
                foundedTripList.Add(newFoundedTripList);
            }
            return ServiceResult<List<FindTripServiceResponseModel>>.SuccessResponse(foundedTripList);
        }
    }
}
