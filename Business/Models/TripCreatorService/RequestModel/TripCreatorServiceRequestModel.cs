namespace Business.Models.TripCreatorService.RequestModel
{
    public class TripCreatorServiceRequestModel
    {
        public string DriverName { get; set; }
        public string Routate { get; set; }
        public DateTime TripDate { get; set; }
        public int AllowedMaxPassagerCount { get; set; }
        public string ExtraInformation { get; set; }
    }
}
