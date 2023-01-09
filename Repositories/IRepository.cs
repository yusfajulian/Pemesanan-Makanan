using ApiPemesanan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPemesanan.Repositories
{
    public interface IRepository
    {
        // AKUN 
        public Task<IEnumerable<Akun>> GetAkuns();
        public Task<Akun> GetAkun(string username);
        public Task<IEnumerable<Akun>> username(string username);
        public Task<IEnumerable<Akun>> password(string username, string password);
        public Task CreateAkun(Akun data);

        // MENU
        public Task<IEnumerable<Menu>> GetMenus();
        public Task<Menu> GetMenuNo(int no);
        public Task<IEnumerable<Menu>> GetMenuMakanan();
        public Task<IEnumerable<Menu>> GetMenuMinuman();
        public Task<IEnumerable<Menu>> GetMenuReady();
        public Task CreateMenu(GetMenu menu);
        public Task UpdateMenu(int nomor, GetMenu menu);

        // PESANAN
        public Task<IEnumerable<Pesanan>> GetPesanan();
        public Task<Pesanan> GetPesananNo(string no);
        public Task CreatePesanan(CreatePesanan pesanan);
        public Task UpdatePesanan(string no, Pesanan pesanan);
    }
}
