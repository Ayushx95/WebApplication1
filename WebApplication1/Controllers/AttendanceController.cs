using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceRepository _repo;
        private readonly IStudentRepository _studentRepo;

        public AttendanceController(IAttendanceRepository repo, IStudentRepository studentRepo)
        {
            _repo = repo;
            _studentRepo = studentRepo;
        }

        public async Task<IActionResult> Index(int? studentId)
        {
            var students = await _studentRepo.GetAllStudentsAsync();
            ViewBag.Students = new SelectList(students, "Id", "Name", studentId);
            ViewBag.SelectedStudentId = studentId;

            if (studentId.HasValue)
            {
                var filtered = await _repo.GetAttendancesForStudentAsync(studentId.Value);
                return View(filtered);
            }

            var list = await _repo.GetAllAttendancesAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _repo.GetAttendanceAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        public async Task<IActionResult> Create()
        {
            var students = await _studentRepo.GetAllStudentsAsync();
            ViewBag.Students = new SelectList(students, "Id", "Name");
            return View(new Attendance { Date = DateTime.UtcNow.Date });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Attendance attendance)
        {
            if (!ModelState.IsValid)
            {
                var students = await _studentRepo.GetAllStudentsAsync();
                ViewBag.Students = new SelectList(students, "Id", "Name", attendance.StudentId);
                return View(attendance);
            }

            await _repo.AddAttendanceAsync(attendance);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var att = await _repo.GetAttendanceAsync(id);
            if (att == null) return NotFound();
            var students = await _studentRepo.GetAllStudentsAsync();
            ViewBag.Students = new SelectList(students, "Id", "Name", att.StudentId);
            return View(att);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Attendance attendance)
        {
            if (id != attendance.Id) return BadRequest();
            if (!ModelState.IsValid)
            {
                var students = await _studentRepo.GetAllStudentsAsync();
                ViewBag.Students = new SelectList(students, "Id", "Name", attendance.StudentId);
                return View(attendance);
            }

            var updated = await _repo.UpdateAttendanceAsync(attendance);
            if (!updated) return NotFound();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var att = await _repo.GetAttendanceAsync(id);
            if (att == null) return NotFound();
            return View(att);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAttendanceAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
