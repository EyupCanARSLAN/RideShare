using Application.Models.RestModels.Request;
using AutoMapper;
using Business.Interfaces.ServiceAggrigatorInterface;
using Business.Model.ServiceModel.TripServiceModel.FindTripService.RequestModels;
using Business.Model.ServiceModel.TripServiceModel.FindTripService.ResponseModels;
using Business.Model.ServiceModel.TripServiceModel.TripCreatorService.RequestModel;
using Business.Model.ServiceModel.TripServiceModel.TripCreatorService.ResponseModel;
using Business.Model.ServiceModel.TripServiceModel.TripReservationService.RequestModel;
using Business.Model.ServiceModel.TripServiceModel.TripReservationService.ResponseModel;
using Business.Model.ServiceModel.TripServiceModel.TripStatusService.RequestModel;
using Common;
using Microsoft.AspNetCore.Mvc;


namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideShareController : ControllerBase

    {
        private ITripServiceAggrigator _tripServiceAggrigator;
        private readonly IMapper _mapper;
 
        public RideShareController(ITripServiceAggrigator tripServiceAggrigator, IMapper mapper)
        {
            _tripServiceAggrigator = tripServiceAggrigator;
            _mapper = mapper;
        }

        /// <summary>
        /// Create trip request
        /// </summary>
        /// <param name="createTripRestRequetModel"></param>
        /// <returns></returns>
  
        [HttpPost("CreateTripRequest")]
        public ServiceResult<TripCreatorServiceResponseModel> CreateTripRequest(CreateTripRestRequetModel createTripRestRequetModel)
        {
    
            var tripCreatorServiceRequestModel = _mapper.Map<TripCreatorServiceRequestModel>(createTripRestRequetModel);
            return _tripServiceAggrigator.CreateTrip(tripCreatorServiceRequestModel);
        }

        /// <summary>
        /// Find Trip and Trip Token
        /// </summary>
        /// <param name="createTripRestRequetModel"></param>
        /// <returns></returns>
        [HttpPost("FindTrip")]
        public ServiceResult<List<FindTripServiceResponseModel>> FindTrip(FindTripRestRequestModel findTripApiRestRequestModel)
        {

            var findTripServiceRequestModel = _mapper.Map<FindTripServiceRequestModel>(findTripApiRestRequestModel);
            return _tripServiceAggrigator.FindTrip(findTripServiceRequestModel);
        }

        /// <summary>
        /// Make a Reservation with TripToken. Triptoken can be found from "FindTrip" EndPoint
        /// </summary>
        /// <param name="tripStatusRestRequestModel"></param>
        /// <returns></returns>
        [HttpPost("TripReservation")]
        public ServiceResult<TripReservationServiceResponseModel> TripReservation(TripReservationRestRequestModel tripStatusRestRequestModel)
        {
            var tripReservationServiceRequestModel = _mapper.Map<TripReservationServiceRequestModel>(tripStatusRestRequestModel);
            return _tripServiceAggrigator.TripReservation(tripReservationServiceRequestModel);
        }

        /// <summary>
        /// Set Active or False to Trip Status. TripStatus can change via TripToken. This token can be generated via "CreateTripRequest" EndPoint
        /// </summary>
        /// <param name="tripStatusRestRequestModel"></param>
        /// <returns></returns>
        [HttpPost("TripStatus")]
        public ServiceResult<string> TripStatus(TripStatusRestRequestModel tripStatusRestRequestModel)
        {

            var tripStatusServiceRequestModel = _mapper.Map<TripStatusServiceRequestModel>(tripStatusRestRequestModel);
            return _tripServiceAggrigator.TripStatusChange(tripStatusServiceRequestModel);
        }
    }
}
