using Cashier;

Param.CashWelcome();

//C A S H I E R  I N  F I L E

var trimmedNick = Param.TrimmNick();

var cashierInFile = new CashierInFile(trimmedNick);

Param.CashHeader();

AddItemsValuesToFile(cashierInFile);

static void AddItemsValuesToFile(CashierInFile cashierInFile)
{
    cashierInFile.PriceAdded += CashierInFilePriceAdded;
    void CashierInFilePriceAdded(object sender, EventArgs args)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Artykuł skasowany.");
        // Console.WriteLine("To jest Pan Delegant z powiatu:");
        // Console.WriteLine("https://www.youtube.com/watch?v=V-QGKoCI1eM");
        Console.ResetColor();
    }
    
    while (true)
    {
        Console.Write("Wprowadź kolejny artykuł: ");
        var input = Console.ReadLine();

        if (input == "q" || input == "Q")
        {
            if (!cashierInFile.HasPrice())
            {
                Console.WriteLine("\nNie dodano żadnego artykułu!");
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

Console.WriteLine();
Console.WriteLine("---");
cashierInFile.ShowGlobalInputs();
var globalStatistics = cashierInFile.GetStatistics();
Console.WriteLine();
Console.WriteLine("---");
Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("Statystyki sklepu:");
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
Console.WriteLine();
Console.WriteLine("---");
cashierInFile.ViewStatistics(trimmedNick);

// C A S H I E R  I N  M E M O R Y

Console.WriteLine();
Console.WriteLine("---");
trimmedNick = Param.TrimmNick();
var cashierInMemory = new CashierInMemory(trimmedNick);
Param.CashHeader();

AddItemsValuesToMemory(cashierInMemory);

static void AddItemsValuesToMemory(CashierInMemory cashierInMemory)
{
    cashierInMemory.PriceAdded += CashierInMemoryPriceAdded;
    void CashierInMemoryPriceAdded(object sender, EventArgs args)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Artykuł skasowany.");
        // Console.WriteLine("To jest Pan Delegant z powiatu:");
        // Console.WriteLine("https://www.youtube.com/watch?v=V-QGKoCI1eM");
        Console.ResetColor();
    }
    
    while (true)
    {
        Console.Write("Wprowadź kolejny artykuł: ");
        var input = Console.ReadLine();

        if (input == "q" || input == "Q")
        {
            if (!cashierInMemory.HasPrice())
            {
                Console.WriteLine("\nNie dodano żadnego artykułu!");
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

Console.WriteLine();
Console.WriteLine("---");
cashierInMemory.ViewStatistics(trimmedNick);
Param.ByeBye();