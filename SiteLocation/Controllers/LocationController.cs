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

        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            var locations = await locationRepository.GetAllAsync();
            // Mapper le domain Model to Dto
            var reponse = new List<LocationDto>();
            foreach (var location in locations)
            {
                reponse.Add(new LocationDto
                {
                    LocationId = location.LocationId,
                    DateLocation= location.DateLocation,
                    DateRetour = location.DateRetour,
                    Client = location.Client,
                    Manager = location.Manager,
                    EtatVehicule=location.EtatVehicule,
                    Assurance = location.Assurance,
                    AgenceRetour=location.AgenceRetour,
                    AgenceRetrait=location.AgenceRetrait,
                    Vehicule=location.Vehicule

                });
            }
            return Ok(reponse);
        }

        [HttpGet]
        [Route("{locationId:int}")]
        public async Task<IActionResult> GetLocationById([FromRoute] int locationId)
        {
            var existLocation = await locationRepository.GetById(locationId);

            if (existLocation is null)
            {
                return NotFound();
            }
            var reponse = new LocationDto
            {
                LocationId = existLocation.LocationId,
                DateLocation= existLocation.DateLocation,
                DateRetour=existLocation.DateRetour,
                Client = existLocation.Client,
                Manager = existLocation.Manager,
                Vehicule = existLocation.Vehicule,
                Assurance = existLocation.Assurance,
                AgenceRetour=existLocation.AgenceRetour,
                AgenceRetrait=existLocation.AgenceRetrait,
                EtatVehicule = existLocation.EtatVehicule
            };
            return Ok(reponse);
        }

        [HttpPut]
        [Route("{locationId:int}")]
        public async Task<IActionResult> UpdateLocation([FromRoute] int locationId, UpdateLocationDto request)
        {
            // Dto to Domain medel
            var location = new Location
            {               
                DateRetour = request.DateRetour,
                DateLocation= request.DateLocation,
                Client = request.Client,
                Manager = request.Manager,
                Vehicule = request.Vehicule,
                Assurance = request.Assurance,
                AgenceRetour=request.AgenceRetour,
                AgenceRetrait=request.AgenceRetrait,
                EtatVehicule = request.EtatVehicule,
            };
            location = await locationRepository.UpdateAsync(location);
            if (location == null)
            {
                return BadRequest();
            }
            // Convertie le Domain medel to Dto
            var reponse = new LocationDto
            {
                LocationId  = location.LocationId,
                DateRetour = location.DateRetour,
                DateLocation= location.DateLocation,
                Client = location.Client,
                Manager = location.Manager,
                Vehicule = location.Vehicule,
                Assurance = location.Assurance,
                AgenceRetrait = location.AgenceRetrait,
                AgenceRetour = location.AgenceRetour,
                EtatVehicule = location.EtatVehicule
            };
            return Ok(reponse);
        }

        [HttpDelete]
        [Route("{locationId:int}")]
        public async Task<IActionResult> DeleteLocation([FromRoute] int locationId)
        {
            var location = await locationRepository.DeleteAsync(locationId);
            if (location is null)
            {
                return BadRequest();
            }
            // Convertir Domain te Model
            var reponse = new Location
            {
                LocationId = location.LocationId,
                DateRetour = location.DateRetour,
                DateLocation = location.DateLocation,
                Client = location.Client,
                Manager = location.Manager,
                Vehicule = location.Vehicule,
                Assurance = location.Assurance,
                AgenceRetrait = location.AgenceRetrait,
                AgenceRetour = location.AgenceRetour,
                EtatVehicule = location.EtatVehicule
            };
            return Ok(reponse);

        }
    }
}
