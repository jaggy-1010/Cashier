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



}