using Altsystems.FeedRSSAnalytics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Altsystems.FeedRSSAnalytics.Infra.Data.Mappings
{
    public class ArticleMatrixMap : IEntityTypeConfiguration<ArticleMatrix>
    {
        public void Configure(EntityTypeBuilder<ArticleMatrix> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AuthorId)
                .HasColumnType("varchar(100)")
                .IsRequired()
                .HasColumnName("AuthorId");

            builder.Property(x => x.Author)
                .HasColumnType("varchar(150)")
                .IsRequired()
                .HasColumnName("Author");

            builder.Property(x => x.Link)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(x => x.Title)
                .HasColumnType("varchar(300)")
                .IsRequired();

            builder.Property(x => x.Type)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Category)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Views)
                .HasColumnType("nvarchar(max)");
        }
    }
}


