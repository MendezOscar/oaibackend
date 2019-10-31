using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class PlanDetalle
    {
        public int PlanDetalleId { get; set; }
        public int PlanId { get; set; }
        public int CursoId { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Planes Plan { get; set; }
    }
}
