namespace Cashier;

public class CashierInMemory : CashierBase
{
    private List<double> prices = new List<double>();

    public CashierInMemory(string cashierNick) : base(cashierNick)
    {
    }

    public override void AddPrice(double price)
    {
        if (price > 0)
        {
            this.prices.Add(price);
        }
        else
        {
            throw new Exception("Wartość wprowadzana musi być wieksza od 0.00");
        }
    }

    public override void AddPrice(string price)
    {
        if(price != null)
        {
            if(double.TryParse(price, out double result))
            {
                this.AddPrice(result);
            }
            else if (price.Length == 1)
            {
                var result1 = Convert.ToChar(price);
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

        foreach (var price in prices)
        {
            statistics.AddPrice(price);
        }
        return statistics;
    }

    public Statistics GetCashierStatistics()
    {
        throw new NotImplementedException();
    }

    public override bool HasPrice()
    {
        if (prices.Count != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}