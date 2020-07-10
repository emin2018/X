using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using X.Core.Entities;

namespace X.Data.EntityFrameworkCore.Seeds
{
    public class PersonSeed : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(
                new Person{Id=1,Name = "Muhammet",Surname = "Seymenoğlu",PhoneNumber = "05555555555",MailAddress = "x@gmail.com",IdentificationNumber = "11111111111"},
                new Person{Id=2,Name = "Emin",Surname = "Seymenoğlu",PhoneNumber = "05555555556",MailAddress = "y@gmail.com",IdentificationNumber = "11111111112"}
            );
        }
    }
}
