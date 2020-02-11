using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryProjectPart2
{
    public class PersistentStore : Store
    {
        public override void StoreProduct(Product product)
        {
            products.Add(product);
        }
    }
}
