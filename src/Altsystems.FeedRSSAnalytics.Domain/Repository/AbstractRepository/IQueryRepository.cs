using Altsystems.FeedRSSAnalytics.Domain.Entities;

namespace Altsystems.FeedRSSAnalytics.Domain.Repository.AbstractRepository
{
    public interface IQueryRepository
    {
        IQueryable<Category> GetCategoriesByAuthorId(string authorId);
        IQueryable<Authors> GetAuthors();
    }
}
