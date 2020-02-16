using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InventoryProjectPart2
{
    public abstract class CsvStore : StorageCapable
    {
        public List<Product> products = new List<Product>();

        public void SaveToCsv(Product product)
        {
            string filePath = "store.csv";

            if (!File.Exists(filePath))
            {
                try
                {
                    using (StreamWriter file = new StreamWriter(filePath))
                    {
                        if (product is CDProduct)
                        {
                            CDProduct cdProduct = (CDProduct)product;
                            file.WriteLine("CDProduct," + cdProduct.Name + "," + cdProduct.Price + "," + cdProduct.NumOfTracks);
                        }
                        else if (product is BookProduct)
                        {
                            BookProduct bookProduct = (BookProduct)product;
                            file.WriteLine("BookProduct," + bookProduct.Name + "," + bookProduct.Price + "," + bookProduct.NumOfPages);
                        }

                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.ToString());
                }
            }
            else
            {
                if (product is CDProduct)
                {
                    CDProduct cdProduct = (CDProduct)product;
                    var append=File.AppendText("store.csv");
                    append.WriteLine("CDProduct," + cdProduct.Name + "," + cdProduct.Price + "," + cdProduct.NumOfTracks);
                    append.Close();
                }
                else if (product is BookProduct)
                {
                    BookProduct bookProduct = (BookProduct)product;
                    var append = File.AppendText("store.csv");
                    append.WriteLine("BookProduct," + bookProduct.Name + "," + bookProduct.Price + "," + bookProduct.NumOfPages);
                    append.Close();
                }  
            }
        }

        public abstract void StoreProduct(Product product);

        public Product CreateProduct(string type, string name, int price, int size)
        {
            Product product;
            if (type.ToLower().Equals("cd"))
            {
                product = new CDProduct(name, price, size);
            }
            else if (type.ToLower().Equals("book"))
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
                List<Product> listOfProducts = new List<Product>();
                using (StreamReader file=new StreamReader("store.csv"))
                {
                    string line = file.ReadLine();
                    string[] datas=line.Split(",");
                    int name = 1;
                    int price = 2;
                    int size = 3;

                    if(datas[0].Equals("CDProduct"))
                    {
                        CDProduct product = new CDProduct(datas[name], int.Parse(datas[price]), int.Parse(datas[size]));
                        listOfProducts.Add(product);
                    }
                    else if (datas[0].Equals("BookProduct"))
                    {
                        BookProduct product = new BookProduct(datas[name], int.Parse(datas[price]), int.Parse(datas[size]));
                        listOfProducts.Add(product);
                    }
                }
                return listOfProducts;
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
            }
        }


        public void ToStore(Product product)
        {
            products.Add(product);
            SaveToCsv(product);
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
