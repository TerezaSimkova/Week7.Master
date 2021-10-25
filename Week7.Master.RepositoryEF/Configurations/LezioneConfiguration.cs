using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week7.Master.Core.Entities;

namespace Week7.Master.RepositoryEF
{
    internal class LezioneConfiguration : IEntityTypeConfiguration<Lezione>
    {
        public void Configure(EntityTypeBuilder<Lezione> modelBuilder)
        {
            modelBuilder.ToTable("Lezioni");
            modelBuilder.HasKey(c => c.LezioneID);
            modelBuilder.Property(c => c.DataOraInizio).IsRequired();
            modelBuilder.Property(c => c.Aula).IsRequired();

            modelBuilder.HasOne(l => l.Docente).WithMany(d => d.Lezioni).HasForeignKey(l => l.DocenteID);

            modelBuilder.HasOne(l => l.Corso).WithMany(c => c.Lezioni).HasForeignKey(l => l.CorsoCodice);

        }
    }
}