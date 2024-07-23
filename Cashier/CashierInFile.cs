namespace Cashier;

public class CashierInFile // : CashierBase 
{
    private string cashierNick;
    private string cashierFileName;


    public string CashierNick { get; private set; }


    public CashierInFile(string cashierNick)
    {
        this.CashierNick = cashierNick;
        cashierFileName = ($"{cashierNick.ToLower()}_{Param.CASHIER_CASH_VALUES}");
    }
    

    private int counter = 0;

    public void AddPrice(double price)
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

    public void AddPrice(string price)
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

    public void AddPrice(int price)
    {
        double result = price;
        this.AddPrice(result);
    }
    
    public void AddPrice(float price)
    {
        double result = price;
        this.AddPrice(result);
    }

    public void AddPrice(char price)
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

    public bool HasPrice()
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