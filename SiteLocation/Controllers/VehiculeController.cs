using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using SiteLocation.Models.DTO;
using SiteLocation.Repository.Interfaces;
using SiteLocation.Repository.Repositories;
using SiteLocationVihecule.Data;
using SiteLocationVihecule.Models.Domain;
using SiteLocationVihecule.Models.DTO;

namespace SiteLocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculeController : ControllerBase
    {
        private readonly IVehiculeRepository _vehiculeRepository;
        public VehiculeController(IVehiculeRepository vehiculeRepository)
        {
            this._vehiculeRepository = vehiculeRepository;
        }

        // créer une methode Post pour enregistrer les vehicules
        [HttpPost]
        public async Task<IActionResult> CreateVehicule([FromBody] CreateVehiculeDto request)
        {

            // mapper le Dto to Domain Model
            var vehicule = new Vehicule
            {
                Marque = request.Marque,
                AnneeConstruction = request.AnneeConstruction,
                NomVehicule = request.NomVehicule,
                Disponibilite = request.Disponibilite,
                Carburant = request.Carburant,
                TypeVehicule = request.TypeVehicule,
                NombrePlace = request.NombrePlace,
                Couleur = request.Couleur,
                FullOption = request.FullOption,
                AgeMinConducteur = request.AgeMinConducteur,
                Agence = request.Agence,
                Prix = request.Prix
            };

            // Avec cette ligne le controlleur ne sais pas comment la methode crée le vehicule 
            await _vehiculeRepository.CreateAsync(vehicule);

            // mapper le Domain Model to Dto
            var reponse = new Vehicule
            {

                Marque = vehicule.Marque,
                VehiculeId = vehicule.VehiculeId,
                AnneeConstruction = vehicule.AnneeConstruction,
                NomVehicule = vehicule.NomVehicule,
                Disponibilite = vehicule.Disponibilite,
                Carburant = vehicule.Carburant,
                TypeVehicule = vehicule.TypeVehicule,
                NombrePlace = vehicule.NombrePlace,
                Couleur = vehicule.Couleur,
                FullOption = vehicule.FullOption,
                AgeMinConducteur = vehicule.AgeMinConducteur,
                Agence = vehicule.Agence,
                Prix = vehicule.Prix

            };
            return Ok();
        }

        // Création de la méthode GetAll pour afficher tout les véhicules crées
        // Le chemin va etre  :https://localhost:7052/api/Vehicule
        [HttpGet]
        public async Task<IActionResult> GetAllVehicules()
        {
            var vehicules = await _vehiculeRepository.GetAllAsync();
            // Mapper le domain Model to Dto
            var reponse = new List<VehiculeDto>();
            foreach (var vehicule in vehicules)
            {
                reponse.Add(new VehiculeDto
                {
                    Marque = vehicule.Marque,
                    VehiculeId = vehicule.VehiculeId,
                    AnneeConstruction = vehicule.AnneeConstruction,
                    NomVehicule = vehicule.NomVehicule,
                    Disponibilite = vehicule.Disponibilite,
                    Carburant = vehicule.Carburant,
                    TypeVehicule = vehicule.TypeVehicule,
                    NombrePlace = vehicule.NombrePlace,
                    Couleur = vehicule.Couleur,
                    FullOption = vehicule.FullOption,
                    AgeMinConducteur = vehicule.AgeMinConducteur,
                    Agence = vehicule.Agence,
                    Prix = vehicule.Prix
                });
            }
            return Ok(reponse);
        }

        // le chemin pour le GetById est : https://localhost:7052/api/Vehicule  {id}
        [HttpGet]
        [Route("{vehiculeId:int}")]
        public async Task<IActionResult> GetVehiculeById([FromRoute]int vehiculeId)
        {
            var existVehicule = await _vehiculeRepository.GetById(vehiculeId);

            if (existVehicule is null) 
            { 
                return NotFound();
            }
            var reponse = new VehiculeDto
            {
                VehiculeId = existVehicule.VehiculeId,
                NomVehicule = existVehicule.NomVehicule,
                Marque = existVehicule.Marque,
                Disponibilite = existVehicule.Disponibilite,
                Carburant = existVehicule.Carburant,
                Couleur = existVehicule.Couleur,
                AgeMinConducteur = existVehicule.AgeMinConducteur,
                Agence = existVehicule.Agence,
                AnneeConstruction = existVehicule.AnneeConstruction,
                Prix = existVehicule.Prix,
                NombrePlace = existVehicule.NombrePlace,
                FullOption = existVehicule.FullOption,
                TypeVehicule = existVehicule.TypeVehicule
            };
            return Ok(reponse);
        }
        // le chemin pour la méthode put est : https://localhost:7052/api/Vehicule  {id}
        [HttpPut]
        [Route("{vehiculeId:int}")]
        public async Task<IActionResult> UpdateVehicule([FromRoute] int vehiculeId, UpdateVehiculeDto request)
        {
            // Dto to Domain medel
            var vehicule = new Vehicule
            {
                VehiculeId = vehiculeId,
                Marque = request.Marque,
                AnneeConstruction = request.AnneeConstruction,
                NomVehicule = request.NomVehicule,
                Disponibilite = request.Disponibilite,
                Carburant = request.Carburant,
                TypeVehicule = request.TypeVehicule,
                NombrePlace = request.NombrePlace,
                Couleur = request.Couleur,
                FullOption = request.FullOption,
                AgeMinConducteur = request.AgeMinConducteur,
                Agence = request.Agence,
                Prix = request.Prix
            };
            vehicule = await _vehiculeRepository.UpdateAsync(vehicule);
            if(vehicule == null)
            {
                return BadRequest();
            }
            // Convertie le Domain medel to Dto
            var reponse = new VehiculeDto
            {
                Marque = vehicule.Marque,
                VehiculeId = vehicule.VehiculeId,
                AnneeConstruction = vehicule.AnneeConstruction,
                NomVehicule = vehicule.NomVehicule,
                Disponibilite = vehicule.Disponibilite,
                Carburant = vehicule.Carburant,
                TypeVehicule = vehicule.TypeVehicule,
                NombrePlace = vehicule.NombrePlace,
                Couleur = vehicule.Couleur,
                FullOption = vehicule.FullOption,
                AgeMinConducteur = vehicule.AgeMinConducteur,
                Agence = vehicule.Agence,
                Prix = vehicule.Prix
            };
            return Ok(reponse);
        }
        [HttpDelete]
        [Route("{vehiculeId:int}")]
        public async Task<IActionResult> DeleteVehicule([FromRoute] int vehiculeId)
        {
            var vehicule = await _vehiculeRepository.DeleteAsync(vehiculeId);
            if(vehicule is null)
            {
                return BadRequest();
            }
            // Convertir Domain te Model
            var reponse = new Vehicule
            {
                VehiculeId = vehicule.VehiculeId,
                Marque = vehicule.Marque,
                AnneeConstruction = vehicule.AnneeConstruction,
                NomVehicule = vehicule.NomVehicule,
                Disponibilite = vehicule.Disponibilite,
                Carburant = vehicule.Carburant,
                TypeVehicule = vehicule.TypeVehicule,
                NombrePlace = vehicule.NombrePlace,
                Couleur = vehicule.Couleur,
                FullOption = vehicule.FullOption,
                AgeMinConducteur = vehicule.AgeMinConducteur,
                Agence = vehicule.Agence,
                Prix = vehicule.Prix
            };
            return Ok(reponse);

        }
    }
}
