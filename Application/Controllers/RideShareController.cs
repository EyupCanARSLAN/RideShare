using Application.Models.RestModels.Request;
using AutoMapper;
using Business.Interfaces;
using Business.Models.FindTripService.RequestModels;
using Business.Models.FindTripService.ResponseModels;
using Business.Models.TripCreatorService.RequestModel;
using Business.Models.TripCreatorService.ResponseModel;
using Business.Models.TripReservationService.RequestModel;
using Business.Models.TripReservationService.ResponseModel;
using Business.Models.TripStatusService.RequestModel;
using Common;
using Microsoft.AspNetCore.Mvc;


namespace URLShortening.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideShareController : ControllerBase

    {
        private readonly IFindTripService _findTripSerive;
        private readonly ITripCreatorService _tripCreatorService;
        private readonly ITripStatusService _tripStatusService;
        private readonly ITripReservationService _tripreservationService;
        private readonly IMapper _mapper;
 
        public RideShareController(IFindTripService findTripSerive, ITripCreatorService tripCreatorService, ITripStatusService tripStatusService, ITripReservationService tripReservationService, IMapper mapper)
        {
            _findTripSerive = findTripSerive;
            _tripCreatorService = tripCreatorService;
            _tripStatusService = tripStatusService;
            _tripreservationService = tripReservationService;
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
            return _tripCreatorService.Execute(tripCreatorServiceRequestModel);
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
            return _findTripSerive.Execute(findTripServiceRequestModel);
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
            return _tripreservationService.Execute(tripReservationServiceRequestModel);
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
            return _tripStatusService.Execute(tripStatusServiceRequestModel);
        }
    }
}
