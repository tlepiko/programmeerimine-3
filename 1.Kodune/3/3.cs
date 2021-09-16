using System;
using System.Collections.Generic;
using System.Linq;


var numbrid = new List<int>() {};

bool exitWish = false;
int kontroll;
do {
    Console.Write("Sisesta listi number (Lõpetamiseks vajuta ENTER)");
    string input = Console.ReadLine();
    bool success = int.TryParse(input, out kontroll);
    if (success) {
        numbrid.Add(int.Parse(input));
    } else if (input == "") {
        exitWish = true;
    } else {
        Console.WriteLine("Palun sisesta vaid numbreid!");
    }
} while (!exitWish);

var duplicates = numbrid 
    .GroupBy(i => i)
    .Where(g => g.Count() > 1)
    .Select(g => g.Key);

Console.Write("Korduvad numbrid on: ");
foreach (var i in duplicates)
{
    Console.Write(i);
}
