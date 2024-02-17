namespace ExpenseTracker.Utilities
{
    public static class DateTimeExtensions
    {
        // Keeps date format consistent across culture's
        public static string ToCustomShortDateString(this DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy");
        }
    }
}