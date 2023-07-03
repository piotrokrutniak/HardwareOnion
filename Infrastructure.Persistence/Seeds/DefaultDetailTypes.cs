using Application.Interfaces.Repositories;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public static class DefaultDetailTypes
    {
        public static async Task SeedAsync(IDetailTypeRepositoryAsync detailTypeRepositoryAsync)
        {
            List<DetailType> detailTypes = new List<DetailType>
                {
                    new DetailType("Memory Type", "Parameter"),
                    new DetailType("Memory Size", "Parameter"),
                    new DetailType("Memory Speed", "Parameter"),
                    new DetailType("Clock Speed", "Parameter"),
                    new DetailType("Cores", "Parameter"),
                    new DetailType("Release Year", "Parameter"),
                    new DetailType("Socket", "Parameter"),
                    new DetailType("Resolution", "Parameter"),
                    new DetailType("Slot", "Parameter"),
                    new DetailType("Ports", "Parameter"),
                };

            if (!detailTypeRepositoryAsync.GetAllAsync().Result.Any())
            {
                foreach (DetailType detailType in detailTypes)
                {
                    await detailTypeRepositoryAsync.AddAsync(detailType);
                }
            }
        }
    }
}
