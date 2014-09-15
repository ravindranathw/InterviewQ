using System;
using System.Collections.Generic;
using System.Linq;
using InterviewQ.Business.Contracts;
using InterviewQ.Business.Models;
using InterviewQ.Business.Util;
using InterviewQ.Resources.Data.RepositoryContracts;
using InterviewQ.Resources.EF.Entities;

namespace InterviewQ.Business
{
    /// <summary>
    /// Test generated for an Junior level with 70% easy 30% Medium questions
    /// </summary>
    public class GeneratedTestForJunior : IGeneratedTest
    {
        private readonly IDifficultyLevelRepository _difficultyLevelRepository;
        private readonly IQuestionRepository _questionRepository;


        public GeneratedTestForJunior(
            IQuestionRepository questionRepository,
            IDifficultyLevelRepository difficultyLevelRepository)
        {
            _questionRepository = questionRepository;
            _difficultyLevelRepository = difficultyLevelRepository;
        }

        /// <summary>
        ///  Generate a Junior Level Test
        /// </summary>
        /// <param name="numberOfQuestions">Number of questions</param>
        /// <param name="category">Test category</param>
        /// <returns>Generated Test</returns>
        public TestModel GetTestWith(int numberOfQuestions, CategoryModel category)
        {
            var juniorTestQuestions = new List<TestQuestionModel>();


            var difficultyEasy = _difficultyLevelRepository.Get(d => d.Difficulty == DifficultyLevelEnum.Easy).SingleOrDefault();
            
            var difficultyMedium = _difficultyLevelRepository.Get(d => d.Difficulty == DifficultyLevelEnum.Medium).SingleOrDefault();

            var numberOfEasyQuestions   = 70.FloorPercentageOf(numberOfQuestions);
            var numberOfMediumQuestions = 30.FloorPercentageOf(numberOfQuestions);
            numberOfEasyQuestions      += numberOfQuestions - (numberOfEasyQuestions + numberOfMediumQuestions);

            var easyQuestions =
                _questionRepository
                    .Get(q => q.CategoryID == category.Id && q.DifficultyLevelID == difficultyEasy.Id)
                    .Take(numberOfEasyQuestions);

            var mediumQuestions =
                _questionRepository
                    .Get(q => q.CategoryID == category.Id && q.DifficultyLevelID == difficultyMedium.Id)
                    .Take(numberOfMediumQuestions);

            juniorTestQuestions = easyQuestions.Union(mediumQuestions).Shuffle().ToList();

            return new TestModel()
            {
                Id = Guid.NewGuid(),
                Name = string.Format("{0} Test", category.Name),
                Questions = juniorTestQuestions,
            };
        }

    }
}