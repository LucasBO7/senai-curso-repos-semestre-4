float[] numbers = new float[10];
List<float> pairNumbers = new();

for (int i = 0; i < numbers.Length; i++)
{
    // Inserção dos valores
    Console.Write($"Insira um número ({i + 1}/10): ");
    numbers[i] = float.Parse(Console.ReadLine()!);

    // Salva os números pares
    if (numbers[i] % 2 == 0)
        pairNumbers.Add(numbers[i]);
}

// Soma todos os números pares
float sumResult = pairNumbers.Sum();

Console.WriteLine();
Console.WriteLine($"A soma dos números pares é: {sumResult}");