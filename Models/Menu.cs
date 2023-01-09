using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPemesanan.Models
{
    public class Menu
    {
        public int nomor { get; set; }
        public string nama { get; set; }
        public double harga { get; set; }
        public string jenis { get; set; }
        public string status { get; set; }
    }

    public class GetMenu
    {       
        public string nama { get; set; }
        public double harga { get; set; }
        public string jenis { get; set; }
        public string status { get; set; }
    }
}
