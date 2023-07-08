using Domain.Entity;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Repos
{
    public class PassengerRepository: IPassangerRepository
    {
        RideShareDbContext _dbContext;
        public PassengerRepository(RideShareDbContext urlShorteningDbContext)
        {
            _dbContext = urlShorteningDbContext;
        }

        public void SavePassanger(Passanger passenger)
        {
            _dbContext.Add(passenger);
            _dbContext.SaveChanges();
        }
    }
}
