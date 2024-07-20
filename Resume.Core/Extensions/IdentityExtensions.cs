
namespace Resume.Core.Extensions;
public static class IdentityExtensions
{
    public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal == null)
            return default;

        if (claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier) == null)
            return default;

        string? userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return default;
        else
            return int.Parse(userId);
    }

    public static int GetUserId(this IPrincipal principal)
    {
        if (principal == null)
            return default;

        var user = (ClaimsPrincipal)principal;

        return user.GetUserId();
    }

    public static string GetEmail(this ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal != null)
            return claimsPrincipal.FindFirst(ClaimTypes.Email).Value.ToString();

        return "";
    }

    public static string GetMobilePhone(this ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal != null)
            return claimsPrincipal.FindFirst(ClaimTypes.MobilePhone).Value.ToString();

        return "";
    }
}
