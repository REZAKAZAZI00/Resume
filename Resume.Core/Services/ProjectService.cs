

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
    public async Task<List<SelectListItem>> GetCategoryForManageProduct()
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
            var project = await _context.Projects
                .SingleOrDefaultAsync(p => p.Id == model.ProjectId);

            if (project == null)
                return new OutPutModel<bool>
                {
                     Result=false, 
                     StatusCode=404,
                     Message="NotFound Project"
                };
            project.PictureName = model.PictureName;
            string imageName = "";
            if (model.Image.HasLength(0)&&model.Image.IsImage())
            {
                imageName = NameGenerator.GenerateNameForImage(20);
                model.Image.AddImageToServer(imageName,SiteTools.ImageProject);
                model.PictureName.DeleteFile(SiteTools.ImageProject);
                project.PictureName = imageName;

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
                Result=true,
                StatusCode = 200,
                Message=""
            };

        }
        catch (Exception ex)
        {
            return new OutPutModel<bool>
            {
                 Message = ex.Message,
                 Result = true,
                 StatusCode=500
            };
            
        }
    }

    public async Task<OutPutModel<bool>> CreateAsync(CreateProjectViewModel model)
    {
        try
        {
            // TODO UPlaod Iamge
            string imageName = "Default.png";
            if (model.Image.HasLength(0) && model.Image.IsImage())
            {
                imageName = NameGenerator.GenerateNameForImage(20);
                model.Image.AddImageToServer(imageName, SiteTools.ImageProject);
            }

            var newProject = new Project
            {
                 CategoryId = model.CategoryId,
                 Title = model.Title,   
                 DeepLink = model.DeepLink,
                 IsDelete=false,
                 EndDate = model.EndDate,
                 PictureName = imageName, 
                 Description= model.Description,
                 StartDate = model.StartDate,
            };

            _context.Projects.Add(newProject);
            await _context.SaveChangesAsync();
            return new OutPutModel<bool>
            {
                 StatusCode=200,
                 Result=true,
                  Message="" 

            };
        }
        catch (Exception ex)
        {

            return new OutPutModel<bool>
            {
                 Result=false,
                 StatusCode=500,
                 Message=ex.Message
            };
        }
    }

    public async Task<OutPutModel<bool>> DeleteAsync(int id)
    {
        try
        {
            var project=await _context.Projects
                .SingleOrDefaultAsync(p => p.Id == id);

            if (project == null)
                return new OutPutModel<bool>
                {
                     StatusCode=404,
                     Result=false,
                     Message="Not Found Project"
                };
            project.IsDelete = true;
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return new OutPutModel<bool>
            {
                 StatusCode=200,
                 Result=true,
                 Message=""
            };
        }
        catch (Exception ex)
        {

            return new OutPutModel<bool>
            {
                Message = ex.Message,
                StatusCode = 500,
                Result = false
            };
        }
    }

    public async Task<FilterProjectViewModel> FilterAsync(FilterProjectViewModel model)
    {

        return new FilterProjectViewModel();
    }
    #endregion
}
