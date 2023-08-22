using Altsystems.FeedRSSAnalytics.Infra.Data.Orm;
using Altsystems.FeedRSSBlogsAnalyticsApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Altsystems.FeedRSSBlogsAnalyticsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {

        readonly CultureInfo culture = new ("en-US");
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private static readonly object _lockObj = new();

        public AnalyticsController(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetCategory/{authorId}")]
        public IQueryable<CategoryDTO> GetCategoryDTO(string authorId)
        {
            return from x in _dbContext.ArticleMatrices?.Where(x => x.AuthorId == authorId)
                   .GroupBy(x => x.CategoryDTO)
                   select new CategoryDTO
                   {
                       Name = x.FirstOrDefault().CategoryDTO,
                       Count = x.Count()
                   };
        }
    }
}
