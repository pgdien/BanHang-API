using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanHang_API.Connect;
using BanHang_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace BanHang_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : Controller
    {
        // GET api/HangHoa
        [HttpGet]
        public ActionResult<IEnumerable<HangHoa>> Get()
        {
            HangHoa_DTO mysqlGet = new HangHoa_DTO();
            return mysqlGet.getHangHoa();
        }

        // GET api/HangHoa/5
        [HttpGet("{id}")]
        public ActionResult<HangHoa> Get(int id)
        {
            HangHoa_DTO mysqlGet = new HangHoa_DTO();
            return mysqlGet.getHangHoa(id);
        }

        // POST api/HangHoa
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/HangHoa/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/HangHoa/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}