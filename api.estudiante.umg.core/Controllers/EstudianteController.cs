using api.estudiante.umg.core.Dtos;
using api.estudiante.umg.core.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.estudiante.umg.core.Controllers
{
    [Route("api/v1/estudiantes")]
    [ApiController]
    public class EstudianteController: ControllerBase
    {
        private readonly EstudianteServices _service;


        public EstudianteController( EstudianteServices estudianteServices)
        {
            _service = estudianteServices;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllStudentsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _service.GetByIdAsync(id);
            return student == null ? NotFound() : Ok(student);
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create( EstudianteCreateDto estudianteCreateDto)
        {
            var createStudent = await _service.createStudent(estudianteCreateDto);
            return Ok(createStudent);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EstudianteCreateDto estudianteCreateDto)
        {
            var result = await _service.UpdateAsync(id, estudianteCreateDto);
            return result ? NoContent() : BadRequest();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? NoContent() : BadRequest();
        }
       
    }
}
