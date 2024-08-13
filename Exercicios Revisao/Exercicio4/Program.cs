string menu;
do
{
    Console.Write("Insira um número: ");
    float numberInserted = float.Parse(Console.ReadLine()!);
    PrintMultiplicationTable(numberInserted);

    Console.Write("Deseja buscar a taboada de outro número? (s/n): ");
    menu = Console.ReadLine()!.ToLower();
    Console.Clear();
} while (menu == "s");





static void PrintMultiplicationTable(float number)
{
    for (int i = 0; i <= 10; i++)
    {
        float result = number * i;
        Console.WriteLine($"{number} * {i} = {result}");
    }
}
