using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.RepositoryMock
{
    public class RepositoryDocentiMock : IRepositoryDocenti
    {

        public static List<Docente> Docenti = new List<Docente>()
        {
            new Docente{ID = 1,Nome="Mario",Cognome="Rosii",Email="mario.rossi@gmail.com",Telefono="+39 22685974125"},
        };

        public Docente Add(Docente docente)
        {
            if (Docenti.Count == 0)
            {
                docente.ID = 1;
            }
            else
            {
               docente.ID = Docenti.Max(s => s.ID) + 1;
            }

            Docenti.Add(docente);
            return docente;
        }

        public bool Delete(Docente docente)
        {
            Docenti.Remove(docente);
            return true;
        }

        public List<Docente> GetAll()
        {
            return Docenti;
        }

        public Docente GetByDati(Docente nuovoDocente)
        {
           return Docenti.FirstOrDefault(d => d.Nome == nuovoDocente.Nome && d.Cognome == nuovoDocente.Cognome && d.Email == nuovoDocente.Email);
        }

        public Docente GetById(int id)
        {
            return Docenti.Find(d => d.ID == id);
        }

        public Docente Update(Docente docente)
        {
            var old = Docenti.FirstOrDefault(c => c.ID == docente.ID);
            old.Nome = docente.Nome;
            old.Cognome = docente.Cognome;
            old.Email = docente.Email;
            return docente;
        }
    }
}
