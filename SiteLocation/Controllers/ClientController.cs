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
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await clientRepository.GetAllAsync();
            // Mapper le domain Model to Dto
            var reponse = new List<ClientDto>();
            foreach (var client in clients)
            {
                reponse.Add(new ClientDto
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
                });
            }
            return Ok(reponse);
        }
        [HttpGet]
        [Route("{clientId:int}")]
        public async Task<IActionResult> GetClientById([FromRoute] int clientId)
        {
            var existClient = await clientRepository.GetById(clientId);

            if (existClient is null)
            {
                return NotFound();
            }
            var reponse = new ClientDto
            {
                ClientId = existClient.ClientId,
                Nom = existClient.Nom,
                Prenom = existClient.Prenom,
                DateNaissance = existClient.DateNaissance,
                Adresse = existClient.Adresse,
                Email = existClient.Email,
                PermisConduire= existClient.PermisConduire,
                MotPass= existClient.MotPass,
                Tel= existClient.Tel,
            };
            return Ok(reponse);
        }
        [HttpPut]
        [Route("{clientId:int}")]
        public async Task<IActionResult> UpdateClient([FromRoute] int clientId, UpdateClientDto request)
        {
            // Dto to Domain medel
            var client = new Client
            {
                Nom = request.Nom,
                Adresse = request.Adresse,
                Prenom=request.Prenom,
                PermisConduire = request.PermisConduire,
                DateNaissance=request.DateNaissance,
                MotPass=request.MotPass,
                Email = request.Email,
                Tel = request.Tel,
                

            };
            client = await clientRepository.UpdateAsync(client);
            if (clientId == null)
            {
                return BadRequest();
            }
            // Convertie le Domain medel to Dto
            var reponse = new ClientDto
            {
                ClientId = client.ClientId,
                Nom = client.Nom,
                Prenom = client.Prenom,
                DateNaissance = client.DateNaissance,
                Adresse = client.Adresse,
                Email = client.Email,
                PermisConduire = client.PermisConduire,
                MotPass = client.MotPass,
                Tel = client.Tel,

            };
            return Ok(reponse);
        }

        [HttpDelete]
        [Route("{clientId:int}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int clientId)
        {
            var client = await clientRepository.DeleteAsync(clientId);
            if (client is null)
            {
                return BadRequest();
            }
            // Convertir Domain te Model
            var reponse = new Client
            {
                ClientId = client.ClientId,
                Prenom  = client.Prenom,
                DateNaissance = client.DateNaissance,
                Email = client.Email,
                MotPass = client.MotPass,
                Tel = client.Tel,
                PermisConduire = client.PermisConduire,
                Nom = client.Nom,
                Adresse = client.Adresse
                
            };
            return Ok(reponse);

        }
    }

}
