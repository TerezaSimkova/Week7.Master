using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.RepositoryEF.Configurations.RepositoryEF
{
    public class RepositoryLezioniEF : IRepositoryLezioni
    {
        public Lezione Add(Lezione lezione)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Add(lezione);
                ctx.SaveChanges();
            }
            return lezione;
        }

        public bool Delete(Lezione lezione)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Remove(lezione);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Lezione> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Lezioni.Include(l => l.Docente).Include(l => l.Corso).ToList();
            }
        }

        public List<Lezione> GetByCorsoCodice(string codiceCorso)
        {
            throw new NotImplementedException();
        }

        public Lezione GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Lezioni.Include(l => l.Docente).Include(l => l.Corso).FirstOrDefault(l=>l.LezioneID== id);
            }
        }

        public List<Lezione> GetLezioniDelCorso(string nome)
        {
            throw new NotImplementedException();
        }

        public Lezione Update(Lezione lezione)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Lezioni.Update(lezione);
                ctx.SaveChanges();
            }
            return lezione;
        }
    }
}
