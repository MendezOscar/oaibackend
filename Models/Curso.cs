using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class Curso
    {
        public Curso()
        {
            OfertaAcademicaDetalle = new HashSet<OfertaAcademicaDetalle>();
            PlanDetalle = new HashSet<PlanDetalle>();
        }

        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public int Uv { get; set; }

        public virtual ICollection<OfertaAcademicaDetalle> OfertaAcademicaDetalle { get; set; }
        public virtual ICollection<PlanDetalle> PlanDetalle { get; set; }
    }
}
