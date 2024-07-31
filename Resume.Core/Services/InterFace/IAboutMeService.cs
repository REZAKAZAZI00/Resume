namespace Resume.Core.Services.InterFace;
public interface IAboutMeService
{
    Task<AdminSideEditAboutMeViewModel> GetInfoAsync();

    Task<OutPutModel<bool>> UpdateAsync(AdminSideEditAboutMeViewModel model);

}
