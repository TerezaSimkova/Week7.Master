using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week7.Master.MVC.Models
{
    public class LezioneViewModel
    {
        public int LezioneID { get; set; }
        public DateTime DataOraInizio { get; set; }
        public int Durata { get; set; }
        public string Aula { get; set; }
        //FK verso docente      
        public int DocenteID { get; set; }
        public DocenteViewModel Docente { get; set; }
        //FK verso corso
        public string CorsoCodice { get; set; }
        public CorsoViewModel Corso { get; set; }
    }
}
