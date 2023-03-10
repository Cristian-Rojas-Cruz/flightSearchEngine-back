using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightSearchEngine_back.Models.Repository.Interface
{
    internal interface IRepositoryPlace
    {
        Task<bool> Add(Place place);
        Task Update(string objectId, Place place);
        Task Delete(string objectId);
        Task<Place> GetPlace(string objectId);
        Task<Place> GetPlaceByIata(string iata);
        Task<IEnumerable<Place>> GetPlaces();
    }
}
