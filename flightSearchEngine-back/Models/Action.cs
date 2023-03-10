using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flightSearchEngine_back.Models
{
    public static class ActionTypesEnumerator
    {
        public static readonly string getDestinationPlaces = "getDestinationPlaces";
        public static readonly string getFlightsByFullRoute = "getFlightsByFullRoute";
        public static readonly string getFlightsByFullRouteFiltered = "getFlightsByFullRouteFiltered";
        public static readonly string filterFlightsByDatePriceAndIata = "FilterFlightsByDatePriceAndIata";
    }
    public class FilterFlightsAction
    {
        public string action { get; set; }
        public FilterDatesPricesIataPayload payload { get; set; }
    }
    public class getFlightsByFullRouteAction
    {
        public string action { get; set; }
        public FliterByStartingAirportAndDestinationAirportPayload payload { get; set; }
    }
    public class getFlightsByFullRouteActionFiltered
    {
        public string action { get; set; }
        public FliterByStartingAirportAndDestinationAirportPayloadFiltered payload { get; set; }
    }
    public class getDestinationPlacesAction
    {
        public string action { get; set; }
        public FilterDatesPricesIataPayload payload { get; set; }
    }

}