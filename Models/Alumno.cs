using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            PlanAlumno = new HashSet<PlanAlumno>();
        }

        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Cuenta { get; set; }

        public virtual ICollection<PlanAlumno> PlanAlumno { get; set; }
    }
}
