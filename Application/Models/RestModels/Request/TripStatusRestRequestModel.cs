namespace Application.Models.RestModels.Request
{
    public class TripStatusRestRequestModel
    {
        /// <summary>
        /// Use token that generetad by CreateTripRequest Rest Api
        /// </summary>
        /// <example>Use token that generetad by CreateTripRequest Rest Api </example>
        public string TripToken { get; set; }
        /// <summary>
        /// Set Active Or Passive status via True and False
        /// </summary>
        /// <example>false </example>
        public bool IsActive { get; set; }
    }
}
