using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Siena.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El numero de documento es obligatorio")]
        [MaxLength(10, ErrorMessage = "El numero de documento excede el numero maximo de caracteres (10)")]
        public int Documento { get; set; }

        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(10, ErrorMessage = "El numero de documento excede el numero maximo de caracteres (30)")]
        public string Nombre { get; set; }

        [MaxLength(10, ErrorMessage = "El numero de celular excede el numero maximo de caracteres (10)")]
        public int Celular { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [EmailAddress(ErrorMessage = "Debe ingresar un mail válido")]
        [MaxLength(10, ErrorMessage = "El numero de documento excede el numero maximo de caracteres (30)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El genero es obligatorio")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "La selección es obligatorio")]
        public string Aprendiz { get; set; }

        [Required(ErrorMessage = "La selección es obligatorio")]
        public string Egresado { get; set; }

        [Required(ErrorMessage = "El nombre de la formación es obligatorio")]
        [MaxLength(30, ErrorMessage = "El nombre de la formación excede el numero maximo de caracteres (30)")]
        public string AreaFormacion { get; set; }

        public DateTime FechaEgresado{ get; set; }

        [Required(ErrorMessage = "La direccion es obligatorio")]
        [MaxLength(30, ErrorMessage = "La direccion excede el numero maximo de caracteres (30)")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El barrio es obligatorio")]
        [MaxLength(30, ErrorMessage = "El barrio excede el numero maximo de caracteres (30)")]
        public string Barrio { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria")]
        [MaxLength(30, ErrorMessage = "El nombre de la ciudad excede el numero maximo de caracteres (30)")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio")]
        [MaxLength(30, ErrorMessage = "El nombre del departamento excede el numero maximo de caracteres (30)")]
        public string Departamento { get; set; }

        public DateTime FechaRegistro { get; set; }

    }
}