using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaratonProgramacion.Models
{
    public class Grupo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre Grupo es obligatorio")] //Data Anotation
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre Grupo")]
        public string NombreGrupo { get; set; }
       [Required(ErrorMessage = "El campo Estado es obligatorio")] //Data Anotation
       [Display(Name = "Estado")]
        public bool Estado { get; set; }
        [Required(ErrorMessage = "El campo Fecha Creación es obligatorio")] //Data Anotation
        [Display(Name = "Fecha Creacion")]
        public DateTime FechaCreacion { get; set; }

        //lider de equipo
        #region Lider
        [Required(ErrorMessage = "El campo Nombre es obligatorio")] //Data Anotation
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre Lider")]
        public string NombreLider { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Apellido Lider")]
        public string ApellidoLider { get; set; }

        [Required(ErrorMessage = "El campo Identificacion es obligatorio")]
        [StringLength(12, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Identificacion Lider")]
        public string IdentificacionLider  { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Correo Lider")]
        public string CorreoLider { get; set; }

        [Required(ErrorMessage = "El campo LenguajeProgramacion es obligatorio")]
        [StringLength(20, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Lenguaje De Programacion Lider")]
        public string LenguajeProgramacionLider { get; set; }
        #endregion

        #region INTEGRANTES
        //integrante 2
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre Integrante 2")]
        public string NombreIntegrante2 { get; set; }

        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Apellido Integrante 2")]
        public string ApellidoIntegrante2 { get; set; }

        [StringLength(12, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Identificacion Integrante 2")]
        public string IdentificacionIntegrante2 { get; set; }

        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Correo Integrante 2")]
        public string CorreoIntegrante2 { get; set; }

        [StringLength(20, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Lenguaje De Programacion Integrante 2")]
        public string LenguajeProgramacionIntegrante2 { get; set; }

        //integrante 3

        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre Integrante 3")]
        public string NombreIntegrante3 { get; set; }

        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Apellido Integrante 3")]
        public string ApellidoIntegrante3 { get; set; }

        [StringLength(12, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Identificacion Integrante 3")]
        public string IdentificacionIntegrante3 { get; set; }

        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Correo Integrante 3")]
        public string CorreoIntegrante3 { get; set; }

        [StringLength(20, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Lenguaje De Programacion Integrante 3")]
        public string LenguajeProgramacionIntegrante3 { get; set; }
        #endregion
    }
}
