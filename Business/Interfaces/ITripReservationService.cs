using Business.Models.TripReservationService.RequestModel;
using Business.Models.TripReservationService.ResponseModel;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ITripReservationService
    {
        ServiceResult<TripReservationServiceResponseModel> Execute(TripReservationServiceRequestModel reservationToSelectedTripViewModel);

    }
}
