using System;

int[,] array1 = new int[4, 4] { { 1, 2, 3, 4 },
                                { 4, 3, 2, 1 },
                                { 2, 3, 4, 1 },
                                { 2, 4, 3, 1 }
                                };

int rowsLength = array1.GetLength(0);
int colsLength = array1.GetLength(1);

for (int i = 0; i < rowsLength; i++)
{
    for (int j = 0; j < colsLength; j++)
    {
        Console.Write(string.Format("{0} ", array1[i, j]));
    }
    Console.WriteLine("");
}
Console.ReadLine();