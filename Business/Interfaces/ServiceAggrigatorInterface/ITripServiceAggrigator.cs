using Business.Interfaces.ServiceInterface.TripServiceInterface;

namespace Business.Interfaces.ServiceAggrigatorInterface
{
    public interface ITripServiceAggrigator: IFindTripService, ITripCreatorService, ITripReservationService, ITripStatusService
    {
    }
}
