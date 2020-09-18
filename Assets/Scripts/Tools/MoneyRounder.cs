using System;

/// <summary>
/// Tool to Return a human readable value for Thousands and Millions of Dollars
/// </summary>
public static class MoneyRounder
{
    public static string GetMoneyRoundedToNearestPower(long unitValue) {
        if (unitValue >= 1000) {
            if (unitValue >= 1000000) {
                return $"{unitValue / 1000000} Million";
            }
            return $"{unitValue / 1000} Thousand";
        }
        return String.Empty;
    }
}
