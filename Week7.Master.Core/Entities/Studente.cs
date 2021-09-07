using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.Master.Core.Entities
{
    public class Studente : Persona
    {
        public DateTime DataDiNascita { get; set; }
        public string TitoloStudio { get; set; }

        //Foreignkey
        public string CorsoCodice { get; set; }
        public Corso Corso { get; set; }

        public override string ToString()
        {
            return $"Id:{ID}\t{Nome}\t{Cognome}\tnato il {DataDiNascita.ToShortDateString()}\t Altre into: {Email} - {TitoloStudio}";
        }
    }
}
