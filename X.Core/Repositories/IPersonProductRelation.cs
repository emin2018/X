using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.Core.Entities;

namespace X.Core.Repositories
{
    public interface IPersonProductRelation : IRepository<PersonProductRelation>
    {
        Task<PersonProductRelation> GetWithPersonProductByIdAsync(int id);
    }
}
