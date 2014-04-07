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
	/// ͨ���ַ�����������
	/// </summary>
	public class StringTools
	{
		/// <summary>
		/// ���캯��
		/// </summary>
		public StringTools()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
        /// ����ļ�����չ��
        /// </summary>
        /// <param name="FileName">��������"txt", "jpg"�ȣ����û����չ��������""</param>
        static public string GetFileExtName(string FileName)
        {
            int index = FileName.LastIndexOf('.');
            if (index == -1)
                return "";

            string ExtName = FileName.Substring(index + 1);
            return ExtName;
        }
        //�����ݽ��и�ʽ��
        static public string FormatBody(string str)
        {
            str = str.Replace("\n����", "\n");
            str = str.Replace("\n��", "\n");
            while (str.StartsWith("��"))
                str = str.Substring(2);

            string NewStr = str.Replace("\n", "<br>\n����");
            return "����" + NewStr;
        }
		/// <summary>
		/// �ִ���ȡ����
		/// </summary>
		/// <param name="ss">Ҫ��ȡ���ִ�</param>
		/// <param name="maxlen">����ִ�����</param>
		/// <returns>�ض̺���ִ�</returns>
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
		/// �ִ���ȡ����
		/// </summary>
		/// <param name="OldStr">Ҫ��ȡ���ִ�</param>
		/// <param name="MaxLen">����ִ�����</param>
		/// <returns>�ض̺���ִ�</returns>
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
		/// �����ַ��е��ص��Ķ����Լ����ҵĶ���
		/// </summary>
		/// <param name="ss">Ҫ�������ֵ��ִ�</param>
		/// <param name="delstr">Ҫ�������ִ�</param>
		/// <returns>��������֮����ִ�</returns>
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
		/// ���������ִ����㵽������
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
		/// ��ӱ���0
		/// </summary>
		/// <param name="subid"></param>
		/// <returns></returns>
		public static string AddZero(string subid)
		{
			return AddZero(subid,5);
		}

		/// <summary>
		/// ���������ִ����㵽����ұ�
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
		/// С��λ���������㵽��λ
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
		/// �Ҳಹ��
		/// </summary>
		/// <param name="subid"></param>
		/// <returns></returns>
		public static string AddZeroR(string subid)
		{
			return AddZeroR(subid,5);
		}

		/// <summary>
		/// �Բ���ķ�ʽ��ʾ�ַ���ǰ׺
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
        /// �Բ���ķ�ʽ��ʾ�ַ���
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
                    strChar = "�� ";
                    break;
                case 3:
                    strChar = "�� �� ";
                    break;
                case 5:
                    strChar = "�� �� �� ";
                    break;
                case 8:
                    strChar = "�� �� �� �� ";
                    break;
                case 10:
                    strChar = "�� �� �� �� �� ";
                    break;
            }
            return strChar;
        }

		/// <summary>
		/// ���˷Ƿ��ַ�
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
		/// ����ַ����Ƿ�����Ƿ��ַ�
		/// </summary>
		/// <param name="str">�����ַ���</param>
		/// <param name="invalid">�Ƿ��ַ���</param>
		/// <param name="needCheck">�Ƿ���Ϊ��</param>
		/// <returns>True�����Ƿ��ַ���Ϊ��False�޷Ƿ��ַ�</returns>
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
		/// ����ִ��Ϸ���
		/// </summary>
		/// <param name="str">�����ַ���</param>
		/// <param name="invalid">�Ƿ����ַ�</param>
		/// <returns>True�����Ƿ��ַ���Ϊ��False�޷Ƿ��ַ�</returns>
		public static bool checkInvalid(string str,string invalid)
		{
			return checkInvalid(str,invalid,true);
		}

		/// <summary>
		/// ����ִ��Ϸ���
		/// </summary>
		/// <param name="str">�ַ���</param>
		/// <returns>True�����Ƿ��ַ���Ϊ��False�޷Ƿ��ַ�</returns>
		public static bool checkInvalid(string str)
		{
			return checkInvalid(str,"\'\"<>+\\",true);
		}

		/// <summary>
		/// ���alert�ű�
		/// </summary>
		/// <param name="outstr"></param>
		/// <returns></returns>
		public static string AlertScript(string outstr)
		{
			return "alert('" + outstr + "');\n";
		}

		/// <summary>
		/// ���Focus�ű�
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string FocusScript(string obj)
		{
			return "document.forms[0].all[\"" + obj + "\"].focus();\n";
		}

		/// <summary>
		/// ������script��Χ���ִ�
		/// </summary>
		/// <param name="outstr">Ҫ����Ľű���</param>
		/// <returns></returns>
		public static string AddScript(string outstr)
		{
			string tempstr="<script language=javascript>\n"
				+outstr+"\n"
				+"</script>\n";
			return tempstr;
		}

		/// <summary>
		/// ת��ip��long
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
		/// ת���ַ���ip��������
		/// </summary>
		/// <param name="ipString"></param>
		/// <returns></returns>
		public static long ConvertIpToLong(string ipString)
		{
			IPAddress ip = IPAddress.Parse(ipString);
			return ConvertIpToLong(ip);
		}
		
		/// <summary>
		/// ת��������ip���ַ�����
		/// </summary>
		/// <param name="sip">������ip</param>
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
		/// ��ȡUrl��ǰ׺
		/// </summary>
		/// <param name="url">������url·��</param>
		/// <returns>url������·��</returns>
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
		/// ����Ϣ�ְ�ָ�����Ƚ��зָ�
		/// </summary>
		/// <param name="msg">Ҫ�ָ����Ϣ</param>
		/// <param name="splitlen">ָ���ķָ��(Ӣ�ĳ���)</param>
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
        //�����ݴ�JS�ļ�
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
        /// MD5 16λ���� ���ܺ���Ϊ��д
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
        /// MD5 16λ���� ���ܺ���Ϊ��д
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
        /// ���������ļ���key����ȡValueֵ
        /// </summary>
        /// <param name="Key">�����ļ��е�Keyֵ</param>
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
