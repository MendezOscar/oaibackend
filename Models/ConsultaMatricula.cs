using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class ConsultaMatricula
    {
        public int ConsultaMatriculaId { get; set; }
        public int Periodo { get; set; }
        public int Anio { get; set; }
        public int Estado { get; set; }
    }
}
