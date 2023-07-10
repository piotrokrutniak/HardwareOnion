using Application.Interfaces.Repositories;
using Domain.Models.Images;
using Domain.Models.Products;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Repositories
{
    public class ImageRepositoryAsync : GenericRepositoryAsync<Image>, IImageRepositoryAsync
    {
        private readonly DbSet<Image> _images;

        public ImageRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _images = dbContext.Set<Image>();
    }
        }
}
