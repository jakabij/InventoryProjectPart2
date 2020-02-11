using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace InventoryProjectPart2
{
    public class CDProduct:Product
    {
        [XmlAttribute("size")]
        public int NumOfTracks { get; set; }

        public CDProduct()
        {

        }
        public CDProduct(string name,int price,int tracks)
        {
            this.Name = name;
            this.Price = price;
            this.NumOfTracks = tracks;
        }
    }
}
