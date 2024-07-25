
namespace Resume.Core.Services;

public class WorkExperiencesService: IWorkExperiencesService
{
    #region Fields
    private readonly ResumeDbContext _context;
    private readonly ILogger<WorkExperiencesService> _logger;
    #endregion

    #region Constructor

    public WorkExperiencesService(ResumeDbContext context, ILogger<WorkExperiencesService> logger)
    {
        _context = context;
        _logger = logger;
    }


    #endregion


    #region Methods
    public async Task<List<WorkExperiencesDetailViewModel>> GetWorkExperiencesAsync()
    {
       var workExp=await _context.WorkExperiences
            .AsNoTracking()
            .Select(e=> new WorkExperiencesDetailViewModel
            {
                 CompanyName = e.CompanyName,
                 Description = e.Description,
                 StartDate = e.StartDate,
                 JobTitle=e.JobTitle,
                 EndDate = e.EndDate,   
            })
            .Take(5)
            .ToListAsync();

        return workExp;
    }

    #endregion
}
