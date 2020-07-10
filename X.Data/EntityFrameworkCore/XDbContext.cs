using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using X.Core.Entities;
using X.Data.EntityFrameworkCore.Configurations;
using X.Data.EntityFrameworkCore.Seeds;

namespace X.Data.EntityFrameworkCore
{
    public class XDbContext : DbContext
    {
        public XDbContext(DbContextOptions<XDbContext> options) : base(options)
        {
            
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PersonProductRelation> PersonProductRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //db tabloları oluşturulurken kullanılacak config
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new PersonProductRelationConfiguration());

            //tablolara basılacak ilk veriler
            modelBuilder.ApplyConfiguration(new PersonSeed());
            modelBuilder.ApplyConfiguration(new ProductSeed());


        }
    }
}
