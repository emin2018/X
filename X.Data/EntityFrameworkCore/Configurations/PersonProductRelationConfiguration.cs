using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using X.Core.Entities;

namespace X.Data.EntityFrameworkCore.Configurations
{
    public class PersonProductRelationConfiguration : IEntityTypeConfiguration<PersonProductRelation>
    {
        public void Configure(EntityTypeBuilder<PersonProductRelation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.ToTable("PersonProductRelations");
        }
    }
}
