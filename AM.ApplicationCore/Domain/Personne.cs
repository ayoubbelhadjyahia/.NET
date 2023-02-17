using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Personne
    {
        public Personne()
        {
        }
        public virtual void GetMy()
        {
            Console.WriteLine("je suis personne");
        }
        public bool Login(string username, string password) {

            return username == nom && password == Password ;
        } 
        public bool Login(string username, string password,string email) { 
            
        //if(username == nom && password==Password && email== Email)
        //        return true;
        //return false;
        //
        return username == nom && password == Password && email==Email;  
                } 

        public Personne(string nom, string prenom, string email, string confirmePassword, string password, DateTime dateNaissance)
        {
            this.nom = nom;
            this.prenom = prenom;
            Email = email;
            ConfirmePassword = confirmePassword;
            Password = password;
            DateNaissance = dateNaissance;
        }

        public String nom { get; set; }
        public String prenom { get; set; }
        public String Email { get; set; }
        public String ConfirmePassword { get; set; }
        public String Password { get; set; }
        public DateTime DateNaissance { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return "\nNom="+nom+ "\nPrenom=" + prenom+ "\nEmail=" + Email+ "\nDateNaissance=" + DateNaissance + "\nPassword=" + Password + "\nConfirmerPassword=" + ConfirmePassword;
        }




    }
    
    
}
