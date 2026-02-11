using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Quality_Monitoring
{
    class LogFile
    {
        // 로그파일 관리 클래스

        private static LogFile _Singleton;

        public LogFile()
        {
        }

        public static LogFile GetInstance()
        {
            if (_Singleton == null)
            {
                _Singleton = new LogFile();
            }

            return _Singleton;
        }

        public void InitFolder()
        {
            string sCurrentDirectory = Directory.GetCurrentDirectory();
            m_sCurrentLogDirectory = sCurrentDirectory + "\\Log";

            if (Directory.Exists(m_sCurrentLogDirectory) == false)
            {
                Directory.CreateDirectory(m_sCurrentLogDirectory);
            }
        }

        private string m_sCurrentLogDirectory = null;
        private string m_sCurrentFileName = null;

        public void CreateLogMonthFolder()
        {
            string sCurrentDirectory = Directory.GetCurrentDirectory();
            string sYearMonth = DateTime.Now.ToString("yyyyMM");
            m_sCurrentLogDirectory = sCurrentDirectory + "\\Log\\" + sYearMonth;

            if (Directory.Exists(m_sCurrentLogDirectory) == false)
            {
                Directory.CreateDirectory(m_sCurrentLogDirectory);
            }

            string sFileName = DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".txt";
            m_sCurrentFileName = m_sCurrentLogDirectory + "\\" + sFileName;
        }

        private string m_sCreatedDate = "";
        public void CreateLogFile()
        {
            m_sCreatedDate = DateTime.Now.ToString("yyyyMMdd");

            string sFileName = "ProgramLog_" + DateTime.Now.ToString("yyMMdd") + ".txt";
            m_sCurrentFileName = m_sCurrentLogDirectory + "\\" + sFileName;

            m_sw = new StreamWriter(m_sCurrentFileName, true);
            m_sw.AutoFlush = true;
        }

        protected string GetCurrentDate()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }

        StreamWriter m_sw = null;
        public void StartLog()
        {
            lock (this)
            {
                //m_sw = File.AppendText(m_sCurrentFileName);
                m_sw = new StreamWriter(m_sCurrentFileName);
            }
        }

        public void StartLogWithDate()
        {
            lock (this)
            {
                m_sw = new StreamWriter(m_sCurrentFileName, true);
                m_sw.AutoFlush = true;
            }
        }

        public void CloseLog()
        {
            lock (this)
            {
                if (m_sw != null)
                {
                    m_sw.Close();
                }
            }
        }


        public void WriteLog(string sData)
        {
            lock (this)
            {
                if (m_sCreatedDate != GetCurrentDate())
                {
                    CloseLog();
                    CreateLogFile();
                }

                string sFinalData = string.Format("{0:yyyy-MM-dd HH:mm:ss.fff}         {1}", DateTime.Now, sData);

                m_sw.WriteLine(sFinalData);

            }
        }

        public void WriteLog(string format, params Object[] args)
        {
            lock (this)
            {
                if (m_sCreatedDate != GetCurrentDate())
                {
                    CloseLog();
                    CreateLogFile();
                }

                string sFinalData = string.Format("{0:yyyy-MM-dd HH:mm:ss.fff}         {1}", DateTime.Now, string.Format(format, args));

                m_sw.WriteLine(sFinalData);
            }
        }
    }
}
