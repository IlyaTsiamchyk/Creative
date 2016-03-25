using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using EventCloud.Core.Entities;
using EventCloud.Tags;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EventCloud.Tags
{
    public class TagAppService : ITagAppService
    {
        private readonly IRepository<Tag, int> _tagRepository;

        public TagAppService(
            IRepository<Tag, int> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<Tag> Details(int id)
        {
            var tags = await _tagRepository.FirstOrDefaultAsync(id);

            if (tags == null)
            {
                throw new UserFriendlyException("Could not found the tags.");
            }

            return tags;
        }
    }
}