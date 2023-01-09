using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPemesanan.Models
{
    public class Pesanan
    {
        public string nomor_pesanan { get; set; }
        public string nomor_meja { get; set; }
        public string makanan { get; set; }
        public string minuman { get; set; }
        public string status { get; set; } 
    }

    public class CreatePesanan
    {
        public string nomor_meja { get; set; }
        public string makanan { get; set; }
        public string minuman { get; set; }
        public string status { get; set; }
    }

    public class makanan
    {
        public string nama { get; set; }
    }

    public class minuman
    {
        public string nama { get; set; }
    }
}
