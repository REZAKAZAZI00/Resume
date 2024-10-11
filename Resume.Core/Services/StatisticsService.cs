
namespace Resume.Core.Services;
public class StatisticsService:IStatisticsService
{
	#region Fields
	private readonly ResumeDbContext _context;
    private readonly ILogger<StatisticsService> _logger;
    #endregion


    #region Constructor

    public StatisticsService(ResumeDbContext context, ILogger<StatisticsService> logger)
    {
        _context = context;
        _logger = logger;
    }


    #endregion


    #region Methods

    public async Task<int> GetToTotalProjectsAsync()
    {
        return await _context.Projects.CountAsync();    
    }
    #endregion

}
