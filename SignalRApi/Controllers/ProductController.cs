using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    { 
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());

            return Ok(value);

        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.Tadd(new Product()
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price   = createProductDto.Price,
                ProductName = createProductDto.ProductName,
                ProductStatus = createProductDto.ProductStatus,
                CategoryID = createProductDto.CategoryID,
                

            });
            
            return Ok("Product Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var values =_productService.TGetByID(id);
            _productService.Tdelete(values);
            return Ok("Product Silindi");
        }


		[HttpGet("{id}")]
		public IActionResult GetProduct(int id)
		{
			var value = _productService.TGetByID(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
		{
			_productService.Tupdate(new Product()
			{
				Description = updateProductDto.Description,
				ImageUrl = updateProductDto.ImageUrl,
				Price = updateProductDto.Price,
				ProductName = updateProductDto.ProductName,
				ProductStatus = updateProductDto.ProductStatus,
				ProductID = updateProductDto.ProductID,
				CategoryID = updateProductDto.CategoryID
			});
			return Ok("Ürün Bilgisi Güncellendi");
			
        }
        [HttpGet("ProductCount")]
        public IActionResult TProductCount()
        {
            return Ok(_productService.TProductCount());
        }
        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByHamburger()
        {
            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }
        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByDrink()
        {
            return Ok(_productService.TProductCountByCategoryNameDrink());
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }
        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            return Ok(_productService.TProductNameByMaxPrice());
        }

        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            return Ok(_productService.TProductNameByMinPrice());
        }

        [HttpGet("ProductAvgPriceByHomburger")]
        public IActionResult ProductAvgPriceByHomburger()
        {
            return Ok(_productService.TProductAvgPriceByHomburger());
        }


        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductsWithCategory
            {
                Description = y.Description,
                Price = y.Price,
                ImageUrl= y.ImageUrl,
                ProductID =y.ProductID,
                ProductStatus = y.ProductStatus,
                ProductName = y.ProductName,
                CategoryName = y.Category.CategoryName,
                

            });
            return Ok(values.ToList());
        }
    }
}
