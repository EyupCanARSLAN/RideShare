using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    /// <summary>
    /// Hold the trip detail information
    /// </summary>
    [Table("TripDetail")]
    public class TripDetail
    {
        [Key]
        public int Id { get; set; }
        public string Route { get; set; }
        public int Distance { get; set; }

        public int PassengerCountForThisDistance { get; set; }

        [ForeignKey("TripFK")]
        public Trip Trip { get; set; }
        public int TripFK { get; set; }
        public string TripDetailToken { get; set; }

        public ICollection<Passanger> PassengerList { get; set; }
    }
}
