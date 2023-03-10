using System;
using System.Collections.Generic;

namespace flightSearchEngine_back.Models
{
    public class FilterDatesPricesIataPayload
    {
        public Interval<long> dates { get; set; }
        public Interval<float> prices { get; set; }
        public string iata { get; set; }
    }
    public class EnumerableFlightsPayload
    {
        public IEnumerable<Flight> flights { get; set; }
    }
    public class FliterByStartingAirportAndDestinationAirportPayload
    {
        public string StartingAirportIata { get; set; }
        public string DestinationAirportIata { get; set; }

    }
    public class FliterByStartingAirportAndDestinationAirportPayloadFiltered
    {
        public string StartingAirportIata { get; set; }
        public string DestinationAirportIata { get; set; }
        public FilterDatesPricesIataPayload filter { get; set; }

    }
    public class IataPayload
    {
        public string iata { get; set; }
    }
}