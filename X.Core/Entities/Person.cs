using System;
using System.Collections.Generic;
using System.Text;

namespace X.Core.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<PersonProductRelation> PersonProductRelations { get; set; }
    }
}
