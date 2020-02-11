using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace InventoryProjectPart2
{
    [XmlInclude(typeof(PersistentStore))]
    [XmlInclude(typeof(Product))]
    [XmlInclude(typeof(CDProduct))]
    [XmlInclude(typeof(BookProduct))]
    public abstract class Product
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public int Price { get; set; }
    }
}
