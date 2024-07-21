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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;
        public BookingManager (IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }
    
        public void Tadd(Booking entity)
        {
          _bookingDal.Add(entity);
        }

        public void Tdelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public Booking TGetByID(int id)
        {
          return _bookingDal.GetByID(id);
        }

        public List<Booking> TGetListAll()
        {
          return _bookingDal.GetListAll();
        }

        public void Tupdate(Booking entity)
        {
           _bookingDal.Update(entity);
        }
    }
}
