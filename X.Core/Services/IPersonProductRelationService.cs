using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.Core.Entities;

namespace X.Core.Services
{
    public interface IPersonProductRelationService : IService<PersonProductRelation>
    {
        Task<PersonProductRelation> GetWithPersonProductByIdAsync(int id);
    }
}
