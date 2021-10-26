using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;

namespace Week7.Master.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        //mi permette di parlare con il livello superiore - Program-utente e poi con business layer
        //aggiungere "elenco delle funzionalita richieste dalla traccia"
        #region Funzionalita Corsi
        //visualizza corsi
        //creo un metodo che poi mi portera al Core
        public List<Corso> GetAllCorsi();

        //Insert corso,mi prende un corso in input,poi mi restitiusci una stringa
        public string InserisciNuovoCorso(Corso newCorso);

        //modifica corso
        public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione);

        //Eliminare corso
        public string EliminaCorso(string codiceCorsoDaEliminare);
        #endregion

        #region Funzionalita Studenti

        public List<Studente> GetAllStudenti();
        public string InserisciNuovoStudente(Studente nuovoStudente);
        public string ModificaStudente(int id, string nuovoEmail);
        public string EliminaStudente(int id);
        public List<Studente> VisualizzaStudentiCorso(string scelta);
        #endregion

        #region Funzionalita Docente

        public List<Docente> GetAllDocenti();
        public string InserisciNuovoDocente(Docente nuovoDocente);
        public string ModificaDocente(int id, string nome, string cognome, string email);
        public string EliminaDocente(int id);
        #endregion

        #region Funzioalit Lezini

        public List<Lezione> GetAllLezioni();
        public string InserisciNuovaLezione(Lezione nuovaLezione);
        public string ModificaLezione(int idLezione, string aula);
        public string EliminaLezione(int lezioneDaEliminare);
        public List<Lezione> VisualizzaLezioneConCodiceCorso(string codiceCorso);
        public List<Lezione> VisualizzaLezioniDelCorso(string nomeCorso);
        #endregion
    }
}
