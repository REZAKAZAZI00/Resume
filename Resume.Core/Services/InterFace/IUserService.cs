
namespace Resume.Core.Services.InterFace;

public interface IUserService
{
    Task<CreateUserResult> Create(CreateUserViewModel model);

}

