using GestionTallerDeMotos.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Controllers
{
    [Authorize(Roles = RoleName.Administrador)]
    public class RolController : Controller
    {
        private ApplicationDbContext _context;

        public RolController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Rol
        public ActionResult Index()
        {
            var roles = _context.Roles.ToList();

            return View("ListaDeRoles", roles);
        }

        /// <summary>
        /// Create  a New role
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var rol = new IdentityRole();

            return View(rol);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            _context.Roles.Add(Role);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /Roles/Edit/5
        public ActionResult Edit(string roleName)
        {
            var thisRole = _context.Roles
                .Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase))
                .FirstOrDefault();

            return View(thisRole);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole role)
        {
            try
            {
                _context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string RoleName)
        {
            var thisRole = _context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            _context.Roles.Remove(thisRole);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ManageUserRoles()
        {
            var list = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var usrMgr = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var account = new AccountController(usrMgr);
            account.UserManager.AddToRole(user.Id, RoleName);

            ViewBag.ResultMessage = "Role created successfully !";

            // prepopulat roles for the view dropdown
            var list = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var usrMgr = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

                var account = new AccountController(usrMgr);

                ViewBag.RolesForThisUser = account.UserManager.GetRoles(user.Id);

                // prepopulat roles for the view dropdown
                var list = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;
            }

            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            if (string.IsNullOrEmpty(RoleName))
            {
                ViewBag.ResultMessage = "Debe seleccionar un rol";
                return View("ManageUserRoles");
            }
            if (string.IsNullOrEmpty(UserName))
            {
                ViewBag.ResultMessage = "Debe seleccionar un usuario";
                return View("ManageUserRoles");
            }
            var usrMgr = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var account = new AccountController(usrMgr);
            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (account.UserManager.IsInRole(user.Id, RoleName))
            {
                account.UserManager.RemoveFromRole(user.Id, RoleName);
                ViewBag.ResultMessage = "Role removed from this user successfully !";
            }
            else
            {
                ViewBag.ResultMessage = "This user doesn't belong to selected role.";
            }
            // prepopulat roles for the view dropdown
            var list = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return View("ManageUserRoles");
        }
    }
}