
namespace Resume.Core.Services.InterFace;

public interface ISkillsService
{


    Task<List<SkillsInfoViewModel>> GetSkillsInfoShowInHomeAsync();

}
