using ApiPemesanan.Data;
using ApiPemesanan.Models;
using ApiPemesanan.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPemesanan.Controllers
{
    [Route("api")]
    [ApiController]
    public class AkunController : ControllerBase
    {
        private readonly IRepository _akunRepo;
        private Respon _balikan = new();
        private object _respon;
        
        public AkunController(IRepository akunRepo)
        {
            _akunRepo = akunRepo;
        }

        [Route("akun")]
        [HttpGet]
        public async Task<IActionResult> GetAkun()
        {
            try
            {
                var Akuns = await _akunRepo.GetAkuns();
                _respon = _balikan.buatResponGet(_balikan.CodeOk, Akuns);
                return Ok(_respon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                var username = await _akunRepo.username(login.username);
                int type = username.Select(x => x.type).FirstOrDefault();
                string user = username.Select(x => x.username).FirstOrDefault();
                
                if (user != null)
                {
                    var password = await _akunRepo.password(login.username, login.password);
                    string pass = password.Select(x => x.password).FirstOrDefault();
                    if (pass != null)
                    {
                        _respon = _balikan.buatResponLogin(_balikan.CodeOk, _balikan.SuksesLogin(),type);
                        return Ok(_respon);
                    }
                }
                _respon = _balikan.buatResponApi(_balikan.CodeBadRequest, _balikan.GagalLogin());
                return Ok(_respon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("CreateAkun")]
        [HttpPost]
        public async Task<IActionResult> CreateAkun(Akun akun)
        {
            try
            {
                var createAkun = await _akunRepo.GetAkun(akun.username);
                if(createAkun == null)
                {
                    await _akunRepo.CreateAkun(akun);

                    _respon = _balikan.buatResponApi(_balikan.CodeOk, _balikan.SuksesDaftar());
                    return Ok(_respon);
                }

                _respon = _balikan.buatResponApi(_balikan.CodeBadRequest, _balikan.GagalDaftar());
                return Ok(_respon);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
