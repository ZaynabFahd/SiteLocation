﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using SiteLocation.Models.DTO;
using SiteLocationVihecule.Data;
using SiteLocationVihecule.Models.Domain;
using SiteLocationVihecule.Models.DTO;

namespace SiteLocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public VehiculeController(ApplicationDbContext dbContext)
        {
               this._dbContext = dbContext;
        }

        // On va créer une methode Post pour enregistrer les vehicules
        [HttpPost]
        public async Task<IActionResult> CreateVehicule(CreateVehiculeDto request)
        {

            // On va mapper le Dto to Domain Model
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
            await _dbContext.Vehicules.AddAsync(vehicule);
            await _dbContext.SaveChangesAsync();


            // On va mapper le Domain Model to Dto

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
    }
}
