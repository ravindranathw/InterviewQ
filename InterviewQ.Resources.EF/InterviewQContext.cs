using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using InterviewQ.Business.Entities;
using InterviewQ.Resources.EF.Models.Mapping;

namespace InterviewQ.Resources.EF.Models
{
    public partial class InterviewQContext : DbContext
    {
        static InterviewQContext()
        {
            Database.SetInitializer<InterviewQContext>(null);
        }

        public InterviewQContext()
            : base("Name=InterviewQContext")
        {
        }

        public DbSet<QuestionAnswer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public DbSet<TestQuestion> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestions> TestQuestions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnswerMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new DifficultyLevelMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new TestMap());
            modelBuilder.Configurations.Add(new TestQuestionsMap());
        }
    }
}
