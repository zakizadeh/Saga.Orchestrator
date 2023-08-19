using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        public IHttpClientFactory HttpClientFactory { get; }

        public InventoryController(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }
        [HttpPost]
        public int Post([FromBody] Inventory inventory)
        {
            throw new Exception("error in creating order");
            var orderClient = HttpClientFactory.CreateClient("Inventory");

            Console.WriteLine($"Updated inventory for:{ inventory.ProductName}");
            return 2;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine($"Deleted inventory :{id}");
        }


       
    }
}
