using api.estudiante.umg.core.Models;
using Microsoft.EntityFrameworkCore;

namespace api.estudiante.umg.core.Context
{
    public class EstudianteUMGContext : DbContext
    {
        public EstudianteUMGContext(DbContextOptions<EstudianteUMGContext> options) : base(options) { }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
    }
}
