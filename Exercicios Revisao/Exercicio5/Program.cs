using System.Text;
using System.Text.RegularExpressions;

string exitApp;
do
{

    Console.WriteLine("Digite um texto qualquer: ");
    string textInserted = Console.ReadLine()!;
    char[] alphabetLetters = ['a', 'e', 'i', 'o', 'u'];

    // Remove os acentos para posterior comparação
    textInserted = RemoveAccents(textInserted);

    // Imprime a quantidade de cada letra do alfabeto
    foreach (char letter in alphabetLetters)
    {
        Console.WriteLine($"[{letter.ToString().ToUpper()}]: " + textInserted.Count(c => c == letter));
    }

    Console.WriteLine();
    Console.WriteLine("Deseja sair da aplicação? (s/n): ");
    exitApp = Console.ReadLine()!;
    Console.Clear();
} while (exitApp != "s");


// Remove acentuação da frase utilizando código REGEX
static string RemoveAccents(string texto)
{
    string normalized = texto.Normalize(NormalizationForm.FormD);

    // Remove os acentos usando Regex
    Regex regex = new(@"\p{Mn}", RegexOptions.IgnoreCase);
    string result = regex.Replace(normalized, "");

    // Normaliza novamente para o formato original
    return result.Normalize(NormalizationForm.FormC);
}
