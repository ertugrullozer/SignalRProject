using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult>Index()
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7035/api/Product/ProductListWithCategory");
			if (responseMessage.IsSuccessStatusCode) 
			{ 
				var jsonData= await responseMessage.Content.ReadAsStringAsync();
				var values= JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateProduct()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDtos createProductDtos)
		{
			createProductDtos.ProductStatus = true;
			var client =_httpClientFactory.CreateClient();
			var jsonData= JsonConvert.SerializeObject(createProductDtos);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage= await client.PostAsync("https://localhost:7035/api/Product/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
				return View();
		}
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7035/api/Product/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateProduct(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7035/api/Product/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData= await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductDtos>(jsonData);
				return View(values);
			}
			 
			return View();
		}
		[HttpPost]
		public async Task<IActionResult>UpdateProduct(UpdateProductDtos updateProductDtos)
		{
			var client= _httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(updateProductDtos);
			StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage= await client.PutAsync("https://localhost:7035/api/Product/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}

		

	}
}
