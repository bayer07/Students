using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Students.Data.Interfaces;
using Students.Domain.Enums;
using Students.Domain.Models;
using Students.Web.DTOs;
using Students.Web.Models;

namespace Students.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRepository<Student> repository;
        private readonly IMapper mapper;
        public StudentsController(IStudentRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(string name, string identity, string group, int gender, int? pageNumber)
        {
            IQueryable<Student> students = repository.AsQueryable();
            if (pageNumber == null)
            {
                pageNumber = 1;
            }

            if (gender != 0)
            {
                var g = (Gender)gender;
                students = students.Where(x => x.Gender == g);
            }

            if (!string.IsNullOrEmpty(name))
            {
                var nameFilterInLower = name.ToLower();
                students = students.Where(s => s.LastName.ToLower().Contains(nameFilterInLower)
                                               || s.FirstName.ToLower().Contains(nameFilterInLower)
                                               || s.Patronymic != null &&
                                               s.Patronymic.ToLower().Contains(nameFilterInLower));
            }

            if (!string.IsNullOrEmpty(identity))
            {
                var identityFilterInLower = identity.ToLower();
                students = students.Where(s => s.UniqIdentity != null && s.UniqIdentity.ToLower().Contains(identityFilterInLower));
            }

            if (!string.IsNullOrEmpty(group))
            {
                var groupFilterInLower = group.ToLower();
                students = students.Where(s =>
                        s.GroupStudents.Any(x => x.Group.Name.ToLower().Contains(groupFilterInLower)));
            }

            var genderEnums = from Gender g in Enum.GetValues(typeof(Gender))
                              select new { ID = (int)g, Name = g.ToString() };
            var genders = genderEnums.ToList();
            genders.Add(new { ID = 0, Name = string.Empty });

            var paginatedList = await PaginatedList<Student>.CreateAsync(students, pageNumber ?? 1, 3);
            var studentDtos = mapper.Map<List<StudentDto>>(paginatedList);
            return View(new StudentsViewModel
            {
                Name = name,
                Identity = identity,
                Group = group,
                Students = studentDtos,
                Gender = gender,
                GenderList = new SelectList(genders, "ID", "Name", gender),
                PageNumber = pageNumber,
                HasNextPage = paginatedList.HasNextPage,
                HasPreviousPage = paginatedList.HasPreviousPage
            });
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await repository.GetById((int)id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gender,LastName,FirstName,Patronymic,UniqIdentity")] Student student)
        {
            if (ModelState.IsValid)
            {
                repository.Create(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await repository.GetById((int)id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gender,LastName,FirstName,Patronymic,UniqIdentity")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await repository.GetById((int)id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await repository.GetById(id);
            repository.Delete(student);
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return repository.GetById(id) != null;
        }
    }
}
