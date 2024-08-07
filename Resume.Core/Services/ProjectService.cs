using SixLabors.ImageSharp;

namespace Resume.Core.Services;
public class ProjectService : IProjectService
{
    #region Fields

    private readonly ResumeDbContext _context;
    private readonly ILogger<ProjectService> _logger;

    #endregion

    #region Constructor
    public ProjectService(ResumeDbContext context, ILogger<ProjectService> logger)
    {
        _context = context;
        _logger = logger;
    }


    #endregion


    #region Methods
    public async Task<List<SelectListItem>> GetCategoryForManageProductAsync()
    {
        return await _context.Categories
            .AsNoTracking()
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Title
            })
            .ToListAsync();
    }

    public async Task<OutPutModel<bool>> UpdateAsync(UpdateProjectViewModel model)
    {
        try
        {
            var project = await _context.Projects.FindAsync(model.ProjectId);

            if (project == null)
                return new OutPutModel<bool>
                {
                    Result = false,
                    StatusCode = 404,
                    Message = "NotFound Project"
                };

            if (model.Image is not null)
            {
                if (model.Image.IsImage())
                {
                    if (project.PictureName != "Default.png")
                    {
                        project.PictureName.DeleteImage(SiteTools.ImageProject, SiteTools.ImageProjectthumb);
                    }
                    project.PictureName = NameGenerator.GenerateNameForImage(15) + Path.GetExtension(model.Image.FileName);
                    model.Image.AddImageToServer(fileName: project.PictureName,
                                            SiteTools.ImageProject,
                                            thumbPath: SiteTools.ImageProjectthumb,
                                            width: 150, height: 100);
                }
                else
                {

                    return new OutPutModel<bool>
                    {
                        StatusCode = 400,
                        Result = false,
                        Message = "The uploaded file is not an image. Please upload a file with one of : .jpg, .jpeg, .png"

                    };
                }
            }

            project.StartDate = model.StartDate;
            project.EndDate = model.EndDate;
            project.Description = model.Description;
            project.CategoryId = model.CategoryId;
            project.DeepLink = model.DeepLink;
            project.Title = model.Title;

            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return new OutPutModel<bool>
            {
                Result = true,
                StatusCode = 200,
                Message = "Updated  SuccessFully."
            };

        }
        catch (Exception ex)
        {
            return new OutPutModel<bool>
            {
                Message = "Unexpected error. Please try again.",
                Result = true,
                StatusCode = 500
            };

        }
    }

    public async Task<OutPutModel<bool>> CreateAsync(CreateProjectViewModel model)
    {
        try
        {
            // UPlaod Iamge
            string imageName = "Default.png";
            if (model.Image is not null)
            {
                if (model.Image.IsImage())
                {
                    imageName = NameGenerator.GenerateNameForImage(15) + Path.GetExtension(model.Image.FileName);
                    model.Image.AddImageToServer(fileName: imageName,
                        SiteTools.ImageProject,
                        thumbPath: SiteTools.ImageProjectthumb,
                        width: 150, height: 100);

                }
                else
                {

                    return new OutPutModel<bool>
                    {
                        StatusCode = 400,
                        Result = false,
                        Message = "The uploaded file is not an image. Please upload a file with one of : .jpg, .jpeg, .png"

                    };
                }
            }

            var newProject = new Project
            {
                CategoryId = model.CategoryId,
                Title = model.Title,
                DeepLink = model.DeepLink,
                IsDelete = false,
                EndDate = model.EndDate,
                PictureName = imageName,
                Description = model.Description,
                StartDate = model.StartDate,
            };

            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();
            return new OutPutModel<bool>
            {
                StatusCode = 200,
                Result = true,
                Message = "Added  SuccessFully."

            };
        }
        catch (Exception ex)
        {

            return new OutPutModel<bool>
            {
                Result = false,
                StatusCode = 500,
                Message = "Unexpected error. Please try again."
            };
        }
    }

    public async Task<OutPutModel<bool>> DeleteAsync(DeleteProjectViewModel model)
    {
        try
        {
            var project = await _context.Projects.FindAsync(model.ProjectId);

            if (project == null)
                return new OutPutModel<bool>
                {
                    StatusCode = 404,
                    Result = false,
                    Message = "Not Found Project."
                };

            if (project.PictureName != "Default.png")
            {
                project.PictureName.DeleteImage(SiteTools.ImageProject, SiteTools.ImageProjectthumb);
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return new OutPutModel<bool>
            {
                StatusCode = 200,
                Result = true,
                Message = "Deleted SuccessFully."
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                Message = "Unexpected error. Please try again.",
                StatusCode = 500,
                Result = false
            };
        }
    }

    public async Task<FilterProjectViewModel> FilterAsync(FilterProjectViewModel model)
    {

        try
        {
            var query = _context.Projects
                                .Include(c => c.Category)
                                .AsNoTracking()
                                .AsQueryable();

            string title = $"%{model.Title}%";
            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(e => EF.Functions.Like(e.Title, title));

            if (model.StartDate != null)
                query = query.Where(p => p.StartDate > model.StartDate);


            if (model.EndDate != null)
                query = query.Where(p => p.EndDate > model.StartDate);


            await model.Paging(query
                .Select(p => new ProjectDetailsViewModel
                {
                    StartDate = p.StartDate,
                    ProjectId = p.Id,
                    EndDate = p.EndDate,
                    Title = p.Title,
                    CategoryId = p.CategoryId,
                    PictureName = p.PictureName,
                    DeepLink = p.DeepLink,
                    Description = p.Description,
                    IsDelete = p.IsDelete,
                    CategoryTitle = p.Category.Title

                }));

            return model;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);

            return null;
        }
    }

    public async Task<DeleteProjectViewModel> GetProjectForDeleteByIdAsync(int id)
    {
        try
        {
            var project = await _context.Projects
               .Where(x => x.Id == id)
               .Select(p => new DeleteProjectViewModel
               {

                   Title = p.Title,
                   ProjectId = p.Id,

               })
               .SingleOrDefaultAsync();
            return project;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);

            return null;
        }
    }

    public async Task<UpdateProjectViewModel> GetProjectForUpdateByIdAsync(int id)
    {
        try
        {
            var project = await _context.Projects
                .Where(x => x.Id == id)
                .Include(c => c.Category)
                .Select(p => new UpdateProjectViewModel
                {
                    CategoryId = p.CategoryId,
                    DeepLink = p.DeepLink,
                    Description = p.Description,
                    CategoryTitle = p.Category.Title,
                    Title = p.Title,
                    IsDelete = p.IsDelete,
                    EndDate = p.EndDate,
                    PictureName = p.PictureName,
                    ProjectId = p.Id,
                    StartDate = p.StartDate,
                })
                .SingleOrDefaultAsync();
            return project;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }
    #endregion
}
