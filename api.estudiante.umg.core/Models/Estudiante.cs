using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace api.estudiante.umg.core.Models
{
    [Table("EstudiantesUMG")]
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad {  get; set; }
        public string CorreoElectronico { get; set; }

    }
}
