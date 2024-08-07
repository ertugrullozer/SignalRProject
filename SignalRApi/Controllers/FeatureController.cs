using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        [HttpGet]
        public IActionResult FeaturList() 
        {

            var values =_featureService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto) 
        {
            Feature feature = new Feature()
            {
                Title1 = createFeatureDto.Title1,
                Title2 = createFeatureDto.Title2,
                Title3 = createFeatureDto.Title3,
                Description1 = createFeatureDto.Description1,
                Description2 = createFeatureDto.Description2,
                Description3 = createFeatureDto.Description3

            };
            _featureService.Tadd(feature);
            return Ok("Feature Eklendi");
        
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var values=_featureService.TGetByID(id);
            _featureService.Tdelete(values);
            return Ok("Feature Silindi");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            Feature feature = new Feature()
            {
              Title1 = updateFeatureDto.Title1,
              Title2 = updateFeatureDto.Title2,
              Title3 = updateFeatureDto.Title3,
              Description1 = updateFeatureDto.Description1,
              Description2 = updateFeatureDto.Description2,
              Description3 = updateFeatureDto.Description3


            };
            _featureService.Tupdate(feature);
            return Ok("Feature Güncellendi");

        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var values = _featureService.TGetByID(id);
            return Ok(values);
        }

    }
  
    
}
