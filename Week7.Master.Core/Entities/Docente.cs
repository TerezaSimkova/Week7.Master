﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.Master.Core.Entities
{
    public class Docente : Persona
    {
        public string Telefono { get; set; }

        //Lista Lezioni
        public List<Lezione> Lezioni { get; set; } = new List<Lezione>();

        public override string ToString()
        {
            return $"Docente Id:{ID}\t{Nome}\t{Cognome}\t Altre into: {Email} - {Telefono}";
        }
    }
}
