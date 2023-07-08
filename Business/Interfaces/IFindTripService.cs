using Business.Models.FindTripService.RequestModels;
using Business.Models.FindTripService.ResponseModels;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IFindTripService
    {
        ServiceResult<List<FindTripServiceResponseModel>> Execute(FindTripServiceRequestModel findTripViewModel);
    }
}
