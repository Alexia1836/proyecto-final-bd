using System.ComponentModel.DataAnnotations;

namespace api.estudiante.umg.core.Dtos
{
    public class EstudianteCreateDto
    {
        [Required(ErrorMessage = "El campo de Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo de Apellido es requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo de Edad es requerido")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo de Correo Electronico es requerido")]
        public string CorreoElectronico { get; set; }
    }
}
