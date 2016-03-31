using Abp.Application.Services.Dto;

namespace EventCloud.Application
{
    public class ChapterInput : IInputDto
    {
        public int NumberOfChapter { get; set; }

        public int CreativeId { get; set; }
    }
}