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
    public class AgenceController : ControllerBase
    {
        private readonly IAgenceRepository agenceRepository;
        public AgenceController(IAgenceRepository agenceRepository)
        {
            this.agenceRepository = agenceRepository;
        }

        // Post : {apibaseurl}/api/clients
        [HttpPost]
        public async Task<IActionResult> CreateAgence([FromBody] CreateAgenceRequestDto request)
        {

            // Mapper Dto to Domain;
            var agence = new Agence
            {
                Nom = request.Nom,
                Adresse = request.Adresse,
                ManagerResponsable = request.ManagerResponsable,
            };
            await agenceRepository.CreateAsync(agence);
            var reponse = new Agence
            {
                AgenceId = agence.AgenceId,
                Nom = agence.Nom,
                Adresse = agence.Adresse,
                ManagerResponsable = agence.ManagerResponsable,

            };
            return Ok(reponse);
        }
        // Création de la méthode GetAll pour afficher tout les agences crées
        // Le chemin va etre  :https://localhost:7052/api/Agences
        [HttpGet]
        public async Task<IActionResult> GetAllAgences()
        {
            var agences = await agenceRepository.GetAllAsync();
            // Mapper le domain Model to Dto
            var reponse = new List<AgenceDto>();
            foreach (var agence in agences)
            {
                reponse.Add(new AgenceDto
                {
                    Nom = agence.Nom,
                    Adresse = agence.Adresse,
                    ManagerResponsable = agence.ManagerResponsable
                });
            }
            return Ok(reponse);
        }
        [HttpGet]
        [Route("{agenceId:int}")]
        public async Task<IActionResult> GetAgenceById([FromRoute] int agenceId)
        {
            var existAgence = await agenceRepository.GetById(agenceId);

            if (existAgence is null)
            {
                return NotFound();
            }
            var reponse = new AgenceDto
            {
                AgenceId = existAgence.AgenceId,
                Nom = existAgence.Nom,
                Adresse = existAgence.Adresse,
                ManagerResponsable = existAgence.ManagerResponsable
            };
            return Ok(reponse);
        }
        // le chemin pour la méthode put est : https://localhost:7052/api/Agence  {id}
        [HttpPut]
        [Route("{agenceId:int}")]
        public async Task<IActionResult> UpdateAgence([FromRoute] int agenceId, UpdateAgenceDto request)
        {
            // Dto to Domain medel
            var agence = new Agence
            {
                Nom = request.Nom,
                Adresse = request.Adresse,
                ManagerResponsable = request.ManagerResponsable
                
            };
            agence = await agenceRepository.UpdateAsync(agence);
            if (agence == null)
            {
                return BadRequest();
            }
            // Convertie le Domain medel to Dto
            var reponse = new AgenceDto
            {
                AgenceId = agence.AgenceId,
                Nom = agence.Nom,
                Adresse = agence.Adresse,
                ManagerResponsable = agence.ManagerResponsable
              
            };
            return Ok(reponse);
        }
        [HttpDelete]
        [Route("{agenceId:int}")]
        public async Task<IActionResult> DeleteAgence([FromRoute] int agenceId)
        {
            var agence = await agenceRepository.DeleteAsync(agenceId);
            if (agence is null)
            {
                return BadRequest();
            }
            // Convertir Domain te Model
            var reponse = new Agence
            {
                AgenceId = agence.AgenceId,
                Nom = agence.Nom,
                Adresse = agence.Adresse,
                ManagerResponsable = agence.ManagerResponsable
            };
            return Ok(reponse);

        }
    }
}
