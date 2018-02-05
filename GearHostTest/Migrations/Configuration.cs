namespace GearHostTest.Migrations
{
    using GearHostTest.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GearHostTest.Models.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;


        }

        protected override void Seed(GearHostTest.Models.UserContext context)
        {
            //  This method will be called after migrating to the latest version.
            if(context.Users.Count() == 0)
            {
                User user = new User();
                user.Name = "ZAFIRON";
                user.Pass = "QWErty";
                context.Users.AddOrUpdate(user);
            }
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
