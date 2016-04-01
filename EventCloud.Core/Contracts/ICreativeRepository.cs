using Abp.Domain.Repositories;
using EventCloud.Core.Entities;
using EventCloud.Creatives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCloud.Contracts
{
    public interface ICreativeRepository : IRepository<Creative, int>
    {
        void AddRate(Rate rate);
        void AddChapter(Chapter chapter);
        void UpdateChapter(Chapter chapter);

    }
}
