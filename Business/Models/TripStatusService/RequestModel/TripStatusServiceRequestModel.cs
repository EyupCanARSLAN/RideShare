using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.TripStatusService.RequestModel
{
    public class TripStatusServiceRequestModel
    {
        public string TripToken { get; set; }
        public bool IsActive { get; set; }
    }
}
