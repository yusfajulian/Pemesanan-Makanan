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
    [Route("api")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IRepository _akunRepo;
        private Respon _balikan = new();
        private object _respon;

        public MenuController(IRepository akunRepo)
        {
            _akunRepo = akunRepo;
        }

        [Route("allMenu")]
        [HttpGet]
        public async Task<IActionResult> GetMenus()
        {
            try
            {
                var menu = await _akunRepo.GetMenus();
                _respon = _balikan.buatResponGet(_balikan.CodeOk, menu);
                return Ok(_respon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("menuMakanan")]
        [HttpGet]
        public async Task<IActionResult> GetMakanan()
        {
            try
            {
                var menu = await _akunRepo.GetMenuMakanan();
                _respon = _balikan.buatResponGet(_balikan.CodeOk, menu);
                return Ok(_respon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("meniMinuman")]
        [HttpGet]
        public async Task<IActionResult> GetMinuman()
        {
            try
            {
                var menu = await _akunRepo.GetMenuMinuman();
                _respon = _balikan.buatResponGet(_balikan.CodeOk, menu);
                return Ok(_respon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("meniReady")]
        [HttpGet]
        public async Task<IActionResult> GetMenuReady()
        {
            try
            {
                var menu = await _akunRepo.GetMenuReady();
                _respon = _balikan.buatResponGet(_balikan.CodeOk, menu);
                return Ok(_respon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("CreateMenu")]
        [HttpPost]
        public async Task<IActionResult> CreateMenu(GetMenu menu)
        {
            try
            {
                await _akunRepo.CreateMenu(menu);

                _respon = _balikan.buatResponApi(_balikan.CodeOk, _balikan.SuksesTambahMenu());
                return Ok(_respon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("UpdateMenu")]
        [HttpPut]
        public async Task<IActionResult> UpdateMenu(int nomor,GetMenu menu)
        {
            try
            {
                var no = await _akunRepo.GetMenuNo(nomor);
                if(no != null)
                {
                    await _akunRepo.UpdateMenu(nomor,menu);

                    _respon = _balikan.buatResponApi(_balikan.CodeOk, _balikan.SuksesUpdateMenu());
                    return Ok(_respon);
                }
                _respon = _balikan.buatResponApi(_balikan.CodeBadRequest, _balikan.DataNull());
                return Ok(_respon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
