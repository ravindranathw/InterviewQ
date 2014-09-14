using System.Collections.Generic;
using System.Collections.ObjectModel;
using InterviewQ.Resources.EF.Entities;

namespace InterviewQ.Resources.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InterviewQ.Resources.EF.Models.InterviewQContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            
        }

        protected override void Seed(InterviewQ.Resources.EF.Models.InterviewQContext context)
        {
            var categories = new Category()
            {
                Id = Guid.NewGuid(),
                Name = ".NET",
            };

            var difficultyLevelHard = new DifficultyLevel() {Difficulty = DifficultyLevelEnum.Hard, Id = Guid.NewGuid()};
            var difficultyLevelEasy = new DifficultyLevel() { Difficulty = DifficultyLevelEnum.Easy, Id = Guid.NewGuid() };

            var hardQuestion = new TestQuestion()
            {
                CategoryID = categories.Id,
                DifficultyLevelID = difficultyLevelHard.Id,
                Id = Guid.NewGuid(),
                Question = "Difficult .NET Question",
            };


            var easyQuestion = new TestQuestion()
            {
                CategoryID = categories.Id,
                DifficultyLevelID = difficultyLevelEasy.Id,
                Id = Guid.NewGuid(),
                Question = "Easy .NET Question",
            };

            var  answerForHardQuestion = new QuestionAnswer()
            {
                Answer = "Answe for .NET Difficult Question",
                QuestionID = hardQuestion.Id,
            };

            var answerForEasyQuestion = new QuestionAnswer()
            {
                Answer = "Answe for .NET Easy Question",
                QuestionID = easyQuestion.Id,
            };

            var test = new Test()
            {
                Id = Guid.NewGuid(),
                Name = ".NET TEST With 1 Question",
            };

            var testQuestions = new TestQuestions()
            {
                TestID = test.Id,
                TestQuestionID = hardQuestion.Id,
            };

            context.DifficultyLevels.AddOrUpdate(difficultyLevelHard);
            context.DifficultyLevels.AddOrUpdate(difficultyLevelEasy);

            context.Categories.AddOrUpdate(categories);

            context.Answers.AddOrUpdate(answerForHardQuestion);
            context.Answers.AddOrUpdate(answerForEasyQuestion);

            context.Questions.AddOrUpdate(hardQuestion);
            context.Questions.AddOrUpdate(easyQuestion);

            context.Tests.AddOrUpdate(test);


            context.TestQuestions.AddOrUpdate(testQuestions);

            ////  This method will be called after migrating to the latest version.

            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            ////  to avoid creating duplicate seed data. E.g.
            ////
            ////    context.People.AddOrUpdate(
            ////      p => p.FullName,
            ////      new Person { FullName = "Andrew Peters" },
            ////      new Person { FullName = "Brice Lambson" },
            ////      new Person { FullName = "Rowan Miller" }
            ////    );
            ////
        }
    }
}
