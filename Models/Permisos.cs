using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class Permisos
    {
        public Permisos()
        {
            Permisosxusuario = new HashSet<Permisosxusuario>();
        }

        public int PermisoId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Permisosxusuario> Permisosxusuario { get; set; }
    }
}
