
namespace Resume.Core.Services;
public class AboutMeService: IAboutMeService
{
    #region Fields
    private readonly ILogger<AboutMeService> _logger;   

    private readonly ResumeDbContext _context;
    #endregion

    #region Constructor

    public AboutMeService(ResumeDbContext context, ILogger<AboutMeService> logger)
    {
        _context = context;
        _logger = logger;
    }
    #endregion



    #region Methods
    public async Task<AdminSideEditAboutMeViewModel> GetInfoAsync()
    {
        try
        {
            var result=await _context.AboutMe.Select(a=> new AdminSideEditAboutMeViewModel
            {
                 Id = a.Id,
                 Bio=a.Bio,
                 ImageName=a.PictureName,
                 Location=a.Location,
                 Position=a.Position,
            })
            .SingleOrDefaultAsync();

            return result;
        }
        catch (Exception ex)
        {
            return new AdminSideEditAboutMeViewModel();
           
        }
    }

    public async Task<OutPutModel<bool>> UpdateAsync(AdminSideEditAboutMeViewModel model)
    {
        try
        {
             
            var aboutMe=await _context.AboutMe.FindAsync(model.Id);

            if (aboutMe is null)
                return new OutPutModel<bool>
                {
                     StatusCode=404,
                     Result=false,
                     Message="NotFound AboutMe"
                };

            if(model.Avatar is not null)
            {
                if (model.Avatar.IsImage())
                {
                    if (aboutMe.PictureName != "")
                    {
                        aboutMe.PictureName.DeleteImage(SiteTools.AboutMeAvatar);
                    }
                    aboutMe.PictureName = NameGenerator.GenerateNameForImage(15)+ Path.GetExtension(model.Avatar.FileName);
                    model.Avatar.AddImageToServer(fileName: aboutMe.PictureName, SiteTools.AboutMeAvatar);

                }
                else
                {

                    return new OutPutModel<bool>
                    {
                         StatusCode=400,
                        Result=false,
                         Message=""
                    };
                }

            }
            aboutMe.Location = model.Location;
            aboutMe.Position = model.Position;
            aboutMe.Bio = model.Bio;
           
            _context.AboutMe.Update(aboutMe);
            await _context.SaveChangesAsync();  
            return new OutPutModel<bool>
            {
                 Result=true,
                 StatusCode=200,
                 Message=""
            };
        }
        catch (Exception ex)
        {

            return new OutPutModel<bool>
            {
                  Message = ex.Message,
                  Result = false,
                  StatusCode=500  
            };
        }
    }

    #endregion
}
