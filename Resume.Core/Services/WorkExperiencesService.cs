namespace Resume.Core.Services;
public class WorkExperiencesService : IWorkExperiencesService
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
        var workExp = await _context.WorkExperiences
             .AsNoTracking()
             .Select(e => new WorkExperiencesDetailViewModel
             {
                 CompanyName = e.CompanyName,
                 Description = e.Description,
                 StartDate = e.StartDate,
                 JobTitle = e.JobTitle,
                 EndDate = e.EndDate,
             })
             .OrderByDescending(e => e.StartDate)
             .Take(5)
             .ToListAsync();

        return workExp;
    }

    public async Task<OutPutModel<bool>> UpdateAsync(UpdateWorkExperiencesViewModel model)
    {
        try
        {
            var work = await _context.WorkExperiences.FindAsync(model.WE_Id);

            if (work is null)
                return new OutPutModel<bool>
                {
                    Result = false,
                    StatusCode = 404,
                    Message = "Not Found WorkExperiences."
                };

            work.StartDate = model.StartDate;
            work.EndDate = model.EndDate;
            work.JobTitle = model.JobTitle;
            work.Description = model.Description;
            work.CompanyName = model.CompanyName;


            _context.WorkExperiences.Update(work);
            await _context.SaveChangesAsync();
            return new OutPutModel<bool>
            {
                Result = true,
                StatusCode = 200,
                Message = "Updated SuccessFully"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                Result = false,
                StatusCode = 500,
                Message = "Unexpected error. Please try again.",
            };
        }
    }
    public async Task<OutPutModel<bool>> CreateAsync(CreateWorkExperiencesViewModel model)
    {
        try
        {

            var newWork = new WorkExperiences()
            {
                CompanyName = model.CompanyName,
                Description = model.Description,
                StartDate = model.StartDate,
                JobTitle = model.JobTitle,
                EndDate = model.EndDate,
                CreateDate = DateTime.Now,
                UserId = 2
            };
            _context.WorkExperiences.Add(newWork);
            await _context.SaveChangesAsync();
            return new OutPutModel<bool>
            {
                StatusCode = 200,
                Result = true,
                Message = "Added SuccessFully."
            };
        }
        catch (Exception ex)
        {

            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                Result = false,
                StatusCode = 500,
                Message = "Unexpected error. Please try again.",
            };
        }
    }
    public async Task<FilterWorkExperiencesViewModel> FilterAsync(FilterWorkExperiencesViewModel model)
    {
        try
        {
            var query = _context.WorkExperiences
                                .AsNoTracking()
                                .AsQueryable();

            string title = $"%{model.JobTitle}%";
            if (!string.IsNullOrEmpty(model.JobTitle))
                query = query.Where(e => EF.Functions.Like(e.JobTitle, title));

            await model.Paging(query
                .Select(e => new WorkExperiencesDetailViewModel
                {
                    JobTitle = e.JobTitle,
                    CompanyName = e.CompanyName,
                    StartDate = e.StartDate,
                    Description = e.Description,
                    Id = e.Id,
                    EndDate = e.EndDate ?? default,
                }));

            return model;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }
    public async Task<UpdateWorkExperiencesViewModel> GetForUpdateAsync(int id)
    {
        try
        {
            var work = await _context.WorkExperiences
                .Where(w => w.Id == id)
                .Select(w => new UpdateWorkExperiencesViewModel
                {
                    CompanyName = w.CompanyName,
                    StartDate = w.StartDate,
                    Description = w.Description,
                    EndDate = w.EndDate ?? default,
                    WE_Id = w.Id,
                    JobTitle = w.JobTitle,
                }).SingleOrDefaultAsync();

            return work;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;

        }
    }
    public async Task<OutPutModel<bool>> DeleteAsync(DeleteWorkExperiencesViewModel model)
    {
        try
        {
            var work=await _context.WorkExperiences
                .FindAsync(model.WE_Id);

            if (work is null)
                return new OutPutModel<bool>
                {
                     Result=false,
                     StatusCode=404,
                     Message= "Not Found WorkExperiences"

                };

            _context.WorkExperiences.Remove(work);
            await _context.SaveChangesAsync();

            return new OutPutModel<bool>
            {
                 StatusCode=200,
                 Result=true,
                 Message= "Deleted SuccessFully."
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                Message = "Unexpected error. Please try again.",
                Result = false,
                StatusCode = 500,
            };

        }
    }
    public async Task<DeleteWorkExperiencesViewModel> GetForDeleteAsync(int id)
    {
        try
        {
            var work = await _context.WorkExperiences
              .Where(w => w.Id == id)
              .Select(w => new DeleteWorkExperiencesViewModel
              {
                  WE_Id = w.Id,
                  JobTitle = w.JobTitle,
              }).SingleOrDefaultAsync();

            return work;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message,ex);
            return null;
        }
    }

    #endregion
}
