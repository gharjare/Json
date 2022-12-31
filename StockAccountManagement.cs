using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventory
{
    public class StockAccountManagement
    {
        double amount = 1000;
        List<StockDetails> stock = new List<StockDetails>();
        List<StockDetails> costemer = new List<StockDetails>();
        public void ReadStockJsonFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            this.stock = JsonConvert.DeserializeObject<List<StockDetails>>(json);
            foreach (var content in stock)
            {
                Console.WriteLine(content.StockName + " StockName " + content.Price + " Price " + content.NumOfShare + " NumOfShare ");
            }
        }
        public void ReadcostemerJsonFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            this.costemer = JsonConvert.DeserializeObject<List<StockDetails>>(json);
            foreach (var content in costemer)
            {
                Console.WriteLine(content.StockName + " StockName " + content.Price + " Price " + content.NumOfShare + " NumOfShare ");
            }
        }
        public void BuyStock(string name)
        {
            foreach (var data in stock)
            {
                int count = 0;
                if (data.StockName.Equals(name))
                {
                    Console.WriteLine("Enter the number of stocks you need to buy");
                    int noOfStocks = Convert.ToInt32(Console.ReadLine());
                    if (noOfStocks * data.Price <= amount && noOfStocks <= data.NumOfShare)
                    {
                        StockDetails detailse = new StockDetails()
                        {
                            StockName = data.StockName,
                            Price = data.Price,
                            NumOfShare = noOfStocks
                        };
                        data.NumOfShare -= noOfStocks;

                        foreach (var account in costemer)
                        {
                            if (account.StockName.Equals(name))
                            {
                                count++;
                            }
                        }
                        if (count == 1)
                        {
                            data.NumOfShare += noOfStocks;
                        }
                        else
                        {
                            costemer.Add(data);
                        }
                    }
                }
            }
        }
        public void SellStock(string name)
        {
            foreach (var data in costemer)
            {
                if (data.StockName.Equals(name))
                {
                    Console.WriteLine("Enter the number of stocks you need to sell");
                    int sellStocks = Convert.ToInt32(Console.ReadLine());
                    if (sellStocks <= data.NumOfShare)
                    {
                        data.NumOfShare -= sellStocks;
                        amount += data.Price * sellStocks;
                        
                        foreach (var account in stock)
                        {
                            if (account.StockName.Equals(name))
                            {
                                data.NumOfShare += sellStocks;
                                return;
                            }
                        }
                        
                    }
                }
            }
        }

        public void WiteToStockJsonFile(string filepath)
        {
            var json = JsonConvert.SerializeObject(stock);
            File.WriteAllText(filepath, json);
        }
        public void WiteToCostemerJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(costemer);
            File.WriteAllText(filePath, json);
        }
    }
}
