using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public double Prix { get; set; }
        public String Siege { get; set; }
        public bool VIP { get; set; }
        [ForeignKey("passanFK")]
        public string passanFK { get; set; }
        [ForeignKey("passanFK")]
        public int flightFK { get; set; }
        public Passenger Passenger { get; set; }
        public Flight Flight {get;set;} 
    }
}
