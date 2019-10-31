using System;
using System.Collections.Generic;

namespace oaibackend.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Permisosxusuario = new HashSet<Permisosxusuario>();
        }

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public int Tipo { get; set; }

        public virtual ICollection<Permisosxusuario> Permisosxusuario { get; set; }
    }
}
