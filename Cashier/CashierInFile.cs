namespace Cashier;

public class CashierInFile  : CashierBase // : ICashier 
{
    private string cashierFileName;
    
    public CashierInFile(string cashierNick) : base(cashierNick)
    {
        // this.CashierNick = cashierNick;
        cashierFileName = ($"{cashierNick.ToLower()}_{Param.CASHIER_CASH_VALUES}");
    }
   

    private int counter = 0;

    public override void AddPrice(double price)
    {
        using (var cashWriter = File.AppendText(Param.GLOBAL_CASH_VALUES))
        using (var cashierWriter = File.AppendText($"{cashierFileName}"))
        using (var logWriter = File.AppendText(Param.GLOBAL_CASH_LOG))
        {
            if (price > 0)
            {
                cashWriter.WriteLine("{0:0.00}", price);
                cashierWriter.WriteLine("{0:0.00}",price);
                logWriter.WriteLine($"{DateTime.Now}\t-\t{CashierNick}\t-\t{price.ToString("0.00")}\t-\t{cashierFileName}\t-\t{Param.GLOBAL_CASH_VALUES}");
                counter++;
            }
            else
            {
                throw new Exception("Acceptable values greater then 0.00");
            }
        }
    }

    public override void AddPrice(string price)
    {
        if (price != null)
        {
            if (double.TryParse(price, out double result))
            {
                this.AddPrice(result);
            }
            else if (price.Length == 1)
            {
                char result1 = Convert.ToChar(price);
                this.AddPrice(result1);
            }
            else
            {
                throw new Exception("Nieprawidłowa wartość, wprowadź liczbę lub kod zniżkowy C,P,M,T,R,K,W lub J.");
            }
        }
        else
        {
            throw new Exception("Błąd programu! Zadzwoń do terapeuty.");
        }
    }

    public override void AddPrice(int price)
    {
        double result = price;
        this.AddPrice(result);
    }
    
    public override void AddPrice(float price)
    {
        double result = price;
        this.AddPrice(result);
    }

    public override void AddPrice(char price)
    {
        switch (price)
        {
            case 'C':
            case 'c':
                this.AddPrice(Param.SUGAR);
                break;
            case 'P':
            case 'p':
                this.AddPrice(Param.BREAD);
                break;
            case 'M':
            case 'm':
                this.AddPrice(Param.MILK);
                break;
            case 'T':
            case 't':
                this.AddPrice(Param.BUTTER); 
                break;
            case 'R':
            case 'r':
                this.AddPrice(Param.RICE);
                break;
            case 'K':
            case 'k':
                this.AddPrice(Param.SEMOLINA); 
                break;
            case 'W':
            case 'w':
                this.AddPrice(Param.FLOUR);
                break;
            case 'J':
            case 'j':
                this.AddPrice(Param.EGGS);
                break;
            default:
                throw new Exception("Nieprawidłowa wartość, wprowadź liczbę lub kod zniżkowy C,P,M,T,R,W lub J.");
        }
    }

    public override Statistics GetStatistics()
    {
        var statistics = new Statistics();
        if (File.Exists(Param.GLOBAL_CASH_VALUES))
        {
            using (var reader = File.OpenText(Param.GLOBAL_CASH_VALUES))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    counter++;
                    var price = double.Parse(line);
                    statistics.AddPrice(price);
                    line = reader.ReadLine();
                }
            }
        }

        return statistics;
    }

    public override Statistics GetCashierStatistics()
    {
        var statistics = new Statistics();
        if (File.Exists($"{cashierFileName}"))
        {
            using (var reader = File.OpenText($"{cashierFileName}"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    counter++;
                    var price = double.Parse(line);
                    statistics.AddPrice(price);
                    line = reader.ReadLine();
                }
            }
        }

        return statistics;
    }
    
    public override bool HasPrice()
    {
        if (counter != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}