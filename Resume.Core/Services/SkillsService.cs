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
                query = query.Where(s => EF.Functions.Like(s.SkillName, filterName));


            await model.Paging(query
                .Select(s => new SkillsDetailsViewModel
                {
                    SkillName = s.SkillName,
                    SkillLevel = s.SkillLevel,
                    SkillId = s.Id

                }));

            return model;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }

    }

    public async Task<OutPutModel<bool>> CreateAsync(CreateSkillsViewModel model)
    {
        try
        {

            var newSkills = new Skills
            {
                CreateDate = DateTime.Now,
                SkillLevel = model.Level,
                SkillName = model.Name,
                UserId = 2,
            };
            _context.Skills.Add(newSkills);
            await _context.SaveChangesAsync();
            return new OutPutModel<bool>
            {
                Result = true,
                StatusCode = 200,
                Message = "Added successfully."
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                StatusCode = 500,
                Result = false,
                Message = ex.Message
            };
        }
    }

    public async Task<OutPutModel<bool>> UpdateAsync(UpdateSkillsViewModel model)
    {
        try
        {
            var skill = await _context.Skills.FindAsync(model.SkillsId);
            if (skill is null)
                return new OutPutModel<bool>
                {
                    StatusCode = 404,
                    Result = false,
                    Message = "Not Found Skill"
                };

            skill.SkillLevel = model.Level;
            skill.SkillName = model.Name;

            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
            return new OutPutModel<bool>
            {
                Result = true,
                StatusCode = 200,
                Message = "Updated successfully."
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                StatusCode = 500,
                Result = false,
                Message = ex.Message
            };
        }
    }

    public async Task<OutPutModel<bool>> DeleteAsync(DeleteSkillsViewModel model)
    {
        try
        {
            var exsitingSkills = await _context.Skills
                .FindAsync(model.SkillsId);
            if (exsitingSkills is null)
                return new OutPutModel<bool>
                {
                    StatusCode = 404,
                    Result = false,
                    Message = "NotFound Skills."
                };

            _context.Skills.Remove(exsitingSkills);
            await _context.SaveChangesAsync();

            return new OutPutModel<bool>
            {
                StatusCode = 200,
                Result = true,
                Message = "Deleted Successfully.",
            };
        }
        catch (Exception ex)
        {

            return new OutPutModel<bool>
            {
                StatusCode = 500,
                Message = ex.Message,
                Result = false
            };
        }
    }

    public async Task<UpdateSkillsViewModel> GetSkillByIdAsync(int id)
    {
        var skill = await _context.Skills
           .Where(s => s.Id == id)
           .Select(s => new UpdateSkillsViewModel
           {
               Level = s.SkillLevel,
               Name = s.SkillName,
               SkillsId= s.Id,
           }).SingleOrDefaultAsync();

        return skill;
    }

    public async Task<DeleteSkillsViewModel> GetForDeleteAsync(int id)
    {
        var skill = await _context.Skills
           .Where(s => s.Id == id)
           .Select(s => new DeleteSkillsViewModel
           {
               Name = s.SkillName,
               SkillsId = s.Id,
           }).SingleOrDefaultAsync();

        return skill;
    }

    #endregion
}
