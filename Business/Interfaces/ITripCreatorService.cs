using Business.Models.TripCreatorService.RequestModel;
using Business.Models.TripCreatorService.ResponseModel;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ITripCreatorService
    {
        public ServiceResult<TripCreatorServiceResponseModel> Execute(TripCreatorServiceRequestModel tripCreatorServiceRequestModel);
    }
}
