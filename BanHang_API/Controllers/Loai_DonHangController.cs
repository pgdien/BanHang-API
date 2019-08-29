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
        public string Post(CT_DonHang ct_DH)
        {
            try
            {
                CT_DonHang_DTO mysqlGet = new CT_DonHang_DTO();
                return mysqlGet.addCT_DonHang(ct_DH) == 0 ? "Không thành công" : "Thành công";
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }

        // PUT api/Loai_DonHang/5
        [HttpPut("{id}")]
        public string Put(CT_DonHang ct_DH)
        {
            try
            {
                CT_DonHang_DTO mysqlGet = new CT_DonHang_DTO();
                return mysqlGet.editCT_DonHang(ct_DH) == 0 ? "Không thành công" : "Thành công";
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }

        // DELETE api/Loai_DonHang/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                CT_DonHang_DTO mysqlGet = new CT_DonHang_DTO();
                return mysqlGet.delCT_DonHang(id) == 0 ? "Không thành công" : "Thành công";
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }
    }
}