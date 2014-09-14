using InterviewQ.Business.Models;
using InterviewQ.Resources.EF.Entities;

namespace InterviewQ.Business
{
    public interface IGeneratedTest
    {
        TestModel GetTestWith(int numberOfQuestions, CategoryModel category);
    }
}