using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concreate
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;
        public DiscountManager(IDiscountDal discountDal) 
        { 
            _discountDal = discountDal;
        }
        public void Tadd(Discount entity)
        {
           _discountDal.Add(entity);
        }

        public void Tdelete(Discount entity)
        {
           _discountDal.Delete(entity);
        }

        public Discount TGetByID(int id)
        {
            return _discountDal.GetByID(id);
        }

        public List<Discount> TGetListAll()
        {
            return _discountDal.GetListAll();
        }

        public void Tupdate(Discount entity)
        {
           _discountDal.Update(entity);
        }
    }
}
