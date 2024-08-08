using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookinService;

        public BookingController(IBookingService bookinService)
        {
            _bookinService = bookinService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values=_bookinService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Mail = createBookingDto.Mail,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone,
                Date = createBookingDto.Date
            };
            _bookinService.Tadd(booking);
            return Ok("Rezervasyon Yapıldı");
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var values=_bookinService.TGetByID(id);
            _bookinService.Tdelete(values);
            return Ok("Rezervasyon Silindi");
        }
        [HttpPut]
        public  IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingID=updateBookingDto.BookingID,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone,
                Date = updateBookingDto.Date
            };
            _bookinService.Tupdate(booking);
            return Ok("Rezervasyon Güncellendi");
        }
        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id) 
        {

            var values = _bookinService.TGetByID(id);
            return Ok(values);
        }
    }
}
