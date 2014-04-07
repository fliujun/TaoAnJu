using System;
using System.Collections;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
namespace TaoAnJu.Util
{
	/// <summary>
	/// 通用字符串操作函数
	/// </summary>
	public class StringTools
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public StringTools()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
        public static string GUIDGen()
        {
            System.Guid oGuid = Guid.NewGuid();
            return oGuid.ToString("N");
        }
        public static string PasswordEnc(string strPwdClearText)
        {
            byte[] byteStrPwd;
            byte[] byteEnc;
            System.Security.Cryptography.SHA1Managed oSHA1 = new SHA1Managed();
            byteStrPwd = System.Text.Encoding.Unicode.GetBytes(strPwdClearText);
            byteEnc = oSHA1.ComputeHash(byteStrPwd);
            return Convert.ToBase64String(byteEnc, 0, byteEnc.Length);
        }
        /// <summary>
        /// this is a simple implements and should be change for security reason
        /// 
        /// </summary>
        /// <param name="strRelative"></param>
        /// <returns></returns>
        public static string EncrpytString(string strin)
        {
            byte[] btStrin;
            btStrin = System.Text.Encoding.Unicode.GetBytes(strin);
            return Convert.ToBase64String(btStrin);
        }
        public static string DecryptString(string strin)
        {

            byte[] btStrin;
            try
            {
                btStrin = Convert.FromBase64String(strin);
                return System.Text.Encoding.Unicode.GetString(btStrin);
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 获得文件的扩展名
        /// </summary>
        /// <param name="FileName">返回例如"txt", "jpg"等；如果没有扩展名，返回""</param>
        static public string GetFileExtName(string FileName)
        {
            int index = FileName.LastIndexOf('.');
            if (index == -1)
                return "";

            string ExtName = FileName.Substring(index + 1);
            return ExtName;
        }
        //对内容进行格式化
        static public string FormatBody(string str)
        {
            str = str.Replace("\n　　", "\n");
            str = str.Replace("\n　", "\n");
            while (str.StartsWith("　"))
                str = str.Substring(2);

            string NewStr = str.Replace("\n", "<br>\n　　");
            return "　　" + NewStr;
        }
		/// <summary>
		/// 字串截取函数
		/// </summary>
		/// <param name="ss">要截取的字串</param>
		/// <param name="maxlen">最大字串长度</param>
		/// <returns>截短后的字串</returns>
		public static string CutStr(string ss,int maxlen)
		{
			if (ss==null) return "";
			//if (ss.Length<=maxlen) return ss;
			int len=0;
			int i=0;
			maxlen = maxlen*2;
			for (len=0;len<maxlen;i++)
			{
				len++;
				if (ss[i]>255)
				{
					len ++;
				}
				if (i>=ss.Length-1) break;
			}
			string endstr="...";
			if (i==ss.Length) endstr="";
			return ss.Substring(0,i) + endstr;
		}
		/// <summary>
		/// 字串截取函数
		/// </summary>
		/// <param name="OldStr">要截取的字串</param>
		/// <param name="MaxLen">最大字串长度</param>
		/// <returns>截短后的字串</returns>
		public static string GetShortStr(string OldStr,int MaxLen)
		{
			if(OldStr==null)return "";
			if(MaxLen>OldStr.Length){return OldStr;}
			int len=0;
			int mlen=(OldStr.Length<=MaxLen*2)?OldStr.Length:MaxLen*2;
			for(int i=0;i<mlen;i++)
			{
				if(OldStr[i]<=255)
				{
					++len;
				}
			}
			MaxLen=(OldStr.Length<=MaxLen+len/2)?OldStr.Length:MaxLen+len/2;
			if(MaxLen>=OldStr.Length)
			{
				return OldStr;
			}
			else
			{
				return OldStr.Substring (0,MaxLen-2)+"...";
			}
		}

		/// <summary>
		/// 消除字符中的重叠的逗号以及左右的逗号
		/// </summary>
		/// <param name="ss">要消除重字的字串</param>
		/// <param name="delstr">要消除的字串</param>
		/// <returns>消除重字之后的字串</returns>
		public static string  TrimStrings(string ss,string delstr)
		{
			if (ss==null || ss.Length<=0) return "";
			string temp = ss;
			while (temp.IndexOf(delstr+delstr)>=0)
			{
				temp = temp.Replace(delstr+delstr,delstr);
			}
			if (temp.Length<=0 || temp.Equals(delstr)) return "";
			if (temp.Substring(0,1).Equals(delstr)) temp = temp.Substring(1,temp.Length-1);
			if (temp.Substring(temp.Length-1,1).Equals(delstr)) temp = temp.Substring(0,temp.Length-1);
			return temp;
		}

		/// <summary>
		/// 调整编码字串加零到编号左边
		/// </summary>
		/// <param name="subid"></param>
		/// <param name="maxlen"></param>
		/// <returns></returns>
		public static string AddZero(string subid,int maxlen)
		{
			string tempstr = subid.ToString();
			for (int i=maxlen;i>subid.Length;i--)
			{
				tempstr = "0" + tempstr;
			}
			return tempstr;
		}

		/// <summary>
		/// 添加编码0
		/// </summary>
		/// <param name="subid"></param>
		/// <returns></returns>
		public static string AddZero(string subid)
		{
			return AddZero(subid,5);
		}

		/// <summary>
		/// 调整编码字串加零到编号右边
		/// </summary>
		/// <param name="subid"></param>
		/// <param name="maxlen"></param>
		/// <returns></returns>
		public static string AddZeroR(string subid,int maxlen)
		{
			string tempstr = subid.ToString();
			for (int i=maxlen;i>subid.Length;i--)
			{
				tempstr += "0";
			}
			return tempstr;
		}

		/// <summary>
		/// 小数位不够，补零到两位
		/// </summary>
		/// <param name="subid"></param>
		/// <param name="maxlen"></param>
		/// <returns></returns>
		public static string AddZeroToString(string subid,int maxlen)
		{
			string addstr = "";
			string tempstr = subid.ToString();
			string[] arr_str = subid.Split('.');
			if (arr_str.Length==1)
			{
				for (int i=1;i<=maxlen;i++)
				{
					addstr += "0";
				}
				tempstr += "." + addstr;
			}
			else
			{
				for (int i=arr_str[1].Length;i<maxlen;i++)
				{
					addstr += "0";
				}
				tempstr += addstr;    
			}			
			return tempstr;
		}

		/// <summary>
		/// 右侧补零
		/// </summary>
		/// <param name="subid"></param>
		/// <returns></returns>
		public static string AddZeroR(string subid)
		{
			return AddZeroR(subid,5);
		}

		/// <summary>
		/// 以层叠的方式显示字符串前缀
		/// </summary>
		/// <param name="codes"></param>
		/// <param name="dislen"></param>
		/// <returns></returns>
		public static string getLevelShow(string codes,int dislen)
		{
			string tempstr="";
			for (int i=dislen;i<codes.Length;i=i+dislen)
			{
				tempstr += "--";
			}
			return tempstr;
		}

        /// <summary>
        /// 以层叠的方式显示字符串
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public static string getLevelShow(string codes, int oldcodelength, string oldchar)
        {
            if (oldcodelength == 0 && codes.Length == 0)
                return "";
            if (codes.Length == oldcodelength)
                return oldchar;
            string strChar = "";
            switch (codes.Length)
            {
                case 1:
                    strChar = "│ ";
                    break;
                case 3:
                    strChar = "│ │ ";
                    break;
                case 5:
                    strChar = "│ │ │ ";
                    break;
                case 8:
                    strChar = "│ │ │ │ ";
                    break;
                case 10:
                    strChar = "│ │ │ │ │ ";
                    break;
            }
            return strChar;
        }

		/// <summary>
		/// 过滤非法字符
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string filterInvalid(string str)
		{
			if (str==null || str.Length<=0) return "";
			str = str.Replace("'","");
			str = str.Replace("\"","");
			return str;
		}

		/// <summary>
		/// 检查字符串是否包含非法字符
		/// </summary>
		/// <param name="str">检查的字符串</param>
		/// <param name="invalid">非法字符串</param>
		/// <param name="needCheck">是否不能为空</param>
		/// <returns>True包含非法字符或为空False无非法字符</returns>
		public static bool checkInvalid(string str,string invalid,bool needCheck)
		{
			string tempstr = str;
			if (needCheck && (tempstr==null || tempstr.Length<=0)) return true;
			if (tempstr==null)
			{
				tempstr = "";
			}
			for(int i=0;i<invalid.Length;i++)
			{
				if (tempstr.IndexOf(invalid.Substring(i,1))>=0)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// 检查字串合法性
		/// </summary>
		/// <param name="str">检查的字符串</param>
		/// <param name="invalid">非法的字符</param>
		/// <returns>True包含非法字符或为空False无非法字符</returns>
		public static bool checkInvalid(string str,string invalid)
		{
			return checkInvalid(str,invalid,true);
		}

		/// <summary>
		/// 检查字串合法性
		/// </summary>
		/// <param name="str">字符串</param>
		/// <returns>True包含非法字符或为空False无非法字符</returns>
		public static bool checkInvalid(string str)
		{
			return checkInvalid(str,"\'\"<>+\\",true);
		}

		/// <summary>
		/// 添加alert脚本
		/// </summary>
		/// <param name="outstr"></param>
		/// <returns></returns>
		public static string AlertScript(string outstr)
		{
			return "alert('" + outstr + "');\n";
		}

		/// <summary>
		/// 添加Focus脚本
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string FocusScript(string obj)
		{
			return "document.forms[0].all[\"" + obj + "\"].focus();\n";
		}

		/// <summary>
		/// 返回由script包围的字串
		/// </summary>
		/// <param name="outstr">要输出的脚本串</param>
		/// <returns></returns>
		public static string AddScript(string outstr)
		{
			string tempstr="<script language=javascript>\n"
				+outstr+"\n"
				+"</script>\n";
			return tempstr;
		}

		/// <summary>
		/// 转换ip到long
		/// </summary>
		/// <param name="ip">ip</param>
		/// <returns></returns>
		public static long ConvertIpToLong(IPAddress ip)
		{
			Byte[] bytes = ip.GetAddressBytes();
			long ipLong = 0;

			ipLong += Convert.ToInt64(bytes[0]) * 256 * 256 * 256;

			ipLong += Convert.ToInt64(bytes[1]) * 256 * 256;

			ipLong += Convert.ToInt64(bytes[2]) * 256;

			ipLong += Convert.ToInt64(bytes[3]);

			return ipLong;
		}

		/// <summary>
		/// 转换字符串ip到长整型
		/// </summary>
		/// <param name="ipString"></param>
		/// <returns></returns>
		public static long ConvertIpToLong(string ipString)
		{
			IPAddress ip = IPAddress.Parse(ipString);
			return ConvertIpToLong(ip);
		}
		
		/// <summary>
		/// 转换长整型ip到字符串型
		/// </summary>
		/// <param name="sip">长整型ip</param>
		/// <returns></returns>
		public static string ConvertIpToString(long sip)
		{
			int s1=Convert.ToInt32(sip/256/256/256);
			Int64 s21=Convert.ToInt64(s1)*256*256*256;
			int s2=Convert.ToInt32((sip-s21)/256/256);
			Int64 s31=s2*256*256+s21;
			int s3=Convert.ToInt32((sip-s31)/256);
			int s4=(int)(sip-s3*256-s31);
			return s1.ToString() + "." + s2.ToString() +"." + s3.ToString() +"." + s4.ToString();
		}

		/// <summary>
		/// 获取Url的前缀
		/// </summary>
		/// <param name="url">完整的url路径</param>
		/// <returns>url的最终路径</returns>
		public static string getUrlPrefix(string url)
		{
			string ret = url.Substring(0,url.LastIndexOf("/"));
			if (ret.ToLower().IndexOf("http://")<0)
			{
				ret = "http://" + ret;
			}
			return ret;
		}

		/// <summary>
		/// 将消息分按指定长度进行分割
		/// </summary>
		/// <param name="msg">要分割的消息</param>
		/// <param name="splitlen">指定的分割长度(英文长度)</param>
		/// <returns></returns>
		public static ArrayList SplitMsgByLen(string msg,int splitLen)
		{
			ArrayList al = new ArrayList();
			string temp="";
			int curLen=0;
			int charLen=1;
			for (int i=0;i<msg.Length;i++)
			{
				if (msg[i]>255)
				{
					charLen=2;
				}
				if (curLen+charLen>splitLen)
				{
					curLen = charLen;
					al.Add(temp);
					temp = "" + msg[i];
				}
				else
				{
					curLen += charLen;
					temp += msg[i];
				}
			}

			if (curLen>0)
			{
				al.Add(temp);
			}
			return al;
		}
        //把内容存JS文件
        static public void AddToJSFile(DataTable dt, string FileName)
        {
            string strLogFilePath;

            strLogFilePath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\js\\" + FileName;
            if (System.IO.File.Exists(strLogFilePath))
            {
                System.IO.File.Delete(strLogFilePath);
            }
            System.IO.StreamWriter oLogFile = new System.IO.StreamWriter(new FileStream(strLogFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite), System.Text.Encoding.UTF8);

            Hashtable hs = new Hashtable();
            string vno = "vlevel";
            string tname = "tlevel";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["parentid"].ToString()) == -1)
                {
                    if (hs.ContainsKey(vno))
                    {
                        hs[vno] += "*" + dt.Rows[i]["no"].ToString();
                        hs[tname] += "*" + dt.Rows[i]["name"].ToString().Replace("--", "");
                    }
                    else
                    {
                        hs.Add(vno, dt.Rows[i]["no"].ToString());
                        hs.Add(tname, dt.Rows[i]["name"].ToString().Replace("--", ""));
                    }
                }
                else
                {
                    if (hs.ContainsKey(vno + dt.Rows[i]["parentid"].ToString()))
                    {
                        hs[vno + dt.Rows[i]["parentid"].ToString()] += "*" + dt.Rows[i]["no"].ToString();
                        hs[tname + dt.Rows[i]["parentid"].ToString()] += "*" + dt.Rows[i]["name"].ToString().Replace("--", "");
                    }
                    else
                    {
                        hs.Add(vno + dt.Rows[i]["parentid"].ToString(), dt.Rows[i]["no"].ToString());
                        hs.Add(tname + dt.Rows[i]["parentid"].ToString(), dt.Rows[i]["name"].ToString().Replace("--", ""));
                    }
                }
            }
            string strLine = "";
            IDictionaryEnumerator myEnumerator = hs.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                strLine = myEnumerator.Key + "=\"" + myEnumerator.Value.ToString() + "\";\n";
                oLogFile.Write(strLine);
            }

            oLogFile.Close();
        }
        /// <summary>
        /// MD5_32
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        static public string MD5_32(string input, Encoding encoding)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(encoding.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
        /// <summary>
        /// MD5 16位加密 加密后暗码为大写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public string MD5_16(string input)
        {
            using (System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider())
            {
                string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(input)), 4, 8);
                t2 = t2.Replace("-", "");
                return t2;
            }
        }
        /// <summary>
        /// MD5 16位加密 加密后暗码为大写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public string MD5_16b(string input)
        {
            using (System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider())
            {
                return BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(input)), 4, 8);
            }
        }
        /// <summary>
        /// Web MD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public string MD5_web(string input)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(input, "MD5");
        }

        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public string MD5String(string str)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(str);
            b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');
            return ret;
        }
        /// <summary>
        /// 根据配置文件的key键获取Value值
        /// </summary>
        /// <param name="Key">配置文件中的Key值</param>
        /// <returns></returns>
        static public string getConfigValue(string Key)
        {
            string strValue = "";
            try
            {
                strValue = System.Configuration.ConfigurationManager.AppSettings["" + Key + ""].ToString();
            }
            catch (Exception Ex)
            {
                strValue = Ex.Message;
            }
            return strValue;
        }
	}
}
