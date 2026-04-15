using Storage_HW4;
using System;
using System.Collections.Generic;

namespace Storage_HW4;

public class Program
{
    public static void Main()
    {
        Warehouse warehouse = new Warehouse(10);

        warehouse.OnItemChanged += (cellIndex, itemName) =>
            Console.WriteLine($"Log: in storage {cellIndex} added an item: {itemName}");

        List<string> products = new()
        {
            "keyboard",
            "mouse",
            "",
            "keyboard",
            "monitor"
        };

        Predicate<string> isValidProduct = productName => !string.IsNullOrWhiteSpace(productName);
        Func<string, string> formatProductName = productName => productName.ToUpper();

        int currentCell = 0;

        foreach (string product in products)
        {
            if (!isValidProduct(product))
            {
                Console.WriteLine("Skipped empty name of the product.");
                continue;
            }

            if (currentCell >= warehouse.Capacity)
            {
                Console.WriteLine("There are no free storages.");
                break;
            }

            warehouse[currentCell] = formatProductName(product);
            currentCell++;
        }

        Console.WriteLine();
        Console.WriteLine("Storage info:");

        for (int i = 0; i < warehouse.Capacity; i++)
        {
            string item = warehouse[i];
            Console.WriteLine($"Storage #{i}: {(string.IsNullOrEmpty(item) ? "empty" : item)}");
        }
    }
}