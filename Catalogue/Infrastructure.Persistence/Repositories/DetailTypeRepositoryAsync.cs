using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Products;

namespace Infrastructure.Persistence.Repositories
{
    public class DetailTypeRepositoryAsync : GenericRepositoryAsync<DetailType>, IDetailTypeRepositoryAsync
    {
        private readonly DbSet<DetailType> _detailTypes;

        public DetailTypeRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _detailTypes = dbContext.Set<DetailType>();
        }
    }
}
