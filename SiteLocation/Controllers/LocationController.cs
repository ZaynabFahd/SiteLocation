using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteLocation.Models.DTO;
using SiteLocation.Repository.Interfaces;
using SiteLocation.Repository.Repositories;
using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository locationRepository;
        public LocationController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        // Post : {apibaseurl}/api/clients
        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationRequestDto request)
        {

            // Mapper Dto to Domain;
            var location = new Location
            {
                DateLocation = request.DateLocation,
                DateRetour = request.DateRetour,
                Client = request.Client,
                Manager = request.Manager,
                EtatVehicule = request.EtatVehicule,
                AgenceRetour = request.AgenceRetour,
                AgenceRetrait = request.AgenceRetrait,
                Assurance = request.Assurance,
                Vehicule = request.Vehicule,
            };

            location = await locationRepository.CreateAsync(location);
            var reponse = new Location
            {
                LocationId = location.LocationId,
                DateLocation = location.DateLocation,
                DateRetour = location.DateRetour,
                Client = location.Client,
                Manager = location.Manager,
                EtatVehicule = location.EtatVehicule,
                AgenceRetour = location.AgenceRetour,
                AgenceRetrait = location.AgenceRetrait,
                Assurance = location.Assurance,
                Vehicule = location.Vehicule,
            };
            return Ok(reponse);
        }
    }
}
