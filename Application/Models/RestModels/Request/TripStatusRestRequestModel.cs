namespace Application.Models.RestModels.Request
{
    public class TripStatusRestRequestModel
    {
        public string TripToken { get; set; }
        public bool IsActive { get; set; }
    }
}
