using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using InterviewQ.Business.Entities;

namespace InterviewQ.Resources.EF.Models.Mapping
{
    public class TestMap : EntityTypeConfiguration<Test>
    {
        public TestMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.Name)
                .IsRequired();

            // Table & Column Mappings
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
