using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.Core.Repositories;
using X.Core.UnitOfWorks;
using X.Data.EntityFrameworkCore.Repositories;

namespace X.Data.EntityFrameworkCore.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly XDbContext _dbContext;
        private PersonRepository _personRepository;
        private ProductRepository _productRepository;
        private PersonProductRelationRepository _personProductRelation;
        public IPerson Persons => _personRepository = _personRepository ?? new PersonRepository(_dbContext);
        public IProduct Products => _productRepository = _productRepository ?? new ProductRepository(_dbContext);
        public IPersonProductRelation PersonProductRelations => _personProductRelation = _personProductRelation ?? new PersonProductRelationRepository(_dbContext);
        public UnitOfWork(XDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CommitChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public void CommitChange()
        {
            _dbContext.SaveChanges();
        }
    }
}
