using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banHangWin.DTO
{
    class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int catalog_id { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
        public string detail { get; set; }
        public string image { get; set; }

        public Product() { }
    }
}
