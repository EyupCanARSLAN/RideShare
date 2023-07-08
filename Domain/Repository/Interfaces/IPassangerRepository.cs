using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Interfaces
{

    public interface IPassangerRepository
    {
        public void SavePassanger(Passanger passenger);
    }
}
