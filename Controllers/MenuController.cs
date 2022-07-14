using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoleBasedAuthorization;
using RoleBasedAuthorization.Models;
using RoleBasedAuthorizationCore5.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedAuthorizationCore5.Controllers
{
    public class MenuController : Controller
    {
        public readonly IMenuInfo _menuInfo;
        public MenuController(IMenuInfo menuInfo)
        {
            _menuInfo = menuInfo;
        }


        public async Task<IActionResult> Index()
        {
            var menus = await _menuInfo.GetMenus();
            //return View(roles);
            return View(menus);
        }

        // GET: Roles/Create
        [AuthorizedAction]
        public async Task<IActionResult> Create()
        {
            var parentMenus = await _menuInfo.GetParentMenus();
            ViewBag.ParentId = new SelectList(parentMenus, "Id", "Name");
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Icon,Url,ParentId")] Menus menus)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(roles);
                await _menuInfo.CreateMenus(menus);
                return RedirectToAction(nameof(Index));
            }
            return View(menus);
        }

    }
}
