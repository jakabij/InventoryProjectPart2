using System;

namespace InventoryProjectPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreManager storeManager = new StoreManager();
            StorageCapable storage = new PersistentStore();

            storeManager.AddStorage(storage);

            storeManager.AddBookProduct("Star Wars", 3500, 420);
            storeManager.AddBookProduct("Game of Thrones", 4999, 2000);
           
            storeManager.AddCDProduct("Song1", 2100, 1);
            storeManager.AddCDProduct("Song2", 1050, 2);
            storeManager.AddCDProduct("Song3", 500, 3);

            StorageCapable storage2 = new PersistentCsvStore();
            storeManager.AddStorage(storage2);

            storeManager.AddBookProduct("Star Wars2", 300, 40);
            storeManager.AddBookProduct("Game of Thrones2", 499, 200);

            storeManager.AddCDProduct("Song66", 21, 1);
            storeManager.AddBookProduct("Game of Thrones2", 499, 200);

            Console.WriteLine("In the store: "+storeManager.ListProducts());
        }
    }
}
