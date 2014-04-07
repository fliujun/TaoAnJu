using System;
using System.Diagnostics;
using System.Web;
using System.Text;
using System.IO ;
using System.Security.Cryptography;
using System.Globalization;
namespace TaoAnJu.Util
{
	/// <summary>
	/// UserLogin ��ժҪ˵����
	/// </summary>
	public class CUserAuthen
	{
		private static readonly string COOKIENAME = "LoginUser";
		protected CUserAuthen()
		{
		
		}

		/// <summary>
		/// ��ȡCookie������û��Ƿ��¼��ͬʱ����û���Ϣ
		/// </summary>
		/// <param name="request">HTTP����</param>
		/// <param name="secret">������Կ</param>
		/// <param name="InfoTicket">�������������û��ѵ�¼�������û���Ϣ</param>
		/// <returns>����true��ʾ�û��ѵ�¼��false��ʾ�û�δ��¼</returns>
		public static bool CheckOpLogin(HttpRequest request, string secret, out CUserTicket InfoTicket)
		{
			InfoTicket = null;

			if ((request == null) || (secret == null) || (secret.Length == 0))
				throw new ArgumentNullException("Invalid Argument");

			try
			{
				HttpCookie LoginCookie = request.Cookies[COOKIENAME];
				if (LoginCookie == null)
				{
					return false;
				}
			
				string LoginTicket = request.Cookies[COOKIENAME].Value;

				if (LoginTicket == null)
				{
					return false;
				}

				if (LoginTicket.Length == 0)
				{
					return false;
				}

			
				bool ValidateRet = ValidateOpTicket(LoginTicket,secret,out InfoTicket);
			
				if (!ValidateRet)
					return false;
			
				return true;
							
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// �����¼Cookie
		/// </summary>
		/// <param name="response">HTTP Response</param>
		/// <returns>void</returns>
		public static void ClearLoginTicket(HttpResponse response)
		{
			HttpCookie LoginCookie = new HttpCookie(COOKIENAME, "0");
			LoginCookie.Path = "/";
			response.Cookies.Set(LoginCookie);
			return;
		}

	
		/// <summary>
		/// ��¼��֤�ɹ���д��֤��Ϣ
		/// </summary>
		/// <param name="response">HTTP Response</param>
		/// <param name="InfoTicket">Ҫд�����Ϣ</param>
		/// <param name="secret">������Կ</param>
		/// <returns>����0��ʾִ�гɹ���-1��ʾʧ��</returns>
		public static int WriteLoginTicket(HttpResponse response, CUserTicket InfoTicket, string secret)
		{
			try
			{
				string LoginTicket = GenerateOpTicket(InfoTicket,secret);
				HttpCookie LoginCookie = new HttpCookie(COOKIENAME, LoginTicket);
				LoginCookie.Path = "/";
				response.Cookies.Set(LoginCookie);
				return 0;
			}
			catch (Exception)
			{
				return -1;
			}
		}
		/// <summary>
		/// ���ݵ�¼��Ϣ��������¼��Ϣ��
		/// </summary>
		/// <param name="UserInfoStr">��Ϣ��</param>
		/// <returns>��Ϣ��</returns>
		protected static CUserTicket ParseTicket(string UserInfoStr)
		{
			string[] UserInfoArr = UserInfoStr.Split('\n');
			if (UserInfoArr.Length !=9)
				throw new ArgumentException();

            return new CUserTicket(Int32.Parse(UserInfoArr[0]), UserInfoArr[1], UserInfoArr[2], DateTime.Parse(UserInfoArr[3]), UserInfoArr[4], DateTime.Parse(UserInfoArr[5]), UserInfoArr[6], UserInfoArr[7],Convert.ToBoolean ( UserInfoArr[8]));

		}

	
		/// <summary>
		/// ��֤��¼��Ϣ������CheckOpLogin��������
		/// </summary>
		/// <param name="TicketStr">��Ϣ��</param>
		/// <param name="secret">������Կ</param>
		/// <param name="InfoTicket">�����������Ϣ</param>
		/// <returns>����true��ʾ��֤�ɹ���false��ʾ��֤ʧ��</returns>
		protected static bool ValidateOpTicket(string TicketStr, string secret, out CUserTicket InfoTicket)
		{
			InfoTicket = null;
		
			if ((TicketStr == null) || (secret == null) || (secret.Length == 0))
				throw new ArgumentNullException("Invalid Argument");

			try
			{

			
				byte[] Key = CTicketTool.GetKey(secret);
				byte[] LoginTicketCry = CTicketTool.Base64Decode(Encoding.ASCII.GetBytes(TicketStr));
				byte[] LoginTicketDec = CTicketTool.Decrypt(LoginTicketCry,Key);
				byte[] LoginInfoByte;

				if (LoginTicketDec.Length < 2)
					throw new System.Exception("Invalid ticket");

				int NextLen = CTicketTool.GetPart(LoginTicketDec,0,out LoginInfoByte);

				byte[] TickKey;
			
				if (LoginTicketDec.Length < NextLen + 2)
					throw new System.Exception("Invalid ticket");

				NextLen = CTicketTool.GetPart(LoginTicketDec,NextLen,out TickKey);
				if (!CTicketTool.CompareByteArrays(Key,TickKey))
					throw new System.Exception("Invalid ticket");

				string LoginInfo = Encoding.Unicode.GetString(LoginInfoByte);
			
				InfoTicket = ParseTicket(LoginInfo);

				return true;
							
			}
			catch (Exception)
			{
				return false;
			}
		}


		/// <summary>
		/// ���ɵ�¼��Ϣ������WriteLoginTicket��������
		/// </summary>
		/// <param name="InfoTicket">��Ϣ</param>
		/// <param name="secret">������Կ</param>
		/// <returns>���ؼ��ܺ���Ϣ��</returns>
		protected static string GenerateOpTicket(CUserTicket InfoTicket, string secret)
		{
			if ((InfoTicket == null) || (secret == null) || (secret.Length == 0))
				throw new ArgumentNullException("Invalid Argument");

			try
			{
				string InfoStr = InfoTicket.GenerateInfo();
				byte[] Key = CTicketTool.GetKey(secret);
				byte[] InfoByte = Encoding.Unicode.GetBytes(InfoStr);
			
				MemoryStream MSTicket = new MemoryStream();

				MSTicket.Write(CTicketTool.ConvertLength(InfoByte.Length),0,2);
				MSTicket.Write(InfoByte,0,InfoByte.Length);

				MSTicket.Write(CTicketTool.ConvertLength(Key.Length),0,2);
				MSTicket.Write(Key,0,Key.Length);

			
				byte[] TicketCryptByte = CTicketTool.Crypt(MSTicket.ToArray(),Key);

				string TicketCryptStr = Encoding.ASCII.GetString(CTicketTool.Base64Encode(TicketCryptByte));

				return TicketCryptStr;

			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
	
	/// <summary>
	/// ��֤�����Ϣ��
	/// </summary>
	public class CUserTicket
	{
		public Int32 UserId;
		public string LoginName;
        public string RealName;
		public DateTime LastLoginTime;
		public string LastLoginIp;
		public DateTime ExpireTime;
        public string UserType;
        public string FunIdList;
        public Boolean IsHaveChildFun;
        public CUserTicket(Int32 __UserId, string __LoginName, string __RealName, DateTime __LastLoginTime, string __LastLoginIp, DateTime __ExpireTime, string __UserType, string __FunIdList, Boolean __IsHaveChildFun)
		{
            UserId = __UserId;
            LoginName = __LoginName;
            RealName = __RealName;
			LastLoginTime = __LastLoginTime;
            LastLoginIp = __LastLoginIp;
			ExpireTime = __ExpireTime;
            UserType = __UserType;
            FunIdList = __FunIdList;
            IsHaveChildFun = __IsHaveChildFun;
		}

		public bool HasLogin()
		{
            if (LoginName  != "")
				return true;

			return false;
		}
		
		/// <summary>
		/// ������¼��Ϣ��������Ϣ�ֶμ���"\n"�ָ�
		/// </summary>
		/// <returns>��Ϣ��</returns>
		public string GenerateInfo()
		{
            string OpInfo = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n{8}", UserId.ToString(), LoginName, RealName, LastLoginTime, LastLoginIp, ExpireTime, UserType, FunIdList, IsHaveChildFun.ToString ());
			return OpInfo;
		}
	}
	/// <summary>
	/// Ticket���������ࡣʵ�ּ��ܡ������㷨��HASH�㷨
	/// </summary>
	public class CTicketTool
	{
    
		//ʹ��TripleDES����
		public static byte[] Crypt(byte[] source, byte[] key)
		{
			if ((source.Length ==0)||(source==null)||(key==null)||(key.Length==0))
			{
				throw new ArgumentException("Invalid Argument");
			}

			TripleDESCryptoServiceProvider dsp =new TripleDESCryptoServiceProvider();
			dsp.Mode = CipherMode.ECB;
		
			ICryptoTransform des = dsp.CreateEncryptor(key,null);

			try
			{
				return des.TransformFinalBlock(source,0,source.Length);
			}
			catch(Exception e1)
			{
				throw e1;
			}		

		}

		//ʹ��TripledDES����
		public static byte[] Decrypt(byte[] source,byte[] key)
		{
			if ((source.Length==0)||(source==null)||(key==null)||(key.Length==0))
			{
				throw new ArgumentNullException("Invalid Argument");
			}

			TripleDESCryptoServiceProvider dsp =new TripleDESCryptoServiceProvider();
			dsp.Mode = CipherMode.ECB;

			ICryptoTransform des = dsp.CreateDecryptor(key,null);
			try
			{
				byte [] ret = new byte[source.Length+8];
				int num;
				num =  des.TransformBlock(source,0, source.Length,ret,0);
				des.TransformBlock(source,source.Length-8,8,ret,num);
				return ret;
			}
			catch(Exception e1)
			{
				throw e1;
			}	

		}

		//ʹ��md5����ɢ��
		public static byte[] Hash(byte[] source )
		{
			if((source==null)||(source.Length ==0))
				throw new ArgumentException("source is not valid");

			MD5 m = MD5.Create ();
			return m.ComputeHash (source); 
		}

	
		//��secret���ɼ��ܵ�key
		public static byte[] GetKey(string secret)
		{
			if ((secret==null)||(secret.Length==0))
				throw new ArgumentException("Secret is not valid");
		
			byte[] temp;

			ASCIIEncoding ae = new ASCIIEncoding();
			temp = Hash(ae.GetBytes(secret));
		
			byte[] ret = new byte[16];

			int i;

			if (temp.Length < 16)
			{
				System.Array.Copy(temp,0,ret,0,temp.Length);
				for (i=temp.Length;i < 16;i++)
				{
					ret[i] = 0;
				}
			}
			else
				System.Array.Copy(temp,0,ret,0,16);

			return ret;		
		}

		//�Ľ����base64����:�ܹ�ͨ��http����
		public static string Encode(byte[] source)
		{
			byte[] dest;

			dest = Base64Encode(source);

			string ret;
			ret = new ASCIIEncoding().GetString(dest);
			ret = ret.Replace("+","~");
			ret = ret.Replace("/","@");
			ret = ret.Replace("=","$");
			return ret;

		}

		//�Ľ���base64�Ľ���
		public static byte[] Decode(string source)
		{

			string dest;
			dest = source.Replace("~","+");
			dest = dest.Replace("@","/");
			dest = dest.Replace("$","=");

			byte[] ret;
			ret = Base64Decode(new ASCIIEncoding().GetBytes(dest));

			return ret;
		}

		//ԭʼbase64����
		public static byte[] Base64Encode(byte[] source)
		{
			if((source==null)||(source.Length ==0))
				throw new ArgumentException("source is not valid");

			ToBase64Transform tb64 = new ToBase64Transform();
			MemoryStream stm = new MemoryStream();
			int pos = 0;
			byte[] buff;

			while (pos + 3 < source.Length) 
			{
				buff = tb64.TransformFinalBlock (source, pos, 3);
				stm.Write (buff, 0, buff.Length);
				pos += 3;
			}

			buff = tb64.TransformFinalBlock (source, pos, source.Length - pos);
			stm.Write (buff, 0, buff.Length);

			return stm.ToArray();

		}

		//ԭʼbase64����
		public static byte[] Base64Decode(byte[] source)
		{
			if ((source==null)||(source.Length==0))
				throw new ArgumentException("source is not valid");

			FromBase64Transform fb64 = new FromBase64Transform();
			MemoryStream stm = new MemoryStream();
			int pos = 0;
			byte[] buff;

			while (pos + 4 < source.Length) 
			{
				buff = fb64.TransformFinalBlock (source, pos, 4);
				stm.Write (buff, 0, buff.Length);
				pos += 4;
			}

			buff = fb64.TransformFinalBlock (source, pos, source.Length - pos);
			stm.Write (buff, 0, buff.Length);
			return stm.ToArray();

		}
	
		//�Ƚ�����byte�����Ƿ���ͬ
		public static bool CompareByteArrays(byte[] source,byte[] dest)
		{
			if ((source==null)||(dest==null))
				throw  new ArgumentException("source or dest is not valid");

			bool ret = true;

			if (source.Length != dest.Length)
				return false;
			else
				if (source.Length ==0)
				return true;

			for (int i =0;i<source.Length ;i++)
				if (source[i]!=dest[i])
				{
					ret = false;
					break;
				}
			return ret;		

		}

		//���ݹ���ԭ�ֶγ���
		public static int GetLength(byte[] length)
		{

			if ((length==null)||(length.Length ==0))
				throw new ArgumentException("Invalid Lenght");

			return System.Convert.ToInt16(length[0])* 256 + System.Convert.ToInt16(length[1]);
		}

		//���ݹ�������ֶγ��ȣ�����������д��byte�����з���
		public static byte[] ConvertLength(int length)
		{
			byte[] ret = new byte[2];

			ret[0] =(byte)( length / 256);
			ret[1] = (byte)(length % 256);

			return ret;
		}

		//ȡ����һ���ֶεĳ��ȣ�������һ���ֶε�����
		public static int GetPart(byte[] source,int posStart,out byte[] dest)
		{
			if (source == null || source.Length == 0) 
			{
				throw new ArgumentException ("Invalid TicketRequest.");
			}

			int length; //lenght���ֽ������ǰ��λ�����Ҹ�λ��ǰ����λ�ں�
	
			try
			{

				byte[] ll = new Byte[2];
				ll[0] = source[posStart];
				ll[1] = source[posStart+1];
				length = GetLength(ll);	

				if (source.Length < posStart + 2 + length)
					throw new Exception("Invalid ticket");

				dest = new byte[length];
				System.Array.Copy(source,posStart+2,dest,0,length);
				return posStart + 2 + length ;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
	/// <summary>
	/// �ַ������ܽ�����
	/// Encrypt���������ַ���
	/// Decrypt���������ַ���
	/// ϵͳ�����е������ֶζ��Ƕ����ļ��ܺ�洢�����ݿ���ֻ�洢���ġ�
	/// ������֤ʱҲӦ�õ��ü��ܷ��������ļ��ܣ��Ƚ������Ƿ���ȡ�
	/// </summary>
	public class CSecretProcess
	{
		protected CSecretProcess()
		{
		}

		/// <summary>
		/// ���ܷ���
		/// </summary>
		/// <param name="content">��Ҫ���ܵ���������</param>
		/// <param name="secret">������Կ</param>
		/// <returns>���ؼ��ܺ������ַ���</returns>
		public static string Encrypt(string content,string secret)
		{
			if ((content == null) || (secret == null) || (content.Length == 0) || (secret.Length == 0))
				throw new ArgumentNullException("Invalid Argument");

			try
			{
				byte[] Key = CTicketTool.GetKey(secret);
				byte[] ContentByte = Encoding.Unicode.GetBytes(content);

				MemoryStream MSTicket = new MemoryStream();

				MSTicket.Write(CTicketTool.ConvertLength(ContentByte.Length),0,2);
				MSTicket.Write(ContentByte,0,ContentByte.Length);

				byte[] ContentCryptByte = CTicketTool.Crypt(MSTicket.ToArray(),Key);
				
				string ContentCryptStr = Encoding.ASCII.GetString(CTicketTool.Base64Encode(ContentCryptByte));

				return ContentCryptStr;
			}
			catch(Exception e)
			{
				throw e;
			}

		}

		/// <summary>
		/// ���ܷ���
		/// </summary>
		/// <param name="content">��Ҫ���ܵ���������</param>
		/// <param name="secret">������Կ</param>
		/// <returns>���ؽ��ܺ������ַ���</returns>
		public static string Decrypt(string content,string secret)
		{
			if ((content == null) || (secret == null) || (content.Length == 0) || (secret.Length == 0))
				throw new ArgumentNullException("Invalid Argument");

			try
			{

			
				byte[] Key = CTicketTool.GetKey(secret);

				byte[] CryByte = CTicketTool.Base64Decode(Encoding.ASCII.GetBytes(content));
				byte[] DecByte = CTicketTool.Decrypt(CryByte,Key);
				
				if (DecByte.Length < 2)
					throw new System.Exception("Invalid content");

				byte[] RealDecByte;
				int NextLen = CTicketTool.GetPart(DecByte,0,out RealDecByte);

				string RealDecStr = Encoding.Unicode.GetString(RealDecByte);

				return RealDecStr;

			}
			catch(Exception e)
			{
				throw e;
			}
		}
	}
}
