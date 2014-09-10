using System;
using System.Collections.Generic;
using System.Linq;
using InterviewQ.Business.Models;
using InterviewQ.Business.Util;
using InterviewQ.Resources.Data.RepositoryContracts;
using InterviewQ.Resources.EF.Entities;

namespace InterviewQ.Business
{
    /// <summary>
    /// Test generated for an Mid level with 30% easy 50% medium 20% hard questions
    /// </summary>
    public class GeneratedTestForMid
    {
        private readonly ICatagoryRepository _catagoryRepository;
        private readonly IDifficultyLevelRepository _difficultyLevelRepository;
        private readonly IQuestionRepository _questionRepository;


        public GeneratedTestForMid(
            IQuestionRepository questionRepository,
            IDifficultyLevelRepository difficultyLevelRepository,
            ICatagoryRepository catagoryRepository)
        {
            _questionRepository = questionRepository;
            _difficultyLevelRepository = difficultyLevelRepository;
            _catagoryRepository = catagoryRepository;
        }

        /// <summary>
        ///  Generate a Mid Level Test
        /// </summary>
        /// <param name="numberOfQuestions">Number of questions</param>
        /// <param name="category">Test category</param>
        /// <returns>Generated Test</returns>
        public TestModel GetTestWith(int numberOfQuestions, CategoryModel category)
        {
            var midTestQuestions = new List<TestQuestionModel>();

            var cat = _catagoryRepository.Get(c => c.Id == category.Id).SingleOrDefault();

            var difficultyEasy   = _difficultyLevelRepository.Get(d => d.Difficulty == DifficultyLevelEnum.Easy).SingleOrDefault();
            var difficultyMedium = _difficultyLevelRepository.Get(d => d.Difficulty == DifficultyLevelEnum.Medium).SingleOrDefault();
            var difficultyHard   = _difficultyLevelRepository.Get(d => d.Difficulty == DifficultyLevelEnum.Hard).SingleOrDefault();

            var numberOfEasyQuestions   = 30.FloorPercentageOf(numberOfQuestions);
            var numberOfMediumQuestions = 50.FloorPercentageOf(numberOfQuestions);
            var numberOfHardQuestions   = 20.FloorPercentageOf(numberOfQuestions);

            numberOfHardQuestions += numberOfQuestions - (numberOfEasyQuestions + numberOfMediumQuestions + numberOfHardQuestions);

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


            midTestQuestions = easyQuestions
                .Union(mediumQuestions)
                .Union(hardQuestions)
                .Shuffle().ToList();

            return new TestModel()
            {
                Id = Guid.NewGuid(),
                Name = string.Format("{0} Test", category.Name),
                Questions = midTestQuestions,
            };
        }

    }
}