using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.RestModels.Request
{
    public class FindTripRestRequestModel
    {     /// <summary>
          /// Trip Route
          /// </summary>
          /// <example>F6,G4</example>
        public string Routate { get; set; }
        /// <summary>
        /// Trip Date
        /// </summary>
        /// <example>2023-12-01</example>
        public DateTime TripDate { get; set; }
    }
}
