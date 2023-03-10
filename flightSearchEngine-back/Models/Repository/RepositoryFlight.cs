using flightSearchEngine_back.Models.Repository.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace flightSearchEngine_back.Models.Repository
{
    public class RepositoryFlight : IRepositoryFlight
    {

        private DatabaseContext db = new DatabaseContext();
        public async Task<bool> add(Flight flight)
        {
            try
            {
                await db.getFlightCollection().InsertOneAsync(flight);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task delete(string objectId)
        {
            try
            {
                await db.getFlightCollection().DeleteOneAsync(document => document._id == objectId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Flight>> getFlights()
        {
            return await db.getFlightCollection().Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Flight>> getFlightsByStartingAirport(string startingAirportIata)
        {
            try
            {
                return await db.getFlightCollection().Find(document => document.StartingAirport == startingAirportIata).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Flight>> getFlightsFilteredByDate(Interval<long> dateInterval)
        {
            return await db.getFlightCollection().Find(
                    document => document.FlightDate >= dateInterval.min 
                    && document.FlightDate <= dateInterval.max 
                ).ToListAsync();
        }

        public async Task<IEnumerable<Flight>> getFlightsFilteredByPrice(Interval<float> priceInterval)
        {
            return await db.getFlightCollection().Find(
                        document => document.baseFare >= priceInterval.min
                        && document.baseFare <= priceInterval.max
                    ).ToListAsync();
        }

        public async Task<Flight> getFlight(string objectId)
        {
            try
            {
                var id = new ObjectId(objectId);
                return await db.getFlightCollection().Find(document => document._id == objectId).SingleAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task update(string objectId, Flight flight)
        {
            try
            {

                flight._id = new ObjectId(objectId).ToString();
                await db.getFlightCollection().ReplaceOneAsync(filter: document => document._id == objectId, replacement: flight);
            }
            catch
            {
                throw;
            }
        }

    }
}