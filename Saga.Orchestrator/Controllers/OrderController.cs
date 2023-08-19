using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Saga.Orchestrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
       public OrderController(IHttpClientFactory httpClientFactory) {
            HttpClientFactory = httpClientFactory;
        }

        public IHttpClientFactory HttpClientFactory { get; }

        [HttpPost]
        public async Task<OrderResponse> Post([FromBody] Order order)
        {
            var request = JsonConvert.SerializeObject(order);
            //create order
            var orderClient = HttpClientFactory.CreateClient("Order");
            var orderRespose = await orderClient.PostAsync("/api/Order", new StringContent(request,Encoding.UTF8,"application/JSon"));
            var orderId = await orderRespose.Content.ReadAsStringAsync();

            string inventoryId = string.Empty;
            //Update inventory
            try
            {
                var inventoryClient = HttpClientFactory.CreateClient("Inventory");
                var inventoryRespose = await inventoryClient.PostAsync("/api/Inventory", new StringContent(request, Encoding.UTF8, "application/JSon"));
                if(inventoryRespose.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(inventoryRespose.ReasonPhrase);
                }
                inventoryId = await inventoryRespose.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                await orderClient.DeleteAsync($"/api/Order/{orderId}");
                return new OrderResponse { Success = false, Reason= ex.Message };

            }
            //Send notification
            var notifierClient = HttpClientFactory.CreateClient("Notifier");
            var notifierRespose = await notifierClient.PostAsync("/api/notifier", new StringContent(request, Encoding.UTF8, "application/JSon"));
            var notifierId = await notifierRespose.Content.ReadAsStringAsync();

            Console.WriteLine($"orderId:{orderId}, Inventory: {inventoryId}, Notifier : {notifierId}");

            return new OrderResponse { OrderId = orderId , Success = true};
        }
    }
}
