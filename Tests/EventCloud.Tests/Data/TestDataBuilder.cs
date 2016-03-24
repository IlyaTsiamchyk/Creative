using System.Linq;
using Abp.Timing;
using EventCloud.EntityFramework;
using EventCloud.Events;
using EventCloud.MultiTenancy;
using System;
using EventCloud.Core.Entities;
using EventCloud.Creatives;
using System.Collections.Generic;
using System.Data.Entity;

namespace EventCloud.Tests.Data
{
    public class TestDataBuilder
    {
        public const string TestEventTitle = "Test event title";
        public readonly long AdminId = 1;

        private readonly EventCloudDbContext _context;

        public TestDataBuilder(EventCloudDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateTestEvent();
            CreateTestCreatives();
        }

        private void CreateTestEvent()
        {
            var defaultTenant = _context.Tenants.Single(t => t.TenancyName == Tenant.DefaultTenantName);
            _context.Events.Add(Event.Create(defaultTenant.Id, TestEventTitle, Clock.Now.AddDays(1)));
            _context.SaveChanges();
        }

        private void CreateTestCreatives()
        {
            for (int i = 1; i <= 5; i++)
            {
                var tags = GetTagsAndFillContext();
                var category = new Category { Name = "Fantasy" };
                var creative = new Creative { CreationTime = Clock.Now, Category = category, Tags = tags, UserId = AdminId };
                
                _context.Categories.Add(category);

                _context.Creatives.Add(creative);
            }

            _context.SaveChanges();
        }

        private List<Tag> GetTagsAndFillContext()
        {
            var tags = new List<Tag>();

            for (int j = 1; j <= 3; j++)
            {
                var tag = new Tag { Name = j + " tag" };

                _context.Tags.Add(tag);

                tags.Add(tag);
            }

            return tags;
        }
    }
}