using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

namespace flightSearchEngine_back.Models
{
    public class Place
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("iata")]
        public string iata { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
        [BsonElement("country")]

        public string Country { get; set; }
        [BsonElement("coordinates")]
        public Coordinate Coordinates { get; set; }

    }
}