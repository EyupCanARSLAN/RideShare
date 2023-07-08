using Business.Models.CommomServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.TripReservationService.ResponseModel
{
    public class TripReservationServiceResponseModel
    {
        public TripDetailCommonServiceModel tripInfo { get; set; }
        public string Explanation { get; set; }
        public string Token { get; set; }
    }

  
}
