using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class TripReservationServiceCreateTripModel
    {
        public int ReservationId { get; set; }
        public string TripToken  { get; set; }
    }
}
