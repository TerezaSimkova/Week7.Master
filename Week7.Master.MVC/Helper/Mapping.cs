using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.MVC.Models;

namespace Week7.Master.MVC.Helper
{
    public static class Mapping
    {
        //extention method extendono una classe -> inizia con -> this
        //trasforma corso view model
        public static CorsoViewModel ToCorsoViewModel(this Corso corso) //corso e classe che sta estendendo
        {
            //Oggetto per la visualizazzione
            return new CorsoViewModel
            {
                //a quale proprieta del corso corrisponde? Potrebbe anche avere nome diverso -> della view corso
                //sto trasformando CORSO in CorsoViewModel 
                CodiceCorso = corso.CodiceCorso,
                Nome = corso.Nome,
                Descrizione = corso.Descrizione
            };
        }

        //il contrario -> estensione del Corso view model
        public static Corso ToCorso(this CorsoViewModel corsoViewModel)
        {
            return new Corso
            {

                CodiceCorso = corsoViewModel.CodiceCorso,
                Nome = corsoViewModel.Nome,
                Descrizione = corsoViewModel.Descrizione,
                //Studenti = null,
                //Lezioni = null
            };
        }

        public static DocenteViewModel ToDocentiViewModel(this Docente docente)
        {
            return new DocenteViewModel
            {
                ID = docente.ID,
                Nome = docente.Nome,
                Cognome = docente.Cognome,
                Email = docente.Email,
                Telefono = docente.Telefono
            };
        }
        public static Docente ToDocenti(this DocenteViewModel docentiViewModel)
        {
            return new Docente
            {
                ID = docentiViewModel.ID,
                Nome = docentiViewModel.Nome,
                Cognome = docentiViewModel.Cognome,
                Email = docentiViewModel.Email,
                Telefono = docentiViewModel.Telefono
            };
        }

        public static StudenteViewModel ToStudentiViewModel(this Studente studente)
        {
            return new StudenteViewModel
            {
                ID = studente.ID,
                Nome = studente.Nome,
                Cognome = studente.Cognome,
                Email = studente.Email,
                DataDiNascita = studente.DataDiNascita,
                TitoloStudio = studente.TitoloStudio
            };
        }

        public static Studente ToStudenti(this StudenteViewModel studenteViewModel)
        {
            return new Studente
            {
                ID = studenteViewModel.ID,
                Nome = studenteViewModel.Nome,
                Cognome = studenteViewModel.Cognome,
                Email = studenteViewModel.Email,
                DataDiNascita = studenteViewModel.DataDiNascita,
                TitoloStudio = studenteViewModel.TitoloStudio
            };
        }

        public static LezioneViewModel ToLezioniViewModel(this Lezione lezione)
        {
            return new LezioneViewModel
            {
                 Aula = lezione.Aula,
                 DataOraInizio = lezione.DataOraInizio,
                 Durata = lezione.Durata
            };
        }

        public static Lezione ToLezioni(this LezioneViewModel lezioneViewModel)
        {
            return new Lezione
            {
                Aula = lezioneViewModel.Aula,
                DataOraInizio = lezioneViewModel.DataOraInizio,
                Durata = lezioneViewModel.Durata
            };
        }
    }
}
