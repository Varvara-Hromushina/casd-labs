using System.Linq.Expressions;

string? line; //текущая строка
int[][] matrix = new int[0][]; //матрица
int[] vector = new int[0]; //вектор
int n = 0; //размерность

bool CheckingSymmetry(int[][] matrix, int n)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            if (matrix[i][j] != matrix[j][i]) return false;
        }
    }
    return true;
}

double VectorLength(int[][] matrix, int[] vector, int n)
{
    int[] newMatrix;
    int sum = 0;
    newMatrix = new int[n];
    for (int i = 0; i < n; i++)
    {
        sum = 0;
        for (int j = 0; j < n; j++)
        {
            sum += vector[i] * matrix[i][j];
        }
        newMatrix[i] = sum;
    }

    sum = 0;
    for (int i = 0; i < n; i++)
    {
        sum += newMatrix[i] * vector[i];
    }

    return Math.Sqrt(sum);
}


try
{
    StreamReader f = new StreamReader("data.txt");
    line = f.ReadLine();
    n = Convert.ToInt32(line);
    matrix = new int[n][];
    vector = new int[n];

    for (int i = 0; i < n; i++)
    {
        matrix[i] = f.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
    }
    
    Console.WriteLine("Матрица метрического тензора имеет вид: ");
    for (int i = 0; i < matrix.Length; i++)
    {
        foreach (int x in matrix[i]) Console.Write(x + " ");
        Console.WriteLine();
    }
    
    vector = f.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
    
    f.Close();
}
catch (Exception e)
{
    Console.WriteLine("exception " + e.Message);
}

Console.WriteLine("Вектор имеет вид: ");
for (int i = 0; i < vector.Length; i++)
{
    Console.Write($"{vector[i]} ");
}

Console.WriteLine();

if (CheckingSymmetry(matrix, n))
{
    Console.WriteLine("Матрица метрического тензора симметрична");
    double answer = VectorLength(matrix, vector, n);
    Console.WriteLine($"Длина вектора = {answer}");
}





