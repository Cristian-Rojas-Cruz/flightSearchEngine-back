using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flightSearchEngine_back.Models
{
    public class Flight 
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonElement("flightDate")]
        public long FlightDate { get; set; }
        [BsonElement("startingAirport")]
        public string StartingAirport { get; set; }
        [BsonElement("destinationAirport")]
        public string DestinationAirport { get; set; }
        [BsonElement("baseFare")]
        public float baseFare { get; set; }
        [BsonElement("seatsRemaining")]
        public int seatsRemaining { get; set; }
        [BsonElement("characteristics")]
        public FlightCharacteristic characteristics { get; set; }


    }
}