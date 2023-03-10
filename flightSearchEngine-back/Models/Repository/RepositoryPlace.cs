using flightSearchEngine_back.Models.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace flightSearchEngine_back.Models.Repository
{
    public class RepositoryPlace : IRepositoryPlace
    {
        private DatabaseContext db = new DatabaseContext();
        
        public async Task<bool> Add(Place place)
        {
            try
            {
                await db.getPlaceCollection().InsertOneAsync(place);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task Delete(string objectId)
        {
            try
            {
                await db.getPlaceCollection().DeleteOneAsync(document => document._id == objectId);
            }
            catch 
            {
                throw;
            }
        }

        public async Task<Place> GetPlace(string objectId)
        {
            try
            {
                var id = new ObjectId(objectId);
                return await db.getPlaceCollection().Find(document => document._id == objectId).SingleAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Place> GetPlaceByIata(string iata)
        {
            try
            {
                return await db.getPlaceCollection().Find(document => document.iata == iata).SingleAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Place>> GetPlaces()
        {
            List<Place> list = await db.getPlaceCollection().Find(_ => true).ToListAsync();
            return list;
        }

        public async Task Update(string objectId, Place place)
        {
            try
            {
                place._id = new ObjectId(objectId).ToString(); 
                await db.getPlaceCollection().ReplaceOneAsync(filter: document => document._id == objectId, replacement: place);
            }
            catch 
            {
                throw;
            }
        }
    }
}