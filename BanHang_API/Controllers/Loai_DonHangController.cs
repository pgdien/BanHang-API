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
    public class Loai_DonHangController : Controller
    {
        // GET api/Loai_DonHang
        [HttpGet]
        public ActionResult<IEnumerable<Loai_DonHang>> Get()
        {
            try
            {
                Loai_DonHang_DTO mysqlGet = new Loai_DonHang_DTO();
                return mysqlGet.getLoai_DonHang();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/Loai_DonHang/5
        [HttpGet("{id}")]
        public ActionResult<Loai_DonHang> Get(int id)
        {
            try
            {
                Loai_DonHang_DTO mysqlGet = new Loai_DonHang_DTO();
                return mysqlGet.getLoai_DonHang(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/Loai_DonHang
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Loai_DonHang/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Loai_DonHang/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}