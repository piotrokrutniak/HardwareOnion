using Application.Interfaces.Repositories;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public static class DefaultProductDetails
    {
        public static async Task SeedAsync(IProductDetailRepositoryAsync productDetailRepositoryAsync, IProductRepositoryAsync productRepositoryAsync, IProductTypeRepositoryAsync productTypeRepositoryAsync)
        {
            List<Product> products = productRepositoryAsync.GetAllAsync().Result.ToList();
            List<ProductType> productTypes = productTypeRepositoryAsync.GetAllAsync().Result.ToList();

            if (!productDetailRepositoryAsync.GetAllAsync().Result.Any())
            {
                foreach (Product product in products)
                {
                    List<ProductDetail> productDetails = (productTypes.FirstOrDefault(x => x.Id == product.ProductTypeId).Name) switch
                    {
                        "GPU" => PopulateGpu(product.Id),
                        "CPU" => PopulateCpu(product.Id),
                        "RAM" => PopulateRam(product.Id),
                        "Motherboard" => PopulateMotherboard(product.Id),
                        //Not seeded yet
                        //"PSU" => PopulateGpu(product.Id),
                        //"Hard Drive" => PopulateGpu(product.Id),
                        _ => PopulateGeneric(product.Id)
                    };

                    foreach (var productDetail in productDetails)
                    {
                        await productDetailRepositoryAsync.AddAsync(productDetail);
                    }

                    await productDetailRepositoryAsync.AddAsync(new ProductDetail(detailTypeId: 1, description: "", productId: product.Id));
                } 
            }
            

        }

        public static List<ProductDetail> PopulateGpu(int id)
        {
            List<ProductDetail> details = new List<ProductDetail>
            {
                new ProductDetail(detailTypeId: 1, description: "GDDR6", productId: id),
                new ProductDetail(detailTypeId: 2, description: "8GB", productId: id),
                new ProductDetail(detailTypeId: 6, description: "2020", productId: id),
                new ProductDetail(detailTypeId: 9, description: "PCI-Express 4.0 x 16", productId: id),
                new ProductDetail(detailTypeId: 10, description: "DisplayPort x 3,  HDMI x 1", productId: id)
            };

            return details;
        }

        public static List<ProductDetail> PopulateCpu(int id)
        {
            List<ProductDetail> details = new List<ProductDetail>
            {
                new ProductDetail(detailTypeId: 4, description: "2.6 - 5.0GHz", productId: id),
                new ProductDetail(detailTypeId: 5, description: "4", productId: id),
                new ProductDetail(detailTypeId: 6, description: "2020", productId: id),
                new ProductDetail(detailTypeId: 7, description: "Socket 1151", productId: id)
            };

            return details;
        }

        public static List<ProductDetail> PopulateRam(int id)
        {
            List<ProductDetail> details = new List<ProductDetail>
            {
                new ProductDetail(detailTypeId: 1, description: "DDR4", productId: id),
                new ProductDetail(detailTypeId: 2, description: "8GB", productId: id),
                new ProductDetail(detailTypeId: 3, description: "3200MHz", productId: id),
                new ProductDetail(detailTypeId: 6, description: "2019", productId: id)
            };

            return details;
        }
        public static List<ProductDetail> PopulateMotherboard(int id)
        {
            List<ProductDetail> details = new List<ProductDetail>
            {
                new ProductDetail(detailTypeId: 6, description: "2020", productId: id),
                new ProductDetail(detailTypeId: 7, description: "Socket 1151", productId: id)
            };

            return details;
        }

        public static List<ProductDetail> PopulateGeneric(int id)
        {
            List<ProductDetail> details = new List<ProductDetail>
            {
                new ProductDetail(detailTypeId: 6, description: "2020", productId: id),
            };

            return details;
        }
        


    }
}
