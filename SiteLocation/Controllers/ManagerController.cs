﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteLocation.Models.DTO;
using SiteLocation.Repository.Interfaces;
using SiteLocation.Repository.Repositories;
using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerRepository managerRepository;
        public ManagerController(IManagerRepository managerRepository)
        {
            this.managerRepository = managerRepository;
        }

        // Post : {apibaseurl}/api/clients
        [HttpPost]
        public async Task<IActionResult> CreateManager([FromBody] CreateManagerRequestDto request)
        {

            // Mapper Dto to Domain;
            var manager = new Manager
            {
                Nom = request.Nom,
                Prenom = request.Prenom,
                DateNaissance = request.DateNaissance,
                Adresse = request.Adresse,
                Email = request.Email,
                Agence = request.Agence,
                Tel = request.Tel,
            };
            manager = await managerRepository.CreateAsync(manager);
            var reponse = new Manager
            {
                ManagerId = manager.ManagerId,
                Nom = manager.Nom,
                Prenom = manager.Prenom,
                DateNaissance = manager.DateNaissance,
                Adresse = manager.Adresse,
                Email = manager.Email,
                Agence = manager.Agence,
                Tel = manager.Tel,
            };
            return Ok(reponse);
        }
    }
}
