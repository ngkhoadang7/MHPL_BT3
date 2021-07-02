using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banHangWin.DTO
{
    class Bill
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public int combo_id { get; set; }
        public int quantity { get; set; }
        public float reduce { get; set; }
        public float total { get; set; }
        public float money { get; set; }

    }
}
