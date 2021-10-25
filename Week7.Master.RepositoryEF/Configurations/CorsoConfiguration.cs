using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week7.Master.Core.Entities;

namespace Week7.Master.RepositoryEF
{
    internal class CorsoConfiguration : IEntityTypeConfiguration<Corso>
    {
        public void Configure(EntityTypeBuilder<Corso> modelBuilder)
        {
            //qui specifichiamo come vogliamo la nostra tabella
            modelBuilder.ToTable("Corso"); //specifico i lnome della tabella
            modelBuilder.HasKey(c => c.CodiceCorso); //Corso codice e la chiave primaria del corso PK
            modelBuilder.Property(c => c.Nome).IsRequired();
            modelBuilder.Property(c => c.Descrizione).IsRequired(); //le rendo obligatorie

            //Relazione Corso 1 --> Studenti n(molti)
            //HasMany - corso ha molti studenti, WithOne - ogni studente ha un corso, HaFK - collegamento
            modelBuilder.HasMany(c => c.Studenti).WithOne(s => s.Corso).HasForeignKey(s => s.CorsoCodice);

            //Relazione con lezioni
            modelBuilder.HasMany(c => c.Lezioni).WithOne(l => l.Corso).HasForeignKey(c => c.CorsoCodice);
        }
    }
}