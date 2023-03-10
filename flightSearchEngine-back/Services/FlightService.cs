using flightSearchEngine_back.Models.Repository.Interface;
using flightSearchEngine_back.Models.Repository;
using flightSearchEngine_back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace flightSearchEngine_back.Services
{
    public static class FlightService
    {
        private static IRepositoryFlight FlightRepository = new RepositoryFlight();

        internal static async Task<bool> Add(Flight flight)
        {
            return await FlightRepository.add(flight);
        }

        internal static async Task deleteFlight(string objectId)
        {
            await FlightRepository.delete(objectId);
        }

        internal static async Task<Flight> getFlight(string objectId)
        {
            return await FlightRepository.getFlight(objectId);
        }

        internal static async Task<IEnumerable<Flight>> getFlights()
        {
            return await FlightRepository.getFlights();
        }
        internal static async Task<IEnumerable<Flight>> getFlightsByStartingAirport(string startingAirportIata)
        {
            return await FlightRepository.getFlightsByStartingAirport(startingAirportIata);
        }
        public static async Task<IEnumerable<Flight>> filterFlightsByPrice(Interval<float> price, IEnumerable<Flight> flights)
        {
            List<Flight> res = (List<Flight>)flights;
            return await Task.Run(() => res.FindAll(flight => flight.baseFare >= price.min && flight.baseFare <= price.max));
        }

        internal static async Task<IEnumerable<Flight>> getFlightsByFullRoute(string startingAirportIata, string destinationAirportIata)
        {
            List<Flight> filteredFlightsByStartingAirport = (List<Flight>)await FlightRepository.getFlightsByStartingAirport(startingAirportIata);
            return await filterFlightsByDestinationAirport(destinationAirportIata, filteredFlightsByStartingAirport);

        }
        internal static async Task<IEnumerable<Flight>> getFlightsByFullRouteFiltered(string startingAirportIata, string destinationAirportIata, FilterDatesPricesIataPayload filter)
        {
            return await filterFlightsByPriceAndDate(await getFlightsByFullRoute(startingAirportIata, destinationAirportIata), filter);
        }
        internal static async Task<IEnumerable<Flight>> filterFlightsByDestinationAirport(string destinationAirportIata, IEnumerable<Flight> flightsToFilter)
        {
            List<Flight> filteredFlights = (List<Flight>)flightsToFilter;
            return await Task.Run(() => filteredFlights.FindAll(flight => flight.DestinationAirport == destinationAirportIata));
        }
        public static async Task<IEnumerable<Flight>> filterFlightsFilteredByDate(Interval<long> dateInterval, IEnumerable<Flight> flights)
        {
            List<Flight> res = (List<Flight>)flights;
            return await Task.Run(() =>res.FindAll(flight => flight.FlightDate >= dateInterval.min && flight.FlightDate <= dateInterval.max));
        }
        internal static async Task updateFlight(string objectId, Flight flight)
        {
            await FlightRepository.update(objectId, flight);
        }

        internal static async Task<IEnumerable<Flight>> filterAllFlightsByPriceDateAndAirport(FilterDatesPricesIataPayload payload)
        {
            Interval<long> dateInterval = new Interval<long>(payload.dates.min, payload.dates.max);
            Interval<float> priceInterval = new Interval<float>(payload.prices.min, payload.prices.max);

            return await filterFlightsByPrice(priceInterval,
                        await filterFlightsFilteredByDate(dateInterval,
                            await getFlightsByStartingAirport(payload.iata)));
        }
        internal static async Task<IEnumerable<Flight>> filterFlightsByPriceAndDate(IEnumerable<Flight> flights, FilterDatesPricesIataPayload payload)
        {
            Interval<long> dateInterval = new Interval<long>(payload.dates.min, payload.dates.max);
            Interval<float> priceInterval = new Interval<float>(payload.prices.min, payload.prices.max);

            return await filterFlightsByPrice(priceInterval,
                        await filterFlightsFilteredByDate(dateInterval,flights));
        }
    }
}