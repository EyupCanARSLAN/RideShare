using Application.Models.RestModels.Request;
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
        public RideShareController(IFindTripService findTripSerive, ITripCreatorService tripCreatorService, ITripStatusService tripStatusService, ITripReservationService tripReservationService)
        {
            _findTripSerive = findTripSerive;
            _tripCreatorService = tripCreatorService;
            _tripStatusService = tripStatusService;
            _tripreservationService = tripReservationService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="DriverName">Can</param>
        /// <returns></returns>
        [HttpPost("CreateTripRequest")]
        public ServiceResult<TripCreatorServiceResponseModel> CreateTripRequest(CreateTripRestRequetModel createTripRestRequetModel)
        {
            TripCreatorServiceRequestModel tripCreatorServiceRequestModel = new TripCreatorServiceRequestModel();
            tripCreatorServiceRequestModel.DriverName = createTripRestRequetModel.DriverName;
            tripCreatorServiceRequestModel.Routate = createTripRestRequetModel.Routate;
            tripCreatorServiceRequestModel.TripDate = createTripRestRequetModel.TripDate;
            tripCreatorServiceRequestModel.AllowedMaxPassagerCount = createTripRestRequetModel.AllowedMaxPassagerCount;
            tripCreatorServiceRequestModel.ExtraInformation = createTripRestRequetModel.ExtraInformation;

            return _tripCreatorService.Execute(tripCreatorServiceRequestModel);
        }


        [HttpPost("FindTrip")]
        public ServiceResult<List<FindTripServiceResponseModel>> FindTrip(FindTripRestRequestModel findTripApiRestRequestModel)
        {
            FindTripServiceRequestModel findTripServiceRequestModel = new FindTripServiceRequestModel();
            findTripServiceRequestModel.Routate = findTripApiRestRequestModel.Routate;
            findTripServiceRequestModel.TripDate = findTripApiRestRequestModel.TripDate;

            return _findTripSerive.Execute(findTripServiceRequestModel);
        }



        [HttpPost("TripStatus")]
        public ServiceResult<string> TripStatus(TripStatusRestRequestModel tripStatusRestRequestModel)
        {
          
            TripStatusServiceRequestModel tripStatusServiceRequestModel = new TripStatusServiceRequestModel();
            tripStatusServiceRequestModel.TripToken = tripStatusRestRequestModel.TripToken;
            tripStatusServiceRequestModel.IsActive = tripStatusRestRequestModel.IsActive;
            return _tripStatusService.Execute(tripStatusServiceRequestModel);
        }


        [HttpPost("TripReservation")]
        public ServiceResult<TripReservationServiceResponseModel> TripReservation(TripReservationRestRequestModel tripStatusRestRequestModel)
        {
            TripReservationServiceRequestModel tripReservationServiceRequestModel = new TripReservationServiceRequestModel();

            tripReservationServiceRequestModel.PassangerNameAndSurname = tripStatusRestRequestModel.PassangerNameAndSurname;
            tripReservationServiceRequestModel.TripToken = tripStatusRestRequestModel.TripToken;

          return _tripreservationService.Execute(tripReservationServiceRequestModel);
        }




    }
}
