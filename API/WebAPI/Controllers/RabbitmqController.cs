

namespace WebAPI.Controllers
{
    using DTO;
    using Microsoft.AspNetCore.Mvc;
    using Util;

    [Route("api/[controller]")]
    [ApiController]
    public class RabbitmqController : ControllerBase
    {
         
        // POST api/values
        [HttpPost]
        public void Post([FromBody] ClientDTO client)
        {
            new RabbitmqUtil().SendSerialized(client);
        }
 
    }
}