using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace InventoryProjectPart2
{
    public abstract class Store : StorageCapable
    {
       
        public List<Product> products=new List<Product>();

        public void SaveToXml(Product product)
        {
            
            using (StreamWriter writer = new StreamWriter("products.xml"))
            {
                //XmlRootAttribute attribute = new XmlRootAttribute("Products");
                //XmlSerializer xml = new XmlSerializer(typeof(List<Product>),attribute);   Doesn't work like that
                XmlSerializer xml = new XmlSerializer(typeof(List<Product>));
                xml.Serialize(writer, this.products);
            }
        }

        public abstract void StoreProduct(Product product);

        public Product CreateProduct(string type,string name,int price,int size)
        {
            Product product;
            if(type.ToLower().Equals("cd"))
            {
                product = new CDProduct(name, price, size);
            }
            else if(type.ToLower().Equals("book"))
            {
                product = new BookProduct(name, price, size);
            }
            else
            {
                throw new Exception("No type like that!");
            }

            return product;
        }

        public List<Product> LoadProducts()
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Product>));
                List<Product> allProduct = new List<Product>();
                using (FileStream reader = File.OpenRead("products.xml"))
                {
                    allProduct = (List<Product>)xml.Deserialize(reader);
                }

                return allProduct;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }


        public void ToStore(Product product)
        {
            StoreProduct(product);
            SaveToXml(product);
        }

        public List<Product> GetAllProduct()
        {
            return products;
        }

        public void StoreBookProduct(string name, int price, int pages)
        {
            Product resultProduct = CreateProduct("Book", name, price, pages);
            ToStore(resultProduct);
        }

        public void StoreCdProduct(string name, int price, int tracks)
        {
            Product resultProduct = CreateProduct("CD", name, price, tracks);
            ToStore(resultProduct);
        }
    }
}
