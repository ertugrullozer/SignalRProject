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
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void Tadd(Basket entity)
        {
            throw new NotImplementedException();
        }

        public void Tdelete(Basket entity)
        {
            throw new NotImplementedException();
        }

        public List<Basket> TGetBasketByMenuTableNumber(int id)
        {
            return _basketDal.GetBasketMenuTableNumber(id);
        }

        public Basket TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Basket> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void Tupdate(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}