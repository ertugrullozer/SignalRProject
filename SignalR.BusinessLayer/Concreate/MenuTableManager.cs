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
    public class MenuTableManager : IMenuTableService
    {
        private readonly IMenuTableDal _menuTableDal;

        public MenuTableManager(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;
        }

        public int TActiveMenuTableCount()
        {
         return  _menuTableDal.ActiveMenuTableCount();
        }

        public void Tadd(MenuTable entity)
        {
            throw new NotImplementedException();
        }

        public void Tdelete(MenuTable entity)
        {
            throw new NotImplementedException();
        }

        public MenuTable TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<MenuTable> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public int TMenuTableCount()
        {
           return _menuTableDal.MenuTableCount();
        }

        public void Tupdate(MenuTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
