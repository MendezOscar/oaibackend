using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class PlanAlumno
    {
        public int PlanAlumnoId { get; set; }
        public int AlumnoId { get; set; }
        public int PlanId { get; set; }
        public int Activo { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Planes Plan { get; set; }
    }
}
