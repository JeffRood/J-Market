using J_Market.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace J_Market
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Activa la pruebas automaticas. el parametro migrationdatabasetolatestVersion
            // Resive 2 parametro la direccion del context y el archivo de configuracion de la migracion
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<
                Models.J_MarketContext,
                Migrations.Configuration>());

            ApplicationDbContext db = new ApplicationDbContext();
            CreateRole(db);
            CreateSuperUser(db);
            AddPermissionsToSuperUser(db);
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //Crear un super Usuario
        private void CreateSuperUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("jeffryrodriguez08@gmail.com");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "jeffryrodriguez08@gmail.com",
                    Email = "jeffryrodriguez08@gmail.com"
                };
                userManager.Create(user, "Jeffry123.");
            }

        }
        // Crear Roles
        private void CreateRole(ApplicationDbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if(!roleManager.RoleExists("View"))
            {
                roleManager.Create(new IdentityRole("View"));
            }
            if (!roleManager.RoleExists("Edit"))
            {
                roleManager.Create(new IdentityRole("Edit"));
            }
            if (!roleManager.RoleExists("Create"))
            {
                roleManager.Create(new IdentityRole("Create"));
            }
            if (!roleManager.RoleExists("Delete"))
            {
                roleManager.Create(new IdentityRole("Delete"));
            }
            if (!roleManager.RoleExists("Orders"))
            {
                roleManager.Create(new IdentityRole("Orders"));
            }
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }
            if (!roleManager.RoleExists("Inventories"))
            {
                roleManager.Create(new IdentityRole("Inventories"));
            }
            if (!roleManager.RoleExists("Shoppings"))
            {
                roleManager.Create(new IdentityRole("Shoppings"));
            }

        }
        // Solo darle permiso a un Usuario
        private void AddPermissionsToSuperUser(ApplicationDbContext db)
        {

         
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var user = userManager.FindByName("jeffryrodriguez08@gmail.com");
            // Pertenece a ese Role  P1=el ID del usuario y p2 = y el rol  
            if (!userManager.IsInRole(user.Id, "View"))
            {
                // addtorole me adiciona a un roll y el roles una lista de roles
                userManager.AddToRole(user.Id, "View");
            }
            if (!userManager.IsInRole(user.Id, "Create"))
            {
                // addtorole me adiciona a un roll y el roles una lista de roles
                userManager.AddToRole(user.Id, "Create");
            }
            if (!userManager.IsInRole(user.Id, "Edit"))
            {
                // addtorole me adiciona a un roll y el roles una lista de roles
                userManager.AddToRole(user.Id, "Edit");
            }
            if (!userManager.IsInRole(user.Id, "Delete"))
            {
                // addtorole me adiciona a un roll y el roles una lista de roles
                userManager.AddToRole(user.Id, "Delete");
            }
            if (!userManager.IsInRole(user.Id, "Orders"))
            {
                // addtorole me adiciona a un roll y el roles una lista de roles
                userManager.AddToRole(user.Id, "Orders");
            }
            if (!userManager.IsInRole(user.Id, "Admin"))
            {
                // addtorole me adiciona a un roll y el roles una lista de roles
                userManager.AddToRole(user.Id, "Admin");
            }
            if (!userManager.IsInRole(user.Id, "Inventories"))
            {
                // addtorole me adiciona a un roll y el roles una lista de roles
                userManager.AddToRole(user.Id, "Inventories");
            }
            if (!userManager.IsInRole(user.Id, "Shoppings"))
            {
                // addtorole me adiciona a un roll y el roles una lista de roles
                userManager.AddToRole(user.Id, "Shoppings");
            }

        }

    }
}
