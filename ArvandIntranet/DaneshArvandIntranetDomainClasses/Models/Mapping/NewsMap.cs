using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class NewsMap : EntityTypeConfiguration<News>
    {
        public NewsMap()
        {
            // Primary Key
            this.HasKey(t => t.NewsId);

            // Properties
            this.Property(t => t.NewsUrlFriendly)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.TitlePersian)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.TitleLatin)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.SummaryPersian)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.HtmlSummaryPersian)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.SummaryLatin)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.HtmlSummaryLatin)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.ContentPersian)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.HtmlContentPersian)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.ContentLatin)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.HtmlContentLatin)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.NewsDate)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.NewsTime)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.ShowDate)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.ShowTime)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.ExpireDate)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.ExpireTime)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.ShowWeekDays)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(7);

            this.Property(t => t.NewsLabels)
                .IsRequired()
                .HasMaxLength(3000);

            this.Property(t => t.SmallPictureLink)
                .HasMaxLength(2000);

            this.Property(t => t.LargePictureLink)
                .HasMaxLength(2000);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("NEWS");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.NewsId).HasColumnName("NEWS_ID");
            this.Property(t => t.NewsNo).HasColumnName("NEWS_NO");
            this.Property(t => t.NewsUrlFriendly).HasColumnName("NEWS_URLFRIENDLY");
            this.Property(t => t.NewsGroup).HasColumnName("NEWS_GROUP");
            this.Property(t => t.NewsType).HasColumnName("NEWS_TYPE");
            this.Property(t => t.NewsKind).HasColumnName("NEWS_KIND");
            this.Property(t => t.ShowStatus).HasColumnName("SHOW_STATUS");
            this.Property(t => t.TitlePersian).HasColumnName("TITLE_PERSIAN");
            this.Property(t => t.TitleLatin).HasColumnName("TITLE_LATIN");
            this.Property(t => t.SummaryPersian).HasColumnName("SUMMARY_PERSIAN");
            this.Property(t => t.HtmlSummaryPersian).HasColumnName("HTML_SUMMARY_PERSIAN");
            this.Property(t => t.SummaryLatin).HasColumnName("SUMMARY_LATIN");
            this.Property(t => t.HtmlSummaryLatin).HasColumnName("HTML_SUMMARY_LATIN");
            this.Property(t => t.ContentPersian).HasColumnName("CONTENT_PERSIAN");
            this.Property(t => t.HtmlContentPersian).HasColumnName("HTML_CONTENT_PERSIAN");
            this.Property(t => t.ContentLatin).HasColumnName("CONTENT_LATIN");
            this.Property(t => t.HtmlContentLatin).HasColumnName("HTML_CONTENT_LATIN");
            this.Property(t => t.NewsDate).HasColumnName("NEWS_DATE");
            this.Property(t => t.NewsTime).HasColumnName("NEWS_TIME");
            this.Property(t => t.NewsOrder).HasColumnName("NEWS_ORDER");
            this.Property(t => t.NewsShare).HasColumnName("NEWS_SHARE");
            this.Property(t => t.NewsShareOk).HasColumnName("NEWS_SHARE_OK");
            this.Property(t => t.ShowDate).HasColumnName("SHOW_DATE");
            this.Property(t => t.ShowTime).HasColumnName("SHOW_TIME");
            this.Property(t => t.ExpireDate).HasColumnName("EXPIRE_DATE");
            this.Property(t => t.ExpireTime).HasColumnName("EXPIRE_TIME");
            this.Property(t => t.ShowWeekDays).HasColumnName("SHOW_WEEKDAYS");
            this.Property(t => t.NewsLabels).HasColumnName("NEWS_LABELS");
            this.Property(t => t.InsertUser).HasColumnName("INSERT_USER");
            this.Property(t => t.SmallPictureLink).HasColumnName("SMALL_PICTURE_LINK");
            this.Property(t => t.LargePictureLink).HasColumnName("LARGE_PICTURE_LINK");
            this.Property(t => t.NewsDelete).HasColumnName("NEWS_DELETE");
            this.Property(t => t.Active).HasColumnName("ACTIVE");
            this.Property(t => t.Remark).HasColumnName("REMARK");

            // Relationships
            this.HasRequired(t => t.NewsGroups)
                .WithMany(t => t.NEWS)
                .HasForeignKey(d => d.NewsGroup);
            this.HasRequired(t => t.NewsKinds)
                .WithMany(t => t.NEWS)
                .HasForeignKey(d => d.NewsKind);
            this.HasRequired(t => t.NewsTypes)
                .WithMany(t => t.News)
                .HasForeignKey(d => d.NewsType);

        }
    }
}
