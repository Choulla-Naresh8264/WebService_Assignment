namespace CA2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CA2.Models;

    // this configuration class allows us to seed the database with pre-existing data 
    // more info here: https://blog.safaribooksonline.com/2013/05/20/entity-framework-using-database-migration-to-seed-our-database/

    // The 'Update-Database' command must be called in the Package Manager Console to execute the migration code.
    internal sealed class Configuration : DbMigrationsConfiguration<CA2.Models.CA2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CA2.Models.CA2Context context)
        {
            context.Bands.AddOrUpdate(x => x.Id,
                new Band() { Id = 1, Name = "The Doors" },
                new Band() { Id = 2, Name = "The Cranberries" },
                new Band() { Id = 3, Name = "The Frames" },
                new Band() { Id = 4, Name = "Shadows and Dust" }
                );
            context.Concerts.AddOrUpdate(x => x.Id,
                new Concert()
                {
                    Id = 1,
                    Name = "Wheelans",
                    Date = 010815,
                    Price = 14,
                    Genre = "Rock",
                    BandId = 1
                },
                new Concert()
                {
                    Id = 2,
                    Name = "Sweeneys",
                    Date = 120715,
                    Price = 12,
                    Genre = "Jazz",
                    BandId = 3
                },
                new Concert()
                {
                    Id = 3,
                    Name = "Wheelans",
                    Date = 090915,
                    Price = 19,
                    Genre = "Indie",
                    BandId = 2
                },
                new Concert()
                {
                    Id = 4,
                    Name = "The3Arena",
                    Date = 080715,
                    Price = 1,
                    Genre = "Punk",
                    BandId = 4
                });
         }
    }
}
