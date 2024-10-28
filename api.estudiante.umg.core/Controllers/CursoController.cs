using api.estudiante.umg.core.Dtos;
using api.estudiante.umg.core.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.estudiante.umg.core.Controllers
{
    [Route("api/v1/cursos")]
    public class CursoController: ControllerBase
    {
        private readonly CursoService _service;

        public CursoController(CursoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok( await _service.GetAllCoursesAsync() );

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _service.GetByIdAsync(id);
            return course == null ? NotFound() : Ok( course );
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create( CursoCreateDto cursoCreateDto)
        {
            var createdCourse = await _service.CreateCourseAsync(cursoCreateDto);
            return Ok( createdCourse );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update( int id, CursoCreateDto cursoCreateDto)
        {
            var result = await _service.UpdateAsync(id, cursoCreateDto);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete( int id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? NoContent() : BadRequest();
        }
    }
}
