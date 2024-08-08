
namespace Resume.Core.Services;
public class BlogService : IBlogService
{
    #region Fields

    private readonly ILogger<BlogService> _logger;
    private readonly ResumeDbContext _context;
    private readonly ClaimsPrincipal _user;
    #endregion

    #region Constructor
    public BlogService(ILogger<BlogService> logger, ResumeDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _context = context;
        _user = httpContextAccessor.HttpContext.User;
    }


    #endregion


    #region Methods
    public async Task<OutPutModel<bool>> CreateAsync(CreateBlogViewModel model)
    {
        try
        {
            int userId = _user.GetUserId();

            if (userId == 0)
                return new OutPutModel<bool>
                {
                    StatusCode = 401,
                    Result = false,
                    Message = "Not found UserId."
                };

            string imageName = "Default.png";
            if (model.Image is not null)
            {
                if (model.Image.IsImage())
                {
                    imageName = NameGenerator.GenerateNameForImage(15) + Path.GetExtension(model.Image.FileName);
                    model.Image.AddImageToServer(fileName: imageName,
                        SiteTools.Imageblog,
                        thumbPath: SiteTools.ImageBlogThumb,
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


            var newblog = new Blog()
            {
                UserId = userId,
                CategoryId = model.CategoryId,
                CreateDate = DateTime.Now,
                PictureName = imageName,
                Description = model.Description,
                Tags = model.Tags,
                Title = model.Title,
                ViewCount = 0,
            };

            _context.Blogs.Add(newblog);
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
                Message = "Unexpected error. Please try again.",
                StatusCode = 500,
                Result = false
            };
        }
    }

    public async Task<OutPutModel<bool>> CreateBlogCategoryAsync(CreateBlogCategoryViewModel model)
    {
        try
        {
            
            var newCate = new CategoryBlog()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                Description = model.Description,
                Title = model.Title,
            };

            _context.CategoryBlogs.Add(newCate);
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
                Message = "Unexpected error. Please try again.",
                StatusCode = 500,
                Result = false
            };
        }
    }

    public async Task<OutPutModel<bool>> DeleteAsync(DeleteBlogViewModel model)
    {
        try
        {
            var blog = await _context.Blogs.FindAsync(model.BlogId);

            if (blog is null)
                return new OutPutModel<bool>
                {
                    Result = false,
                    StatusCode = 404,
                    Message = "Not Found Blog."
                };


            if (blog.PictureName != "Default.png")
            {
                blog.PictureName.DeleteImage(SiteTools.Imageblog, SiteTools.ImageBlogThumb);
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return new OutPutModel<bool>
            {
                StatusCode = 200,
                Message = "Deleted SuccessFully.",
                Result = true
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                StatusCode = 500,
                Result = false,
                Message = "Unexpected error. Please try again.",

            };
        }
    }

    public async Task<OutPutModel<bool>> DeleteBlogCategoryAsync(DeleteBlogCategoryViewModel model)
    {
        try
        {
            var blog = await _context.CategoryBlogs.FindAsync(model.CategoryId);

            if (blog is null)
                return new OutPutModel<bool>
                {
                    Result = false,
                    StatusCode = 404,
                    Message = "Not Found Blog."
                };


            blog.IsDelete = true;
            _context.CategoryBlogs.Update(blog);
            await _context.SaveChangesAsync();

            return new OutPutModel<bool>
            {
                StatusCode = 200,
                Message = "Deleted SuccessFully.",
                Result = true
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                StatusCode = 500,
                Result = false,
                Message = "Unexpected error. Please try again.",

            };
        }
    }

    public async Task<FilterBlogViewModel> FilterAsync(FilterBlogViewModel model)
    {
        try
        {

            var query = _context.Blogs.Include(b => b.CategoryBlog)
                .AsNoTrackingWithIdentityResolution()
                .AsQueryable();


            string title = $"%{model.Title}%";
            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(e => EF.Functions.Like(e.Title, title));

            await model.Paging(query
                .Select(b => new BlogDetailsViewModel
                {
                    BlogId = b.Id,
                    CategoryId = b.CategoryId,
                    Title = b.Title,
                    PictureName = b.PictureName,
                    Tags = b.Tags,
                    Description = b.Description,
                    ViewCount = b.ViewCount,
                    CategoryTitle = b.CategoryBlog.Title,
                }));


            return model;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }

    public async Task<FilterBlogCategoryViewModel> FilterAsync(FilterBlogCategoryViewModel model)
    {
        try
        {

            var query = _context.CategoryBlogs
                                .AsNoTracking()
                                .AsQueryable();


            string title = $"%{model.Title}%";
            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(e => EF.Functions.Like(e.Title, title));

            await model.Paging(query
                .Select(b => new BlogCategoryDetailsViewModel
                {
                     CategoryId = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                
                }));


            return model;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }

    public async Task<DeleteBlogCategoryViewModel> GetBlogCategoryForDeleteAsync(int id)
    {
        try
        {
            
            var cate = await _context.CategoryBlogs
               .Where(c => c.Id == id)
               .Select(c => new DeleteBlogCategoryViewModel
               {
                    CategoryId = c.Id,
                    Title=c.Title,
               })
               .SingleOrDefaultAsync();
            return cate;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }

    public async Task<UpdateBlogCategoryViewModel> GetBlogCategoryForUpdateAsync(int id)
    {
        try
        {
            var cate=await _context.CategoryBlogs
                .Where(c=>c .Id == id)
                .Select(c=> new UpdateBlogCategoryViewModel
                {
                     CategeoryId = c.Id,
                     Description = c.Description,
                     Title = c.Title,
                })
                .SingleOrDefaultAsync();
            return cate;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }

    public async Task<DeleteBlogViewModel> GetBlogForDeleteAsync(int id)
    {
        try
        {
            var blog = await _context.Blogs
                .Where(b => b.Id == id)
                .Select(b => new DeleteBlogViewModel
                {
                    BlogId = b.Id,
                    Title = b.Title,

                })
                .SingleOrDefaultAsync();
            return blog;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }

    public async Task<UpdateBlogViewModel> GetBlogForUpdateAsync(int id)
    {
        try
        {
            var blog = await _context.Blogs
                  .Where(b => b.Id == id)
                  .Select(b => new UpdateBlogViewModel
                  {
                      BlogId = b.Id,
                      Title = b.Title,
                      Description = b.Description,
                      PictureName = b.PictureName,
                      Tags = b.Tags,
                      CategoryId = b.CategoryId,
                  })
                  .SingleOrDefaultAsync();

            return blog;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }

    public async Task<List<SelectListItem>> GetCategoryForManageBlogAsync()
    {
        try
        {
            var blog=await _context.CategoryBlogs
                .Select(b=> new SelectListItem
                {
                     Text=b.Title,
                     Value=b.Id.ToString()
                }).ToListAsync();
            return blog;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }

    public async Task<OutPutModel<bool>> UpdateAsync(UpdateBlogViewModel model)
    {
        try
        {
            var blog = await _context.Blogs.FindAsync(model.BlogId);
            if (blog is null)
                return new OutPutModel<bool>
                {
                    Result = false,
                    StatusCode = 404,
                    Message = "Not Found Blog."
                };

            if (model.Image is not null)
            {
                if (model.Image.IsImage())
                {
                    if (blog.PictureName != "Default.png")
                    {
                        blog.PictureName.DeleteImage(SiteTools.Imageblog, SiteTools.ImageBlogThumb);
                    }
                    blog.PictureName = NameGenerator.GenerateNameForImage(15) + Path.GetExtension(model.Image.FileName);
                    model.Image.AddImageToServer(fileName: blog.PictureName,
                                            SiteTools.Imageblog,
                                            thumbPath: SiteTools.ImageBlogThumb,
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

            blog.Title = model.Title;
            blog.Description = model.Description;
            blog.Tags = model.Tags;
            blog.CategoryId = model.CategoryId;
            

            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();

            return new OutPutModel<bool>
            {
                Message = "Updated SuccessFully.",
                StatusCode = 200,
                Result = true,
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                StatusCode = 500,
                Result = false,
                Message = "Unexpected error. Please try again.",
            };
        }
    }

    public async Task<OutPutModel<bool>> UpdateBlogCategoryAsync(UpdateBlogCategoryViewModel model)
    {
        try
        {
            var cate = await _context.CategoryBlogs.FindAsync(model.CategeoryId);
            if (cate is null)
                return new OutPutModel<bool>
                {
                    Result = false,
                    StatusCode = 404,
                    Message = "Not Found Blog."
                };


            cate.Title = model.Title;
            cate.Description = model.Description;
            
           

            _context.CategoryBlogs.Update(cate);
            await _context.SaveChangesAsync();

            return new OutPutModel<bool>
            {
                Message = "Updated SuccessFully.",
                StatusCode = 200,
                Result = true,
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                StatusCode = 500,
                Result = false,
                Message = "Unexpected error. Please try again.",
            };
        }
    }


    #endregion
}
