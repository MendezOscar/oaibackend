using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class OfertaAcademicaDetalle
    {
        public int OfertaAcademicaDetalleId { get; set; }
        public int OfertaAcademicaId { get; set; }
        public string Seccion { get; set; }
        public int AulaId { get; set; }
        public int DocenteId { get; set; }
        public int CursoId { get; set; }
        public int HorarioId { get; set; }

        public virtual Aula Aula { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Docente Docente { get; set; }
        public virtual Horarios Horario { get; set; }
        public virtual OfertaAcademica OfertaAcademica { get; set; }
    }
}
