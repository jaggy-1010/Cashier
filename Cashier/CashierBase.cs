namespace Cashier;

public abstract class CashierBase : ICashier
{
    public CashierBase(string cashierNick)
    {
        this.CashierNick = cashierNick;
    }
    public string CashierNick {get; private set;}

    public abstract Statistics GetStatistics();
    public abstract Statistics GetCashierStatistics();
    public abstract void AddPrice(double price);
    public abstract void AddPrice(string price);
    public abstract void AddPrice(char price);
    public abstract void AddPrice(int price);
    public abstract void AddPrice(float price);
    public abstract bool HasPrice();

    public virtual void ViewEnteredCheckoutPrices()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Skasowane artykuły:");
        Console.ResetColor();
    }

    // public virtual void ViewEnteredCheckoutPrices(string fileName)
    // {
    //     
    // }

    public void ViewStatistics(string trimmedNick)
    {
        ViewEnteredCheckoutPrices();
        Console.WriteLine();
        var statistics = GetCashierStatistics();
        Console.WriteLine("---");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Statystyki kasjerki/kasjera << {trimmedNick} >>:");
        Console.ResetColor();
        Console.Write($"Ilość artykułów:\t\t{statistics.Count}\t\t\t");
        Console.WriteLine($"Suma artykułów:\t\t\t{statistics.Sum:N2}");
        Console.Write($"Najtańszy artykuł:\t\t{statistics.Min:N2}\t\t\t");
        Console.WriteLine($"Najdroższy artykuł:\t\t{statistics.Max:N2}");
        Console.Write($"Średnia wartość artykułu:\t{statistics.Average:N2}\t\t\t");
        if (statistics.CashierTradeLevelInLetters == 'F')
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Poziom sprzedaży kasjera:\t{statistics.CashierTradeLevelInLetters}");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"Poziom sprzedaży kasjera:\t{statistics.CashierTradeLevelInLetters}");
        }
    }

    public void ViewStatistics()
    {
        
        var statistics = GetStatistics();
        Console.WriteLine();
        Console.WriteLine("---");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Statystyki sklepu:");
        Console.ResetColor();
        Console.Write($"Ilość artykułów:\t\t{statistics.Count}\t\t\t");
        Console.WriteLine($"Suma artykułów:\t\t\t{statistics.Sum:N2}");
        Console.Write($"Najtańszy artykuł:\t\t{statistics.Min:N2}\t\t\t");
        Console.WriteLine($"Najdroższy artykuł:\t\t{statistics.Max:N2}");
        Console.Write($"Średnia wartość artykułu:\t{statistics.Average:N2}\t\t\t");
        if (statistics.GlobalTradeLevelInLetters == 'F')
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Poziom sprzedaży sklepu :\t{statistics.GlobalTradeLevelInLetters}");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"Poziom sprzedaży sklepu:\t{statistics.GlobalTradeLevelInLetters}");
        } 
    }
    public delegate void PriceAddedDelegate(object sender, EventArgs args);
    public abstract event PriceAddedDelegate PriceAdded;
}