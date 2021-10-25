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
    public class RepositoryDocentiEF : IRepositoryDocenti
    {
        public Docente Add(Docente docente)
        {

            using (var ctx = new MasterContext())
            {
                ctx.Docenti.Add(docente);
                ctx.SaveChanges();
            }
            return docente;

        }

        public bool Delete(Docente docente)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Docenti.Remove(docente);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Docente> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Docenti.Include(c => c.Lezioni).ToList(); 
            }
        }

        public Docente GetByDati(Docente nuovoDocente)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Docenti.Include(c => c.Lezioni).FirstOrDefault(c => c.Nome == nuovoDocente.Nome && c.Cognome == nuovoDocente.Cognome && c.Email ==nuovoDocente.Email); 
            }
        }

        public Docente GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Docenti.Include(c => c.Lezioni).FirstOrDefault(c => c.ID == id); // filtro per id
            }
        }

        public Docente Update(Docente docente)
        {
            using (var ctx = new MasterContext()) //apro la connesione con DB
            {
                ctx.Docenti.Update(docente);
                ctx.SaveChanges();
            }
            return docente;
        }
    }
}
