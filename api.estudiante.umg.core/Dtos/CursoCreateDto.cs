using System.ComponentModel.DataAnnotations;

namespace api.estudiante.umg.core.Dtos
{
    public class CursoCreateDto
    {
        [Required(ErrorMessage = "El campo NombreCurso es requerido")]
        public string NombreCurso { get; set; }

        [Required(ErrorMessage = "El campo Profesor es requerido")]
        public string Profesor {  get; set; }

        [Required(ErrorMessage = "El campo de Creditos es requerido")]
        public int Creditos { get; set; }

        [Required(ErrorMessage = "El campo de Seccion es requerido")]
        public string Seccion {  get; set; }
    }
}
