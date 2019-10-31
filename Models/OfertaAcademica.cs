using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class OfertaAcademica
    {
        public OfertaAcademica()
        {
            OfertaAcademicaDetalle = new HashSet<OfertaAcademicaDetalle>();
        }

        public int OfertaId { get; set; }
        public int Periodo { get; set; }
        public int Anio { get; set; }

        public virtual ICollection<OfertaAcademicaDetalle> OfertaAcademicaDetalle { get; set; }
    }
}
