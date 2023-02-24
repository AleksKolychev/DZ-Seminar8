/*Задайте прямоугольный двумерный массив. Напишите программу, 
которая будет находить строку с наименьшей суммой элементов.*/

void InputMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            matrix[i, j] = new Random().Next(1, 21);
    }
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} \t");
        Console.WriteLine();
    }
}

int SumRowElements(int[,] matrix, int i)
{
    int sumRow = matrix[i, 0];
    for (int j = 1; j < matrix.GetLength(1); j++)
    {
        sumRow += matrix[i, j];
    }
    return sumRow;
}

Console.Clear();
Console.Write("Введите размер прямоугольного массива: ");
int[] size = Console.ReadLine()!.Split(" ").Select(x => int.Parse(x)).ToArray();
while (size[0] == size[1])
{
    Console.Write("Вы ошиблись!\nВведите размер прямоугольного массива: ");
    size = Console.ReadLine()!.Split(" ").Select(x => int.Parse(x)).ToArray();
}
int[,] matrix = new int[size[0], size[1]];
InputMatrix(matrix);
Console.WriteLine();
PrintMatrix(matrix);

int minSumRow = 0;
int sumRow = SumRowElements(matrix, 0);
for (int i = 1; i < matrix.GetLength(0); i++)
{
    int tempSumRow = SumRowElements(matrix, i);
    if (sumRow > tempSumRow)
    {
        sumRow = tempSumRow;
        minSumRow = i;
    }
}

Console.WriteLine();
Console.WriteLine($"Строкa с наименьшей суммой {sumRow}: {minSumRow + 1}");
