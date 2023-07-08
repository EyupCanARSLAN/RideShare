using Domain.Entity;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository.Repos
{
 
    public class TripRepository : ITripRepository
    {
        RideShareDbContext _dbContext;
        public TripRepository(RideShareDbContext urlShorteningDbContext)
        {
            _dbContext = urlShorteningDbContext;
        }
        public void CreateTrip(Trip trip)
        {
            _dbContext.Add(trip);
            _dbContext.SaveChanges();
        }

        public void UpdateTrip(Trip trip)
        {
            _dbContext.Update(trip);
            _dbContext.SaveChanges();
        }

        public Trip FindTripById(int tripId)
        {
          return  _dbContext.Trip.First(x=>x.Id==tripId);
        }

        public Trip FindTripByToken(string tripToken)
        {
            return _dbContext.Trip.First(x => x.TripToken == tripToken);
        }
    }
}
