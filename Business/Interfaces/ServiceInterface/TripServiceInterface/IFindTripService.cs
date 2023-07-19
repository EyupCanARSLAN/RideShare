using Business.Model.ServiceModel.TripServiceModel.FindTripService.RequestModels;
using Business.Model.ServiceModel.TripServiceModel.FindTripService.ResponseModels;
using Common;

namespace Business.Interfaces.ServiceInterface.TripServiceInterface
{
    public interface IFindTripService
    {
        ServiceResult<List<FindTripServiceResponseModel>> FindTrip(FindTripServiceRequestModel findTripViewModel);
    }
}
