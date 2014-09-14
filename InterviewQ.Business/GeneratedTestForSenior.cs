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
    /// Test generated for an Senior level with 70% easy 30% Medium questions
    /// </summary>
    public class GeneratedTestForSenior : IGeneratedTest
    {
        private readonly ICatagoryRepository _catagoryRepository;
        private readonly IDifficultyLevelRepository _difficultyLevelRepository;
        private readonly IQuestionRepository _questionRepository;


        public GeneratedTestForSenior(
            IQuestionRepository questionRepository,
            IDifficultyLevelRepository difficultyLevelRepository,
            ICatagoryRepository catagoryRepository)
        {
            _questionRepository = questionRepository;
            _difficultyLevelRepository = difficultyLevelRepository;
            _catagoryRepository = catagoryRepository;
        }

        /// <summary>
        ///  Generate a Senior Level Test
        /// </summary>
        /// <param name="numberOfQuestions">Number of questions</param>
        /// <param name="category">Test category</param>
        /// <returns>Generated Test</returns>
        public TestModel GetTestWith(int numberOfQuestions, CategoryModel category)
        {
            var seniorTestQuestions = new List<TestQuestionModel>();

            var cat = _catagoryRepository.Get(c => c.Id == category.Id).SingleOrDefault();

            var difficultyEasy = _difficultyLevelRepository.Get(d => d.Difficulty == DifficultyLevelEnum.Easy).SingleOrDefault();

            var difficultyMedium = _difficultyLevelRepository.Get(d => d.Difficulty == DifficultyLevelEnum.Medium).SingleOrDefault();

            var difficultyHard = _difficultyLevelRepository.Get(d => d.Difficulty == DifficultyLevelEnum.Hard).SingleOrDefault();

            var difficultyVeryHard = _difficultyLevelRepository.Get(d => d.Difficulty == DifficultyLevelEnum.VeryHard).SingleOrDefault();

            ///TODO: we can refine this more by making a testgenerateRuleEngine so could ask to generate 10% easy, 50% hard, 30% hard, 10% very hard and TestGenerateFactory basically 
            /// generates it. Eliminates all these classes
            var numberOfEasyQuestions     = 10.FloorPercentageOf(numberOfQuestions);
            var numberOfMediumQuestions   = 50.FloorPercentageOf(numberOfQuestions);
            var numberOfHardQuestions     = 30.FloorPercentageOf(numberOfQuestions);
            var numberOfVeryHardQuestions = 10.FloorPercentageOf(numberOfQuestions);


            var easyQuestions =
                _questionRepository
                    .Get(q => q.CategoryID == cat.Id && q.DifficultyLevelID == difficultyEasy.Id)
                    .Take(numberOfEasyQuestions);

            var mediumQuestions =
                _questionRepository
                    .Get(q => q.CategoryID == cat.Id && q.DifficultyLevelID == difficultyMedium.Id)
                    .Take(numberOfMediumQuestions);

            var hardQuestions =
                _questionRepository
                    .Get(q => q.CategoryID == cat.Id && q.DifficultyLevelID == difficultyHard.Id)
                    .Take(numberOfHardQuestions);

            var veryHardQuestions =
                _questionRepository
                    .Get(q => q.CategoryID == cat.Id && q.DifficultyLevelID == difficultyVeryHard.Id)
                    .Take(numberOfVeryHardQuestions);

            seniorTestQuestions =
                easyQuestions
                    .Union(mediumQuestions)
                    .Union(hardQuestions)
                    .Union(veryHardQuestions).Shuffle().ToList();

            return new TestModel()
            {
                Id = Guid.NewGuid(),
                Name = string.Format("{0} Test", category.Name),
                Questions = seniorTestQuestions,
            };
        }

    }
}