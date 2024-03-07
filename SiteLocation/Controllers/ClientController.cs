using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SiteLocation.Models.DTO;
using SiteLocation.Repository.Interfaces;
using SiteLocation.Repository.Repositories;
using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        // Post : {apibaseurl}/api/clients
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientRequestDto request)
        {

            // Mapper Dto to Domain;
            var client = new Client
            {
                Nom = request.Nom,
                Prenom = request.Prenom,
                DateNaissance = request.DateNaissance,
                Adresse = request.Adresse,
                Email = request.Email,
                PermisConduire = request.PermisConduire,
                MotPass = request.MotPass,
                Tel = request.Tel,
            };
            // await retourne l'objet client créé que je stoque dans une variable (client)
            client = await clientRepository.CreateAsync(client);

            var reponse = new Client
            {
                ClientId = client.ClientId,
                Nom = client.Nom,
                Prenom = client.Prenom,
                DateNaissance = client.DateNaissance,
                Adresse = client.Adresse,
                Email = client.Email,
                PermisConduire= client.PermisConduire,  
                MotPass= client.MotPass,
                Tel= client.Tel,
            };
            return Ok(reponse);
        }

    }
}
