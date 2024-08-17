﻿using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
        public SignalRHub(ICategoryService categoryService,IProductService productService,IOrderService orderService,IMoneyCaseService moneyCaseService,IMenuTableService menuTableService)
        {
            _categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
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

			var value13 = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("ReciveLastOrderPrice", value13.ToString("0.00") + "₺");

			var value14=_moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReciveTotalMoneyCaseAmount", value14.ToString("0.00") + "₺");

			//16 daha sonra eklenecek

			var value16 = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReciveMenuTableCount", value16);
		}
		
		public async Task SendProgress()
		{
			var value = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReciveTotalMoneyCaseAmount", value.ToString("0.00")+"₺");

			var value2 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReciveActiveOrderCount", value2);
			
			var value3= _menuTableService.TActiveMenuTableCount();
			await Clients.All.SendAsync("ReciveActiveMenuTableCount", value3);
		}

	}
}
