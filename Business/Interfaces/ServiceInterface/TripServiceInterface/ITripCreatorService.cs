using Business.Model.ServiceModel.TripServiceModel.TripCreatorService.RequestModel;
using Business.Model.ServiceModel.TripServiceModel.TripCreatorService.ResponseModel;
using Common;

namespace Business.Interfaces.ServiceInterface.TripServiceInterface
{
    public interface ITripCreatorService
    {
        public ServiceResult<TripCreatorServiceResponseModel> CreateTrip(TripCreatorServiceRequestModel tripCreatorServiceRequestModel);
    }
}
