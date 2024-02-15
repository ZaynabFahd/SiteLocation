using Microsoft.EntityFrameworkCore;
using SiteLocationVihecule.Models.Domain;

namespace SiteLocationVihecule.Data
{
    // La classe DbContext travail toiujours avec le dossier Models Domain
    public class ApplicationDbContext : DbContext
    {

        // constructeur pour passer la connection string
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        // Ces propriétés utilisés pour interagir avec la base de données
        public DbSet<Agence> Agences { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Vehicule> Vehicules { get; set;}
    }   
}
