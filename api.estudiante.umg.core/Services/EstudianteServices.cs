using api.estudiante.umg.core.Context;
using api.estudiante.umg.core.Dtos;
using api.estudiante.umg.core.Models;
using Microsoft.EntityFrameworkCore;

namespace api.estudiante.umg.core.Services
{
    public class EstudianteServices
    {
        protected readonly EstudianteUMGContext _context;
        public EstudianteServices( EstudianteUMGContext context ) {
            _context = context;
        }

        // Crear un nuevo registro de estudiante
        public async Task<Estudiante?> createStudent( EstudianteCreateDto estudianteCreateDto )
        {
            try
            {
                var student = new Estudiante
                {
                   Nombre = estudianteCreateDto.Nombre,
                   Apellido = estudianteCreateDto.Apellido,
                   CorreoElectronico = estudianteCreateDto.CorreoElectronico,
                   Edad = estudianteCreateDto.Edad,
                };

                _context.Estudiantes.Add(student);
                await _context.SaveChangesAsync();

                return student;

            } catch ( Exception ex )
            {
                Console.WriteLine( ex );
                return null;
            }
        }
        //Obtener todos los registros de estudiante
        public async Task<IEnumerable<Estudiante>> GetAllStudentsAsync()
        {
            return await _context.Estudiantes.Select(estudiante => new Estudiante
            {
                Id = estudiante.Id,
                Nombre = estudiante.Nombre,
                Apellido = estudiante.Apellido,
                Edad = estudiante.Edad,
                CorreoElectronico = estudiante.CorreoElectronico
            }).ToListAsync();
        }

        public async Task<Estudiante> GetByIdAsync(int id)
        {
            var student = await _context.Estudiantes.FindAsync(id);
            if (student == null) return null;

            return new Estudiante
            {
                Id = student.Id,
                Nombre = student.Nombre,
                Apellido = student.Apellido,
                Edad = student.Edad,
                CorreoElectronico = student.CorreoElectronico
            };
        }

        //Actualizar el registro
        public async Task<bool> UpdateAsync(int id, EstudianteCreateDto estudianteCreateDto)
        {
            var student = await _context.Estudiantes.FindAsync(id);
            if (student == null) return false;

            student.Nombre = estudianteCreateDto.Nombre;
            student.Apellido = estudianteCreateDto.Apellido;
            student.Edad = estudianteCreateDto.Edad;
            student.CorreoElectronico = estudianteCreateDto.CorreoElectronico;

            await _context.SaveChangesAsync();
            return true;
        }
        // Eliminar un estudiante
        public async Task<bool> DeleteAsync (int id)
        {
            var student = await _context.Estudiantes.FindAsync(id);
            if (student == null) return false;

            _context.Estudiantes.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
