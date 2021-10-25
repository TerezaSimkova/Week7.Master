using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.RepositoryMock
{
    public class RepositoryLezioniMock : IRepositoryLezioni
    {

        public static List<Lezione> Lezioni = new List<Lezione>()
        {
            new Lezione{LezioneID = 1, Aula = "A023", DataOraInizio = new DateTime(2021,12,11), Durata = 60, DocenteID = 1, CorsoCodice = "C-02"}
        };

        public Lezione Add(Lezione lezione)
        {
            if (Lezioni.Count() == 0)
            {
                lezione.LezioneID = 1;
            }
            else
            {
                lezione.LezioneID = Lezioni.Max(x => x.LezioneID) + 1;
            }

            var docente = RepositoryDocentiMock.Docenti.FirstOrDefault(d => d.ID == lezione.DocenteID);
            lezione.Docente = docente;
            var corso = RepositoryCorsiMock.Corsi.FirstOrDefault(c => c.CodiceCorso == lezione.CorsoCodice);
            lezione.Corso = corso;

            docente.Lezioni.Add(lezione);
            corso.Lezioni.Add(lezione);

            Lezioni.Add(lezione);
            return lezione;
        }

        public bool Delete(Lezione lezione)
        {
            Lezioni.Remove(lezione);
            return true;
        }

        public List<Lezione> GetAll()
        {
            return Lezioni;
        }

        public List<Lezione> GetByCorsoCodice(string codiceCorso)
        {
            List<Lezione> l = Lezioni.Where(c => c.CorsoCodice == codiceCorso).ToList();
            return l;
        }

        public Lezione GetById(int id)
        {
            return Lezioni.Find(l => l.LezioneID == id);
        }

        public Lezione Update(Lezione lezione)
        {
            var old = Lezioni.FirstOrDefault(l => l.LezioneID == lezione.LezioneID);
            old.Aula = lezione.Aula;
            return lezione;
        }
    }
}
