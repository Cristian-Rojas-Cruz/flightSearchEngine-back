using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flightSearchEngine_back.Models
{
    [BsonNoId]
    [BsonIgnoreExtraElements]
    public class Coordinate
    {
        [BsonElement("longitude")]
        public float longitude { get; set; }
        [BsonElement("latitude")]
        public float latitude { get; set; }
    }
}