using Application.Models.RestModels.Request;
using AutoMapper;
using Business.Model.ServiceModel.TripServiceModel.FindTripService.RequestModels;
using Business.Model.ServiceModel.TripServiceModel.TripCreatorService.RequestModel;
using Business.Model.ServiceModel.TripServiceModel.TripReservationService.RequestModel;
using Business.Model.ServiceModel.TripServiceModel.TripStatusService.RequestModel;

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
