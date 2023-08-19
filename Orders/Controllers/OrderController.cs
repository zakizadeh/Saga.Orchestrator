using Microsoft.AspNetCore.Mvc;

namespace Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
       public OrderController(IHttpClientFactory httpClientFactory) {
            HttpClientFactory = httpClientFactory;
        }

        public IHttpClientFactory HttpClientFactory { get; }

        [HttpPost]
        public int Post([FromBody] Order order)
        {
            var orderClient = HttpClientFactory.CreateClient("Order");

            return 1;
          //  return new OrderResponse { OrderId = 10 };
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine($"Deleted order :{id}");
        }

    }
}
