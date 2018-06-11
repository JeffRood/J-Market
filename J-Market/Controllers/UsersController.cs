﻿using J_Market.Models;
using J_Market.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace J_Market.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
       private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Users
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            //Lista de usuario
            var users = userManager.Users.ToList();

            //Usuario de la vista
            var usersView = new List<UserView>();

            foreach (var user in users)
            {
                var userView = new UserView
                {
               Email = user.Email,
               Name = user.UserName,
               UserID = user.Id
                };
                usersView.Add(userView);
                    
            }
            return View(usersView);
        }



        public ActionResult Roles(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var roles = roleManager.Roles.ToList();
            //Lista de usuario
            var users = userManager.Users.ToList();
            var user = users.Find( u => u.Id == userID);
            if (user == null)
            {
                return HttpNotFound();
            }
            var rolesView = new List<RoleView>();
          
                foreach (var item in user.Roles)
                {
                    var role = roles.Find(r => r.Id == item.RoleId);
                    var roleView = new RoleView
                    {
                        RoleID = role.Id,
                        Name = role.Name
                    };
                    rolesView.Add(roleView);
                }
        

            var userView = new UserView
            {
                Email = user.Email,
                Name = user.UserName,
                UserID = user.Id,
                Roles = rolesView
            };
           
            return View(userView);
        }

        public ActionResult AddRole(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
               //Lista de usuario
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == userID);
            if (user == null)
            {
                return HttpNotFound();
            }


            var userView = new UserView
            {
                Email = user.Email,
                Name = user.UserName,
                UserID = user.Id
               
            };
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var list = roleManager.Roles.ToList();
            list.Add(new IdentityRole{ Id = "", Name = "[Select a Role...]" });
            list = list.OrderBy(r => r.Name).ToList();
            ViewBag.RoleID = new SelectList(list, "Id", "Name");

            return View (userView);
        }

        [HttpPost]
        public ActionResult AddRole(string userID, FormCollection form)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var roleID = Request["RoleID"];
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            //Lista de usuario
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == userID);

            var userView = new UserView
            {
                Email = user.Email,
                Name = user.UserName,
                UserID = user.Id
            };
            if (string.IsNullOrEmpty(roleID))
            {
                ViewBag.Error = "You must Select a Role";
              
              
                var list = roleManager.Roles.ToList();
                list.Add(new IdentityRole { Id = "", Name = "[Select a Role...]" });
                list = list.OrderBy(r => r.Name).ToList();
                ViewBag.RoleID = new SelectList(list, "Id", "Name");

                return View(userView);
            }
            var roles = roleManager.Roles.ToList();
            var role = roles.Find(r => r.Id == roleID);
            if (!userManager.IsInRole(userID, role.Name))
            {
                userManager.AddToRole(userID, role.Name);
            }


            var rolesView = new List<RoleView>();

            foreach (var item in user.Roles)
            {
                role = roles.Find(r => r.Id == item.RoleId);
                var roleView = new RoleView
                {
                    RoleID = role.Id,
                    Name = role.Name
                };
                rolesView.Add(roleView);
            }


           userView = new UserView
            {
                Email = user.Email,
                Name = user.UserName,
                UserID = user.Id,
                Roles = rolesView
            };

            
            return View("Roles", userView);
        }



        public ActionResult Delete(string userID, string roleID)
        {
            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(roleID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.Users.ToList().Find(u => u.Id == userID); ;
            var role = roleManager.Roles.ToList().Find(r => r.Id == roleID); ;

            // Delete User From Role
            if (userManager.IsInRole(user.Id, role.Name))
            {
                userManager.RemoveFromRole(user.Id, role.Name);
            }


            // Prepare the view to return

            var users = userManager.Users.ToList();
            var roles = roleManager.Roles.ToList();
            var rolesView = new List<RoleView>();

            foreach (var item in user.Roles)
            {
                role = roles.Find(r => r.Id == item.RoleId);
                var roleView = new RoleView
                {
                    RoleID = role.Id,
                    Name = role.Name
                };
                rolesView.Add(roleView);
            }


            var userView = new UserView
            {
                Email = user.Email,
                Name = user.UserName,
                UserID = user.Id,
                Roles = rolesView
            };

            return View("Roles", userView);







        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}