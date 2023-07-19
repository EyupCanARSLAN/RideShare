using Business.Model.ServiceModel.TripServiceModel.TripStatusService.RequestModel;
using Common;

namespace Business.Interfaces.ServiceInterface.TripServiceInterface
{
    public interface ITripStatusService
    {
        ServiceResult<string> TripStatusChange(TripStatusServiceRequestModel tripStatusServiceRequestModel);
    }
}
