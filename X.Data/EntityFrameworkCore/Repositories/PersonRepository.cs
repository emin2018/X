using System;
using System.Collections.Generic;
using System.Text;
using X.Core.Entities;
using X.Core.Repositories;

namespace X.Data.EntityFrameworkCore.Repositories
{
    public class PersonRepository : Repository<Person>,IPerson
    {
        private readonly XDbContext _dbContext;
        public PersonRepository(XDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
