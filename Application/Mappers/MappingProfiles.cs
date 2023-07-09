using Application.Models.RestModels.Request;
using AutoMapper;
using Business.Models.FindTripService.RequestModels;
using Business.Models.TripCreatorService.RequestModel;
using Business.Models.TripReservationService.RequestModel;
using Business.Models.TripStatusService.RequestModel;

namespace Application.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateTripRestRequetModel, TripCreatorServiceRequestModel>();
            CreateMap<FindTripRestRequestModel, FindTripServiceRequestModel>();
            CreateMap<TripStatusRestRequestModel, TripStatusServiceRequestModel > ();
            CreateMap <TripReservationRestRequestModel, TripReservationServiceRequestModel > ();

        }
    }
}
