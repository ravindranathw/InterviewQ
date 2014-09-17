using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using InterviewQ.Resources.Data.RepositoryContracts;
using InterviewQ.Resources.EF.Entities;
using InterviewQ.Resources.EF.Models;

namespace InterviewQ.Resources.Data.Repositories
{
    internal class QuestionRepository : BaseRepository<TestQuestionModel, TestQuestion>, IQuestionRepository
    {
        public QuestionRepository(InterviewQContext db)
            : base(db)
        {

        }

        #region Base class Implementations

        protected override Expression<Func<TestQuestion, bool>> Get(TestQuestionModel model)
        {
            return c => c.Id == model.Id;
        }

        protected override Expression<Func<TestQuestion, bool>> Get(Guid id)
        {
            return c => c.Id == id;
        }

        
        protected override IQueryable<TestQuestion> GetQuery(Expression<Func<TestQuestion, bool>> predicate = null)
        {
            return predicate != null ?
                uow.Questions.Where(predicate) :
                uow.Questions;
        }

        protected override void Remove(TestQuestion entity)
        {
            //TODO: Restrict to admin level
            throw new NotImplementedException();
        }

        protected override void Add(TestQuestionModel source, TestQuestion dest)
        {
            //TODO: Restrict to admin level
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Gives randomly ordered question list with given predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public override IList<TestQuestionModel> Get(Expression<Func<TestQuestion, bool>> predicate = null)
        {
            var random = new Random();

            var data =
                uow.Questions
                    .Where(predicate).ToList();

            if (!data.Any())
                return null;

            return predicate != null
                ? data.OrderBy(r => random.Next())
                    .Select(s => new TestQuestionModel(s))
                    .ToList()
                : data.Select(s => new TestQuestionModel(s)).ToList();
        }
    }
}