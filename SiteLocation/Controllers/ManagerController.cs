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
    public class ManagerController : ControllerBase
    {
        private readonly IManagerRepository managerRepository;
        public ManagerController(IManagerRepository managerRepository)
        {
            this.managerRepository = managerRepository;
        }

        // Post : {apibaseurl}/api/managers
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

        [HttpGet]
        public async Task<IActionResult> GetAllManagers()
        {
            var managers = await managerRepository.GetAllAsync();
            // Mapper le domain Model to Dto
            var reponse = new List<ManagerDto>();
            foreach (var manager in managers)
            {
                reponse.Add(new ManagerDto
                {
                    Nom = manager.Nom,
                    Prenom = manager.Prenom,
                    DateNaissance = manager.DateNaissance,
                    Adresse = manager.Adresse,
                    Email = manager.Email,
                    Agence = manager.Agence,
                    Tel = manager.Tel
                });
            }
            return Ok(reponse);
        }

        [HttpGet]
        [Route("{managerId:int}")]
        public async Task<IActionResult> GetManagerById([FromRoute] int managerId)
        {
            var existManager = await managerRepository.GetById(managerId);

            if (existManager is null)
            {
                return NotFound();
            }
            var reponse = new ManagerDto
            {
                Nom = existManager.Nom,
                Prenom= existManager.Prenom,
                DateNaissance= existManager.DateNaissance,
                Adresse = existManager.Adresse,
                Email = existManager.Email,
                Agence= existManager.Agence,
                Tel = existManager.Tel
            };
            return Ok(reponse);
        }

        [HttpPut]
        [Route("{managerId:int}")]
        public async Task<IActionResult> UpdateManager([FromRoute] int managerId, UpdateManagerDto request)
        {
            // Dto to Domain medel
            var manager = new Manager
            {
                Nom= request.Nom,
                Prenom= request.Prenom,
                DateNaissance= request.DateNaissance,
                Adresse= request.Adresse,
                Email= request.Email,
                Tel = request.Tel,
                Agence = request.Agence
            };
            manager = await managerRepository.UpdateAsync(manager);
            if (manager == null)
            {
                return BadRequest();
            }
            // Convertie le Domain medel to Dto
            var reponse = new ManagerDto
            {
                ManagerId = manager.ManagerId,
                Nom = manager.Nom,
                Prenom= manager.Prenom,
                DateNaissance = manager.DateNaissance,
                Adresse= manager.Adresse,
                Email= manager.Email,
                Tel = manager.Tel,
                Agence = manager.Agence
            };
            return Ok(reponse);
        }

        [HttpDelete]
        [Route("{managerId:int}")]
        public async Task<IActionResult> DeleteManager([FromRoute] int managerId)
        {
            var manager = await managerRepository.DeleteAsync(managerId);
            if (manager is null)
            {
                return BadRequest();
            }
            // Convertir Domain to Model
            var reponse = new Manager
            {
                ManagerId = manager.ManagerId,
                Nom = manager.Nom,
                Prenom= manager.Prenom,
                Email= manager.Email,
                Tel = manager.Tel,
                Agence = manager.Agence,
                Adresse = manager.Adresse,
                DateNaissance= manager.DateNaissance
            };
            return Ok(reponse);
        }
    }
}
