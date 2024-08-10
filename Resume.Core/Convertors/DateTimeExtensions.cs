global using System.Globalization;

namespace Resume.Core.Convertors;
public static class DateTimeExtensions
{

    public static string ToCustomString(this DateOnly dateTime)
    {
        return dateTime.ToString("MMMM yyyy", CultureInfo.InvariantCulture);
    } 
    public static string ToCustomString(this DateTime dateTime)
    {
        return dateTime.ToString("MMMM yyyy", CultureInfo.InvariantCulture);
    }public static string ToCustom(this DateTime dateTime)
    {
        return dateTime.ToString("dd MMM, yyyy ", CultureInfo.InvariantCulture);
    }
}

