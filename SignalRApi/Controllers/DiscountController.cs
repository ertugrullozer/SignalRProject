using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscontDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountController(IDiscountService discountService,IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList() 
        {
            var values= _mapper.Map<List<ResultDiscontDto>>(_discountService.TGetListAll());
            return Ok(values);
        
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.Tadd(new Discount()
            {
                Amount = createDiscountDto.Amount,
                Description = createDiscountDto.Description,
                Title = createDiscountDto.Title,
                ImageUrl = createDiscountDto.ImageUrl
            });
            return Ok("Discount Eklendi");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var values =_discountService.TGetByID(id);
            _discountService.Tdelete(values);
            return Ok("Discount Silindi");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.Tupdate(new Discount()
            {
                DiscountID=updateDiscountDto.DiscountID,
                Amount = updateDiscountDto.Amount,
                Description = updateDiscountDto.Description,
                Title = updateDiscountDto.Title,
                ImageUrl = updateDiscountDto.ImageUrl

            });
            return Ok("Discount Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var values= _discountService.TGetByID(id);
            return Ok(values);
        }
    }

}
