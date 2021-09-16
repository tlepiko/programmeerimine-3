using System;

int[] array1 = new int[] { 1, 2, 3, 4, 5 };
string array1String = "";
foreach(var arrayElement in array1)
{
    array1String = array1String + arrayElement;
}
int length = array1.Length - 1;
string array1Reverse = null;
while (length >= 0)
{
    array1Reverse = array1Reverse + array1[length];
    length--;
}
Console.WriteLine();
Console.WriteLine("Algne massiiv on: " + array1String);
Console.WriteLine();
Console.WriteLine("Massiiv tagurpidi on: " + array1Reverse);
Console.ReadLine();