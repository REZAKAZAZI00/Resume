namespace Resume.Core.Services.InterFace;

public interface IUserService
{
    Task<OutPutModel<bool>> Create(CreateUserViewModel model);

    Task<OutPutModel<bool>> UpdateAsync(EditUserViewModel model);

    Task<EditUserViewModel> GetUserForEditByIdAsync(int id);
    Task<UserInfoViewModel> GetUserForShowAsync();

    Task<FilterUserViewModel> FilterAsync(FilterUserViewModel filter);

    Task<OutPutModel<bool>> LoginAsync(LoginViewModel model);

    Task<bool> DuplicatedPhoneAsync(int id, string phone);
    Task<bool> DuplicatedEmailAsync(int id, string email);


    Task<User> GetUserByEmailAsync(string email);





}

