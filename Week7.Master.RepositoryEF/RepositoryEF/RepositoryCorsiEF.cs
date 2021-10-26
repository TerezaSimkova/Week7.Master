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
    public class RepositoryCorsiEF : IRepositoryCorsi
    {
        public Corso Add(Corso corso)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Corsi.Add(corso);
                ctx.SaveChanges();
            }
            return corso;
        }

        public bool Delete(Corso corso)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Corsi.Remove(corso);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Corso> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Corsi.Include(c => c.Studenti).Include(c => c.Lezioni).ToList(); // voglio includere tutti info delle lezioni e studenti
            }
            
        }

        public Corso GetByCode(string code)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Corsi.Include(c => c.Studenti).Include(c => c.Lezioni).FirstOrDefault(c => c.CodiceCorso == code); // filtro per code 
            }
        }

        public Corso GetByName(string nomeCorso)
        {
            throw new NotImplementedException();
        }

        public Corso Update(Corso corso)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Corsi.Update(corso);
                ctx.SaveChanges();
            }
            return corso;
        }
    }
}
