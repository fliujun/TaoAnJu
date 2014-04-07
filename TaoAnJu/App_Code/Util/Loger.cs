using System;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace TaoAnJu.Util
{
	/// <summary>
	/// Loger 的摘要说明。
	/// </summary>
	public  class Loger
	{
		public Loger()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static void logErr(string attachMessage,System.Exception e)
		{
			logErr(e.TargetSite.Name,e.Source,e,5,attachMessage);
		}

		public static void logErr(string strSource, string strSourceSub, System.Exception e, int intSeveritylevel, string strExpInfo)
		{
			string strCallStack = "方法名:" + e.TargetSite + "\n";
			strCallStack += "原程序或对象名:" + e.Source + "\n";
			strCallStack += "状态:" + e.StackTrace + "\n";
			strCallStack += "错误描述:" + e.Message + "\n";
            logErrXML(strSource, strSourceSub, strCallStack, intSeveritylevel, strExpInfo);
		}

        public static void logErrXML(string strSource, string strSourceSub, string strCallStack, int intSeveritylevel, string strExpInfo)
		{
			string strLogFilePath;
			bool boolLogFileExists;
            strLogFilePath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\log";
            if (!Directory.Exists(strLogFilePath))
            {
                Directory.CreateDirectory(strLogFilePath);
            }
            strLogFilePath += "\\" + DateTime.Now.ToString("yyyyMMdd") + "errlog.xml";
			if(File.Exists(strLogFilePath))
				boolLogFileExists=true;
			else
				boolLogFileExists=false;

			// create the err log xml dom object to get the formated xml string

			System.Xml.XmlDocument oXMLDoc= new XmlDocument();
			System.Xml.XmlElement oRootEl,oContentEl;
			
			oXMLDoc.LoadXml("<err></err>");
			oRootEl = oXMLDoc.DocumentElement;

			oContentEl = oXMLDoc.CreateElement("logtime");
			oContentEl.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			oRootEl.AppendChild(oContentEl);

			oContentEl = oXMLDoc.CreateElement("source");
			oContentEl.InnerText = strSource;
			oRootEl.AppendChild(oContentEl);

			oContentEl = oXMLDoc.CreateElement("subsource");
			oContentEl.InnerText=strSourceSub;
			oRootEl.AppendChild(oContentEl);
			
			oContentEl = oXMLDoc.CreateElement("callstack");
			oContentEl.InnerText=strCallStack;
			oRootEl.AppendChild(oContentEl);

			oContentEl = oXMLDoc.CreateElement("severity");
			oContentEl.InnerText = intSeveritylevel.ToString();
			oRootEl.AppendChild(oContentEl);

			oContentEl = oXMLDoc.CreateElement("errmessage");
			oContentEl.InnerText=strExpInfo;
			oRootEl.AppendChild(oContentEl);

			try
			{
				System.IO.StreamWriter oLogFile= new StreamWriter( new FileStream(strLogFilePath,FileMode.OpenOrCreate,FileAccess.Write,FileShare.ReadWrite), System.Text.Encoding.UTF8);
				
				// if log file exists, seek the location of the xml ending tag, else, wirte the prefix of logfile
				if(boolLogFileExists)
					oLogFile.BaseStream.Seek(-9,SeekOrigin.End);
				else
				{
					oLogFile.Write("<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n\r<errlog>\n\r");
				}
				oLogFile.Write(oRootEl.OuterXml);
				oLogFile.Write("\n\r</errlog>");
				oLogFile.Close();
			}
			catch(System.Exception ee)
			{
				if(!EventLog.SourceExists("TaoAnJu"))
				{
                    EventLog.CreateEventSource("TaoAnJu", "Log");
					Console.WriteLine("CreatingEventSource");
				}
                
				// Create an EventLog instance and assign its source.
				EventLog oLog = new EventLog();
                oLog.Source = "TaoAnJu";
        
				// Write an informational entry to the event log.    
				oLog.WriteEntry("System Errlog write failed, please check the file " + strLogFilePath + ":Message:" + ee.Message);
			}
		}
	}
}
