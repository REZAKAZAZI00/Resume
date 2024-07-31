namespace Resume.Core.Services;

public class UserService : IUserService
{
    #region Fields
    private readonly ITokenHelperService _tokenHelperService;
    private readonly ILogger<UserService> _logger;
    private readonly ResumeDbContext _context;
    #endregion


    #region Constructor

    public UserService(ResumeDbContext context, ILogger<UserService> logger, ITokenHelperService tokenHelperService)
    {
        _context = context;
        _logger = logger;
        _tokenHelperService = tokenHelperService;
    }


    #endregion

    #region Methods
    public async Task<OutPutModel<bool>> Create(CreateUserViewModel model)
    {
        try
        {
            string email = FixedText.FexedEmail(model.Email);
            var newUser = new User
            {
                CreateDate = DateTime.Now,
                Email = email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                IaActive = model.IaActive,
                Password = PasswordHelper.EncodePasswordSHA256(model.Password),
                Phone = model.Phone
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new OutPutModel<bool>
            {
                Message = "",
                Result = true,
                StatusCode = 200,
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool> 
            {
                  StatusCode=500,
                  Result = false,
                Message = "خطای غیرمنتظره ای رخ داد مجدد تلاش کنید",

            };
        }

    }

    public async Task<EditUserViewModel> GetUserForEditByIdAsync(int id)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
                return null;


            return new EditUserViewModel
            {
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Phone = user.Phone,
                IaActive = user.IaActive,
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }

    public async Task<OutPutModel<bool>> UpdateAsync(EditUserViewModel model)
    {
        try
        {
            var user = await _context.Users.FindAsync(model.Id);

            if (user is null)
                return new OutPutModel<bool>
                {
                     StatusCode=404,
                     Result = false,
                     Message="کاربری پیدا نشد."
                };

            string email = FixedText.FexedEmail(model.Email);
            if (await DuplicatedEmailAsync(user.Id, email))
                return new OutPutModel<bool>
                {
                    Result = false,
                    StatusCode = 409,
                    Message = "ایمیل تکراری است."
                };

            if (await DuplicatedPhoneAsync(user.Id, model.Phone))
                return new OutPutModel<bool>
                {
                    Result = false,
                    StatusCode = 409,
                    Message = "شماره تلفن تکراری است."
                };

            user.Email = email;
            user.IaActive = model.IaActive;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.BirthDate = model.BirthDate;
            user.Phone = model.Phone;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return new OutPutModel<bool>
            {
                 Result = true, 
                 Message=""  ,
                 StatusCode=200,

            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                 StatusCode= 500,
                 Result = false,
                Message = "خطای غیرمنتظره ای رخ داد مجدد تلاش کنید",

            };
        }
    }
    public async Task<bool> DuplicatedPhoneAsync(int id, string phone)
    {
        return await _context.Users
            .AsNoTracking()
            .AnyAsync(u => u.Id != id && u.Phone == phone);
    }
    public async Task<bool> DuplicatedEmailAsync(int id, string email)
    {
        return await _context.Users
        .AsNoTracking()
           .AnyAsync(u => u.Id != id && u.Email == email);
    }

    public async Task<FilterUserViewModel> FilterAsync(FilterUserViewModel filter)
    {
        try
        {
            var query = _context.Users
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.Email))
                query = query.Where(u => EF.Functions.Like(u.Email,$"%{filter.Email}%"));

            if (!string.IsNullOrEmpty(filter.Phone))
                query = query.Where(u => EF.Functions.Like(u.Phone,$"%{filter.Phone}%"));

            await filter.Paging(query
                .Select(u => new UserDetailsViewModel
                {
                    Phone = u.Phone,
                    BirthDate = u.BirthDate,
                    CreateDate = u.CreateDate,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    IaActive = u.IaActive,
                    Id = u.Id,
                }));

            return filter;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }

    public async Task<OutPutModel<bool>> LoginAsync(LoginViewModel model)
    {
        try
        {
            string email = FixedText.FexedEmail(model.Email);
            string hashPassword = PasswordHelper.EncodePasswordSHA256(model.Password);

            var user = await GetUserByEmailAsync(email);
            
            if (user.Password != hashPassword)
                return new OutPutModel<bool>
                {
                     Message="کاربری یافت نشد.",
                     Result=false,
                      StatusCode=404,
                };


            if (user is null)
                return new OutPutModel<bool>
                {
                    StatusCode = 404,
                    Message = "کاربری پیدا نشد",
                    Result = false
                };

            _tokenHelperService.GenerateToken(user);
            return new OutPutModel<bool>
            {
                StatusCode = 200,
                Message = "",
                Result = true,
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {

                StatusCode = 500,
                Result = false,
                Message = "خطای غیرمنتظره ای رخ داد مجدد تلاش کنید",

            };

        }
    }
    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users
            .Where(u => u.Email == email)
            .SingleOrDefaultAsync();
    }

    public async Task<UserInfoViewModel> GetUserForShowAsync()
    {
        try
        {
             var user=await _context.Users
                .Include(a=> a.AboutMe)
                .Select(u=> new UserInfoViewModel
                {
                     BirthDate = u.BirthDate,
                     CreateDate = u.CreateDate,
                     Email = u.Email,
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     IaActive = u.IaActive,
                     Phone = u.Phone,
                     Id = u.Id,
                     Bio=u.AboutMe.Bio,
                     Position=u.AboutMe.Position,
                     Location= u.AboutMe.Location,
                     PictureName = u.AboutMe.PictureName,
                }).SingleOrDefaultAsync();
            return user;
               
                
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }
    #endregion
}
