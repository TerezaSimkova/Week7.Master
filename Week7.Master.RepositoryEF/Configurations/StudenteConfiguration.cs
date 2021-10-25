using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week7.Master.Core.Entities;

namespace Week7.Master.RepositoryEF
{
    internal class StudenteConfiguration : IEntityTypeConfiguration<Studente>
    {
        public void Configure(EntityTypeBuilder<Studente> modelBuilder)
        {
            modelBuilder.ToTable("Studenti");
            modelBuilder.HasKey(c => c.ID);
            modelBuilder.Property(c => c.Nome).IsRequired();
            modelBuilder.Property(c => c.Cognome).IsRequired();
            modelBuilder.Property(c => c.Email).IsRequired();
            modelBuilder.Property(c => c.TitoloStudio).IsRequired();

            //Relazione Corso 1 --> Studenti n(molti)
            modelBuilder.HasOne(s => s.Corso).WithMany(c => c.Studenti).HasForeignKey(c => c.CorsoCodice);
        }
    }
}