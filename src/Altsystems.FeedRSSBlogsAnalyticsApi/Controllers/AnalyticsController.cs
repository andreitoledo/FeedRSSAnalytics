using Altsystems.FeedRSSAnalytics.Domain.Entities;
using Altsystems.FeedRSSAnalytics.Domain.Repository.AbstractRepository;
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

        private readonly IQueryRepository _queryRepository;

        public AnalyticsController(ApplicationDbContext dbContext, IConfiguration configuration, IQueryRepository queryRepository)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _queryRepository = queryRepository;
        }

        [HttpGet]
        [Route("GetCategory/{authorId}")]
        public IQueryable<Category> GetCategoryDTO(string authorId)
        {
            return _queryRepository.GetCategoriesByAuthorId(authorId);
        }

        [HttpGet]
        [Route("GetAuthors")]
        public IQueryable<Authors> GetAuthorsDTOs()
        {
            return _queryRepository.GetAuthors();
            
        }
    }
}
