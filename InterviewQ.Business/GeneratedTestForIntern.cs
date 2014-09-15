using System;
using System.Linq;
using InterviewQ.Business.Contracts;
using InterviewQ.Business.Models;
using InterviewQ.Resources.Data.RepositoryContracts;
using InterviewQ.Resources.EF.Entities;

namespace InterviewQ.Business
{
    /// <summary>
    /// Test generated for an intern level with 100% easy questions
    /// </summary>
    public class GeneratedTestForIntern : IGeneratedTest
    {
        private readonly IDifficultyLevelRepository _difficultyLevelRepository;
        private readonly IQuestionRepository _questionRepository;


        public GeneratedTestForIntern(
            IQuestionRepository questionRepository,
            IDifficultyLevelRepository difficultyLevelRepository)
        {
            _questionRepository = questionRepository;
            _difficultyLevelRepository = difficultyLevelRepository;
        }

        /// <summary>
        ///  Generate an Intern Level Test
        /// </summary>
        /// <param name="numberOfQuestions">Number of questions</param>
        /// <param name="category">Test category</param>
        /// <returns>Generated Test</returns>
        public TestModel GetTestWith(int numberOfQuestions, CategoryModel category)
        {
            var difficulty = _difficultyLevelRepository.Get(d => d.Difficulty == DifficultyLevelEnum.Easy).SingleOrDefault();

            var questions =
                _questionRepository
                    .Get(q => q.CategoryID == category.Id && q.DifficultyLevelID == difficulty.Id)
                    .Take(numberOfQuestions).ToList();

            return new TestModel()
            {
                Id = Guid.NewGuid(),
                Name = string.Format("{0} Test", category.Name),
                Questions = questions,
            };
        } 
    }
}