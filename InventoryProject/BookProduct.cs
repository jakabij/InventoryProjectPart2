using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace InventoryProjectPart2
{
    public class BookProduct :Product
    {
        [XmlAttribute("size")]
        public int NumOfPages { get; set; } 

        public BookProduct()
        {

        }
        public BookProduct(string name,int price,int pages)
        {
            this.Name = name;
            this.Price = price;
            this.NumOfPages = pages;
        }
    }
}
