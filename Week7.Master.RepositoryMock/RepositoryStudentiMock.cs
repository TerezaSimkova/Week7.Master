using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.RepositoryMock
{
    public class RepositoryStudentiMock : IRepositoryStudenti
    {
        public static List<Studente> Studenti = new List<Studente>() // lista vuota perche ce foreign key e quindi non la popolo
        {
            new Studente{ID = 1, Nome = "Tereza", Cognome = "Simkova", DataDiNascita = new DateTime(1995,07,26), Email = "tere@gmail.com", TitoloStudio = "Diploma di Design"}
        };

        public Studente Add(Studente studente)
        {
            if (Studenti.Count == 0)
            {
                studente.ID = 1;
            }
            else
            {
                studente.ID = Studenti.Max(s => s.ID) + 1;
            }
            //asoccio corso al studente
            var corso = RepositoryCorsiMock.Corsi.FirstOrDefault(c => c.CodiceCorso == studente.CorsoCodice);
            studente.Corso = corso;

            Studenti.Add(studente);
            return studente;
        }

        public bool Delete(Studente studente)
        {
            Studenti.Remove(studente);
            return true;
        }

        public List<Studente> GetAll()
        {
            return Studenti;
        }

        public List<Studente> GetByCorsoCodice(string scelta)
        {
            return Studenti.Where(c => c.CorsoCodice == scelta).ToList();
        }

        public Studente GetById(int id)
        {
            return Studenti.Find(s => s.ID == id);           
        }

        public Studente Update(Studente studente)
        {
            var old = Studenti.FirstOrDefault(c => c.ID == studente.ID);
            old.Email = studente.Email;
            return studente;
        }
    }
}
