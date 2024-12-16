using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDtos createBookingDtos)
        {
           
            var Client =_httpClientFactory.CreateClient();
            var JsonData=JsonConvert.SerializeObject(createBookingDtos);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var ResponseMessage = await Client.PostAsync("https://localhost:7035/api/Booking", stringContent);
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View();
        }
    }
}
