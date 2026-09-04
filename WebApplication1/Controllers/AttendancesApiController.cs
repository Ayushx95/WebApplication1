using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceRepository _repo;

        public AttendancesController(IAttendanceRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAll()
        {
            var list = await _repo.GetAllAttendancesAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetById(int id)
        {
            var item = await _repo.GetAttendanceAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("bystudent/{studentId}")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetByStudent(int studentId)
        {
            var list = await _repo.GetAttendancesForStudentAsync(studentId);
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult<Attendance>> Create([FromBody] Attendance attendance)
        {
            if (attendance == null) return BadRequest();
            await _repo.AddAttendanceAsync(attendance);
            return CreatedAtAction(nameof(GetById), new { id = attendance.Id }, attendance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Attendance attendance)
        {
            if (attendance == null || id != attendance.Id) return BadRequest();
            var updated = await _repo.UpdateAttendanceAsync(attendance);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.DeleteAttendanceAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
