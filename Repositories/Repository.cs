using ApiPemesanan.Data;
using ApiPemesanan.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPemesanan.Repositories
{
    public class Repository : IRepository
    {
        private readonly DapperContext _context;
        public Repository(DapperContext context)
        {
            _context = context;
        }

        // AKUN
        public async Task<IEnumerable<Akun>> GetAkuns()
        {
            var query = "SELECT * FROM TBL_AKUN";

            using (var connection = _context.CreateConnection())
            {
                var akuns = await connection.QueryAsync<Akun>(query);
                return akuns.ToList();
            }
        }
        public async Task<Akun> GetAkun(string username)
        {
            var query = "SELECT * FROM TBL_AKUN WHERE USERNAME = '"+ username +"'";

            using (var connection = _context.CreateConnection())
            {
                var akuns = await connection.QuerySingleOrDefaultAsync<Akun>(query);
                return akuns;
            }
        }
        public async Task<IEnumerable<Akun>> username(string username)
        {
            var query = "SELECT USERNAME FROM TBL_AKUN WHERE USERNAME ='" + username + "'";

            using (var connection = _context.CreateConnection())
            {
                var Login = await connection.QueryAsync<Akun>(query);
                return Login;
            }
        }
        public async Task<IEnumerable<Akun>> password(string username, string password)
        {
            var query = "SELECT USERNAME,PASSWORD FROM TBL_AKUN WHERE USERNAME ='" + username + "' AND PASSWORD ='" + password + "'";

            using (var connection = _context.CreateConnection())
            {
                var Login = await connection.QueryAsync<Akun>(query);
                return Login;
            }
        }
        public async Task CreateAkun(Akun data)
        {
            var query = "INSERT INTO TBL_AKUN(USERNAME,PASSWORD,TYPE) VALUES ('" + data.username + "','" + data.password + "'," + data.type + ")";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        // MENU
        public async Task<IEnumerable<Menu>> GetMenus()
        {
            var query = "SELECT * FROM TBL_MENU";

            using (var connection = _context.CreateConnection())
            {
                var menu = await connection.QueryAsync<Menu>(query);
                return menu.ToList();
            }
        }
        public async Task<Menu> GetMenuNo(int no)
        {
            var query = "SELECT * FROM TBL_MENU WHERE NOMOR = " + no;

            using (var connection = _context.CreateConnection())
            {
                var menu = await connection.QuerySingleOrDefaultAsync<Menu>(query);
                return menu;
            }
        }
        public async Task<IEnumerable<Menu>> GetMenuMakanan()
        {
            var query = "SELECT * FROM TBL_MENU WHERE JENIS = 'MAKANAN'";

            using (var connection = _context.CreateConnection())
            {
                var menu = await connection.QueryAsync<Menu>(query);
                return menu.ToList();
            }
        }
        public async Task<IEnumerable<Menu>> GetMenuMinuman()
        {
            var query = "SELECT * FROM TBL_MENU WHERE JENIS = 'MINUMAN'";

            using (var connection = _context.CreateConnection())
            {
                var menu = await connection.QueryAsync<Menu>(query);
                return menu.ToList();
            }
        }
        public async Task<IEnumerable<Menu>> GetMenuReady()
        {
            var query = "SELECT * FROM TBL_MENU WHERE STATUS = 'READY'";

            using (var connection = _context.CreateConnection())
            {
                var menu = await connection.QueryAsync<Menu>(query);
                return menu.ToList();
            }
        }
        public async Task CreateMenu(GetMenu menu)
        {
            var query = "INSERT INTO TBL_MENU(NAMA,HARGA,JENIS,STATUS) VALUES ('" + menu.nama + "'," + menu.harga + ",'" + menu.jenis + "','"+ menu.status +"')";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }
        public async Task UpdateMenu(int nomor, GetMenu menu)
        {
            var query = "UPDATE TBL_MENU SET NAMA = '" + menu.nama + "', HARGA = " + menu.harga + ",JENIS = '" + menu.jenis + "', STATUS = '" + menu.status + "' WHERE NOMOR = " + nomor + "";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        // PESANAN
        public async Task<IEnumerable<Pesanan>> GetPesanan()
        {
            var query = "SELECT * FROM TX_PESANAN";

            using (var connection = _context.CreateConnection())
            {
                var menu = await connection.QueryAsync<Pesanan>(query);
                return menu.ToList();
            }
        }

        public async Task<Pesanan> GetPesananNo(string no)
        {
            var query = "SELECT * FROM TX_PESANAN WHERE NOMOR_PESANAN";

            using (var connection = _context.CreateConnection())
            {
                var menu = await connection.QuerySingleOrDefaultAsync<Pesanan>(query);
                return menu;
            }
        }

        public async Task CreatePesanan(CreatePesanan pesanan)
        {
            string nomorPesanan = "ABC";
            DateTime dt = DateTime.Now;
            string tmdate = dt.ToString("ddMMyyyy");
            string nomorSebelumnya;
            string tt;
            int yy;
            string aa;

            var QU = "SELECT DISTINCT NOMOR_PESANAN FROM TX_PESANAN ORDER BY NOMOR_PESANAN DESC";

            using (var connection = _context.CreateConnection())
            {
                var menu = await connection.QueryAsync<Pesanan>(QU);
                nomorSebelumnya = menu.Select(x => x.nomor_pesanan).FirstOrDefault();
            }
            tt = nomorSebelumnya.Substring(3, 8);
            yy = Convert.ToInt32(nomorSebelumnya.Substring(12, 3));

            if (Convert.ToInt32(tt) < Convert.ToInt32(tmdate))
            {
                yy = 1;
                tmdate = tmdate;
            }else
            {
                yy += 1;
                tmdate = tt;
            }
            string dd = yy.ToString();
            if (dd.Length == 1)
            {
                aa = "00" + dd;
            }else if(dd.Length == 2)
            {
                aa = "0" + dd;
            }
            else
            {
                aa = dd;
            }
            nomorPesanan += tmdate + "-" + aa;

            var query = "INSERT INTO TX_PESANAN(NOMOR_PESANAN,NOMOR_MEJA,MAKANAN,MINUMAN,STATUS) VALUES ('" + nomorPesanan + "','" + pesanan.nomor_meja + "','" + pesanan.makanan + "','" + pesanan.minuman + "','"+ pesanan.status +"')";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public Task UpdatePesanan(string no, Pesanan pesanan)
        {
            throw new NotImplementedException();
        }
    }
}
