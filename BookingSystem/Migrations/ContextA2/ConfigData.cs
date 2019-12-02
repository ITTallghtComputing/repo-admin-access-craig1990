namespace BookingSystem.Migrations.ContextA2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigData : DbMigrationsConfiguration<BookingSystem.Models.RDSContext>
    {
        public ConfigData()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\ContextA2";
            ContextKey = "BookingSystem.Models.RDSContext";
        }

        protected override void Seed(BookingSystem.Models.RDSContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
