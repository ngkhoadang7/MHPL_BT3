using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banHangWin.DTO
{
    class Customer
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public DateTime birthDate { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
