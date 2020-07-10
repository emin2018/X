using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using X.Core.Entities;
using X.Core.Repositories;

namespace X.Data.EntityFrameworkCore.Repositories
{
    public class PersonProductRelationRepository : Repository<PersonProductRelation>,IPersonProductRelation
    {
        private readonly XDbContext _dbContext;
        public PersonProductRelationRepository(XDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PersonProductRelation> GetWithPersonProductByIdAsync(int id)
        {
            return await _dbContext.PersonProductRelations.Include(x => x.Person).Include(x => x.Product)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
