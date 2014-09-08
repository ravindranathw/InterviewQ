using System.Data.Entity.ModelConfiguration;
using InterviewQ.Resources.EF.Entities;

namespace InterviewQ.Resources.EF.Models.Mapping
{
    public class TestQuestionsMap : EntityTypeConfiguration<TestQuestions>
    {
        public TestQuestionsMap()
        {
            // Primary Key
            this.HasKey(t => new{t.TestID, t.TestQuestionID});
        }
    }
}
