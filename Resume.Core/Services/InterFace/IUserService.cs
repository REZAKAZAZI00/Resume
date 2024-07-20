namespace Resume.Core.Services.InterFace;

public interface IUserService
{
    Task<OutPutModel<bool>> Create(CreateUserViewModel model);

    Task<OutPutModel<bool>> UpdateAsync(EditUserViewModel model);

    Task<EditUserViewModel> GetUserForEditByIdAysnc(int id);

    Task<FilterUserViewModel> FilterAysnc(FilterUserViewModel filter);

    Task<OutPutModel<bool>> LoginAsync(LoginViewModel model);

    Task<bool> DuplicatedPhoneAysnc(int id, string phone);
    Task<bool> DuplicatedEmailAysnc(int id, string email);


    Task<User> GetUserByEmailAsync(string email);





}

