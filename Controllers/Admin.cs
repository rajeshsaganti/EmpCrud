using EmpCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpCrud.Controllers
{
    public class Admin : Controller
    {
        private readonly EmpDbContext empDbContext;

        public Admin(EmpDbContext empDbContext)
        {
            this.empDbContext = empDbContext;
        }
        public IActionResult Index()
        {

            return View(empDbContext.employees.ToList());
        }
    }
}
