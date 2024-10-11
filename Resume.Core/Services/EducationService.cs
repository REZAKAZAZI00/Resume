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
    public async Task<OutPutModel<bool>> CreateAsync(CreateEducationViewModel model)
    {
        try
        {
            var newEducation = new Education()
            {
                CreateDate = DateTime.Now,
                EndDate = model?.EndDate,
                StartDate = model.StartDate,
                Description = model.Description,
                Degree = model.Degree,
                FieldOfStudy = model.FieldOfStudy,
                InstitutionName = model.InstitutionName,
                UserId = 2,
            };
            _context.Educations.Add(newEducation);
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
            return new OutPutModel<bool>()
            {
                Result = false,
                Message = "Unexpected error. Please try again.",
                StatusCode = 500
            };
        }
    }

    public async Task<OutPutModel<bool>> DeleteAsync(DeleteEducationViewModel model)
    {
        try
        {
            var education = await _context.Educations.FindAsync(model.EducationId);
            if (education != null)
            {

                _context.Educations.Remove(education);
                await _context.SaveChangesAsync();
                return new OutPutModel<bool>
                {
                     StatusCode=200,
                     Result= true,
                     Message= "Deleted SuccessFully."
                };
            }
            return new OutPutModel<bool>
            {
                StatusCode = 404,
                Result = false,
                Message= "Not Found Education."
            };
        }
        catch (Exception ex)
        {

            return new OutPutModel<bool>
            {
                StatusCode = 500,
                Message = "Unexpected error. Please try again.",
                Result = false,
            };
        }

    }

    public async Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model)
    {
        try
        {
            var query = _context.Educations
                                .AsNoTracking()
                                .AsQueryable();

            string name = $"%{model.InstitutionName}%";
            if (!string.IsNullOrEmpty(model.InstitutionName))
                query = query.Where(e => EF.Functions.Like(e.InstitutionName, name));

            string degree = $"%{model.Degree}%";
            if (!string.IsNullOrEmpty(model.Degree))
                query = query.Where(e => EF.Functions.Like(e.Degree, degree));

            await model.Paging(query
                .Select(e => new EducationDetailViewModel
                {
                    Degree = e.Degree,
                    InstitutionName = e.InstitutionName,
                    StartDate = e.StartDate,
                    Description = e.Description,
                    FieldOfStudy = e.FieldOfStudy,
                    EducationId = e.Id,
                    EndDate = e.EndDate ?? default,
                }));

            return model;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public Task<DeleteEducationViewModel> GetEducationForDeleteById(int id)
    {
        try
        {
            var query = _context.Educations
                .Where(e => e.Id == id)
                .Select(e => new DeleteEducationViewModel
                {
                    EducationId = e.Id,
                    InstitutionName = e.InstitutionName,
                })
                .SingleOrDefaultAsync();

            return query;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }

    public async Task<UpdateEducationViewModel> GetEducationForUpdateById(int id)
    {
        var education = await _context.Educations
            .Where(x => x.Id == id)
            .Select(e => new UpdateEducationViewModel
            {
                Description = e.Description,
                EndDate = e.EndDate,
                EducationId = e.Id,
                StartDate = e.StartDate,
                FieldOfStudy = e.FieldOfStudy,
                InstitutionName = e.InstitutionName,
                Degree = e.Degree
            }).SingleOrDefaultAsync();
        return education;
    }

    public async Task<List<EducationDetailViewModel>> GetEducationsAsync()
    {
        var eductions = await _context.Educations
            .AsNoTracking()
            .Select(e => new EducationDetailViewModel
            {
                Degree = e.Degree,
                Description = e.Description,
                EndDate = e.EndDate ?? default,
                FieldOfStudy = e.FieldOfStudy,
                InstitutionName = e.InstitutionName,
                StartDate = e.StartDate,
            })
            .OrderByDescending(x => x.StartDate)
            .ToListAsync();

        return eductions;
    }

    public async Task<OutPutModel<bool>> UpdateAsync(UpdateEducationViewModel model)
    {
        try
        {
            var existingEducation = await _context.Educations.FindAsync(model.EducationId);

            if (existingEducation is null)
                return new OutPutModel<bool>
                {
                    StatusCode = 404,
                    Result = false,
                    Message = "Not Found  Education."
                };


            existingEducation.StartDate = model.StartDate;
            existingEducation.EndDate = model?.EndDate;
            existingEducation.Description = model.Description;
            existingEducation.Degree = model.Degree;
            existingEducation.FieldOfStudy = model.FieldOfStudy;
            existingEducation.InstitutionName = model.InstitutionName;

            _context.Educations.Update(existingEducation);
            await _context.SaveChangesAsync();
            return new OutPutModel<bool>
            {
                Message = "Updated SuccessFully.",
                Result = true,
                StatusCode = 200,
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new OutPutModel<bool>
            {
                Message = "Unexpected error. Please try again.",
                StatusCode = 500,
                Result = false,

            };
        }
    }
    #endregion

}
