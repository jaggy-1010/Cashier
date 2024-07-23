using Cashier;

Console.WriteLine("***************************************");
Console.WriteLine("* Witamy w obsłudze kasy.             *");
Console.WriteLine("* Wprowadzaj kolejne pozycje zgodnie  *");
Console.WriteLine("* z ich wartością.                    *");
Console.WriteLine("* Aby zakończyć naciśnij q ( lub Q ). *");
Console.WriteLine("***************************************");
Console.WriteLine();
Console.Write("Wprowadź nick kasjera: ");

static string trimmNick()
{
    string trimmedNick = "";
    var inputNick = Console.ReadLine();
    var nickLength = inputNick.Length;
    if (nickLength != 0)
    {
        char[] charSeparator = new char[] { ' ' };
        string[] results;
        results = inputNick.Split(charSeparator, StringSplitOptions.TrimEntries);
        int nickArrayLength = results.Length;

        for (int i = 0; i < nickArrayLength; i++)
        {
            trimmedNick += results[i];
        }
    }

    return trimmedNick;
}

var trimmedNick = trimmNick();

var cashierInFile = new CashierInFile(trimmedNick);

while (true)
{
    Console.Write("Wprowadź kolejną pozycję: ");
    var input = Console.ReadLine();

    if (input == "q" || input == "Q")
    {
        if (!cashierInFile.HasPrice())
        {
            Console.WriteLine("\nNie dodano żadnej pozycji!");
        }
        break;
    }
    
    try
    {
        cashierInFile.AddPrice(input);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception catched: {e.Message}");
    }
}

var globalStatistics = cashierInFile.GetStatistics();
Console.WriteLine($"Ilość artykułów:\t\t{globalStatistics.Count}");
Console.WriteLine($"Suma artykułów:\t\t\t{globalStatistics.Sum:N2}");
Console.WriteLine($"Najtańszy artykuł:\t\t{globalStatistics.Min:N2}");
Console.WriteLine($"Najdroższy artykuł:\t\t{globalStatistics.Max:N2}");
Console.WriteLine($"Średnia wartość artykułu:\t{globalStatistics.Average:N2}");
Console.WriteLine($"Poziom sprzedaży sklepu:\t{globalStatistics.GlobalTradeLevelInLetters}");

var cashierStatistics = cashierInFile.GetCashierStatistics();
Console.WriteLine();
Console.WriteLine($"Ilość artykułów:\t\t{cashierStatistics.Count}");
Console.WriteLine($"Suma artykułów:\t\t\t{cashierStatistics.Sum:N2}");
Console.WriteLine($"Najtańszy artykuł:\t\t{cashierStatistics.Min:N2}");
Console.WriteLine($"Najdroższy artykuł:\t\t{cashierStatistics.Max:N2}");
Console.WriteLine($"Średnia wartość artykułu:\t{cashierStatistics.Average:N2}");
Console.WriteLine($"Poziom sprzedaży kasjera:\t{cashierStatistics.CashierTradeLevelInLetters}");

    
