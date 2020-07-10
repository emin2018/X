using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.Core.Entities;
using X.Core.Repositories;
using X.Core.Services;
using X.Core.UnitOfWorks;

namespace X.Service.Services
{
    public class PersonProductRelationService : Service<PersonProductRelation>,IPersonProductRelationService
    {
        public PersonProductRelationService(IUnitOfWork unitOfWork, IRepository<PersonProductRelation> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<PersonProductRelation> GetWithPersonProductByIdAsync(int id)
        {
            return await _unitOfWork.PersonProductRelations.GetWithPersonProductByIdAsync(id);
        }
    }
}
