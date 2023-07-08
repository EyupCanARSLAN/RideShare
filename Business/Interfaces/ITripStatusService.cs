using Business.Models.TripStatusService.RequestModel;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ITripStatusService
    {
        ServiceResult<string> Execute(TripStatusServiceRequestModel tripStatusServiceRequestModel);
    }
}
