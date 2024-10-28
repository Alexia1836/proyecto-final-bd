using api.estudiante.umg.core.Context;
using api.estudiante.umg.core.Dtos;
using api.estudiante.umg.core.Models;
using Microsoft.EntityFrameworkCore;

namespace api.estudiante.umg.core.Services
{
    public class CursoService
    {
        protected readonly EstudianteUMGContext _context;

        public CursoService(EstudianteUMGContext context)
        {
            _context = context;
        }
        // Crear reigstro de curso
        public async Task<Cursos?> CreateCourseAsync( CursoCreateDto cursoCreateDto)
        {
            try
            {
                var course = new Cursos
                {
                    NombreCurso = cursoCreateDto.NombreCurso,
                    Creditos = cursoCreateDto.Creditos,
                    Profesor = cursoCreateDto.Profesor,
                    Seccion = cursoCreateDto.Seccion,
                };
                _context.Cursos.Add(course);
                await _context.SaveChangesAsync();
                return course;

            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        //Obtener todos los registros de cursos
        public async Task<IEnumerable<Cursos>> GetAllCoursesAsync()
        {
            return await _context.Cursos.Select(curso => new Cursos
            {
                Id = curso.Id,
                NombreCurso = curso.NombreCurso,
                Creditos = curso.Creditos,
                Profesor= curso.Profesor,
                Seccion = curso.Seccion
            }).ToListAsync();
        }
        // OBtener curso por ID
        public async Task<Cursos> GetByIdAsync(int id)
        {
            var course = await _context.Cursos.FindAsync(id);
            if (course == null) return null;
            return new Cursos
            {
                Id = course.Id,
                NombreCurso = course.NombreCurso,
                Creditos = course.Creditos,
                Profesor = course.Profesor,
                Seccion = course.Seccion
            };
        }
        // Actualizar registro de Curso
        public async Task<bool> UpdateAsync(int id, CursoCreateDto cursoCreateDto)
        {
            var course = await _context.Cursos.FindAsync(id);
            if (course == null) return false;

            course.NombreCurso = cursoCreateDto.NombreCurso;
            course.Profesor = cursoCreateDto.Profesor;
            course.Creditos = cursoCreateDto.Creditos;
            course.Seccion = cursoCreateDto.Seccion;

            await _context.SaveChangesAsync();
            return true;

        }
        //Eliminar registro de Curso
        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Cursos.FindAsync(id);
            if (course == null) return false;

            _context.Cursos.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
