using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewQ.Business.Models;
using InterviewQ.Resources.EF.Entities;
using InterviewQ.Resources.EF.Models.Mapping;

namespace InterviewQ.Resources.Data.Repositories.Maps
{
    public static class RegisterEntitiesToModelsMap
    {
        public static void Register()
        {
            AutoMapper.Mapper.CreateMap<Category, CategoryModel>().ConstructUsing(c=> new CategoryModel(c));
            AutoMapper.Mapper.CreateMap<DifficultyLevel, DifficultyLevelModel>().ConstructUsing(c => new DifficultyLevelModel(c));
            AutoMapper.Mapper.CreateMap<QuestionAnswer, QuestionAnswerModel>().ConstructUsing(c => new QuestionAnswerModel(c));
            AutoMapper.Mapper.CreateMap<TestQuestion, TestQuestionModel>().ConstructUsing(c => new TestQuestionModel(c));
        }
    }
}
