using System;
using System.Collections.Generic;
using System.Text;
using X.Core.Entities;
using X.Core.Repositories;
using X.Core.Services;
using X.Core.UnitOfWorks;

namespace X.Service.Services
{
    public class ProductService : Service<Product>,IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }
    }
}
