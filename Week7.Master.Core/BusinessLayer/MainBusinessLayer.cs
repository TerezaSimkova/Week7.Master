using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        //Dichiaro quali sono i repository che posso usare
        private readonly IRepositoryCorsi corsiRepo;
        private readonly IRepositoryDocenti docentiRepo;
        private readonly IRepositoryStudenti studentiRepo;
        private readonly IRepositoryLezioni lezioniRepo;

        //devo fare praticamente un costruttore,che mi pormette di costruire
        public MainBusinessLayer(IRepositoryCorsi corsi, IRepositoryDocenti docenti, IRepositoryStudenti studenti, IRepositoryLezioni lezioni)
        {
            corsiRepo = corsi;
            docentiRepo = docenti;
            studentiRepo = studenti;
            lezioniRepo = lezioni;
        }


       

        #region Funzionalita Corsi

        public List<Corso> GetAllCorsi()
        {
            return corsiRepo.GetAll();
        }

        public string InserisciNuovoCorso(Corso newCorso)
        {
            //controllo input -> non deve esistere un altro corso con lo stesso codice 
            var corsoEsistente = corsiRepo.GetByCode(newCorso.CodiceCorso);
            if (corsoEsistente != null)
            {
                return "Errore: Codice già presente!"; //mi torna una stringa 
            }
            else
            {
                corsiRepo.Add(newCorso);
                return "Corso aggiunto corretamente!";
            }
        }

        public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione)
        {
            var corsoEsistente = corsiRepo.GetByCode(codiceCorsoDaModificare);
            if (corsoEsistente == null)
            {
                return "Errore: Codice errato!";
            }
            corsoEsistente.Nome = nuovoNome;
            corsoEsistente.Descrizione = nuovaDescrizione;

            corsiRepo.Update(corsoEsistente);
            return "Corso e stato modificato con successo!";
        }
        public string EliminaCorso(string codiceCorsoDaEliminare)
        {
            var corsoEsistente = corsiRepo.GetByCode(codiceCorsoDaEliminare);
            if (corsoEsistente == null)
            {
                return "Errore: Codice errato!";
            }
            corsiRepo.Delete(corsoEsistente);
            return "Corso eliminato corretamente!";
            //TODO vuoi cancellare corso anche se contiene i studenti? 

        }

        #endregion

        #region Funzinalita Studenti
        public List<Studente> GetAllStudenti()
        {
            return studentiRepo.GetAll();
        }

        public string InserisciNuovoStudente(Studente nuovoStudente)
        {
            //controllo input
            Corso corsoEsistente = corsiRepo.GetByCode(nuovoStudente.CorsoCodice);
            if (corsoEsistente == null)
            {
                return "Errore: Codice sbagliato!";
            }
            studentiRepo.Add(nuovoStudente);
            return "Studente aggiunto con successo!";
        }

        public string ModificaStudente(int id, string nuovoEmail)
        {
            var studenteEsistente = studentiRepo.GetById(id);
            if (studenteEsistente == null)
            {
                return "Errore: ID errato!";
            }
            studenteEsistente.Email = nuovoEmail;

            studentiRepo.Update(studenteEsistente);
            return "Studente e stato modificato con successo!";
        }

        public string EliminaStudente(int id)
        {
            var studenteEsistente = studentiRepo.GetById(id);
            if (studenteEsistente == null)
            {
                return "Errore: ID errato! Oppure non esiste studente con questo ID";
            }
            studentiRepo.Delete(studenteEsistente);
            return "Studente eliminato corretamente!";
        }

        public List<Studente> VisualizzaStudentiCorso(string scelta)
        {
            return studentiRepo.GetByCorsoCodice(scelta);
        }

        #endregion

        #region Funzionalita Docenti
        public List<Docente> GetAllDocenti()
        {
            return docentiRepo.GetAll();
        }

        public string InserisciNuovoDocente(Docente nuovoDocente)
        {

            //Docente docenteEsistente = docentiRepo.GetAll().FirstOrDefault(d => d.Nome == nome && d.Cognome == cognome && d.Email == email);

            //if (docenteEsistente != null)
            //{
            //    return "Esiste gia un insegnante con questo nome, cognome o email!";
            //}
            //else
            //{
            //    docentiRepo.Add(nuovoDocente);
            //    return "Docente aggiunto con successo!";
            //}
            Docente newDocente = docentiRepo.GetByDati(nuovoDocente);
            if (newDocente != null)
            {
                return "Esiste gia un insegnante con questo nome!";
            }
            else
            {
                docentiRepo.Add(nuovoDocente);
                return "Docente aggiunto con successo!";
            }
        }

        public string ModificaDocente(int id, string nome, string cognome, string email)
        {
            var docenteEsistente = docentiRepo.GetById(id);
            if (docenteEsistente == null)
            {
                return "Errore: ID errato!";
            }
            docenteEsistente.Nome = nome;
            docenteEsistente.Cognome = cognome;
            docenteEsistente.Email = email;

            docentiRepo.Update(docenteEsistente);
            return "Docente e stato modificato con successo!";
        }

        public string EliminaDocente(int id)
        {
            Docente docenteDaEliminare = docentiRepo.GetById(id);
            if (docenteDaEliminare == null)
            {
                return "Errore: ID errato.";
            }

            //TODO:non deve essere possibile cancellare un corso che ha almeno una lezione associata
            //nè un corso che ha almeno uno studente iscritto.

            docentiRepo.Delete(docenteDaEliminare);
            return "Docente eliminato correttamente!";
        }

        #endregion

        #region Funzionalita Lezioni

        public List<Lezione> GetAllLezioni()
        {
            return lezioniRepo.GetAll();
        }

        public string InserisciNuovaLezione(Lezione nuovaLezione)
        {
            var corso = corsiRepo.GetByCode(nuovaLezione.CorsoCodice);
            if (corso == null)
            {
                return "Codice corso non esiste!";
            }
            var docente = docentiRepo.GetById(nuovaLezione.DocenteID);
            if (docente == null)
            {
                return "Codice docente inesistente";
            }
            //Si possono eventualmente prevedere altri controlli ad esempio verifica che non esista già
            //una lezione associata allo stesso docente lo stesso giorno..
            //nuovaLezione.Corso = corso;
            //nuovaLezione.Docente = docente; //aggiungere al reposiotory lezioni dove asegno tutto 
            lezioniRepo.Add(nuovaLezione);
            return "Aggiunta correttamente";
        }

        public string ModificaLezione(int idLezione, string aula)
        {
            var lezioneEsiste = lezioniRepo.GetById(idLezione);
            if (lezioneEsiste == null)
            {
                return "Id non esiste!";
            }
            lezioneEsiste.Aula = aula;
            lezioniRepo.Update(lezioneEsiste);
            return "Aula modificata con successo!";
        }

        public string EliminaLezione(int lezioneDaEliminare)
        {
            var lezioneElimina = lezioniRepo.GetById(lezioneDaEliminare);
            if (lezioneDaEliminare == 0)
            {
                return "Errore: ID errato! Oppure non esiste lezione con questo ID";
            }
            lezioniRepo.Delete(lezioneElimina);
            return "Lezione eliminata corretamente!";
        }

        public List<Lezione> VisualizzaLezioneConCodiceCorso(string codiceCorso)
        {
            return lezioniRepo.GetByCorsoCodice(codiceCorso);
        }

        #endregion
    }
}
