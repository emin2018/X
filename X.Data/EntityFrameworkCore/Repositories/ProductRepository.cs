using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using X.Core.Entities;
using X.Core.Repositories;

namespace X.Data.EntityFrameworkCore.Repositories
{
    public class ProductRepository : Repository<Product>,IProduct
    {
        private readonly XDbContext _dbContext;
        public ProductRepository(XDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
