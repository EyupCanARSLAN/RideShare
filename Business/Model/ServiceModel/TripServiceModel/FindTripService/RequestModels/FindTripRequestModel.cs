using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model.ServiceModel.TripServiceModel.FindTripService.RequestModels
{
    public class FindTripServiceRequestModel
    {
        public string Routate { get; set; }
        public DateTime TripDate { get; set; }
    }
}
