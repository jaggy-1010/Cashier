namespace Cashier;

public static class Param
{
    // CONFIG:

    // Data Files -> CashierInFile
    public const string GLOBAL_CASH_VALUES = "globalCashValues.txt";
    public const string CASHIER_CASH_VALUES = "cashValues.txt";
    public const string GLOBAL_CASH_LOG = "globalCashLog.txt";

    // Global trade levels -> Statistics
    public const double HIGH_LEVEL = 100000.0;
    public const double UPPER_MIDDLE_LEVEL = 50000.0;
    public const double MIDDLE_LEVEL = 20000.0;
    public const double STANDARD_LEVEL = 10000.0;
    public const double LOW_LEVEL = 2000.0;

    // Cashier trade levels -> Statistics
    public const double CASHIER_HIGH_LEVEL = 10000.0;
    public const double CASHIER_UPPER_MIDDLE_LEVEL = 5000.0;
    public const double CASHIER_MIDDLE_LEVEL = 2000.0;
    public const double CASHIER_STANDARD_LEVEL = 1000.0;
    public const double CASHIER_LOW_LEVEL = 200.0;

    // Trade levels by letters -> Statistics
    public const char TRADE_LEVEL_A = 'A';
    public const char TRADE_LEVEL_B = 'B';
    public const char TRADE_LEVEL_C = 'C';
    public const char TRADE_LEVEL_D = 'D';
    public const char TRADE_LEVEL_E = 'E';
    public const char TRADE_LEVEL_F = 'F';

    // Constant discount prices -> CashierInFile, CashierInMemory
    public const double SUGAR = 1.20; // Cukier -> C, c
    public const double BREAD = 1.50; // Pieczywo -> P, p
    public const double MILK = 1.50; // Mleko -> M, m
    public const double BUTTER = 2.50; // Tłuszcz -> T, t
    public const double RICE = 1.00; // Ryż -> R, r
    public const double SEMOLINA = 1.20; // Kaszka manna -> K, k
    public const double FLOUR = 1.30; // Wypieki(mąka) -> W, w
    public const double EGGS = 4.00; // Jajka -> J, j

    // MESSAGES:

    public static void CashWelcome()
    {
        Console.WriteLine();
        Console.WriteLine("            Obsługa");
        Console.WriteLine("            K A S Y");
        Console.WriteLine();
    }

    public static void CashHeader()
    {
        Console.WriteLine("---");
        Console.WriteLine("Kody zniżkowe: C(cukier), P(pieczywo), M(mleko), T(tłuszcz, masło), R(ryż), K(k. manna), W(mąka), J(jajka)");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Koniec pracy i wyświetlenie wprowadzonych pozycji: Q(q).");
        Console.ResetColor();
    }

    public static void ByeBye()
    {
        Console.WriteLine("Koniec pracy.");
        Console.WriteLine("Naciśnij dowolny klawisz.");
        Console.ReadKey();
    }

    public static void AllCashiersHeader()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("W S Z Y S C Y  K A S J E R Z Y:");
        Console.ResetColor();
        Console.WriteLine("---");
    }

    public static void CashierHeader(string trimmedNick)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"K A S J E R K A / K A S J E R << {trimmedNick} >>:");
        Console.ResetColor();
        Console.WriteLine("---");
        
    }
    
    // TOOLS:

    public static string TrimmNick()
    {
        string trimmedNick = "";
        string inputNick = "";
        while (inputNick.Length == 0)
        {
            Console.Write("Wprowadź nick kasjerki/kasjera: ");
            inputNick = Console.ReadLine();
        }

        char[] charSeparator = new char[] { ' ' };
        string[] results;
        results = inputNick.Split(charSeparator, StringSplitOptions.TrimEntries);
        int nickArrayLength = results.Length;

        for (int i = 0; i < nickArrayLength; i++)
        {
            trimmedNick += results[i];
        }

        trimmedNick = trimmedNick.ToUpper();

        return trimmedNick;
    }

}