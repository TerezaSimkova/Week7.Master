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
            List<StudenteViewModel> studentiViewModel = new List<StudenteViewModel>();
            foreach (var item in corso.Studenti)
            {
                studentiViewModel.Add(item?.ToStudentiViewModel());
            }
            //Oggetto per la visualizazzione
            return new CorsoViewModel
            {
                //a quale proprieta del corso corrisponde? Potrebbe anche avere nome diverso -> della view corso
                //sto trasformando CORSO in CorsoViewModel 
                CodiceCorso = corso.CodiceCorso,
                Nome = corso.Nome,
                Descrizione = corso.Descrizione,
                Studenti = studentiViewModel
            };
        }

        //il contrario -> estensione del Corso view model
        public static Corso ToCorso(this CorsoViewModel corsoViewModel)
        {
            List<Studente> studenti = new List<Studente>();
            foreach (var item in corsoViewModel.Studenti)
            {
                studenti.Add(item?.ToStudenti());
            }
            return new Corso
            {
                CodiceCorso = corsoViewModel.CodiceCorso,
                Nome = corsoViewModel.Nome,
                Descrizione = corsoViewModel.Descrizione,
                Studenti = studenti,
                //Lezioni = lezioni ->lista da creare
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
                TitoloStudio = studente.TitoloStudio,
                CorsoCodice = studente.CorsoCodice
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
                TitoloStudio = studenteViewModel.TitoloStudio,
                CorsoCodice = studenteViewModel.CorsoCodice
            };
        }

        public static LezioneViewModel ToLezioniViewModel(this Lezione lezione)
        {
            return new LezioneViewModel
            {
                LezioneID = lezione.LezioneID,
                Aula = lezione.Aula,
                DataOraInizio = lezione.DataOraInizio,
                DocenteID= lezione.DocenteID,
                CorsoCodice = lezione.CorsoCodice,
                Durata = lezione.Durata
            };
        }

        public static Lezione ToLezioni(this LezioneViewModel lezioneViewModel)
        {
            return new Lezione
            {
                LezioneID = lezioneViewModel.LezioneID,
                Aula = lezioneViewModel.Aula,
                DataOraInizio = lezioneViewModel.DataOraInizio,
                DocenteID = lezioneViewModel.DocenteID,
                CorsoCodice = lezioneViewModel.CorsoCodice,
                Durata = lezioneViewModel.Durata
            };
        }
    }
}
