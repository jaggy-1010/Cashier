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
}
