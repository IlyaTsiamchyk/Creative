using Abp.Application.Services.Dto;

namespace EventCloud.Creatives
{
    public class GetCreativeListInput : IInputDto
    {
        public int Id { get; set; }
    }
}