using Cashier;

Console.WriteLine("***************************************");
Console.WriteLine("* Witamy w obsłudze kasy.             *");
Console.WriteLine("* Wprowadzaj kolejne pozycje zgodnie  *");
Console.WriteLine("* z ich wartością.                    *");
Console.WriteLine("* Aby zakończyć naciśnij q ( lub Q ). *");
Console.WriteLine("***************************************");
Console.WriteLine();
Console.Write("Wprowadź nick kasjera: ");
var inputNick = Console.ReadLine();
var nickLength = inputNick.Length;
string trimmedNick = "";
if (nickLength != 0)
{
    char[] charSeparator = new char[] { ' ' };
    string[] results;
    results = inputNick.Split(charSeparator, StringSplitOptions.TrimEntries);
    int nickArrayLength = results.Length;

    for (int i = 0; i < nickArrayLength; i++)
    {
        trimmedNick += results[i];
        // if (i < nickArrayLength - 1)
            // trimmedNick += "_";
    }
}

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

// var globalStatistics = cashierInFile.GetStatistics();
// globalStatistics.Count;
// globalStatistics.Sum;
// globalStatistics.Min;
// globalStatistics.Max;
// globalStatistics.Average;
// globalStatistics.TradeLevel;
