

namespace WebAPI.Controllers
{
    using DTO;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Repository;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<DashboardDTO> Get()
        {
            DashboardDTO dashDTO = new DashboardDTO()
            {
                Kpis = new List<KPIs>(),
                Programs = new List<Models.Programs>(),
                Machines = new List<Models.Machine>()
            };

            MachineRepository repository = new MachineRepository();
            dashDTO.Kpis = (List<KPIs>)repository.SelectKPIs();
            dashDTO.Machines = (List<Machine>)repository.SelectTop10Machines();
            dashDTO.Programs = (List<Programs>)repository.SelectTop10Programs();

            return dashDTO;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}