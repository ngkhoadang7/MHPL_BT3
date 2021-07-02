using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using banHangWin.DTO;
using banHangWin.DAL;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace banHangWin.BLL
{
    class ProductBLL
    {
        public static List<Product> getAllProduct()
        {
            return ProductDAL.getAllProduct();
        }

        public static List<Product> getAllProductsByIDsString(string idString) 
        {
            List<Product> productList = getAllProduct();

            var IDs = JsonConvert.DeserializeObject<List<int>>(idString);
            List<Product> result = new List<Product>();
            foreach( int i in IDs)
            {
                foreach(Product item in productList)
                {
                    if(i == item.id)
                    {
                        result.Add(item);
                        break;
                    }
                }
            }
            return result;
        }


        public static string GenerateNameFile(string fileName)
        {
            if (fileName != null)
            {
                int lastDotIndex = fileName.LastIndexOf(".");
                string ext = fileName.Substring(lastDotIndex + 1);
                string name = fileName.Substring(0, lastDotIndex);
                return name + "_" + DateTime.Now.ToString("ddMMyyyy-hhmmss.") + ext;
            }
            else return "";
        }

        public static bool addProduct(Product product)
        {
            if(product.name == "")
            {
                MessageBox.Show("Tên sản phẩm không được để trống");
                return false;
            }

            if (product.detail == "")
            {
                MessageBox.Show("Thông tin sản phẩm không được để trống");
                return false;
            }

            if (product.image == "")
            {
                MessageBox.Show("Hình ảnh sản phẩm không được để trống");
                return false;
            }

            return ProductDAL.addProduct(product);

        }

        public static bool editProduct(Product product, bool haveImage)
        {
            if (product.name == "")
            {
                MessageBox.Show("Tên sản phẩm không được để trống");
                return false;
            }

            if (product.detail == "")
            {
                MessageBox.Show("Thông tin sản phẩm không được để trống");
                return false;
            }

            if (product.image == "")
            {
                MessageBox.Show("Hình ảnh sản phẩm không được để trống");
                return false;
            }

            return ProductDAL.editProduct(product, haveImage);

        }
        public static bool deleteProduct(int id)
        {
            return ProductDAL.deleteProduct(id);
        }
    }
}
