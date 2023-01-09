using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPemesanan.Data
{
    public class Respon
    {
        public Object buatResponApi(int respon_code, string message)
        {
            return new
            {
                status = respon_code == 200 ? "SUKSES" : "FAILED",
                respon_code,
                message
            };
        }
        public Object buatResponGet(int respon_code, object data)
        {
            return new
            {
                status = respon_code == 200 ? "SUKSES" : "FAILED",
                respon_code,
                data
            };
        }

        public Object buatResponLogin(int respon_code, string message, int type)
        {
            return new
            {
                status = respon_code == 200 ? "SUKSES" : "FAILED",
                respon_code,
                message,
                type
            };
        }

        public int CodeOk = 200;

        public int CodeBadRequest = 400;

        public int CodeInternalServerError = 500;

        public string SuksesLogin()
        {
            return "Selamat anda Berhasil Login";
        }

        public string GagalLogin()
        {
            return "Masukan username dan pasword yg benar!";
        }

        public string SuksesDaftar()
        {
            return "Daftar Akun Berhasil";
        }
        public string GagalDaftar()
        {
            return "Daftar Akun Gagal";
        }
        public string SuksesTambahMenu()
        {
            return "Menu Berhasil Ditambahkan";
        }
        public string SuksesUpdateMenu()
        {
            return "Menu Berhasil Di Update";
        }
        public string DataNull()
        {
            return "Data tidak ditemukan";
        }
        public string PesananSukses()
        {
            return "Pesanan Berhasil";
        }
    }
}
