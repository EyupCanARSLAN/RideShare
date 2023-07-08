using Business.Interfaces;
using Business.Models.TripCreatorService.RequestModel;
using Business.Models.TripCreatorService.ResponseModel;
using Common;
using Domain.Entity;
using Domain.Repository.Interfaces;
using RestApi.Models;

namespace Business.Services
{
    /// <summary>
    /// This class create a Trip and Trip Detail accoring to driver's request
    /// </summary>
    public class TripCreatorService: ITripCreatorService
    {

        readonly ITripRepository _tripRepository;
        readonly ITripDetailRepository _tripDetailRepository;
        public TripCreatorService(ITripRepository tripRepository,ITripDetailRepository tripDetailRepository)
        {
            _tripRepository=tripRepository;
            _tripDetailRepository = tripDetailRepository;
        }


        public ServiceResult<TripCreatorServiceResponseModel> Execute(TripCreatorServiceRequestModel tripCreatorServiceRequestModel)
        {

            try
            {
                var isRequirementOk = CheckRequirement(tripCreatorServiceRequestModel);
                if (isRequirementOk.Status == ServiceResultStatus.Fail)
                {
                    return isRequirementOk;
                }

                var createRouteList = GetRouteList(tripCreatorServiceRequestModel);
                var tripId = CreateTrip(tripCreatorServiceRequestModel);
                CreateTripDetail(tripId.ReservationId, createRouteList);

                var explanation = "Your trip was created with the ID " + tripId.TripToken + "  Please note that this id. You can use this id to deactive your travel";
                return ServiceResult<TripCreatorServiceResponseModel>.SuccessResponse(GenerateResultModel(explanation, tripId.TripToken));
            }
            catch(Exception exp)
            {
                return ServiceResult<TripCreatorServiceResponseModel>.FailResponse("Unexpected error occured.");
            }
        }

        /// <summary>
        /// Check viewmodel rules, if they are not acceptable then stop the progress.
        /// </summary>
        /// <param name="tripCreateViewModel"></param>
        /// <returns></returns>
        private ServiceResult<TripCreatorServiceResponseModel> CheckRequirement(TripCreatorServiceRequestModel tripCreatorServiceRequestModel)
        {
            var errorMessageList = "";
            var isItOk = true;

            #region Route Rule Check
            var isRouteFormatAcceptable = !string.IsNullOrWhiteSpace(tripCreatorServiceRequestModel.Routate) && tripCreatorServiceRequestModel.Routate.Contains(",") && !tripCreatorServiceRequestModel.Routate.StartsWith(",") && !tripCreatorServiceRequestModel.Routate.EndsWith(",");
            if (!isRouteFormatAcceptable)
            {
                errorMessageList = "Please check Route field format !";
                isItOk = false;
            }
            #endregion

            #region Travel Date Check
            var isDateValid = tripCreatorServiceRequestModel.TripDate > DateTime.Now;
            if (!isDateValid)
            {
                errorMessageList += " Please insert valid travel date !";
                isItOk = false;
            }
            #endregion

            #region MaxPassangerCount
            var isPassangerCountValid = tripCreatorServiceRequestModel.AllowedMaxPassagerCount > 0;
            if (!isPassangerCountValid)
            {
                errorMessageList += " The passanger count have to be greater then zero!";
                isItOk = false;
            }
            #endregion

            if (isItOk)
            {
                return ServiceResult<TripCreatorServiceResponseModel>.SuccessResponse(GenerateResultModel("",""));
            }
            else
            {
                return ServiceResult<TripCreatorServiceResponseModel>.FailResponse(errorMessageList);
            }

        }

        private List<string> GetRouteList(TripCreatorServiceRequestModel tripCreatorServiceRequestModel)
        {
            return tripCreatorServiceRequestModel.Routate.Split(',').ToList<string>();
        }


        private TripReservationServiceCreateTripModel CreateTrip(TripCreatorServiceRequestModel tripCreatorServiceRequestModel)
        {
            var trip = new Trip();
            trip.isThisTripActive = true;
            trip.CurrentPassangerCount = 0;
            trip.Routate = tripCreatorServiceRequestModel.Routate;
            trip.TripToken= Guid.NewGuid().ToString();
            trip.DriverName = tripCreatorServiceRequestModel.DriverName;
            trip.TravelDate = tripCreatorServiceRequestModel.TripDate;
            trip.Explanation = tripCreatorServiceRequestModel.ExtraInformation;
            trip.Explanation = tripCreatorServiceRequestModel.ExtraInformation;
            trip.AllowedMaxPassagerCount = tripCreatorServiceRequestModel.AllowedMaxPassagerCount;
            _tripRepository.CreateTrip(trip);

             var returnModel = new TripReservationServiceCreateTripModel();
            returnModel.ReservationId = trip.Id;
            returnModel.TripToken = trip.TripToken;
            return returnModel;
        }

        private void CreateTripDetail(int tripId, List<String> routeList )
        {
            var pointCount = 0;
            foreach (var eachPoint in routeList)
            {
                pointCount++;
                var distance = 50;//Each city distance 50km
                for (int currentPointCount = pointCount; currentPointCount < routeList.Count(); currentPointCount++)
                {
                    var pointName = eachPoint + "," + routeList[currentPointCount];
                    SaveTravelDetailToDb(tripId, pointName, distance);
                    distance=distance+50;
                }
            }
        }

        private void SaveTravelDetailToDb(int tripId, string route, int distance)
        {
            var tripDetail = new TripDetail();
            tripDetail.TripFK = tripId;
            tripDetail.TripDetailToken= Guid.NewGuid().ToString();
            tripDetail.Route = route;
            tripDetail.PassengerCountForThisDistance = 0;
            tripDetail.Distance = distance;
            _tripDetailRepository.CreateTripDetail(tripDetail);
        }

      private TripCreatorServiceResponseModel GenerateResultModel(string explanation, string token)
        {
            var model = new TripCreatorServiceResponseModel();
            model.Explanation = explanation;
            model.TripToken = token;
            return model;
        }
    }
}
