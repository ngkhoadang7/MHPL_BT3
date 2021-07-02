using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banHangWin.DTO
{
    class Delivery
    {
        public int id { get; set; }
        public int bill_id { get; set; }
        public string shipper { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime date { get; set; }
        public string note { get; set; }
    }
}
