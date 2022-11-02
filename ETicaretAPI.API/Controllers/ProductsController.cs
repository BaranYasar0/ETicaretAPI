using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id=Guid.NewGuid(),Stock=2,Name="pro 1",CreatedDate=DateTime.Now,Price=123},
                new(){Id=Guid.NewGuid(),Stock=32,Name="pro 2",CreatedDate=DateTime.Now,Price=1234},
                new(){Id=Guid.NewGuid(),Stock=21,Name="pro 3",CreatedDate=DateTime.Now,Price=1233},

            });
            var count=await _productWriteRepository.SaveAsync();
        }

    }
}
