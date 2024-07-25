namespace Cashier;

public abstract class CashierBase : ICashier
{
    public CashierBase(string cashierNick)
    {
        this.CashierNick = cashierNick;
    }
    public string CashierNick {get; private set;}

    public abstract Statistics GetStatistics();
    // public abstract Statistics GetCashierStatistics(); 
    public abstract void AddPrice(double price);
    public abstract void AddPrice(string price);
    public abstract void AddPrice(char price);
    public abstract void AddPrice(int price);
    public abstract void AddPrice(float price);
    public abstract bool HasPrice();
    public delegate void PriceAddedDelegate(object sender, EventArgs args);
    public abstract event PriceAddedDelegate PriceAdded;
}