using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace oaibackend.Models
{
    public partial class oaidbContext : DbContext
    {
        public oaidbContext()
        {
        }

        public oaidbContext(DbContextOptions<oaidbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Aula> Aula { get; set; }
        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<ConsultaMatricula> ConsultaMatricula { get; set; }
        public virtual DbSet<ConsultaMatriculaDetalle> ConsultaMatriculaDetalle { get; set; }
        public virtual DbSet<Coordinador> Coordinador { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Docente> Docente { get; set; }
        public virtual DbSet<Horarios> Horarios { get; set; }
        public virtual DbSet<OfertaAcademica> OfertaAcademica { get; set; }
        public virtual DbSet<OfertaAcademicaDetalle> OfertaAcademicaDetalle { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Permisosxusuario> Permisosxusuario { get; set; }
        public virtual DbSet<PlanAlumno> PlanAlumno { get; set; }
        public virtual DbSet<PlanDetalle> PlanDetalle { get; set; }
        public virtual DbSet<Planes> Planes { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RVM649N\\SQLEXPRESS;Database=oaidb;User Id=Mendez; Password=M3nd3z; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.Property(e => e.Clave).IsUnicode(false);

                entity.Property(e => e.Cuenta)
                    .HasColumnName("cuenta")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Coordinador)
                    .WithMany(p => p.Carrera)
                    .HasForeignKey(d => d.CoordinadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Carrera__Coordin__25869641");
            });

            modelBuilder.Entity<Coordinador>(entity =>
            {
                entity.Property(e => e.Clave).IsUnicode(false);

                entity.Property(e => e.Cuenta)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Uv).HasColumnName("UV");
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.Property(e => e.Cuenta)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.Docente)
                    .HasForeignKey(d => d.CarreraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Docente__Carrera__3E52440B");
            });

            modelBuilder.Entity<Horarios>(entity =>
            {
                entity.Property(e => e.HoraFinal).HasColumnType("datetime");

                entity.Property(e => e.HoraInicio).HasColumnType("datetime");
            });

            modelBuilder.Entity<OfertaAcademica>(entity =>
            {
                entity.HasKey(e => e.OfertaId)
                    .HasName("PK__OfertaAc__F2629429017BD371");
            });

            modelBuilder.Entity<OfertaAcademicaDetalle>(entity =>
            {
                entity.Property(e => e.Seccion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Aula)
                    .WithMany(p => p.OfertaAcademicaDetalle)
                    .HasForeignKey(d => d.AulaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OfertaAca__AulaI__440B1D61");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.OfertaAcademicaDetalle)
                    .HasForeignKey(d => d.CursoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OfertaAca__Curso__45F365D3");

                entity.HasOne(d => d.Docente)
                    .WithMany(p => p.OfertaAcademicaDetalle)
                    .HasForeignKey(d => d.DocenteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OfertaAca__Docen__44FF419A");

                entity.HasOne(d => d.Horario)
                    .WithMany(p => p.OfertaAcademicaDetalle)
                    .HasForeignKey(d => d.HorarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OfertaAca__Horar__46E78A0C");

                entity.HasOne(d => d.OfertaAcademica)
                    .WithMany(p => p.OfertaAcademicaDetalle)
                    .HasForeignKey(d => d.OfertaAcademicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OfertaAca__Ofert__4316F928");
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.HasKey(e => e.PermisoId)
                    .HasName("PK__Permisos__96E0C7236607EE9D");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permisosxusuario>(entity =>
            {
                entity.HasKey(e => e.PermisosporusuarioId)
                    .HasName("PK__Permisos__84DE8E830F917D8D");

                entity.HasOne(d => d.Permiso)
                    .WithMany(p => p.Permisosxusuario)
                    .HasForeignKey(d => d.PermisoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permisosx__Permi__4F7CD00D");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Permisosxusuario)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permisosx__Usuar__4E88ABD4");
            });

            modelBuilder.Entity<PlanAlumno>(entity =>
            {
                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.PlanAlumno)
                    .HasForeignKey(d => d.AlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlanAlumn__Alumn__35BCFE0A");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.PlanAlumno)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlanAlumn__PlanI__36B12243");
            });

            modelBuilder.Entity<PlanDetalle>(entity =>
            {
                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.PlanDetalle)
                    .HasForeignKey(d => d.CursoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlanDetal__Curso__2E1BDC42");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.PlanDetalle)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlanDetal__Curso__2D27B809");
            });

            modelBuilder.Entity<Planes>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PK__Planes__755C22B7CE0CBF16");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.Planes)
                    .HasForeignKey(d => d.CarreraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Planes__CarreraI__286302EC");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
