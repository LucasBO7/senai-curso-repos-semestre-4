string[] nameList = new string[5];

// Inserção dos valores
Console.WriteLine($"Insira 5 nomes!");
for (int i = 0; i < nameList.Length; i++)
{
    Console.Write($"Nome {i + 1}: ");
    nameList[i] = Console.ReadLine()!;
}

// Ordena em ordem alfabética
nameList = nameList.OrderBy(n => n).ToArray();
Console.Clear();

// Imprime os nomes em ordem alfabética
foreach (var item in nameList)
{
    Console.WriteLine(item);
}
