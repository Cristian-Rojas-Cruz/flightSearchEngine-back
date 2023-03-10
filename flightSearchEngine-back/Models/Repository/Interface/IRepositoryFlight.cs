using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightSearchEngine_back.Models.Repository.Interface
{
    internal interface IRepositoryFlight
    {
        Task<bool> add(Flight flight);
        Task update(string objectId, Flight flight);
        Task delete(string objectId);
        Task<Flight> getFlight(string objectId);
        Task<IEnumerable<Flight>> getFlights();
        Task<IEnumerable<Flight>> getFlightsFilteredByDate(Interval<long> dateInterval);
        Task<IEnumerable<Flight>> getFlightsFilteredByPrice(Interval<float> priceInterval);
        Task<IEnumerable<Flight>> getFlightsByStartingAirport(string startingAirportIata);

    }
}
