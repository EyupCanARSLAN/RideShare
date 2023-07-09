namespace Application.Models.RestModels.Request
{
  
    public class CreateTripRestRequetModel
    {
        /// <summary>
        /// DriverName
        /// </summary>
        /// <example>Eyup Arslan</example>
        public string DriverName { get; set; }
        /// <summary>
        /// Trip Route
        /// </summary>
        /// <example>F5,F6,G6,G5,G4,F4</example>
        public string Routate { get; set; }
        /// <summary>
        /// Trip Date
        /// </summary>
        /// <example>2023-12-01T00:00:00</example>
        public DateTime TripDate { get; set; }
        /// <summary>
        /// AllowedMaxPassagerCount
        /// </summary>
        /// <example>4</example>
        public int AllowedMaxPassagerCount { get; set; }
        /// <summary>
        /// AllowedMaxPassagerCount
        /// </summary>
        /// <example>Start F5, Finish F4 cities. Only 4 passanger</example>
        public string ExtraInformation { get; set; }
    }
}
