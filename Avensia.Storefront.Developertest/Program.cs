using System;
using StructureMap;

namespace Avensia.Storefront.Developertest
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(new DefaultRegistry());

            var productListVisualizer = container.GetInstance<ProductListVisualizer>();
            productListVisualizer.SelectedCurrency = "USD"; // Default Currency

            var shouldRun = true;
            DisplayOptions(productListVisualizer.SelectedCurrency);

            while (shouldRun)
            {
                Console.Write("Enter an option: ");
                var input = Console.ReadKey();
                Console.WriteLine("\n");
                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.WriteLine("Printing all products");
                        productListVisualizer.OutputAllProduct();
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.WriteLine("Printing paginated products");
                        productListVisualizer.OutputPaginatedProducts(1,5);
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.WriteLine("Printing products grouped by price");
                        productListVisualizer.OutputProductGroupedByPriceSegment();
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        Console.WriteLine("Change Currency (USD, GBP, SEK, DKK)");
                        var newCurrency = Console.ReadLine().ToUpper();
                        productListVisualizer.OutputChangeCurrency(newCurrency);
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        Console.WriteLine("Display Currency (Yesterday | Today):");
                        var selectedDay = Console.ReadLine().ToUpper();
                        productListVisualizer.OutputExchangeRates(selectedDay);
                        break;
                    case ConsoleKey.Q:
                        shouldRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                Console.WriteLine();
                DisplayOptions(productListVisualizer.SelectedCurrency);
            }

            Console.Write("\n\rPress any key to exit!");
            Console.ReadKey();
        }

        private static void DisplayOptions(string selectedCurrency)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Print all products");
            Console.WriteLine("2 - Print paginated products");
            Console.WriteLine("3 - Print products grouped by price");
            Console.WriteLine($"4 - Change Currency (Current - {selectedCurrency})");
            Console.WriteLine("5 - Display Exchange Rates");
            Console.WriteLine("q - Quit");
        }
    }
}
