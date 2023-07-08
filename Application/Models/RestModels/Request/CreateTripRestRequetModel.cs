namespace Application.Models.RestModels.Request
{
    public class CreateTripRestRequetModel
    {
        public string DriverName { get; set; }
        public string Routate { get; set; }
        public DateTime TripDate { get; set; }
        public int AllowedMaxPassagerCount { get; set; }
        public string ExtraInformation { get; set; }
    }
}
