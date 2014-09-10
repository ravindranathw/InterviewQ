using System;
using InterviewQ.Business.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewQ.Business.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var numberOfQuestions = 15;

            var val = 70.FloorPercentageOf(numberOfQuestions);
            var val2 = 30.FloorPercentageOf(numberOfQuestions);// > (numberOfQuestions- val) ? ;
            val2 += numberOfQuestions - (val + val2);
        }
    }
}
