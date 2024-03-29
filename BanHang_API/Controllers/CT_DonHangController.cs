﻿using BanHang_API.Connect;
using BanHang_API.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        [HttpGet("test")]
        public void test()
        {
            try
            {
                CT_DonHang_DTO mysqlGet = new CT_DonHang_DTO();
                mysqlGet.testTransaction();
            }
            catch (Exception ex)
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

        // GET api/CT_DonHang/5
        [HttpGet("for_hd/{id}")]
        public ActionResult<IEnumerable<CT_DonHang>> Get(string id)
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

        // PUT api/CT_DonHang/5
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

        // DELETE api/CT_DonHang/5
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