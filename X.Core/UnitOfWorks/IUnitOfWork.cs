using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.Core.Repositories;

namespace X.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IPerson Persons{ get;}
        IProduct Products { get; }
        IPersonProductRelation PersonProductRelations { get; }
        Task CommitChangeAsync();
        void CommitChange();
    }
}
