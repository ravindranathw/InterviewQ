using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQ.Business.Entities
{
    public class Test
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

    }

    public class TestQuestions
    {
        public Guid TestID { get; set; }
        public Guid TestQuestionID { get; set; }
    }
}
