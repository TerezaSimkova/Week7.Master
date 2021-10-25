using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week7.Master.Core.Entities;

namespace Week7.Master.RepositoryEF
{
    internal class DocenteConfiguration : IEntityTypeConfiguration<Docente>
    {
        public void Configure(EntityTypeBuilder<Docente> modelBuilder)
        {
            modelBuilder.ToTable("Docenti");
            modelBuilder.HasKey(c => c.ID);
            modelBuilder.Property(c => c.Nome).IsRequired();
            modelBuilder.Property(c => c.Cognome).IsRequired();
            modelBuilder.Property(c => c.Email).IsRequired();
            modelBuilder.Property(c => c.Telefono).IsRequired().HasMaxLength(10);

            modelBuilder.HasMany(d => d.Lezioni).WithOne(l => l.Docente).HasForeignKey(d => d.DocenteID);
        }
    }
}