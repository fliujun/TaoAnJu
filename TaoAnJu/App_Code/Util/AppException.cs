using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaoAnJu.Util
{
    /// <summary>
    /// AppException 的摘要说明。
    /// </summary>
    public class AppException : System.ApplicationException
    {
        //私有类成员
        protected bool m_boolLogException;
        protected int m_intSeverity;

        public AppException()
            : base()
        {
            m_boolLogException = false;
            m_intSeverity = 1;
        }
        public AppException(bool boolLogExp)
            : base()
        {
            m_boolLogException = boolLogExp;
            m_intSeverity = 1;
            if (boolLogExp)
                LogException();

        }

        public AppException(string message, int intSeverity)
            : base(message)
        {
            m_intSeverity = intSeverity;
            m_boolLogException = false;
        }

        public AppException(string message, System.Exception inner, int intSeverity)
            : base(message, inner)
        {
            m_intSeverity = intSeverity;
            m_boolLogException = false;
        }
        public AppException(string message, int intSeverity, bool boolLogExp)
            : base(message)
        {
            m_intSeverity = intSeverity;
            m_boolLogException = boolLogExp;
            if (boolLogExp)
                LogException();
        }

        public AppException(string message, System.Exception inner, int intSeverity, bool boolLogExp)
            : base(message, inner)
        {
            m_intSeverity = intSeverity;
            m_boolLogException = boolLogExp;
            if (boolLogExp)
                LogException();
        }

        private void LogException()
        {
            Loger.logErrXML(base.Source, base.TargetSite.ToString(), base.StackTrace, m_intSeverity, base.Message);
        }
    }
}