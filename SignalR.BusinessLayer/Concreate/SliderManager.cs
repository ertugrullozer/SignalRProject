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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void Tadd(Slider entity)
        {
            throw new NotImplementedException();
        }

        public void Tdelete(Slider entity)
        {
            throw new NotImplementedException();
        }

        public Slider TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Slider> TGetListAll()
        {
            return _sliderDal.GetListAll();
        }

        public void Tupdate(Slider entity)
        {
            throw new NotImplementedException();
        }
    }
}
