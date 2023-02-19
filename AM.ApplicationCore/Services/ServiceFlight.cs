using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Plane = AM.ApplicationCore.Domain.Plane;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>(); // Création d'une liste 
       

        // 6 + 7 
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            ////methode 3adeya 1
            ////for (int i = 0; i < Flights.Count; i++)
            ////{
            ////    if (Flights[i].destination == destination)
            ////    {
            ////        dates.Add(Flights[i].flightDate);
            ////    }
            ////}
            ////return dates;

            ////methode 3adeya 2
            //foreach (var flight in Flights)
            //{
            //    if (flight.destination == destination)
            //    {
            //        dates.Add(flight.flightDate);
            //    }
            //}
            //
            ////question 9
            /////////methode link 1
            //var query = from f in Flights
            //            where f.destination==destination
            //           select f.flightDate;
            //           return query.ToList();
            /////////question 9 zeda
            var query=Flights
                .Where(f => f.destination == destination)
                .Select(f=>f.flightDate).ToList();
            return query;
        }
        ///10
        public void ShowFlightDetails(Plane plane)
        {
            var query = Flights
                .Where(f => f.plane.planeId == plane.planeId)
                .Select(f => new { f.flightDate, f.destination });
            foreach (var item in query) { Console.WriteLine(item); }
        }
        ///11

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var query = Flights
                .Count(f => f.flightDate >= startDate && (f.flightDate - startDate).TotalDays < 7);
            return query;
        }

        ///12
        double DurationAverage(string destination)
        {
            var query = Flights
                .Where(f => f.destination.Equals("destination"))
                .Average(f => f.estimatedDuration);
            return query;
        }
        ///13 
        List<Flight> OrderedDurationFlights()
        {
            var query = Flights
                .OrderByDescending(f=>f.estimatedDuration).ToList();

            return query ;
        }

        //14
        List<Passenger> SeniorTravellers(Flight flight)
        {
            var query = flight.passengers.OfType<Traveller>()
                //.Where(p => p is Traveller)
                .OrderBy(p => p.birthDate).Take(3);
            List<Passenger> pa =new List<Passenger>(query);
        return pa;
                }

        //15
       void DestinationGroupedFlights()
        {
            var query = Flights
                .GroupBy(f => f.destination);
            foreach(var f in query)
            {
                Console.WriteLine(f.Key);
                foreach(var g in f)
                {
                    Console.WriteLine(g.flightDate);
                }
            }
             
        }


        public void FlightDetailsDel(Plane p,Func<Plane> detail)
        {

            var query = Flights
                .Where(f => f.plane.planeId == p.planeId)
                .Select(f => new { f.flightDate, f.destination });
            foreach (var item in query) { Console.WriteLine(item); }

        }
        public int DurationAverageDel(Func<String, int> duree)
        {
            
        }



        public List<Flight> GetFlights(string filterValue, Func<Flight, String, Boolean> condition)
        {
            List<Flight> f = new List<Flight>() ;
            foreach (var flight in Flights)
            {
                if (condition(flight,filterValue))
                {
                    f.Add(flight);
                    Console.WriteLine(flight);
                }
            }
            // Methode 1
            //if(filterType.Equals("destination"))
            //{
            //    foreach (var flight in Flights)
            //    {
            //        if (flight.destination.Equals(filterValue))
            //        {
            //            f.Add(flight);
            //        }
            //    }
            //}

            //if (filterType.Equals("departure"))
            //{
            //    foreach (var flight in Flights)
            //    {
            //        if (flight.departure.Equals(filterValue))
            //        {
            //            f.Add(flight);
            //        }
            //    }
            //}

            //if (filterType.Equals("estimatedDuration"))
            //{
            //    foreach (var flight in Flights)
            //    {
            //        if (flight.estimatedDuration == int.Parse(filterValue))
            //        {
            //            f.Add(flight);
            //        }
            //    }
            //}

            //if (filterType.Equals("flightDate"))
            //{
            //    foreach (var flight in Flights)
            //    {
            //        DateTime dateTime = new DateTime();
            //        dateTime = DateTime.Parse(filterValue);
            //        if (flight.flightDate==dateTime)
            //        {
            //            f.Add(flight);
            //        }
            //    }
            //}

            //if (filterType.Equals("effectiveArrival"))
            //{
            //    foreach (var flight in Flights)
            //    {
            //        DateTime dateTime = new DateTime();
            //        dateTime = DateTime.Parse(filterValue);
            //        if (flight.effectiveArrival == dateTime)
            //        {
            //            f.Add(flight);
            //        }
            //    }
            //}

            //if (filterType.Equals("flightId"))
            //{
            //    foreach (var flight in Flights)
            //    {
            //        int k = int.Parse(filterValue);
            //        if (flight.flightId == k)
            //        {
            //            f.Add(flight);
            //        }
            //    }
            //}


            // Methode 2 
            //switch (filterType)
            //{
            //    case "destination":
            //        foreach (var flight in Flights)
            //        {
            //            if (flight.destination.Equals(filterValue))
            //            {
            //                f.Add(flight);
            //            }
            //        }
            //        break;

            //    case "flightId":
            //        foreach (var flight in Flights)
            //        {
            //            if (flight.flightId == int.Parse(filterValue))
            //            {
            //                f.Add(flight);
            //            }
            //        }
            //        break;

            //    case "effectiveArrival":
            //        foreach (var flight in Flights)
            //        {
            //            DateTime dateTime = new DateTime();
            //            dateTime = DateTime.Parse(filterValue);
            //            if (flight.effectiveArrival == dateTime)
            //            {
            //                f.Add(flight);
            //            }
            //        }
            //        break;

            //    case "flightDate":
            //        foreach (var flight in Flights)
            //        {
            //            DateTime dateTime = new DateTime();
            //            dateTime = DateTime.Parse(filterValue);
            //            if (flight.flightDate == dateTime)
            //            {
            //                f.Add(flight);
            //            }
            //        }
            //        break;
            //}

            return f;

        }
    }
}
