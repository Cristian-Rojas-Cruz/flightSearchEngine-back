using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flightSearchEngine_back.Models
{
    public class FlightCharacteristic
    {
        [BsonElement("isEconomy")]
        public Boolean IsEconomy { get; set; }
        [BsonElement("isRefundable")]
        public Boolean IsRefundable { get; set; }
        [BsonElement("isNonStop")]
        public Boolean IsNonStop { get; set; }
    }
}