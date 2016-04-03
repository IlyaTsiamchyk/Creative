﻿using EventCloud.Contracts;
using EventCloud.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventCloud.Core.Entities;
using System.Data.Entity;
using Abp.EntityFramework;
using EventCloud.Creatives;
using System.Data.Entity.Core;

namespace EventCloud.EntityFramework.Repositories
{
    public class CreativeRepository : EventCloudRepositoryBase<Creative, int>, ICreativeRepository
    {

        public CreativeRepository(IDbContextProvider<EventCloudDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public void AddChapter(Chapter chapter)
        {
            Context.Entry(chapter).State = System.Data.Entity.EntityState.Added;
            Context.SaveChanges();
        }

        public void AddRate(Rate rate)
        {
            Rate r = Context.Rates.Where(rt => rt.UserBy == rate.UserBy).FirstOrDefault<Rate>();

            if (r != null) throw new ArgumentException("You are already send your rating.");

            Context.Entry(rate).State = System.Data.Entity.EntityState.Added;
            Context.SaveChanges();
        }

        public void UpdateChapter(Chapter chapter)
        {
            if (chapter.Id != 0)
                Context.Entry<Chapter>(chapter).State = System.Data.Entity.EntityState.Modified;
            else
            {
                //Context.Entry<Chapter>(chapter).State = System.Data.Entity.EntityState.Added;
                Context.Chapters.Add(chapter);
            }

            Context.SaveChanges();      
        }
    }
}
