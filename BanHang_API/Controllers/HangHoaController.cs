using BanHang_API.Connect;
using BanHang_API.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
            try
            {
                HangHoa_DTO mysqlGet = new HangHoa_DTO();
                return mysqlGet.getHangHoa();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/HangHoa/5
        [HttpGet("{id}")]
        public ActionResult<HangHoa> Get(int id)
        {
            try
            {
                HangHoa_DTO mysqlGet = new HangHoa_DTO();
                return mysqlGet.getHangHoa(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/HangHoa
        [HttpPost]
        public string Post(HangHoa hh)
        {
            try
            {
                HangHoa_DTO mysqlGet = new HangHoa_DTO();
                return mysqlGet.addHangHoa(hh) == 0 ? "Không thành công" : "Thành công";
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }

        // PUT api/HangHoa/5
        [HttpPut("{id}")]
        public string Put(HangHoa hh)
        {
            try
            {
                HangHoa_DTO mysqlGet = new HangHoa_DTO();
                return mysqlGet.editHangHoa(hh) == 0 ? "Không thành công" : "Thành công";
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }

        // DELETE api/HangHoa/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                HangHoa_DTO mysqlGet = new HangHoa_DTO();
                return mysqlGet.delHangHoa(id) == 0 ? "Không thành công" : "Thành công";
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }
    }
}