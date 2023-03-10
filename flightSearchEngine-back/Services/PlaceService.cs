using flightSearchEngine_back.Models;
using flightSearchEngine_back.Models.Repository;
using flightSearchEngine_back.Models.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace flightSearchEngine_back.Services
{
    public static class PlaceService
    {
        private static IRepositoryPlace placeRepository = new RepositoryPlace();

        internal static async Task<bool> Add(Place place)
        {
            return await placeRepository.Add(place);
        }

        internal static async Task deletePlace(string objectId)
        {
            await placeRepository.Delete(objectId); 
        }

        internal static async Task<IEnumerable<Place>> getDestinationPlaces(FilterDatesPricesIataPayload payload)
        {
            return await getDestinationPlacesFromFlightList(
                    await FlightService.filterAllFlightsByPriceDateAndAirport(payload)
                   );
        }
        internal static async Task<IEnumerable<Place>> getDestinationPlacesFromFlightList(IEnumerable<Flight> flights)
        {
            List<Flight> flightList = (List<Flight>)flights;
            List<Place> places = (List<Place>)await getPlaces();
            List<Place> res = new List<Place>();

            flightList.ForEach(flight => {
                places.ForEach(place =>
                {
                    if (flight.DestinationAirport == place.iata)
                    {
                        res.Add(place);
                    }
                });
            });

            return res;
        }

        internal static async Task<Place> getPlace(string objectId)
        {
            return await placeRepository.GetPlace(objectId);
        }
        internal static async Task<Place> getPlaceByIata(string Iata)
        {
            return await placeRepository.GetPlaceByIata(Iata);
        }

        internal static async Task<IEnumerable<Place>> getPlaces()
        {
            return await placeRepository.GetPlaces();
        }
        internal static async Task updatePlace(string objectId, Place place)
        {
           await placeRepository.Update(objectId, place);
        }
    }
}