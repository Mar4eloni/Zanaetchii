using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Controllers
{
    public class AdminController : Controller
    {
        //private readonly RoleManager<IdentityRole> roleManager;

        //public AdminController(RoleManager<IdentityRole> roleManager)
        //{
        //    this.roleManager = roleManager;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(ProjectRole role)
        //{
        //    var existingrole = await roleManager.RoleExistsAsync(role.RoleName);
        //    if (!existingrole)
        //    {
        //        var result = await roleManager.CreateAsync(new IdentityRole(role.RoleName));
        //    }
        //    return View();
        //}
    }
}
