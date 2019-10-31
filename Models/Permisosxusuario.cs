using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class Permisosxusuario
    {
        public int PermisosporusuarioId { get; set; }
        public int UsuarioId { get; set; }
        public int PermisoId { get; set; }

        public virtual Permisos Permiso { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
