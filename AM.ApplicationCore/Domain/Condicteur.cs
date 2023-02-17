using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Condicteur :Personne
    {
        public DateTime DatePermi { get; set; }
        public String TypePermi { get; set; }

        public override string ToString()
        {
            return base.ToString()+" "+DatePermi+" "+TypePermi;
        }
        public override void GetMy()
        {   
            base.GetMy();
            Console.WriteLine("je suis conducteur");
        }



    }
}
