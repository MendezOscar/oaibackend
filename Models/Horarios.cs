using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class Horarios
    {
        public Horarios()
        {
            OfertaAcademicaDetalle = new HashSet<OfertaAcademicaDetalle>();
        }

        public int HorariosId { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }

        public virtual ICollection<OfertaAcademicaDetalle> OfertaAcademicaDetalle { get; set; }
    }
}
