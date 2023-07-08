using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Interfaces
{

    public interface ITripRepository
    {
        Trip FindTripByToken(string tripToken);
        Trip FindTripById(int tripId);
        void CreateTrip(Trip trip);
        void UpdateTrip(Trip trip);
    }
}
