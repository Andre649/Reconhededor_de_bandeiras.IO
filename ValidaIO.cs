using System.Text.RegularExpressions;

// 1. Entrada de dados
Console.WriteLine("--- Validador de Bandeiras Jarvs ---");
Console.Write("Digite o número do cartão: ");
string input = Console.ReadLine() ?? "";

// 2. Execução da Lógica
string bandeira = CardValidator.IdentifyBrand(input);

// 3. Output
Console.WriteLine($"\nResultado: {bandeira}");
Console.WriteLine("------------------------------------");

// Classe de suporte (pode ficar no mesmo arquivo ou em um CardValidator.cs)
public static class CardValidator
{
    private static readonly Dictionary<string, string> BrandRules = new()
    {
        { "Visa", @"^4[0-9]{15}$" },
        { "MasterCard", @"^(5[1-5][0-9]{14}|2(22[1-9][0-9]{12}|2[3-9][0-9]{13}|[3-6][0-9]{14}|7[0-1][0-9]{13}|720[0-9]{12}))$" },
        { "American Express", @"^3[47][0-9]{13}$" },
        { "Diners Club", @"^3(?:0[0-5]|[68][0-9])[0-9]{11}$" },
        { "Discover", @"^6(?:011|5[0-9]{2})[0-9]{12}$" },
        { "enRoute", @"^(2014|2149)[0-9]{11}$" },
        { "JCB", @"^(?:2131|1800|35\d{3})\d{11}$" },
        { "Voyager", @"^8699[0-9]{11}$" },
        { "HiperCard", @"^606282[0-9]{10}$" },
        { "Aura", @"^50[0-9]{14}$" }
    };

    public static string IdentifyBrand(string cardNumber)
    {
        string cleanNumber = Regex.Replace(cardNumber, @"[^\d]", "");

        foreach (var rule in BrandRules)
        {
            if (Regex.IsMatch(cleanNumber, rule.Value)) return rule.Key;
        }

        return "Bandeira não identificada ou número inválido.";
    }
}