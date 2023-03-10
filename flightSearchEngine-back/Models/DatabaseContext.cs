using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace flightSearchEngine_back.Models
{
    public class DatabaseContext
    {
        private readonly IMongoDatabase Database;

        public DatabaseContext()
        {
            var settings = MongoClientSettings.FromConnectionString(ConfigurationManager.AppSettings["mongo"]);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            Database = client.GetDatabase("FlightSearchEngine");
        }

        public IMongoCollection<Place> getPlaceCollection()
        {
            return Database.GetCollection<Place>("Place");
        }
        public IMongoCollection<Flight> getFlightCollection()
        {
            return Database.GetCollection<Flight>("Flight");
        }

    }
}