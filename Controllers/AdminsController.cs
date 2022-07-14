using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RoleBasedAuthorization.Models;
using RoleBasedAuthorizationCore5;
using RoleBasedAuthorizationCore5.Models;
using RoleBasedAuthorizationCore5.Services.Interfaces;

namespace RoleBasedAuthorization.Controllers
{
    public class AdminsController : Controller
    {
        //MyDbContext _context = new MyDbContext();
        private readonly string _connectionString;

        public readonly IAdminInfo _adminInfo;
        public AdminsController(IConfiguration configuration, IAdminInfo adminInfo)
        {
            _adminInfo = adminInfo;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // GET: Admins
        [AuthorizedAction]
        public async Task<IActionResult> Index()
        {
            //var myDbContext = _context.Admins.Include(a => a.Roles);
            //var admins = await GetAdmins();
            var vmList = new List<Admins>();
            var admins = await _adminInfo.GetAdmins();
            foreach (var item in admins)
            {
                var vm = new Admins();
                vm.Id = item.Id;
                vm.FullName = item.FullName;
                vm.Email = item.Email;
                vm.Username = item.Username.ToUpper();
                vm.Password = item.Password;
                vm.RolesId = item.RolesId;
                vm.Roles = await _adminInfo.GetRolesById(item.RolesId);
                vmList.Add(vm);
            }
            return View(vmList);      
            //return View( await myDbContext.ToListAsync());
            //return View(admins);
        }


        [HttpGet]
        public ActionResult EventPermission()
        {
            int roleId = (int)HttpContext.Session.GetInt32("role_id");
            var permission = GetEventPermission(roleId);
            return Json(data: permission);
        }

        public List<LinkRoleMenuPermission> GetEventPermission(int roleId)
        {
            var query = "Select m.id, rp.MenuId,m.name MenuName, m.url, rp.ViewPermission,rp.CreatePermission,rp.UpdatePermission,rp.DeletePermission From RoleWisePermission rp, menus m Where m.id = rp.MenuId And rp.RoleId = " + roleId + "";
            using (var connection = new SqlConnection(_connectionString))
            {
                List<LinkRoleMenuPermission> items = new List<LinkRoleMenuPermission>();
                //var model = new PurchaseDetailModel();
                connection.Open();
                var result = connection.Query<LinkRoleMenuPermission>(query);
                var length = result.Count();
                int Sl = 1;
                if (length > 0)
                {
                    foreach (var item in result)
                    {
                        var model = new LinkRoleMenuPermission();
                        model.Sl = Sl;
                        model.MenuId = item.MenuId;
                        model.MenuName = item.MenuName;
                        model.ViewPermission = item.ViewPermission;
                        model.EditPermission = item.EditPermission;
                        model.CreatePermission = item.CreatePermission;
                        model.DeletePermission = item.DeletePermission;
                        model.URL = item.URL;
                        //model.Iselected = item.Iselected;
                        //model.Delete = item.Delete;

                        //model.Total_Price = item.Total_Price;
                        //model.Quantity = item.Quantity;
                        //model.Purchase_Detail_Id = item.Purchase_Detail_Id;
                        //model.Purchase_Master_Id = item.Purchase_Master_Id;
                        Sl++;
                        items.Add(model);
                    }

                }

                return items;
            }
        }



        // GET: Admins/Create
        [AuthorizedAction]
        public async Task<IActionResult> Create()
        {
            var roles = await _adminInfo.GetRoles();
            ViewBag.RolesId = new SelectList(roles, "Roles_Master_Id", "Title");
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Admins admins)
        {
            if (ModelState.IsValid)
            {
                //{
                //    _context.Add(Create);
                //if (await IsUsernameExistAsync(admins.Username))
                //{
                //    ModelState.AddModelError("Username", "User with this Username already exists");
                //    return View(admins);
                //}
                await _adminInfo.CreateAdmin(admins);
                //    return RedirectToAction(nameof(Index));
                //}
                return RedirectToAction(nameof(Index));
            }

            var roles = await _adminInfo.GetRoles();
            ViewData["RolesId"] = new SelectList(roles, "Roles_Master_Id", "Title", admins.RolesId);
            //return View(admins);
            return Json(admins);
        }


        //[HttpPost]
        //public JsonResult CheckUsernameAvailability(string username)
        //{
        //    //int roleId = (int)HttpContext.Session.GetInt32("role_id");
        //    var userName = IsUsernameExistAsync(username);
        //    return Json(data: userName);
        //}

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> CheckUsernameAvailability(string username)
       {
            if (await IsUsernameExistAsync(username))
            {
                return Json($"A user named {username} already exists.");
            }

            return Json(true);
        }
        //private async Task<int> IsUsernameExistAsync(string username)
        //{
        //    var query = "Select username from admins Where username = '" + username + "'";
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(query);
        //        return result;
        //    }


        //}
        private async Task<bool> IsUsernameExistAsync(string username)
        {
            bool IsTrue = false;
            var query = "Select username from admins Where username = '" + username + "'";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync(query);
                var length = result.Count();
                if (length > 0)
                {
                    IsTrue = true;
                }
                else
                {
                    IsTrue = false;
                }
            }
            return IsTrue;

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var admins = await _context.Admins.SingleOrDefaultAsync(m => m.Id == id);
            var admins = await _adminInfo.GetAdminById(id);
            if (admins == null)
            {
                return NotFound();
            }
            var roles = await _adminInfo.GetRoles();
            ViewData["RolesId"] = new SelectList(roles, "Roles_Master_Id", "Title", admins.RolesId);
            //ViewData["RolesId"] = new SelectList(_context.Roles, "Id", "Title", admins.RolesId);
            return View(admins);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Admins admins)
        {
            if (id != admins.Id)
            {
                return NotFound();
            }

            //Admins admin = await _context.Admins.Where(s => s.Id == admins.Id).FirstOrDefaultAsync();
            //admin.FullName = admins.FullName;
            //admin.Email = admins.Email;
            //admin.RolesId = admins.RolesId;
            //await _context.SaveChangesAsync();
            await _adminInfo.UpdateAdmin(admins);
            return Json(admins);
            //return RedirectToAction(nameof(Index));
        }

        //GET: Admins/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    //var admins = await _context.Admins
        //    //    .Include(a => a.Roles)
        //    //    .SingleOrDefaultAsync(m => m.Id == id);
        //    var admins = await _adminInfo.GetAdminById(id);
        //    if (admins == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(admins);
        //}

        // POST: Admins/DeleteConfirmed/5
        [HttpGet, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var admins = await _context.Admins.SingleOrDefaultAsync(m => m.Id == id);
            //_context.Admins.Remove(admins);
            //await _context.SaveChangesAsync();
            var admins = await _adminInfo.GetAdminById(id);
            if (admins == null)
            {
                return NotFound();
            }
             await _adminInfo.GetDeleteByAdminId(admins);

            return RedirectToAction(nameof(Index));
        }

        //private bool AdminsExists(int id)
        //{
        //    return _context.Admins.Any(e => e.Id == id);
        //}
    }
}
