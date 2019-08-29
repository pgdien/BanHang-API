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
    public class DonHangController : Controller
    {
        // GET api/DonHang
        [HttpGet]
        public ActionResult<IEnumerable<DonHang>> Get()
        {
            try
            {
                DonHang_DTO mysqlGet = new DonHang_DTO();
                return mysqlGet.getDonHang();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/DonHang/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<DonHang>> Get(int id)
        {
            try
            {
                DonHang_DTO mysqlGet = new DonHang_DTO();
                return mysqlGet.getDonHang();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/DonHang
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/DonHang/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/DonHang/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}