using flightSearchEngine_back.Models;
using flightSearchEngine_back.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace flightSearchEngine_back.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlaceController : ApiController
    {
        // GET api/Place?objectId=
        public async Task<Place> Get(string objectId)
        {
            return await PlaceService.getPlace(objectId);
        }
        [ResponseType(typeof(Task<Place>))]
        [HttpPost]
        [Route("api/Place/iata")]
        public async Task<Place> Post([FromBody] IataPayload iata)
        {
            return await PlaceService.getPlaceByIata(iata.iata);
        }
        public async Task<IEnumerable<Place>> Get()
        {
            return await PlaceService.getPlaces();
        }

        // GET api/Place
        [ResponseType(typeof(Task<IEnumerable<Place>>))]
        [HttpPost]
        [Route("api/Place/filter")]
        public async Task<IEnumerable<Place>> Post([FromBody] FilterFlightsAction action) 
        {
            if (action.action == ActionTypesEnumerator.getDestinationPlaces)
            {
                return await PlaceService.getDestinationPlaces(action.payload);
            }else
            {
                return new List<Place>();
            }
        }

        // GET api/Place/
        public async Task<Place> Post([System.Web.Http.FromBody] Place place)
        {
            var output = await PlaceService.Add(place);
            if (output == true)
            { 
                return place;
            }
            return null;
        }

        // DELETE api/Place/

        public async Task Delete(string objectId)
        {
            await PlaceService.deletePlace(objectId);
        }

        // DELETE api/Place/
        public async Task Put(string objectId, Place place)
        {
            await PlaceService.updatePlace(objectId, place);
        }
    }
}
