using System;

namespace Model.Domain.DbHelper
{
    public class QuarterCalculator
    {
        public static int GetQuarter(DateTime date)
        {
            return (date.Month + 2)/3;
        }
        
        public static int GetFinancialQuarter(DateTime date)
        {
            return (date.AddMonths(-3).Month + 2)/3;
        }
    }
}