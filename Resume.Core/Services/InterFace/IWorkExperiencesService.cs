
namespace Resume.Core.Services.InterFace;

public interface IWorkExperiencesService
{

    Task<List<WorkExperiencesDetailViewModel>> GetWorkExperiencesAsync();
}
