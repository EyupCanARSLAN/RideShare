using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Model.ServiceModel.TripServiceModel.TripReservationService.InternalModel
{
    public class TripReservationServiceCreateTripModel
    {
        public int ReservationId { get; set; }
        public string TripToken  { get; set; }
    }
}
