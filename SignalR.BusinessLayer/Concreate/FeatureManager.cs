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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureService;

        public FeatureManager(IFeatureDal featureService)
        {
            _featureService = featureService;
        }

        public void Tadd(Feature entity)
        {
            _featureService.Add(entity);
        }

        public void Tdelete(Feature entity)
        {
           _featureService.Delete(entity);
        }

        public Feature TGetByID(int id)
        {
            return _featureService.GetByID(id);
        }

        public List<Feature> TGetListAll()
        {
           return _featureService.GetListAll();
        }

        public void Tupdate(Feature entity)
        {
          _featureService.Update(entity);
    }
}
