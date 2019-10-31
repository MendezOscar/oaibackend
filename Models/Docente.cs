using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class Docente
    {
        public Docente()
        {
            OfertaAcademicaDetalle = new HashSet<OfertaAcademicaDetalle>();
        }

        public int DocenteId { get; set; }
        public string Nombre { get; set; }
        public string Cuenta { get; set; }
        public int CarreraId { get; set; }

        public virtual Carrera Carrera { get; set; }
        public virtual ICollection<OfertaAcademicaDetalle> OfertaAcademicaDetalle { get; set; }
    }
}
