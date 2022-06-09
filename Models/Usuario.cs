using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaratonProgramacion.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo Nombre es obligatorio")] //Data Anotation
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength =3)]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")] 
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo Identificacion es obligatorio")] 
        [StringLength(12, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Identificacion")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo LenguajeProgramacion es obligatorio")] 
        [StringLength(20, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Lenguaje De Programacion")]
        public string LenguajeProgramacion { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")] 
        [Display(Name = "Es Lider")]
        public Boolean Lider { get; set; }

        [Required(ErrorMessage = "El campo Id equipo es obligatorio")] 
        [Display(Name = "Id equipo")]        
        public int IdEquipo {  get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }
    }
}
