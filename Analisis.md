#Todas las imagenes estan dentro de la carpeta imagenes

##Analisis

A. En el desarrollo se diseño pensando en los productos y la creacion de los mismo usando las estructuras mas simples que permitan a toda la api funcional para que sea mucho mas simple ademas de implementar dto para evitar que se guarden en la base de datos cosas repetidas o innecesarias.

B.
dotnet ef migrations add InitialCreate
dotnet ef database update

Y los comandos de actualizacion cada vez que necesitaba cambiar la base de datos


C.Comando utilizado para crear el contenedor
docker container create --name examen-final postgres:latest

D. Me encargue de forma particular de hacer todo el setup de docker, ver la base de datos, la implementacion de swagger todas las pruebas y el manejo de toda la app general
La IA me ayudo para problemas varios que fueran surgiendo y para ciertas partes del codigo de c#
