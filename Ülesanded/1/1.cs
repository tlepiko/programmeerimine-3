using System;

int[] array1 = new int[] { 1, 2, 3, 4, 5 };
int[] array2 = array1;
int length = 0;
string array1String = null;
while (length <= array1.Length-1)
{
    if (length == array1.Length-1) {
        array1String = array1String + array1[length] + ".";
    } else {
        array1String = array1String + array1[length] + ", ";
    }
    length++;
}

int length2 = array1.Length - 1;
string array1Reverse = null;
int array2Index = 0;
while (length2 >= 0)
{
    array2[array2Index] = array1[length2];
    array2Index++;
    Console.WriteLine(array2[0]);
    array1Reverse = array1Reverse + array1[length2];
    if (length2 == 0) {
        array1Reverse = array1Reverse + ".";
    } else {
        array1Reverse = array1Reverse + ", ";
    }
    length2--;
}
Console.WriteLine();
Console.WriteLine("Algne massiiv on: " + array1String);
Console.WriteLine();
Console.WriteLine("Massiiv tagurpidi on: " + array1Reverse);
Console.ReadLine();