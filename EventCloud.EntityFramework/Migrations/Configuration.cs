namespace EventCloud.Migrations
{
    using Abp.Timing;
    using Core.Entities;
    using Creatives;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EventCloud.EntityFramework.EventCloudDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EventCloud.EntityFramework.EventCloudDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            CreateTestCreatives(context);
        }
        private void CreateTestCreatives(EventCloud.EntityFramework.EventCloudDbContext context)
        {
            for (int i = 1; i <= 5; i++)
            {
                var tags = GetTagsAndFillContext(context);
                var category = new Category { Name = "Fantasy" };
                var creative = new Creative { CreationTime = Clock.Now, Category = category, Tags = tags, UserId = 1 };

                context.Categories.Add(category);

                context.Creatives.Add(creative);
            }

            context.SaveChanges();
        }

        private List<Tag> GetTagsAndFillContext(EventCloud.EntityFramework.EventCloudDbContext context)
        {
            var tags = new List<Tag>();

            for (int j = 1; j <= 3; j++)
            {
                var tag = new Tag { Name = j + " tag" };

                context.Tags.Add(tag);

                tags.Add(tag);
            }

            return tags;
        }
    }
}
