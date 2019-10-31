using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class Coordinador
    {
        public Coordinador()
        {
            Carrera = new HashSet<Carrera>();
        }

        public int CoordinadorId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Carrera> Carrera { get; set; }
    }
}
