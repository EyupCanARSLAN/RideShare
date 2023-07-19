using Business.Interfaces.ServiceAggrigatorInterface;
using Business.Interfaces.ServiceInterface.TripServiceInterface;
using Business.Model.ServiceModel.TripServiceModel.FindTripService.RequestModels;
using Business.Model.ServiceModel.TripServiceModel.FindTripService.ResponseModels;
using Business.Model.ServiceModel.TripServiceModel.TripCreatorService.RequestModel;
using Business.Model.ServiceModel.TripServiceModel.TripCreatorService.ResponseModel;
using Business.Model.ServiceModel.TripServiceModel.TripReservationService.RequestModel;
using Business.Model.ServiceModel.TripServiceModel.TripReservationService.ResponseModel;
using Business.Model.ServiceModel.TripServiceModel.TripStatusService.RequestModel;
using Common;

namespace Business.ServiceAggrigator
{
    public class TripServiceAggrigator: ITripServiceAggrigator
    {
        private IFindTripService _findTripService;
        private ITripCreatorService _tripCreatorService;
        private ITripReservationService _tripReservationService;
        private ITripStatusService _tripStatusService;

        public TripServiceAggrigator(IFindTripService findTripService, ITripCreatorService tripCreatorService, ITripReservationService tripReservationService, ITripStatusService tripStatusService)
        {
            _findTripService = findTripService;
            _tripCreatorService = tripCreatorService;
            _tripReservationService = tripReservationService;
            _tripStatusService = tripStatusService;
        }

        public ServiceResult<List<FindTripServiceResponseModel>> FindTrip(FindTripServiceRequestModel findTripViewModel)
        {
            return _findTripService.FindTrip(findTripViewModel);
        }

        public ServiceResult<TripCreatorServiceResponseModel> CreateTrip(TripCreatorServiceRequestModel tripCreatorServiceRequestModel)
        {
            return _tripCreatorService.CreateTrip(tripCreatorServiceRequestModel);
        }

        public ServiceResult<TripReservationServiceResponseModel> TripReservation(TripReservationServiceRequestModel reservationToSelectedTripViewModel)
        {
            return _tripReservationService.TripReservation(reservationToSelectedTripViewModel);
        }

        public ServiceResult<string> TripStatusChange(TripStatusServiceRequestModel tripStatusServiceRequestModel)
        {
            return _tripStatusService.TripStatusChange(tripStatusServiceRequestModel);
        }
    }
}
