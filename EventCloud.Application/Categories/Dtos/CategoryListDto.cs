using EventCloud.Creatives;
using System.Collections.Generic;

namespace EventCloud.Categories
{
    public class CategoryListDto
    {
        public virtual string Name { get; set; }
        public virtual IList<Creative> Creatives { get; set; }
        public virtual string Url { get; set; }
    }
}