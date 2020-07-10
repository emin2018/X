using System;
using System.Collections.Generic;
using System.Text;

namespace X.Core.Entities
{
    public class PersonProductRelation
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ProductId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Product Product { get; set; }
        public bool IsDeleted { get; set; }
    }
}
