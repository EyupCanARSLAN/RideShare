using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    /// <summary>
    /// Hold the passanger information
    /// </summary>
    [Table("Passanger")]

    public class Passanger
    {
        [Key]
        public int Id { get; set; }
        public String PassangerName { get; set; }


        [ForeignKey("TripDetailFk")]
        public TripDetail TripDetail { get; set; }
        public int TripDetailFk { get; set; }

        public string TokenForThisReservation { get; set; }
    }
}
