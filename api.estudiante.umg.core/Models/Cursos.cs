using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.estudiante.umg.core.Models
{
    [Table("CursosUMG")]
    public class Cursos
    {
        [Key]
        public int Id { get; set; }

        public string NombreCurso { get; set; }

        public string Profesor {  get; set; }

        public int Creditos { get; set; }

        public string Seccion { get; set; }

    }
}
