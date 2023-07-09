namespace Application.Models.RestModels.Request
{
    public class TripReservationRestRequestModel
    {    /// <summary>
         /// Get this via FindTrip RestApi
         /// </summary>
         /// <example>Get this via FindTrip RestApi </example>
        public string TripToken { get; set; }
        /// <summary>
        /// PassangerNameAndSurname
        /// </summary>
        /// <example>Can Arslan </example>
        public string PassangerNameAndSurname { get; set; }
    }
}
