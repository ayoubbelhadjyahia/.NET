using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Display(Name="Date of Birth"),DataType(DataType.Date)]
        public DateTime birthDate { get; set; }
        [StringLength(maximumLength:25, MinimumLength =7,ErrorMessage ="un message d'erreur")]
        public int PassengerId { get; set; }
        [DataType(DataType.EmailAddress)]
       //wa7da menhom [EmailAddress]
        public string emailAdress { get; set; }
        [RegularExpression("[0-9]{8}")]//{,8}mel 0 lel 8
        /// lel int [MinLength(8),MaxLength(8)]
        public string telNumber { get; set; }
        [Key,MaxLength(7)]
        public string passportNumber { get; set; }
        public virtual List<Ticket> tickets { get; set; }

        public FullName FullName { get; set; }
        public virtual List<Reservation> Reservations{ get; set; }

        public override string ToString()
        {
            return birthDate + " " + emailAdress + " " + telNumber + " " + passportNumber ;
        }

        /*
        public bool CheckProfile(string fName, string lName)
        {
            return fName == firstName && lName == lastName;
        }
        public bool CheckProfile(string fName, string lName, string email)
        {
            return fName == firstName && lName == lastName && email == emailAdress;
        }
        */

     /*   public bool CheckProfile(string fName, string lName, string email=null)
        {
            if (email==null)
                return fName == firstName && lName == lastName;

            return fName == firstName && lName == lastName && email == emailAdress;
        }
     */
        public virtual void PassengerType()
        {
            Console.WriteLine("I am passenger");
        }

    }
}
