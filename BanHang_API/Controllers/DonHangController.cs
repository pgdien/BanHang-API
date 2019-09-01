using BanHang_API.Connect;
using BanHang_API.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public string Post(DonHang dh)
        {
            try
            {
                DonHang_DTO mysqlGet = new DonHang_DTO();
                return mysqlGet.addDonHang(dh) == 0 ? "Không thành công" : "Thành công";
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }

        // PUT api/DonHang/5
        [HttpPut("{id}")]
        public string Put(DonHang dh)
        {
            try
            {
                DonHang_DTO mysqlGet = new DonHang_DTO();
                return mysqlGet.editDonHang(dh) == 0 ? "Không thành công" : "Thành công";
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }

        // DELETE api/DonHang/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                DonHang_DTO mysqlGet = new DonHang_DTO();
                return mysqlGet.delDonHang(id) == 0 ? "Không thành công" : "Thành công";
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }
    }
}