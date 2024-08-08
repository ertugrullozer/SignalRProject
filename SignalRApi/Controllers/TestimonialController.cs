using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService,IMapper mapper) 
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult TestimonialList() 
        {
            var values= _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto) 
        {
            _testimonialService.Tadd(new Testimonial()
            {
                Title=createTestimonialDto.Title,
                Comment=createTestimonialDto.Comment,
                ImageUrl=createTestimonialDto.ImageUrl,
                Name=createTestimonialDto.Name,
                Status=createTestimonialDto.Status
            });
            return Ok("Testimonial Eklendi");
        
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id) 
        {
            var values= _testimonialService.TGetByID(id);
            _testimonialService.Tdelete(values);
            return Ok("Testimonial Silindi");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.Tupdate(new Testimonial()
            {
                TestimonialID=updateTestimonialDto.TestimonialID,
                Title = updateTestimonialDto.Title,
                Comment = updateTestimonialDto.Comment,
                Name = updateTestimonialDto.Name,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Status = updateTestimonialDto.Status

            });
            return Ok("Testimonial Güncellendi");

        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            return Ok(values);
        }

    }
}
