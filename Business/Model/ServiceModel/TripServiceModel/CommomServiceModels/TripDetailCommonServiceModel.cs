using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model.ServiceModel.TripServiceModel.CommomServiceModels
{
    public class TripDetailCommonServiceModel
    {
        public string ReservationKey { get; set; }
        public string ExpForReservationKey { get; set; }

        public string DriverName { get; set; }
        public string Explanation { get; set; }

        /// <summary>
        /// Estimated travel distance  for person who search trip at the search route
        /// </summary>
        public string EstimatedDistanceForPassangerSearchRouteAsKm { get; set; }
        /// <summary>
        ///FullTripRoute
        /// </summary>
        public string FullTripRoute { get; set; }
        /// <summary>
        /// Searched Route  for person who search trip
        /// </summary>
        public string YourRoute { get; set; }
        /// <summary>
        /// Allowed maximun passanger count by driver 
        /// </summary>
        public int CarMaxPassangerCount { get; set; }
        /// <summary>
        /// Empty seat as total
        /// </summary>
        public int EmptySeatsInTheCar { get; set; }
        /// <summary>
        /// The passanger count that reserved seat in the same route for person who search trip
        /// </summary>
        public int TotalPassangerCountInYourRotate { get; set; }
    }
}
