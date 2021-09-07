using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.Master.Core.Entities
{
    public class Corso
    {
        public string CodiceCorso { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }

        //Perche Studente ha la sua foreign key , corso contiene una lista dei studenti
        public List<Studente> Studenti { get; set; } = new List<Studente>();

        //Lista verso Lezioni
        public List<Lezione> Lezioni { get; set; } = new List<Lezione>();

        public override string ToString()
        {
            return $"{CodiceCorso} \t {Nome} \t {Descrizione}";
        }
    }
}
