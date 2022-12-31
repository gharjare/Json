namespace StockInventory
{
    class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Stock Account Management");
            string stocksFilePath = @"C:\Users\Achal\source\repos\StockInventory\StockInventory\Stock.json";
            string costemerFilePath = @"C:\Users\Achal\source\repos\StockInventory\StockInventory\Costemer.json";
            StockAccountManagement management = new StockAccountManagement();
            management.ReadStockJsonFile(stocksFilePath);
            management.ReadcostemerJsonFile(costemerFilePath);
            management.BuyStock("Google");
            management.SellStock("Google");
            management.WiteToStockJsonFile(stocksFilePath);
            management.WiteToCostemerJsonFile(costemerFilePath);

        }
    }
}
