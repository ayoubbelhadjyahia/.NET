using AM.ApplicationCore.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane:IService<Plane>
    {
        public IList<Passenger> GetPassenger(Plane plane);
        public IList<Flight> GetFlights(int n);
        public bool IsAvailablePlane(int n, Flight flight);
        public void DeletePlanes();
    }
}
