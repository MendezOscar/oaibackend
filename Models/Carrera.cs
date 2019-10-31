using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Docente = new HashSet<Docente>();
            Planes = new HashSet<Planes>();
        }

        public int CarreraId { get; set; }
        public string Nombre { get; set; }
        public int CoordinadorId { get; set; }

        public virtual Coordinador Coordinador { get; set; }
        public virtual ICollection<Docente> Docente { get; set; }
        public virtual ICollection<Planes> Planes { get; set; }
    }
}
