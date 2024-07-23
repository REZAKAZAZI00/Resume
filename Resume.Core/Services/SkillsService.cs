namespace Resume.Core.Services;

public class SkillsService: ISkillsService
{

    #region Fields
    private readonly ILogger<SkillsService> _logger;
    private readonly ResumeDbContext _context;
    #endregion

    #region Constructor
    public SkillsService(ResumeDbContext context, ILogger<SkillsService> logger)
    {
        _context = context;
        _logger = logger;
    }


    #endregion


    #region Methods

    public async Task<List<SkillsInfoViewModel>> GetSkillsInfoShowInHomeAsync()
    {
        var skills=await  _context.Skills
            .Select(s=> new SkillsInfoViewModel
            {
                 SkillLevel = s.SkillLevel,
                 SkillName=s.SkillName  
            })
            .OrderByDescending(s => s.SkillLevel)
            .Take(5)
            .ToListAsync();

        return skills;
    }
    #endregion
}
