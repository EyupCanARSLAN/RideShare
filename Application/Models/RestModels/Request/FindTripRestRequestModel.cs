using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.RestModels.Request
{
    public class FindTripRestRequestModel
    {
        public string Routate { get; set; }
        public DateTime TripDate { get; set; }
    }
}
