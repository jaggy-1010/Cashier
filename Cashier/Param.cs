namespace Cashier;

public class Param
{
    // CONFIG:
    
    // Data Files -> CashierInFile
    public const string GLOBAL_CASH_VALUES = "globalCashValues.txt";
    public const string CASHIER_CASH_VALUES = "cashValues.txt";
    public const string GLOBAL_CASH_LOG = "globalCashLog.txt";
    
    // Trade levels -> Statistics
    public const double HIGH_LEVEL = 10000.0;
    public const double UPPER_MIDDLE_LEVEL = 5000.0;
    public const double MIDDLE_LEVEL = 2000.0;
    public const double STANDARD_LEVEL = 1000.0;
    public const double LOW_LEVEL = 200.0;
    
    // Trade levels by letters -> Statistics
    public const char TRADE_LEVEL_A = 'A';
    public const char TRADE_LEVEL_B = 'B';
    public const char TRADE_LEVEL_C = 'C';
    public const char TRADE_LEVEL_D = 'D';
    public const char TRADE_LEVEL_E = 'E';
    public const char TRADE_LEVEL_F = 'F';
    
    // Constant discount prices -> CashierInFile
    public const double SUGAR = 1.20;
    public const double BREAD = 1.50;
    public const double MILK = 1.50;
    public const double BUTTER = 2.50;
    public const double RICE = 1.00;
    public const double SEMOLINA = 1.20;
    public const double FLOUR = 1.30;
    public const double EGGS = 4.00;
}
