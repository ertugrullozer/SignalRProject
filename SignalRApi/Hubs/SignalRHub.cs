using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		SignalRContext context= new SignalRContext();
		public async Task SendCAtegoryCount()
		{
			var value = context.Categories.Count();
			await Clients.All.SendAsync("ReciveCategoryCount",value);
		}

	}
}
