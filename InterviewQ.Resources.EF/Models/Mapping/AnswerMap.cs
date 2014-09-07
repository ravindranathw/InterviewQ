using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using InterviewQ.Business.Entities;

namespace InterviewQ.Resources.EF.Models.Mapping
{
    public class AnswerMap : EntityTypeConfiguration<QuestionAnswer>
    {
        public AnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.QuestionID);

            // Properties
            this.Property(t => t.QuestionID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Answer)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Answers");
            this.Property(t => t.QuestionID).HasColumnName("QuestionID");
            this.Property(t => t.Answer).HasColumnName("Answer");

            // Relationships
            this.HasRequired(t => t.TestQuestion)
                .WithOptional(t => t.QuestionAnswer);

        }
    }
}
