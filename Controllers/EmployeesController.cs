using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpCrud.Models;
using System.IO;

namespace EmpCrud.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmpDbContext _context;

        public EmployeesController(EmpDbContext context)
        {
            _context = context;
        }
        public JsonResult getAllEmployee()
        {

            List<Employee> users = new List<Employee>();
            users = _context.employees.Select(c => c).ToList();

            return Json(new { data = users });
        }
        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.employees.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


        public IActionResult Create()
        {
            return View();
        }
        public byte[] GetImage(string sBase)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase))
            {
                bytes = Convert.FromBase64String(sBase);
            }
            return bytes;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.ImageFile != null && employee.ImageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await employee.ImageFile.CopyToAsync(ms);
                        employee.Photo = ms.ToArray();

                    }
                }
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (employee.ImageFile != null && employee.ImageFile.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await employee.ImageFile.CopyToAsync(ms);
                            employee.Photo = ms.ToArray();

                        }
                    }
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            return View(employee);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.employees.FindAsync(id);
            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.employees.Any(e => e.Id == id);
        }
    }
}
