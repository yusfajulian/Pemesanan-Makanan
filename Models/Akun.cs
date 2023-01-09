using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPemesanan.Models
{
    public class Akun
    {
        public string username { get; set; }
        public string password { get; set; }
        public int type { get; set; }
    }

    public class Login
    {
        public string username { get; set; } = "";
        public string password { get; set; } = "";
    }
}
