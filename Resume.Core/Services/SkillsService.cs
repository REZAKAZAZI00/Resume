using System.Web.Mvc;

namespace Resume.Core.Services;

public class SkillsService : ISkillsService
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
        var skills = await _context.Skills
            .AsNoTracking()
            .Select(s => new SkillsInfoViewModel
            {
                SkillLevel = s.SkillLevel,
                SkillName = s.SkillName
            })
            .OrderByDescending(s => s.SkillLevel)
            .Take(5)
            .ToListAsync();

        return skills;
    }

    public async Task<FilterSkillsViewModel> FilterAsync(FilterSkillsViewModel model)
    {
        try
        {
            var query = _context.Skills
                                .AsNoTracking()
                                .AsQueryable();

            string filterName = $"%{model.SkillName}%";
            if (!string.IsNullOrEmpty(model.SkillName))
                query = query.Where(s => EF.Functions.Like(s.SkillName,filterName ));


            await model.Paging(query
                .Select(s => new SkillsDetailsViewModel
                {
                    SkillName=s.SkillName,
                    SkillLevel=s.SkillLevel,
                    SkillId=s.Id
                    
                }));

            return model;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }

    }
    #endregion
}
