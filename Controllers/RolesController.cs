using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RoleBasedAuthorization.Models;
using RoleBasedAuthorizationCore5.Models;
using RoleBasedAuthorizationCore5.Services.Helpers;
using RoleBasedAuthorizationCore5.Services.Interfaces;

namespace RoleBasedAuthorization.Controllers
{
    public class RolesController : Controller
    {
        MyDbContext _context = new MyDbContext();
        private readonly IRolesInfo _rolesInfo;
        //private readonly IDGenerated _iDGenerated;
        private readonly string _connectionString;
        public RolesController(IConfiguration configuration, IRolesInfo rolesInfo)
        {
            _rolesInfo = rolesInfo;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        // GET: Admins




        // GET: Roles
        //[AuthorizedAction]
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Roles.ToListAsync());
        //}
        [AuthorizedAction]
        public async Task<IActionResult> Index()
        {
            int roleId = (int)HttpContext.Session.GetInt32("role_id");
            ViewBag.Permission = GetEventPermissionAsync(roleId);
            //var myDbContext = _context.Admins.Include(a => a.Roles);
            var roles = await _rolesInfo.GetRoles();
            return View(roles);
        }

        public async Task<List<Roles>> GetEventPermissionAsync(int roleId)
        {
            var query = "Select Id, RoleId, MenuId, MenuName, Url, ViewPermission, CreatePermission, UpdatePermission, DeletePermission From RoleWisePermission Where RoleId = " + roleId + "";
            //var queryDetail = "INSERT INTO RoleWisePermission (Id, RoleId, MenuId, MenuName, Url, ViewPermission, CreatePermission, UpdatePermission, DeletePermission) VALUES (" + detail.Roles_Detail_Id + "," + MaxID + "," + detail.MenuId + ", '" + detail.MenuName + "', '" + detail.Url + "', '" + detail.View + "','" + detail.Create + "', '" + detail.Edit + "', '" + detail.Delete + "')";
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<Roles>(query);
                return result.ToList();
            }

            //roleDto = new Roles
               
        }

        [HttpGet]
        public async Task<JsonResult> PermissionWithMenu()
        {
            int roleId = (int)HttpContext.Session.GetInt32("role_id");
            var result = await GetPermissionWithMenu(roleId);
            return Json(data: result);

        }

        [HttpGet]
        public async Task<JsonResult> PermissionWithRoleId(int Id)
        {
            //int roleId = (int)HttpContext.Session.GetInt32("role_id");
            var result = await GetPermissionWithRoleId(Id);
            //return PartialView("_viewall", PurchaseList);
            //return PartialView("_viewAll", result);
            return Json(data: result);

        }

        public async Task<List<LinkRoleMenuPermission>> GetPermissionWithMenu(int id)
        {
            //    var query = "Select pd.Medicine_Id, m.Medicine_Name,pd.Batch_No,pd.Quantity,pd.Buying_Price, m.Selling_Price,pd.Expiry_Date, pd.Total_Price " +
            //" from Purchase_Detail_tbl pd, MedicineInfo m " +
            //" where m.Medicine_Id = pd.Medicine_Id And pd.Purchase_Master_Id=" + id + " Order By pd.Medicine_Id ";
            //"and Convert(date,m.expiry_date,103) < Convert(date,'" + currentDate + "',103)";
            //var query = "Select m.id,m.name,m.url,rm.roles_id,p.Id,p.Name,rp.PermissionId,rp.IsSelected From menus m, link_roles_menus rm, Permission p, RoleWisePermission rp "+
            //    " Where m.id = rm.menus_id "+
            //    " And rp.PermissionId = p.Id "; 
            var query = "Select m.id MenuId,m.name MenuName, m.url,rm.roles_id From menus m, link_roles_menus rm Where m.id = rm.menus_id And rm.roles_id = " + id + "";
            //var query = "Select m.id, rp.MenuId,m.name MenuName, m.url, rp.ViewPermission,rp.CreatePermission,rp.UpdatePermission,rp.DeletePermission From RoleWisePermission rp, menus m Where m.id = rp.MenuId And rp.RoleId = "+ id + "";
            using (var connection = new SqlConnection(_connectionString))
            {
                List<LinkRoleMenuPermission> items = new List<LinkRoleMenuPermission>();
                //var model = new PurchaseDetailModel();
                connection.Open();
                var result = await connection.QueryAsync<LinkRoleMenuPermission>(query);
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
                        model.EditPermission = item.EditPermission;
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

        public async Task<List<LinkRoleMenuPermission>> GetPermissionWithRoleId(int id)
        {
            //    var query = "Select pd.Medicine_Id, m.Medicine_Name,pd.Batch_No,pd.Quantity,pd.Buying_Price, m.Selling_Price,pd.Expiry_Date, pd.Total_Price " +
            //" from Purchase_Detail_tbl pd, MedicineInfo m " +
            //" where m.Medicine_Id = pd.Medicine_Id And pd.Purchase_Master_Id=" + id + " Order By pd.Medicine_Id ";
            //"and Convert(date,m.expiry_date,103) < Convert(date,'" + currentDate + "',103)";
            //var query = "Select m.id,m.name,m.url,rm.roles_id,p.Id,p.Name,rp.PermissionId,rp.IsSelected From menus m, link_roles_menus rm, Permission p, RoleWisePermission rp "+
            //    " Where m.id = rm.menus_id "+
            //    " And rp.PermissionId = p.Id "; 
            //var query = "Select m.id MenuId,m.name MenuName, m.url,rm.roles_id From menus m, link_roles_menus rm Where m.id = rm.menus_id And rm.roles_id = "+id+"";
            var query = "Select m.id, rp.MenuId,m.name MenuName, m.url, rp.ViewPermission,rp.CreatePermission,rp.UpdatePermission EditPermission,rp.DeletePermission From RoleWisePermission rp, menus m Where m.id = rp.MenuId And rp.RoleId = " + id + "";
            using (var connection = new SqlConnection(_connectionString))
            {
                List<LinkRoleMenuPermission> items = new List<LinkRoleMenuPermission>();
                //var model = new PurchaseDetailModel();
                connection.Open();
                var result = await connection.QueryAsync<LinkRoleMenuPermission>(query);
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





        // GET: Roles/Create
        [AuthorizedAction]
        public IActionResult Create()
        {
            return View();
        }

        [AuthorizedAction]
        public IActionResult Create1()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create( Roles roles)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(roles);
                await _rolesInfo.CreateRoles(roles);
                return RedirectToAction(nameof(Index));
            }
            //return View(roles);
            return Json(roles);
        }


        // GET: Roles/Edit/5
        public async Task<IActionResult> EditPermission(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var roles = await _context.Roles.SingleOrDefaultAsync(m => m.Id == id);
            var roles = await _rolesInfo.GetRoleById(id);
            if (roles == null)
            {
                return NotFound();
            }

            //DataSet ds = new DataSet();
            ////List<string> menus_id = _context.LinkRolesMenus.Where(s => s.RolesId == id).Select(s => s.MenusId.ToString()).ToList();
            //List<string> menus_id = await _rolesInfo.GetRoleWiseMenu(id);
            //List<Menus> menus = await _rolesInfo.GetMenus();

            //ds = ToDataSet(menus);
            //DataTable table = ds.Tables[0];
            //DataRow[] parentMenus = table.Select("ParentId = 0");

            //var sb = new StringBuilder();
            //string unorderedList = GenerateUL(parentMenus, table, sb, menus_id);
            //ViewBag.menu = unorderedList;

            return View(roles);
        }


        [HttpPost]
        public async Task<IActionResult> EditPermission(int id, Roles roles)
        {

            if (ModelState.IsValid)
            {
                //_context.Add(roles);
                await _rolesInfo.DeletePermisionWithRoleIdAsync(id);
                await _rolesInfo.UpdateRoleWithPermission(id,roles);
                //return RedirectToAction(nameof(Index));
            }
            //return View(roles);
            return Json(roles);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var roles = await _context.Roles.SingleOrDefaultAsync(m => m.Id == id);
            var roles = await _rolesInfo.GetRoleById(id);
            if (roles == null)
            {
                return NotFound();
            }

            DataSet ds = new DataSet();
            //List<string> menus_id = _context.LinkRolesMenus.Where(s => s.RolesId == id).Select(s => s.MenusId.ToString()).ToList();
            List<string> menus_id = await _rolesInfo.GetRoleWiseMenu(id);
            List<Menus> menus = await _rolesInfo.GetMenus();

            ds = ToDataSet(menus);
            DataTable table = ds.Tables[0];
            DataRow[] parentMenus = table.Select("ParentId = 0");

            var sb = new StringBuilder();
            string unorderedList = GenerateUL(parentMenus, table, sb, menus_id);
            ViewBag.menu = unorderedList;

            return View(roles);
        }



        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Roles roles)
        {
            if (id != roles.Roles_Master_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roles);
                    await _context.SaveChangesAsync();
                    //await _rolesInfo.UpdateRole(roles);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesExists(roles.Roles_Master_Id))
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
            return View(roles);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = await _context.Roles
                .SingleOrDefaultAsync(m => m.Roles_Master_Id == id);
            if (roles == null)
            {
                return NotFound();
            }

            return View(roles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            foreach (var role in _context.LinkRolesMenus.Where(s => s.RolesId == id))
            {
                _context.LinkRolesMenus.Remove(role);
            }
            await _context.SaveChangesAsync();

            var roles = await _context.Roles.SingleOrDefaultAsync(m => m.Roles_Master_Id == id);
            _context.Roles.Remove(roles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id, List<int> roles)
        {
            //var temp = _context.LinkRolesMenus.Where(s => s.RolesId == id);
            List<LinkRolesMenus> temp = await _rolesInfo.GetLinkMenuByRole(id);
            foreach (var item in temp)
            {
                 //_context.LinkRolesMenus.Remove(item);
                _rolesInfo.DeleteAsync(item);
            }

            foreach (var role in roles)
            {
                _rolesInfo.AddAsync(role,id);
                //_context.LinkRolesMenus.Add(new LinkRolesMenus { MenusId = role, RolesId = id });
            }

            _context.SaveChanges();

            return Json(new { status = true, message = "Successfully Updated Role!" });
        }

        private bool RolesExists(int id)
        {
            return _context.Roles.Any(e => e.Roles_Master_Id == id);
        }


        private string GenerateUL(DataRow[] menu, DataTable table, StringBuilder sb, List<string> menus_id)
        {
            if (menu.Length > 0)
            {
                foreach (DataRow dr in menu)
                {
                    string id = dr["id"].ToString();
                    string handler = dr["url"].ToString();
                    string menuText = dr["name"].ToString();
                    string icon = dr["icon"].ToString();

                    string pid = dr["id"].ToString();
                    string parentId = dr["ParentId"].ToString();

                    string status = (menus_id.Contains(id)) ? "Checked" : "";

                    DataRow[] subMenu = table.Select(String.Format("ParentId = '{0}'", pid));
                    if (subMenu.Length > 0 && !pid.Equals(parentId))
                    {
                        string line = String.Format(@"<li class=""has""><input type=""checkbox"" name=""subdomain[]"" id=""{5}"" value=""{1}"" {4}><label>> {1}</label>", handler, menuText, icon, "target", status, id);
                        sb.Append(line);

                        var subMenuBuilder = new StringBuilder();
                        sb.AppendLine(String.Format(@"<ul>"));
                        sb.Append(GenerateUL(subMenu, table, subMenuBuilder, menus_id));
                        sb.Append("</ul>");
                    }
                    else
                    {
                        string line = String.Format(@"<li class=""""><input type=""checkbox"" name=""subdomain[]"" id=""{5}"" value=""{1}"" {4}><label>{1}</label>", handler, menuText, icon, "target", status, id);
                        sb.Append(line);
                    }
                    sb.Append("</li>");
                }
            }
            return sb.ToString();
        }

        public DataSet ToDataSet<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dataTable);
            return ds;
        }
    }
}
