using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
        public SignalRHub(ICategoryService categoryService,IProductService productService,IOrderService orderService)
        {
            _categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
        }

		public async Task SendStatistic()
		{
			var value = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReciveCategoryCount", value);

			var value2 = _productService.TProductCount();
			await Clients.All.SendAsync("ReciveProductCount", value2);

			var value3 =_categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReciveActiveCategoryCount",value3);

			var value4= _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("RecivePasiveCategoryCount", value4);

			var value5 = _productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReciveProductCountByCategoryNameHamburger", value5);

			var value6=_productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReciveProductCountByCategoryNameDrink", value6);
			
			var value7=_productService.TProductPriceAvg();
			await Clients.All.SendAsync("ReciveProductPriceAvg", value7.ToString("0.00")+"₺");

			var value8=_productService.TProductNameByMaxPrice();
			await Clients.All.SendAsync("ReciveProductNameByMaxPrice", value8);

			var value9=_productService.TProductNameByMinPrice();
			await Clients.All.SendAsync("ReciveProductNameByMinPrice", value9);

			var value10=_productService.TProductAvgPriceByHomburger();
			await Clients.All.SendAsync("ReciveProductAvgPriceByHomburger", value10.ToString("0.00"+"₺"));

			var value11=_orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReciveActiveOrderCount", value11);

			var value12=_orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReciveTotalOrderCount", value12);
		}
		

	}
}
