﻿using Microsoft.EntityFrameworkCore;
using SiteLocation.Repository.Interfaces;
using SiteLocationVihecule.Data;
using SiteLocationVihecule.Models.Domain;

namespace SiteLocation.Repository.Repositories
{
    // Pour l'utiliser je vais l'injecter dans le fichier program
    public class VehiculeRepository : IVehiculeRepository
    {
        // Je crée un constructeur et je lui injecte la classe DbContext

        private readonly ApplicationDbContext _dbcontext;
        public VehiculeRepository(ApplicationDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public async Task<Vehicule> CreateAsync(Vehicule vehicule)
        {
            await _dbcontext.Vehicules.AddAsync(vehicule);
            await _dbcontext.SaveChangesAsync();

            return vehicule;
        }


        // J'implemente l'interface en utilisant la dbcontext et la collection de vehicules
        // pour afficher la liste des véhicules
        public async Task<IEnumerable<Vehicule>> GetAllAsync()
        {
            return await _dbcontext.Vehicules.ToListAsync();
        }

        public async Task<Vehicule?> GetById(int id)
        {
            return await _dbcontext.Vehicules.FirstOrDefaultAsync(x => x.VehiculeId == id);
        }

        public async Task<Vehicule?> UpdateAsync(Vehicule vehicule)
        {
            var existVehicule = await _dbcontext.Vehicules.FirstOrDefaultAsync(x => x.VehiculeId == vehicule.VehiculeId);
            if(existVehicule != null)
            {
                _dbcontext.Entry(existVehicule).CurrentValues.SetValues(vehicule);
                await _dbcontext.SaveChangesAsync();
                return vehicule;
            }
            return null;
        }
        public async Task<Vehicule?> DeleteAsync(int id)
        {
            var existVehicule = await _dbcontext.Vehicules.FirstOrDefaultAsync(x => x.VehiculeId == id);
            if (existVehicule is null)
            {
                return null;
            }
                _dbcontext.Vehicules.Remove(existVehicule);
                await _dbcontext.SaveChangesAsync();
                return existVehicule;
                       
        }
    }
}
