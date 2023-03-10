using flightSearchEngine_back.Models;
using flightSearchEngine_back.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace flightSearchEngine_back.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FlightController : ApiController
    {
        // GET api/Flight
        public async Task<IEnumerable<Flight>> Get()
        {
            return await FlightService.getFlights();
        }
        // GET api/Flight
        [ResponseType(typeof(Task<IEnumerable<Flight>>))]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Flight/filter")]
        public async Task<IEnumerable<Flight>> GetFlightsFiltered([System.Web.Http.FromBody] FilterFlightsAction action)
        {
            if (action.action == ActionTypesEnumerator.filterFlightsByDatePriceAndIata)
            {
                return await FlightService.filterAllFlightsByPriceDateAndAirport(action.payload);
            }
            return new List<Flight>();
        }
        // GET api/Flight
        [ResponseType(typeof(Task<IEnumerable<Flight>>))]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Flight/route")]
        public async Task<IEnumerable<Flight>> Get([System.Web.Http.FromBody] getFlightsByFullRouteAction action)
        {
            if (action.action == ActionTypesEnumerator.getFlightsByFullRoute)
            {
                return await FlightService.getFlightsByFullRoute(action.payload.StartingAirportIata, action.payload.DestinationAirportIata);
            }
            else 
            { 
                return new List<Flight>();
            }
        }
        [ResponseType(typeof(Task<IEnumerable<Flight>>))]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Flight/filter/route")]
        public async Task<IEnumerable<Flight>> Post([System.Web.Http.FromBody] getFlightsByFullRouteActionFiltered action)
        {
            if (action.action == ActionTypesEnumerator.getFlightsByFullRouteFiltered)
            {
                return await FlightService.getFlightsByFullRouteFiltered(action.payload.StartingAirportIata, action.payload.DestinationAirportIata, action.payload.filter);
            }
            else
            {
                return new List<Flight>();
            }
        }
        // GET api/Flight/
        public async Task<Flight> Get(string objectId)
        {
            return await FlightService.getFlight(objectId);
        }

        public async Task<Flight> Post([System.Web.Http.FromBody] Flight flight)
        {
            var output = await FlightService.Add(flight);
            if (output == true)
            {
                return flight;
            }
            return null;
        }
        // DELETE api/Flight/
        public async Task Delete(string objectId)
        {
            await FlightService.deleteFlight(objectId);
        }
        // DELETE api/Flight/
        public async Task Put(string objectId, [System.Web.Http.FromBody] Flight flight)
        {
            await FlightService.updateFlight(objectId, flight);
        }
    }
}
