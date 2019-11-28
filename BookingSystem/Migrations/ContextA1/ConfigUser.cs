namespace BookingSystem.Migrations.ContextA1
{
    using BookingSystem.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigUser : DbMigrationsConfiguration<BookingSystem.Models.ApplicationDbContext>
    {
        public ConfigUser()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ContextA1";
            ContextKey = "BookingSystem.Models.ApplicationDbContext";
        }

        protected override void Seed(BookingSystem.Models.ApplicationDbContext context)
        {
            // makes an admin role if one doesn't exist
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };


                manager.Create(role);
            }

            // if user doesn't exist, create one and add it to the admin role
            if (!context.Users.Any(u => u.UserName == "user1"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "user1@test.com",
                    Email = "user1@test.com"
                };

                manager.Create(user, "password");
                manager.AddToRole(user.Id, "Admin");
            }
            if (!context.Users.Any(u => u.UserName == "user2"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "user2@test.com",
                    Email = "user2@test.com"
                };

                manager.Create(user, "password");
                manager.AddToRole(user.Id, "Admin");
            }
            if (!context.Users.Any(u => u.UserName == "user3"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "user3@test.com",
                    Email = "user3@test.com"
                };

                manager.Create(user, "password");
                manager.AddToRole(user.Id, "Admin");
            }


            context.SaveChanges();
        }
    }
}
