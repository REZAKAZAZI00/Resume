
namespace Resume.Core.Services;

public class EducationService : IEducationService
{
    #region Fields

    private readonly ILogger<EducationService> _logger;
    private readonly ResumeDbContext _context;
    #endregion

    #region Constructor


    public EducationService(ResumeDbContext context, ILogger<EducationService> logger)
    {
        _context = context;
        _logger = logger;
    }
    #endregion

    #region Methods
    public Task<OutPutModel<bool>> CreateEducationAsync(CreateEducationViewModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<List<EducationDetailViewModel>> GetEducationsAsync()
    {
        var eductions = await _context.Educations
            .AsNoTracking()
            .Select(e => new EducationDetailViewModel
            {
                Degree = e.Degree,
                Description = e.Description,
                EndDate = e.EndDate?? default,
                FieldOfStudy = e.FieldOfStudy,
                InstitutionName = e.InstitutionName,
                StartDate = e.StartDate,
            }).ToListAsync();

        return eductions;
    }

    public Task<OutPutModel<bool>> UpdateEducationAsync(UpdateEducationViewModel model)
    {
        throw new NotImplementedException();
    }
    #endregion

}
