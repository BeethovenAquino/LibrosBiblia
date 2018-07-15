 create  DATABASE LibroBibliaDb
GO
USE LibroBibliaDb
GO
create TABLE LibroBiblias
(
	  LibroId int primary key identity(1,1),
         Descripcion varchar(max),
         Siglas varchar(15),
         Tipo varchar(15)
);

