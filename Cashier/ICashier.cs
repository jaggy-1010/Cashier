using static Cashier.CashierBase;

namespace Cashier;

public interface ICashier
{
    string CashierNick { get; }

    Statistics GetStatistics();
    void AddPrice(double price);
    void AddPrice(string price);
    void AddPrice(char price);
    void AddPrice(int price);
    void AddPrice(float price);
    bool HasPrice();
    void ViewEnteredCheckoutPrices();
    // delegate void PriceAddedDelegate();
    event PriceAddedDelegate PriceAdded;
}