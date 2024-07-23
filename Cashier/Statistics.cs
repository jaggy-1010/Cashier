namespace Cashier;

public class Statistics
{
    private double _min;
    private double _max; 
    
    public double Min 
    {
        get
        {
            if (this.Count == 0)
            {
                return 0;
            }
            else
            {
                return _min;
            }
        }
        set
        {
            _min = value;
        }
    }

    public double Max 
    {
        get
        {
            if (this.Count == 0)
            {
                return 0;
            }
            else
            {
                return _max;
            }
        }
        set
        {
            _max = value;
        }
    }
    public double Sum { get; set; }
    public int Count { get; set; }
    public double Average
    {
        get
        {
            if (this.Count != 0)
            {
                return this.Sum / this.Count;
            }
            else
            {
                return 0;
            }
        }
    }
    public char GlobalTradeLevelInLetters
    {
        get
        {
            switch(this.Sum)
            {
                case var sum when sum >= Param.HIGH_LEVEL:
                    return Param.TRADE_LEVEL_A;
                case var sum when sum >= Param.UPPER_MIDDLE_LEVEL:
                    return Param.TRADE_LEVEL_B;
                case var sum when sum>= Param.MIDDLE_LEVEL:
                    return Param.TRADE_LEVEL_C;
                case var sum when sum >= Param.STANDARD_LEVEL:
                    return Param.TRADE_LEVEL_D;
                case var sum when sum >= Param.LOW_LEVEL:
                    return Param.TRADE_LEVEL_E;
                default:
                    return Param.TRADE_LEVEL_F;
            }
        }
    }
    
    public char CashierTradeLevelInLetters
    {
        get
        {
            switch(this.Sum)
            {
                case var sum when sum >= Param.CASHIER_HIGH_LEVEL:
                    return Param.TRADE_LEVEL_A;
                case var sum when sum >= Param.CASHIER_UPPER_MIDDLE_LEVEL:
                    return Param.TRADE_LEVEL_B;
                case var sum when sum>= Param.CASHIER_MIDDLE_LEVEL:
                    return Param.TRADE_LEVEL_C;
                case var sum when sum >= Param.CASHIER_STANDARD_LEVEL:
                    return Param.TRADE_LEVEL_D;
                case var sum when sum >= Param.CASHIER_LOW_LEVEL:
                    return Param.TRADE_LEVEL_E;
                default:
                    return Param.TRADE_LEVEL_F;
            }
        }
    }
    public Statistics()
    {
        this.Count = 0;
        this.Sum = 0;
        this.Min = double.MaxValue;
        this.Max = double.MinValue;
    }

    public void AddPrice(double score)
    {
        this.Count++;
        this.Sum += score;
        this.Min = Math.Min(score, this.Min);
        this.Max = Math.Max(score, this.Max);
    }
}