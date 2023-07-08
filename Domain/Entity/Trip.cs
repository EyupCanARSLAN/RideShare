using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    /// <summary>
    /// Hold the trip information
    /// </summary>
    [Table("Trip")]
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        public string DriverName { get; set; }
        public DateTime TravelDate { get; set; }
        public int AllowedMaxPassagerCount { get; set; }
        public int CurrentPassangerCount { get; set; }
        public bool isThisTripActive { get; set; }

        public string Routate { get; set; }

        public string Explanation { get; set; }
        public string TripToken { get; set; }
        public ICollection<TripDetail> TripDetail { get; set; }

    }
}
