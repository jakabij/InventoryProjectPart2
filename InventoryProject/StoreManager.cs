using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace InventoryProjectPart2
{
    public class StoreManager
    {

        StorageCapable storageCapable;
        public void AddStorage(StorageCapable storage)
        {
            storageCapable = storage;
        }

        public void AddCDProduct(string name,int price,int tracks)
        {
            storageCapable.StoreCdProduct(name, price, tracks);
        }

        public void AddBookProduct(string name, int price, int pages)
        {
            storageCapable.StoreBookProduct(name, price, pages);
        }


        public string ListProducts()
        {
            string result = "";
            List<Product> products = GetAllProduct();
            int count = 0;
            for (;count<products.Count-1;count++)
            {
                result += products[count].Name;
                result += ", ";
            }
            return result += products[count].Name;
        }


        public List<Product> GetAllProduct()
        {
            try 
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Product>));
                List<Product> allProduct = new List<Product>();
                using (FileStream reader = File.OpenRead("products.xml"))
                {
                    allProduct=(List<Product>)xml.Deserialize(reader);
                }

                return allProduct;
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
