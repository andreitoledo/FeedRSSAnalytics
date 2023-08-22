using Altsystems.FeedRSSAnalytics.Domain.Entities;
using Altsystems.FeedRSSAnalytics.Domain.Repository.AbstractRepository;
using Altsystems.FeedRSSAnalytics.Infra.Data.Orm;

namespace Altsystems.FeedRSSAnalytics.Infra.Repository.ImplementationRepository
{
    public class QueryRepository : IQueryRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public QueryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Authors>? GetAuthors()
        {
            return _dbContext.ArticleMatrices.GroupBy(x => x.AuthorId)
                .Select(x => new Authors
                {
                    AuthorId = x.FirstOrDefault().AuthorId,
                    Author = x.FirstOrDefault().Author,
                    Count = x.Count()
                })

                .OrderBy(x => x.Author);
        }

        public IQueryable<Category>? GetCategoriesByAuthorId(string authorId)
        {
            return from x in _dbContext.ArticleMatrices?.Where(x => x.AuthorId == authorId)
                   .GroupBy(x => x.CategoryDTO)
                   select new Category
                   {
                       Name = x.FirstOrDefault().CategoryDTO,
                       Count = x.Count()
                   };
        }
    }
}
