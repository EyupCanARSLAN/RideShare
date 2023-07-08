using Domain.Entity;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Repos
{
    public class TripDetailRepository: ITripDetailRepository
    {
        RideShareDbContext _dbContext;
        public TripDetailRepository(RideShareDbContext urlShorteningDbContext)
        {
            _dbContext = urlShorteningDbContext;
        }

        public void CreateTripDetail(TripDetail tripDetail)
        {
            _dbContext.Add(tripDetail);
            _dbContext.SaveChanges();
        }
        

        public List<TripDetail> SearchTripWithDetailInDb(string route, DateTime tripDate)
        {
           return _dbContext.TripDetail.Include(x => x.Trip).Where(x => x.Trip.CurrentPassangerCount < x.Trip.AllowedMaxPassagerCount && x.Route == route && x.Trip.TravelDate == tripDate && x.Trip.isThisTripActive).ToList();
        }

        public TripDetail FindTripDetailByToken(string tripToken)
        {
            return _dbContext.TripDetail.Include(x => x.Trip).FirstOrDefault(x =>  x.TripDetailToken == tripToken && x.Trip.isThisTripActive);
        }

       public TripDetail FindTripDetailById(int tripDetailId)
        {
            return _dbContext.TripDetail.Find(tripDetailId);
        }


        public void UpdateTripDetail(TripDetail tripDetail)
        {
            _dbContext.Update(tripDetail);
            _dbContext.SaveChanges();
        }

    }
}
