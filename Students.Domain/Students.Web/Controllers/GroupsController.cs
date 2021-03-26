using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Data.Interfaces;
using Students.Domain.Models;
using Students.Web.DTOs;
using Students.Web.Models;

namespace Students.Web.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IRepository<Group> repository;
        private readonly IMapper mapper;
        public GroupsController(IRepository<Group> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(string name)
        {
            var groups = repository.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                var nameInLower = name.ToLower();
                groups = groups.Where(x => x.Name.ToLower().Contains(nameInLower));
            }

            var groupDtos = mapper.Map<IEnumerable<GroupDto>>(groups);
            return View(new GroupsViewModel { Groups = groupDtos, Name = name });
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await repository.GetById((int)id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] Group group)
        {
            if (ModelState.IsValid)
            {
                repository.Create(group);
                return RedirectToAction(nameof(Index));
            }
            return View(@group);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await repository.GetById((int)id);
            if (group == null)
            {
                return NotFound();
            }
            return View(@group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] Group group)
        {
            if (id != @group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(group);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.Id))
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
            return View(@group);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await repository.GetById((int)id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var group = await repository.GetById((int)id);
            repository.Delete(group);
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return repository.GetById(id) != null;
        }
    }
}
