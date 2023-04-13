using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodingAssignment.Data;
using CodingAssignment.Models;

namespace CodingAssignment.Controllers
{
    public class TasksController : Controller
    {
        private readonly ProjectManagementDbContext _context;

        public TasksController(ProjectManagementDbContext context)
        {
            _context = context;
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name");
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        public async Task<IActionResult> Create(Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Projects", new { id = task.ProjectId });
            }

            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name", task.ProjectId);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name", task.ProjectId);
            return View(task);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Models.Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(task);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Projects", new { id = task.ProjectId});
            }

            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Name", task.ProjectId);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Task.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            _context.Remove(task);
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Projects", new { id = task.ProjectId });
        }
    }
}
