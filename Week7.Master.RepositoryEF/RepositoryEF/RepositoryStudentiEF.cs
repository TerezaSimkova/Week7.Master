using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.RepositoryEF.Configurations.RepositoryEF
{
    public class RepositoryStudentiEF : IRepositoryStudenti
    {
        public Studente Add(Studente studente)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Studenti.Add(studente);
                ctx.SaveChanges();
            }
            return studente;
        }

        public bool Delete(Studente studente)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Studenti.Remove(studente);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Studente> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Studenti.ToList(); // anche corsi ?
            }
        }

        public List<Studente> GetByCorsoCodice(string scelta)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Studenti.Where(c => c.CorsoCodice == scelta).ToList(); 
            }
        }

        public Studente GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Studenti.FirstOrDefault(c => c.ID == id);
            }
        }

        public Studente Update(Studente studente)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Studenti.Update(studente);
                ctx.SaveChanges();
            };
            return studente;
        }
    }
}
