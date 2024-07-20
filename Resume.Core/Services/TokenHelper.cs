namespace Resume.Core.Services;

public class TokenHelper : ITokenHelperService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TokenHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public void GenerateToken(User user)
    {
      

      var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.MobilePhone, user.Phone)
            };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var principal = new ClaimsPrincipal(identity);
        var properties = new AuthenticationProperties
        {
            IsPersistent = true,
        };

        _httpContextAccessor.HttpContext.SignInAsync( principal, properties);

    }
}
