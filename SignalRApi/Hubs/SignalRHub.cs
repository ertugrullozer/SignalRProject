using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
        public SignalRHub(ICategoryService categoryService,IProductService productService)
        {
            _categoryService = categoryService;
			_productService = productService;
        }

        public async Task SendCAtegoryCount()
		{
			var value = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReciveCategoryCount",value);
		}
		public async Task SendProductCount()
		{
			var value2 =_productService.TProductCount();
			await Clients.All.SendAsync("ReciveProductCount",value2);
		}

	}
}
