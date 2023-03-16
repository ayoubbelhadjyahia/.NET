using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Seat
    {
        public int SeatId { get; set; }
        [Required(ErrorMessage ="Erreur 404"),MinLength(1)]
        public String Name { get; set; }
        public String SeatNumber { get; set; }
        [Range(0,20)]
        public int size { get; set; }

        public  virtual Plane Plane { get; set; }
        public virtual Section ? Section { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
        [ForeignKey(nameof(Plane))]
        public int PlaneFK { get; set; }
        public int ? SectionFK { get; set; }

    }
}
