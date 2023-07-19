using Business.Model.ServiceModel.TripServiceModel.TripReservationService.RequestModel;
using Business.Model.ServiceModel.TripServiceModel.TripReservationService.ResponseModel;
using Common;

namespace Business.Interfaces.ServiceInterface.TripServiceInterface
{
    public interface ITripReservationService
    {
        ServiceResult<TripReservationServiceResponseModel> TripReservation(TripReservationServiceRequestModel reservationToSelectedTripViewModel);

    }
}
