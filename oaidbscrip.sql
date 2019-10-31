create table Carrera (
CarreraId int identity(1,1) primary key,
Nombre varchar(max) not null,
CoordinadorId int not null,
foreign key (CoordinadorId) references Coordinador(CoordinadorId)
)

create table Coordinador(
CoordinadorId int identity(1,1) primary key,
Nombre varchar(max) not null,
)

create table Planes (
PlanId int identity(1,1) primary key,
Nombre varchar(max) not null,
CarreraId int not null,
foreign key (CarreraId) references Carrera(CarreraId)
)  

create table Curso(
CursoId int identity(1,1) primary key,
Nombre varchar(max) not null,
UV int not null
)

create table PlanDetalle(
PlanDetalleId int identity(1,1) primary key,
PlanId int not null,
CursoId int not null
foreign key (PlanId) references Planes(PlanId),
foreign key (CursoId) references Curso(CursoId)
)

create table Alumno(
AlumnoId int identity(1,1) primary key,
Nombre varchar(max),
cuenta varchar(10)
) 
 
create table PlanAlumno(
PlanAlumnoId int identity(1,1) primary key,
AlumnoId int not null,
PlanId int not null,
Activo int not null,
foreign key (AlumnoId) references Alumno(AlumnoId),
foreign key (PlanId) references Planes(PlanId)
)

create table Horarios(
HorariosId int identity(1,1) primary key,
HoraInicio datetime not null,
HoraFinal dateTime not null,
)

create table Aula (
AulaId int identity (1,1) primary key,
Nombre varchar(max),
Capacidad int not null
)

create table Docente(
DocenteId int identity(1,1) primary key,
Nombre varchar(max) not null,
Cuenta varchar(max) not null,
CarreraId int not null,
foreign key (CarreraId) references Carrera(CarreraId)
)

create table OfertaAcademica(
OfertaId int identity(1,1) primary key,
Periodo int not null,
Anio int not null
)
create table OfertaAcademicaDetalle(
OfertaAcademicaDetalleId int identity(1,1) primary key,
OfertaAcademicaId int not null,
Seccion varchar(15),
AulaId int not null,
DocenteId int not null,
CursoId int not null,
HorarioId int not null,
foreign key (OfertaAcademicaId) references OfertaAcademica(OfertaId),
foreign key (AulaId) references Aula(AulaId),
foreign key (DocenteId) references Docente(DocenteId),
foreign key (CursoId) references Curso(CursoId),
foreign key (HorarioId) references Horarios(HorariosId)
)

create table Usuario(
UsuarioId int identity(1,1) primary key,
Nombre varchar(50),
Clave varchar(50) not null,
Tipo int not null
)
create table Permisos(
PermisoId int identity (1,1) primary key,
Nombre varchar(50)
)
create table Permisosxusuario(
PermisosporusuarioId int identity(1,1) primary key,
UsuarioId int not null,
PermisoId int not null,
foreign key (UsuarioId) references Usuario(UsuarioId),
foreign key (PermisoId) references Permisos(PermisoId)
)

create table ConsultaMatricula(
ConsultaMatriculaId int identity(1,1)  primary key,
Periodo int not null,
Anio int not null,
Estado int not null
)

create table ConsultaMatriculaDetalle(
ConsultaMatriculaDetalleId int identity(1,1) primary key,
ConsultaMatriculaId int not null,
AlumnoId int not null,
CursoId int not null,
Dia int not null
)