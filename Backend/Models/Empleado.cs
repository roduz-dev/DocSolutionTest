using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Usuario es requerido")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido Paterno es requerido")]
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "El Telefono es requerido")]
        [MaxLength(12, ErrorMessage = "La longitud máxima del telefono es de 12")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El Correo Eléctronico es requerido")]
        public string CorreoElectronico { get; set; }
        public string Puesto { get; set; }
        [Required(ErrorMessage = "La fecha de ingreso es requerida")]
        public string FechaIngreso { get; set; }
        [Required(ErrorMessage = "El password es requerido")]
        public string Password { get; set;}

    }
}
