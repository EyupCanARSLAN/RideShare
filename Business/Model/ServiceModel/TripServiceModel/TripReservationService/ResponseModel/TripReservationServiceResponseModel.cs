using Business.Model.ServiceModel.TripServiceModel.CommomServiceModels;

namespace Business.Model.ServiceModel.TripServiceModel.TripReservationService.ResponseModel
{
    public class TripReservationServiceResponseModel
    {
        public TripDetailCommonServiceModel tripInfo { get; set; }
        public string Explanation { get; set; }
        public string Token { get; set; }
    }

  
}
