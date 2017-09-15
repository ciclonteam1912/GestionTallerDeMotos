using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionTallerDeMotos.Models
{
    public class IdentityManager
    {
        RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        public bool RoleExists(string name)
        {
            return roleManager.RoleExists(name);
        }
    }
}