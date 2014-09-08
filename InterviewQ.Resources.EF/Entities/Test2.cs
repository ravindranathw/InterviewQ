using System;
using System.Collections.Generic;

namespace InterviewQ.Resources.Data.Entities
{
    public class Test2:ITest
    {

        #region ITest Members

        public ICollection<IQuestion> Questions
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region ITestInfo Members

        public Guid TestID { get; private set; }

        public string TestName { get; private set; }

        #endregion
    }
}
