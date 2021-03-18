CREATE DATABASE SIENA
On Primary
(Name = SIENA_Data,
Filename = 'D:\Documentos\Sena\Analisis y desarrollo de la información\Cuarto trimestre\ASP.NET\Semana 8\SIENA\Database\SIENA.MDF',
Size = 50mb, MaxSize = 100mb,
Filegrowth = 20%)
Log on
(Name = SCES_log,
Filename = 'D:\Documentos\Sena\Analisis y desarrollo de la información\Cuarto trimestre\ASP.NET\Semana 8\SIENA\Database\SIENA.ldf',
Size = 10MB,
MaxSize = 15mb,
FileGrowth = 5mb)

USE SIENA