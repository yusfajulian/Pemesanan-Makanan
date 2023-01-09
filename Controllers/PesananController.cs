using ApiPemesanan.Data;
using ApiPemesanan.Models;
using ApiPemesanan.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPemesanan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesananController : ControllerBase
    {
        private readonly IRepository _Repo;
        private Respon _balikan = new();
        private object _respon;

        public PesananController(IRepository akunRepo)
        {
            _Repo = akunRepo;
        }

        [Route("pesanan")]
        [HttpGet]
        public async Task<IActionResult> GetPesanan()
        {
            try
            {
                var pesanan = await _Repo.GetPesanan();
                _respon = _balikan.buatResponGet(_balikan.CodeOk, pesanan);
                return Ok(_respon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("createpesanan")]
        [HttpPost]
        public async Task<IActionResult> CreatePesanan(CreatePesanan pesanan)
        {
            try
            {
                await _Repo.CreatePesanan(pesanan);

                _respon = _balikan.buatResponApi(_balikan.CodeOk, _balikan.SuksesDaftar());
                return Ok(_respon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
