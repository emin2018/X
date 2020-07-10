using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using X.Core.Entities;
using X.Core.Repositories;
using X.Core.Services;
using X.Core.UnitOfWorks;

namespace X.Service.Services
{
    public class PersonService : Service<Person>,IPersonService
    {
        public PersonService(IUnitOfWork unitOfWork, IRepository<Person> repository) : base(unitOfWork, repository)
        {
        }
    }
}
