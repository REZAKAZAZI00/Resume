namespace Resume.Core.Services;

public class UserService: IUserService
{
    #region Fields
    private readonly ILogger<UserService> _logger;
    private readonly ResumeDbContext _context;
    #endregion


    #region Constructor

    public UserService(ResumeDbContext context, ILogger<UserService> logger)
    {
        _context = context;
        _logger = logger;
    }


    #endregion

    #region Methods
    public async Task<CreateUserResult> Create(CreateUserViewModel model)
    {
        try
        {
            var newUser = new User
            {
               CreateDate = DateTime.Now,
               Email = model.Email,
               FirstName = model.FirstName,
               LastName = model.LastName,
               BirthDate = model.BirthDate,
               IaActive = model.IaActive,
               Password = PasswordHelper.EncodePasswordSHA256(model.Password),
               Phone = model.Phone
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            
            return CreateUserResult.Success;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message,ex);    
            return CreateUserResult.Error;
        }

    }
    #endregion
}
