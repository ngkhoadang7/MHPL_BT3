using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using banHangWin.DTO;
using banHangWin.DAL;
using System.Windows.Forms;

namespace banHangWin.BLL
{
    class ComboBLL
    {
        public static List<Combo> getAllCombo()
        {
            return ComboDAL.getAllCombo();
        }

        public static bool addCombo(string name, float reduce, List<Product> productList)
        {
            if(name == "")
            {
                MessageBox.Show("Tên Combo không được để trống");
                return false;
            }

            if (productList.Count == 0)
            {
                MessageBox.Show("Sản phẩm trong Combo không được để trống");
                return false;
            }
            string temp = "[";
            Product last = productList.Last();
            foreach (Product item in productList)
            {
                if (item.Equals(last))
                {
                    temp += item.id;
                } 
                else
                {
                    temp += item.id + ",";
                }
            }
            temp += "]";
            Combo combo = new Combo();
            combo.name = name;
            combo.products = temp;
            combo.reduce = reduce;
            return ComboDAL.addCombo(combo);
        }

        public static bool editCombo(int id, string name, float reduce, List<Product> productList)
        {
            if (name == "")
            {
                MessageBox.Show("Tên Combo không được để trống");
                return false;
            }

            if (productList.Count == 0)
            {
                MessageBox.Show("Sản phẩm trong Combo không được để trống");
                return false;
            }
            string temp = "[";
            Product last = productList.Last();
            foreach (Product item in productList)
            {
                if (item.Equals(last))
                {
                    temp += item.id;
                }
                else
                {
                    temp += item.id + ",";
                }
            }
            temp += "]";
            Combo combo = new Combo();
            combo.id = id;
            combo.name = name;
            combo.products = temp;
            combo.reduce = reduce;
            return ComboDAL.editCombo(combo);
        }

        public static Combo getComboById(int id)
        {
            return ComboDAL.getComboById(id);
        }

        public static bool deleteCombo(int id)
        {
            return ComboDAL.deleteCombo(id);
        }
    }
}
