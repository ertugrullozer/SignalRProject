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

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        [HttpGet]
        public IActionResult TestimonialList() 
        {
            var values= _testimonialService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto) 
        {
            Testimonial testimonial = new Testimonial()
            {
                Title = createTestimonialDto.Title,
                Comment = createTestimonialDto.Comment,
                Name = createTestimonialDto.Name,
                ImageUrl = createTestimonialDto.ImageUrl,
                Status = createTestimonialDto.Status
            };
            _testimonialService.Tadd(testimonial);
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
            Testimonial testimonial = new Testimonial()
            {
                Title = updateTestimonialDto.Title,
                Comment = updateTestimonialDto.Comment,
                Name = updateTestimonialDto.Name,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Status = updateTestimonialDto.Status

            };
            _testimonialService.Tupdate(testimonial);
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
