using Abp.Application.Services.Dto;

namespace EventCloud.Application
{
    public class RateInput : IInputDto
    {
        public double Value { get; set; }
        public int UserBy { get; set; }

        public int CreativeId { get; set; }
    }
}