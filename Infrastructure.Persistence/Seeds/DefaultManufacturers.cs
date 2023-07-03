using Application.Interfaces.Repositories;
using Domain.Models.Entities;
using Infrastructure.Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public static class DefaultManufacturers
    {
        public static async Task SeedAsync(IManufacturerRepositoryAsync manufacturerRepositoryAsync)
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>
                { 
                    new Manufacturer("Nvidia"),
                    new Manufacturer("AMD"),
                    new Manufacturer("Intel"),
                    new Manufacturer("NZXT"),
                    new Manufacturer("Samsung"),
                    new Manufacturer("Crucial"),
                    new Manufacturer("Kingston"),
                };

            if (!manufacturerRepositoryAsync.GetAllAsync().Result.Any())
            {
                foreach (var manufacturer in manufacturers)
                {
                    await manufacturerRepositoryAsync.AddAsync(manufacturer);
                }
            }
        }
    }
}
