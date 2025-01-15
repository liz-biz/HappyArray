using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main(string[] args)
    {
        List<string[]> products = new List<string[]>
        {
            new string[] { "Cheese", "Dairy" },
            new string[] {"Carrots", "Produce" },
            new string[] {"Romaine Lettuce", "Produce" },
            new string[] {"Chocolate Milk", "Dairy" },
            new string[] {"Flour", "Pantry" },
            new string[] {"Iceberg Lettuce", "Produce" },
            new string[] {"Coffee", "Pantry" },
            new string[] {"Pasta", "Pantry" },
            new string[] {"Milk", "Dairy" },
            new string[] {"Blueberries", "Produce" },
            new string[] {"Pasta Sauce", "Pantry" }
        };
        List<string> list1 = new List<string> { "Blueberries", "Milk", "Coffee","Flour","Cheese", "Carrots" };
        List<string> list2 = new List<string> { "Blueberries", "Carrots", "Coffee", "Milk", "Flour", "Cheese" };
        List<string> list3 = new List<string> { "Blueberries", "Carrots", "Romaine Lettuce", "Iceberg Lettuce" };
        List<string> list4 = new List<string> { "Milk", "Flour", "Chocolate Milk", "Pasta Sauce" };
        List<string> list5 = new List<string> { "Cheese", "Potatoes", "Blueberries", "Canned Tune" };
        Console.WriteLine("Result for List 1: " + shopping(products, list1));
        Console.WriteLine("Result for List 2: " + shopping(products, list2));
        Console.WriteLine("Result for List 3: " + shopping(products, list3));
        Console.WriteLine("Result for List 4: " + shopping(products, list4));
        Console.WriteLine("Result for List 5: " + shopping(products, list5));

        Console.WriteLine("Result for List 1: " + shopping2(products, list1));
        Console.WriteLine("Result for List 2: " + shopping2(products, list2));
        Console.WriteLine("Result for List 3: " + shopping2(products, list3));
        Console.WriteLine("Result for List 4: " + shopping2(products, list4));
        Console.WriteLine("Result for List 5: " + shopping2(products, list5));
    }
    public static int shopping(List<string[]> products, List<string> shoppingList)
    {
        List<string> departments = new List<string>();

        for (int i = 0, j = 0; i < shoppingList.Count; i++)
        {
            foreach (string[] product in products)
            {
                if (product[0].Equals(shoppingList[i]))
                {
                    if (departments.Count == 0)
                    {
                        departments.Add(product[1]);
                        break;
                    }
                    else if (!departments[j].Equals(product[1]))
                    {
                        departments.Add(product[1]);
                        j++;
                        break;
                    }
                }
            }
        }
        return departments.Count - departments.Distinct().Count();
    }
    public static int shopping2(List<string[]> products, List<string> shoppingList)
    {
        Dictionary<string,string> productDict = products.ToDictionary(p=> p[0],p=> p[1]);
        List<string> departments = new List<string>();

        foreach (var item in shoppingList)
        {
            if (productDict.TryGetValue(item, out string department))
            {
                if (departments.Count == 0 || departments.Last() != department)
                {
                    departments.Add(department);
                }
            }
        }
        return departments.Count - departments.Distinct().Count();
    }
}
