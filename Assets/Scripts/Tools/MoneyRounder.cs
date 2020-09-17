using System;

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
