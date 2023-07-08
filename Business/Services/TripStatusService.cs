using Business.Interfaces;
using Business.Models.TripStatusService.RequestModel;
using Common;
using Domain.Repository.Interfaces;

namespace Business.Services
{
    public class TripStatusService: ITripStatusService
    {
        readonly ITripRepository _tripRepository;
        public TripStatusService(ITripRepository tripRepository)
        {
            _tripRepository=tripRepository;
        }
        public ServiceResult<string> Execute(TripStatusServiceRequestModel tripStatusServiceRequestModel)
        {
            try
            {
                SetTripStatus(tripStatusServiceRequestModel);
                return ServiceResult<string>.SuccessResponse("Your trip status set changed.");
            }
            catch (Exception exp)
            {
                return ServiceResult<string>.FailResponse("Unexpected error occured.");
            }
        }
        private void SetTripStatus(TripStatusServiceRequestModel tripStatusServiceRequestModel)
        {
            var trip = _tripRepository.FindTripByToken(tripStatusServiceRequestModel.TripToken);
            trip.isThisTripActive = tripStatusServiceRequestModel.IsActive;
            _tripRepository.UpdateTrip(trip);
        }
    }
}