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
    public class CT_DonHangController : Controller
    {
        // GET api/CT_DonHang
        [HttpGet]
        public ActionResult<IEnumerable<CT_DonHang>> Get()
        {
            try
            {
                CT_DonHang_DTO mysqlGet = new CT_DonHang_DTO();
                return mysqlGet.getCT_DonHang();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/CT_DonHang/5
        [HttpGet("{id}")]
        public ActionResult<CT_DonHang> Get(int id)
        {
            try
            {
                CT_DonHang_DTO mysqlGet = new CT_DonHang_DTO();
                return mysqlGet.getCT_DonHang(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST api/CT_DonHang
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/CT_DonHang/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/CT_DonHang/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}