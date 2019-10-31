using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class Aula
    {
        public Aula()
        {
            OfertaAcademicaDetalle = new HashSet<OfertaAcademicaDetalle>();
        }

        public int AulaId { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }

        public virtual ICollection<OfertaAcademicaDetalle> OfertaAcademicaDetalle { get; set; }
    }
}
