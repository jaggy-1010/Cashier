using Cashier;

// Console.WriteLine("*dd**************************************");
Console.WriteLine("* K A S A *");
// Console.WriteLine("* Wprowadzaj kolejne pozycje zgodnie  *");
// Console.WriteLine("* z ich wartością.                    *");
// Console.WriteLine("* Aby zakończyć naciśnij q ( lub Q ). *");
// Console.WriteLine("***************************************");
Console.WriteLine();

var trimmedNick = trimmNick();

var cashierInFile = new CashierInFile(trimmedNick);
Console.WriteLine("---");

AddItemsValuesToFile(cashierInFile);

static string trimmNick()
{
    Console.Write("Wprowadź nick kasjera: ");
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

static void AddItemsValuesToFile(CashierInFile cashierInFile)
{
    
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
}


var globalStatistics = cashierInFile.GetStatistics();
Console.WriteLine("---");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Statystyki sklepu (wszystkich kasjerów):");
Console.ResetColor();
Console.Write($"Ilość artykułów:\t\t{globalStatistics.Count}\t\t\t");
Console.WriteLine($"Suma artykułów:\t\t\t{globalStatistics.Sum:N2}");
Console.Write($"Najtańszy artykuł:\t\t{globalStatistics.Min:N2}\t\t\t");
Console.WriteLine($"Najdroższy artykuł:\t\t{globalStatistics.Max:N2}");
Console.Write($"Średnia wartość artykułu:\t{globalStatistics.Average:N2}\t\t\t");
if (globalStatistics.GlobalTradeLevelInLetters == 'F')
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Poziom sprzedaży sklepu :\t{globalStatistics.GlobalTradeLevelInLetters}");
    Console.ResetColor();
}
else
{
    Console.WriteLine($"Poziom sprzedaży sklepu:\t{globalStatistics.GlobalTradeLevelInLetters}");
}

var cashierStatistics = cashierInFile.GetCashierStatistics();
Console.WriteLine("---");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"Statystyki kasjera {trimmedNick}:");
Console.ResetColor();
Console.Write($"Ilość artykułów:\t\t{cashierStatistics.Count}\t\t\t");
Console.WriteLine($"Suma artykułów:\t\t\t{cashierStatistics.Sum:N2}");
Console.Write($"Najtańszy artykuł:\t\t{cashierStatistics.Min:N2}\t\t\t");
Console.WriteLine($"Najdroższy artykuł:\t\t{cashierStatistics.Max:N2}");
Console.Write($"Średnia wartość artykułu:\t{cashierStatistics.Average:N2}\t\t\t");
if (cashierStatistics.CashierTradeLevelInLetters == 'F')
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Poziom sprzedaży kasjera:\t{cashierStatistics.CashierTradeLevelInLetters}");
    Console.ResetColor();
}
else
{
    Console.WriteLine($"Poziom sprzedaży kasjera:\t{cashierStatistics.CashierTradeLevelInLetters}");
}

Console.WriteLine();
Console.WriteLine("--------------------------------------------------------------------------");

Console.WriteLine("Podaj nick kasjera:");
string input = Console.ReadLine();

var cashierInMemory = new CashierInMemory(input);
Console.WriteLine("---");

AddItemsValuesToMemory(cashierInMemory);

static void AddItemsValuesToMemory(CashierInMemory cashierInMemory)
{
    
    while (true)
    {
        Console.Write("Wprowadź kolejną pozycję: ");
        var input = Console.ReadLine();

        if (input == "q" || input == "Q")
        {
            if (!cashierInMemory.HasPrice())
            {
                Console.WriteLine("\nNie dodano żadnej pozycji!");
            }

            break;
        }

        try
        {
            cashierInMemory.AddPrice(input);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception catched: {e.Message}");
        }
    }
}


var statistics = cashierInMemory.GetStatistics();

Console.WriteLine("---");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"Statystyki kasjera : {input}");
Console.ResetColor();
Console.Write($"Ilość artykułów:\t\t{statistics.Count}\t\t\t");
Console.WriteLine($"Suma artykułów:\t\t\t{statistics.Sum:N2}");
Console.Write($"Najtańszy artykuł:\t\t{statistics.Min:N2}\t\t\t");
Console.WriteLine($"Najdroższy artykuł:\t\t{statistics.Max:N2}");
Console.Write($"Średnia wartość artykułu:\t{statistics.Average:N2}\t\t\t");
if (globalStatistics.GlobalTradeLevelInLetters == 'F')
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Poziom sprzedaży kasjera :\t{statistics.GlobalTradeLevelInLetters}");
    Console.ResetColor();
}
else
{
    Console.WriteLine($"Poziom sprzedaży sklepu:\t{globalStatistics.GlobalTradeLevelInLetters}");
}


