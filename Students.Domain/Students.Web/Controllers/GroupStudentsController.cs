using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Students.Data.Interfaces;
using Students.Domain.Models;

namespace Students.Web.Controllers
{
    public class GroupStudentsController : Controller
    {
        private readonly IRepository<GroupStudent> repository;
        private readonly IRepository<Group> groupRepository;
        private readonly IRepository<Student> studentRepository;
        public GroupStudentsController(IRepository<GroupStudent> repository, IStudentRepository studentRepository, IRepository<Group> groupRepository)
        {
            this.repository = repository;
            this.groupRepository = groupRepository;
            this.studentRepository = studentRepository;
        }

        // GET: GroupStudents
        public async Task<IActionResult> Index()
        {
            var grSt = await repository.GetAll();
            return View(grSt);
        }

        // GET: GroupStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupStudent = await repository.GetById((int)id);
            if (groupStudent == null)
            {
                return NotFound();
            }

            return View(groupStudent);
        }

        // GET: GroupStudents/Create
        public async Task<IActionResult> Create()
        {
            List<Group> groups = await groupRepository.GetAll();
            List<Student> students = await studentRepository.GetAll();
            var list = students.Select(x => new
                {x.Id, Name = $"{x.FirstName} {x.LastName} {x.Patronymic} ({x.UniqIdentity})"});
            ViewData["GroupId"] = new SelectList(groups, "Id", "Name");
            ViewData["StudentId"] = new SelectList(list, "Id", "Name");
            return View();
        }

        // POST: GroupStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,StudentId,Id")] GroupStudent groupStudent)
        {
            if (ModelState.IsValid)
            {
                repository.Create(groupStudent);
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(await groupRepository.GetAll(), "Id", "Name", groupStudent.GroupId);
            ViewData["StudentId"] = new SelectList(await studentRepository.GetAll(), "Id", "FirstName", groupStudent.StudentId);
            return View(groupStudent);
        }

        // GET: GroupStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupStudent = await repository.GetById((int)id);
            if (groupStudent == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(await groupRepository.GetAll(), "Id", "Name", groupStudent.GroupId);
            ViewData["StudentId"] = new SelectList(await studentRepository.GetAll(), "Id", "FirstName", groupStudent.StudentId);
            return View(groupStudent);
        }

        // POST: GroupStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupId,StudentId,Id")] GroupStudent groupStudent)
        {
            if (id != groupStudent.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(groupStudent);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupStudentExists(groupStudent.GroupId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(await groupRepository.GetAll(), "Id", "Name", groupStudent.GroupId);
            ViewData["StudentId"] = new SelectList(await studentRepository.GetAll(), "Id", "FirstName", groupStudent.StudentId);
            return View(groupStudent);
        }

        // GET: GroupStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupStudent = await repository.GetById((int)id);
            if (groupStudent == null)
            {
                return NotFound();
            }

            return View(groupStudent);
        }

        // POST: GroupStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupStudent = await repository.GetById(id);
            repository.Delete(groupStudent);
            return RedirectToAction(nameof(Index));
        }

        private bool GroupStudentExists(int id)
        {
            return repository.GetById(id) != null;
        }
    }
}
