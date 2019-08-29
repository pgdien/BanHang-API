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
    public class KhachHangController : Controller
    {
        // GET api/KhachHang
        [HttpGet]
        public ActionResult<IEnumerable<KhachHang>> Get()
        {
            try
            {
                KhachHang_DTO mysqlGet = new KhachHang_DTO();
                return mysqlGet.getKhachHang();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/KhachHang/5
        [HttpGet("{id}")]
        public ActionResult<KhachHang> Get(int id)
        {
            try
            {
                KhachHang_DTO mysqlGet = new KhachHang_DTO();
                return mysqlGet.getKhachHang(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/KhachHang
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/KhachHang/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/KhachHang/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}