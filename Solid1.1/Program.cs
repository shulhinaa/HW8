using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Solid1
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Item(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

    public class Order
    {
        public IList<Item> ItemList { get; set; }

        public Order()
        {
            ItemList = new List<Item>();
        }

        public Order(IList<Item> list)
        {
            ItemList = list;
        }
    }

    public class OrderManager
    {
        public void AddItem(Order order, Item item)
        {
            order.ItemList.Add(item);
        }

        public void DeleteItem(Order order, Item item)
        {
            order.ItemList.Remove(item);
        }

        public void GetItems(Order order)
        {
            foreach (var item in order.ItemList)
            {
                Console.WriteLine($"Item: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
            }
        }

        public void GetItemCount(Order order)
        {
            Console.WriteLine($"Total Items: {order.ItemList.Count}");
        }
    }


    public class OrderPriceCalculator
    {
        public void CalculateTotalSum(Order order)
        {
            decimal total = 0;
            foreach (var item in order.ItemList)
            {
                total += item.Price * item.Quantity;
            }
            Console.WriteLine($"Total Sum: {total}");
        }
    }

    public class OrderDisplayer
    {
        public void PrintOrder(Order order)
        {
            Console.WriteLine("Order Details:");
            foreach (var item in order.ItemList)
            {
                Console.WriteLine($"Item: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
            }
        }

        public void ShowOrder(Order order)
        {
            Console.WriteLine("Showing order in a user-friendly way...");
            PrintOrder(order);
        }
    }

        public class OrderStorageManager
        {
            private readonly string _filePath;

            public OrderStorageManager(string filePath)
            {
                _filePath = filePath;
            }

            public void SaveOrder(Order order)
            {
                try
                {
                    var json = JsonSerializer.Serialize(order, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

                    File.WriteAllText(_filePath, json);
                    Console.WriteLine($"Order saved");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to save order: {ex.Message}");
                }
            }

            public Order LoadOrder()
            {
                try
                {
                    if (!File.Exists(_filePath))
                    {
                        Console.WriteLine("No order file found.");
                        return null;
                    }

                    var json = File.ReadAllText(_filePath);
                    var order = JsonSerializer.Deserialize<Order>(json);

                    Console.WriteLine($"Order loaded");
                    return order;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load order: {ex.Message}");
                    return null;
                }
            }

            public void UpdateOrder(Order order)
            {
                try
                {
                    SaveOrder(order); 
                    Console.WriteLine("Order updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to update order: {ex.Message}");
                }
            }

            public void DeleteOrder()
            {
                try
                {
                    if (File.Exists(_filePath))
                    {
                        File.Delete(_filePath);
                        Console.WriteLine("Order file deleted.");
                    }
                    else
                    {
                        Console.WriteLine("No order file to delete.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to delete order: {ex.Message}");
                }
            }
        }



    public class Program
    {
        public static void Main()
        {
            var item1 = new Item("Apple", 0.5m, 12);
            var item2 = new Item("Banana", 0.3m, 12);

            string filePath = @"C:\програмування\uni_projects\с#\HW8\Solid1.1\orders.json";
            var order = new Order();
            var orderManager = new OrderManager();
            var priceCalculator = new OrderPriceCalculator();
            var orderDisplayer = new OrderDisplayer();
            var storageManager = new OrderStorageManager(filePath);

            orderManager.AddItem(order, item1);
            orderManager.AddItem(order, item2);

            orderDisplayer.PrintOrder(order);

            priceCalculator.CalculateTotalSum(order);

            storageManager.SaveOrder(order);

            orderManager.DeleteItem(order, item1);
            Console.WriteLine("\nAfter deleting an item:");
            orderDisplayer.PrintOrder(order);
        }
    }
}
