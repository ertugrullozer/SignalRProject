﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concreate
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public int TActiveOrderCount()
        {
           return _orderDal.ActiveOrderCount();
        }

        public void Tadd(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Tdelete(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public int TTotalOrderCount()
        {
           return _orderDal.TotalOrderCount();
        }

        public void Tupdate(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}