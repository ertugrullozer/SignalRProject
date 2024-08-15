﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrder : GenericRepository<Order>, IOrderDal
    {
        public EfOrder(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context= new SignalRContext();
            return context.Orders.Where(x=>x.Description=="Müşteri Masada").Count();
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }
    }
}
