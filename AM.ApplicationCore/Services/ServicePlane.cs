using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public IList<Flight> GetFlights(int n)
        {
            //  return GetAll().OrderBy(p=>p.planeId).TakeLast(n).SelectMany(p=>p.flights).OrderBy(p=>p.flightDate).ToList();
            return GetAll().OrderByDescending(p => p.planeId).Take(n).SelectMany(p => p.flights).OrderBy(p => p.flightDate).ToList();
        }

        public IList<Passenger> GetPassenger(Plane plane)
        {
           return plane.flights.SelectMany(p => p.tickets).Select(f => f.Passenger).Distinct().ToList();
        }
        public bool IsAvailablePlane(int n,Flight flight)
        {
          //  int capacity = Get(p => p.flights.Where(f => f.flightId == flight.flightId).Count() > 0).capacity;
           // var plane= GetAll().Where(p=>p.flights.Contains(flight)==true).First(); 
           // var flightt=plane.flights.Single(j=>j.flightId==flight.flightId);
            int capacity = Get(p=>p.flights.Contains(flight) == true).capacity;
            int nbPassengers = flight.tickets.Count();
            //return ;
            return capacity >= (nbPassengers + n);
        }
        public void DeletePlanes()
        {
            ///////////pour un objet 
            //foreach (var p in  GetAll().Where(p => (DateTime.Now - p.manufactureDate).TotalDays > 365 * 10).ToList())
            // {
            //     Delete(p);
            // }
            // Commit();


            ////////pour une list
            Delete(p => (DateTime.Now - p.manufactureDate).TotalDays > 365 * 10);
            Commit();  

        }
    }
}
