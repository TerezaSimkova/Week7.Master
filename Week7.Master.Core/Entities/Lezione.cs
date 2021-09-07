using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.Master.Core.Entities
{
    public class Lezione
    {
        public int LezioneID { get; set; }
        public DateTime DataOraInizio { get; set; }
        public int Durata { get; set; }
        public string Aula { get; set; }

        //FK verso docente      
        public int DocenteID { get; set; }
        public Docente Docente { get; set; }
        //FK verso corso
        public string CorsoCodice { get; set; }
        public Corso Corso { get; set; }

        public override string ToString()
        {
            return $"Lezione: {LezioneID}\tData: {DataOraInizio}\tAula:{Aula}\tDurata(in gg):{Durata}\tDocente: {Docente.ToString()}\t{Corso.ToString()}\n\n"; //to string stampa info relativi al corso e docente 
        }

    }
}
