string exitProgram;

do
{
    // Inserção do número a ser consultado
    Console.Write($"Insira um número inteiro: ");
    var insertedNumber = int.Parse(Console.ReadLine()!);

    // Verifica se o valor é impar ou par e imprime
    if (insertedNumber % 2 == 0)
        Console.WriteLine($"O número {insertedNumber} é par!");
    else
        Console.WriteLine($"O número {insertedNumber} é ímpar!");

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Deseja sair do programa? (s/n): ");
    Console.ResetColor();
    exitProgram = Console.ReadLine()!.ToLower();
    Console.Clear();
} while (exitProgram != "s");
