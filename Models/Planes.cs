using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class Planes
    {
        public Planes()
        {
            PlanAlumno = new HashSet<PlanAlumno>();
            PlanDetalle = new HashSet<PlanDetalle>();
        }

        public int PlanId { get; set; }
        public string Nombre { get; set; }
        public int CarreraId { get; set; }

        public virtual Carrera Carrera { get; set; }
        public virtual ICollection<PlanAlumno> PlanAlumno { get; set; }
        public virtual ICollection<PlanDetalle> PlanDetalle { get; set; }
    }
}
