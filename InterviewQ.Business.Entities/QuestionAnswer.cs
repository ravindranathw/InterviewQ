using System;

namespace InterviewQ.Business.Entities
{
    public partial class QuestionAnswer
    {
        public Guid QuestionID { get; set; }
        public string Answer { get; set; }
        public virtual TestQuestion TestQuestion { get; set; }
    }
}
