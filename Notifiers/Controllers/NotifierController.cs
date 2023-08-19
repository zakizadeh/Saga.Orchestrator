using Microsoft.AspNetCore.Mvc;

namespace Notifiers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifierController : Controller
    {

        [HttpPost]
        public int Post([FromBody] Notifier notifier)
        {
            Console.WriteLine($"Updated transaction for:{notifier.ProductName}");
            return 3;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine($"Sent rollback transaction notification :{id}");
        }


    }
}
