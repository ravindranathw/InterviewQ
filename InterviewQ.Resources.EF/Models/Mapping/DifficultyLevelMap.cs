using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using InterviewQ.Business.Entities;

namespace InterviewQ.Resources.EF.Models.Mapping
{
    public class DifficultyLevelMap : EntityTypeConfiguration<DifficultyLevel>
    {
        public DifficultyLevelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Difficulty)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DifficultyLevels");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Difficulty).HasColumnName("Difficulty");
        }
    }
}
