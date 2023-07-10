using Application.Interfaces.Repositories;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public static class DefaultProducts
    {
        public static async Task SeedAsync(IProductRepositoryAsync productRepositoryAsync)
        {
            //string name, string description, decimal price, int quantity, int productTypeId, int manufacturerId
            string descGPU = "Get Amplified with the ZOTAC GAMING GeForce RTX 30 Series based on the NVIDIA Ampere architecture. Built with enhanced RT Core and Tensor Cores, new streaming multiprocessors, and high-speed GDDR6 memory, the ZOTAC GAMING GeForce RTX 3060 Twin Edge OC gives rise to amplified gaming with high fidelity";
            string descCPU = "Intel sets the industry standard for processor innovation and performance, powering laptops, desktops, workstations and servers-for business and personal use, immersive gaming, content creation, IoT, Artificial Intelligence, and more. Explore the range of options here.";
            string descCPUAMD = "Be unstoppable with the unprecedented speed of the world’s best desktop processors. AMD Ryzen 5000 Series processors deliver the ultimate in high performance, whether you’re playing the latest games, designing the next skyscraper or crunching scientific data. With AMD Ryzen, you’re always in the lead.";
            string descGPUAMD = "Radeon RX 6500 XT is a tenacious beast with a tough metal exterior, efficient cooling, and components that offer enhanced endurance. An all-metal shroud houses two powerful axial-tech fans with dual ball fan bearings. Underneath, a thick heatsink keeps thermals under tight control.";

            List<Product> products = new List<Product>
                {
                    new Product("RTX 3060", descGPU, 999.99m, 90, 1, 1),
                    new Product("RTX 3070", descGPU, 1249.99m, 90, 1, 1),
                    new Product("RTX 3080", descGPU, 1359.99m, 90, 1, 1),
                    new Product("RTX 3090", descGPU, 1649.99m, 90, 1, 1),
                    new Product("RTX 4060", descGPU, 1199.99m, 90, 1, 1),
                    new Product("RTX 4070", descGPU, 1399.99m, 90, 1, 1),
                    new Product("RTX 4080", descGPU, 1699.99m, 90, 1, 1),
                    new Product("RTX 4090", descGPU, 1899.99m, 90, 1, 1),
                
                    new Product("RX 6500 xt", descGPUAMD, 499.99m, 90, 1, 2),
                    new Product("RX 6400", descGPUAMD, 749.99m, 90, 1, 2),
                    new Product("RX 6300", descGPUAMD, 859.99m, 90, 1, 2),
                    new Product("RX 580", descGPUAMD, 949.99m, 90, 1, 2),
                    new Product("RX 6500", descGPUAMD, 749.99m, 90, 1, 2),
                    new Product("RX 6600 XT", descGPUAMD, 899.99m, 90, 1, 2),
                    new Product("RX 6700 XT", descGPUAMD, 1399.99m, 90, 1, 2),
                    new Product("RX 6800", descGPUAMD, 1899.99m, 90, 1, 2),

                    new Product("Intel Core I9-13800K", descCPU, 1899.99m, 90, 2, 3),
                    new Product("Intel Core I7-13700K", descCPU, 1299.99m, 90, 2, 3),
                    new Product("Intel Core I5-13400F", descCPU, 699.99m, 90, 2, 3),
                    new Product("Intel Core I3-13200", descCPU, 459.99m, 90, 2, 3),
                    new Product("Intel Core I9-12800K", descCPU, 1399.99m, 90, 2, 3),
                    new Product("Intel Core I7-12700K", descCPU, 1099.99m, 90, 2, 3),
                    new Product("Intel Core I5-12400F", descCPU, 599.99m, 90, 2, 3),
                    new Product("Intel Core I3-12200", descCPU, 359.99m, 90, 2, 3),
                    new Product("Intel Core I3-12200", descCPUAMD, 359.99m, 90, 2, 3),

                    new Product("Ryzen 5700X", descCPUAMD, 1899.99m, 90, 2, 3),
                    new Product("Ryzen 5700G", descCPUAMD, 1299.99m, 90, 2, 3),
                    new Product("Ryzen 5600X", descCPUAMD, 699.99m, 90, 2, 3),
                    new Product("Ryzen 5500X", descCPUAMD, 459.99m, 90, 2, 3),
                    new Product("Ryzen 4900X", descCPUAMD, 1399.99m, 90, 2, 3),
                    new Product("Ryzen 4700G", descCPUAMD, 1099.99m, 90, 2, 3),
                    new Product("Ryzen 4700X", descCPUAMD, 599.99m, 90, 2, 3),
                    new Product("Ryzen 4500X", descCPUAMD, 359.99m, 90, 2, 3),
                    new Product("Ryzen 4100", descCPUAMD, 259.99m, 90, 2, 3),
                    

                };

            if (!productRepositoryAsync.GetAllAsync().Result.Any())
            {
                foreach (var product in products)
                {
                    await productRepositoryAsync.AddAsync(product);
                }
            }
        }
    }
}
