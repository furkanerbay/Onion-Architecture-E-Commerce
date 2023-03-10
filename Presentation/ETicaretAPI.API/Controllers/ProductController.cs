using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IOrderWriteRepository orderWriteRepository,
            ICustomerWriteRepository customerWriteRepository,
            IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        [HttpGet()]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //new(){Id = Guid.NewGuid(),Name = "Product 1",Price = 100,CreatedDate = DateTime.UtcNow,Stock = 10},
            //new(){Id = Guid.NewGuid(),Name = "Product 1",Price = 100,CreatedDate = DateTime.UtcNow,Stock = 10},
            //});
            //await _productWriteRepository.SaveAsync();

            //await _productWriteRepository.AddAsync(new() { Name = "C Product", Price = 1.500F, Stock = 10 });

            //await _productWriteRepository.SaveAsync();

            //var customerId = Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Muhittin" });

            //await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla", Address = "Ankara/Çankaya",CustomerId = customerId });
            //await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla 2", Address = "Ankara/Pursaklar" , CustomerId = customerId});
            //await _orderWriteRepository.SaveAsync();


            Order order = await _orderReadRepository.GetByIdAsync("75070da5-c343-46a4-83b3-2baefb43a4f0");
            order.Address = "Istanbul";
            await _orderWriteRepository.SaveAsync();
        }

        

    }
}
