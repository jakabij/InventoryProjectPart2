using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryProjectPart2
{
    class PersistentCsvStore : CsvStore
    {
        public override void StoreProduct(Product product)
        {
            products.Add(product);
        }
    }
}
