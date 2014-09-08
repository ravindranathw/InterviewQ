using System.Data.Entity.ModelConfiguration;
using InterviewQ.Resources.EF.Entities;

namespace InterviewQ.Resources.EF.Models.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<TestQuestion>
    {
        public QuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Question)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Questions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.Question).HasColumnName("Question");
            this.Property(t => t.DifficultyLevelID).HasColumnName("DifficultyLevelID");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.CategoryID);
            this.HasRequired(t => t.DifficultyLevel)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.DifficultyLevelID);

        }
    }
}
