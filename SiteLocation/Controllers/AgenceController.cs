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
        public AgenceController(IAgenceRepository cagenceRepository)
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
    }
}
