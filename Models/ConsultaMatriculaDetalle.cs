using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class ConsultaMatriculaDetalle
    {
        public int ConsultaMatriculaDetalleId { get; set; }
        public int ConsultaMatriculaId { get; set; }
        public int AlumnoId { get; set; }
        public int CursoId { get; set; }
        public int Dia { get; set; }
    }
}
