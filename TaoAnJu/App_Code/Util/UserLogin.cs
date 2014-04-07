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
	/// UserLogin 的摘要说明。
	/// </summary>
	public class CUserAuthen
	{
		private static readonly string COOKIENAME = "LoginUser";
		protected CUserAuthen()
		{
		
		}

		/// <summary>
		/// 读取Cookie，检查用户是否登录，同时输出用户信息
		/// </summary>
		/// <param name="request">HTTP请求</param>
		/// <param name="secret">加密密钥</param>
		/// <param name="InfoTicket">输出参数，如果用户已登录，返回用户信息</param>
		/// <returns>返回true表示用户已登录，false表示用户未登录</returns>
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
		/// 清除登录Cookie
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
		/// 登录验证成功后，写认证信息
		/// </summary>
		/// <param name="response">HTTP Response</param>
		/// <param name="InfoTicket">要写入的信息</param>
		/// <param name="secret">加密密钥</param>
		/// <returns>返回0表示执行成功，-1表示失败</returns>
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
		/// 根据登录信息串产生登录信息类
		/// </summary>
		/// <param name="UserInfoStr">信息串</param>
		/// <returns>信息类</returns>
		protected static CUserTicket ParseTicket(string UserInfoStr)
		{
			string[] UserInfoArr = UserInfoStr.Split('\n');
			if (UserInfoArr.Length !=9)
				throw new ArgumentException();

            return new CUserTicket(Int32.Parse(UserInfoArr[0]), UserInfoArr[1], UserInfoArr[2], DateTime.Parse(UserInfoArr[3]), UserInfoArr[4], DateTime.Parse(UserInfoArr[5]), UserInfoArr[6], UserInfoArr[7],Convert.ToBoolean ( UserInfoArr[8]));

		}

	
		/// <summary>
		/// 验证登录信息串，由CheckOpLogin方法调用
		/// </summary>
		/// <param name="TicketStr">信息串</param>
		/// <param name="secret">加密密钥</param>
		/// <param name="InfoTicket">输出参数，信息</param>
		/// <returns>返回true表示验证成功，false表示验证失败</returns>
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
		/// 生成登录信息串，由WriteLoginTicket方法调用
		/// </summary>
		/// <param name="InfoTicket">信息</param>
		/// <param name="secret">加密密钥</param>
		/// <returns>返回加密后信息串</returns>
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
	/// 认证后的信息类
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
		/// 产生登录信息串。各信息字段间以"\n"分隔
		/// </summary>
		/// <returns>信息串</returns>
		public string GenerateInfo()
		{
            string OpInfo = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n{8}", UserId.ToString(), LoginName, RealName, LastLoginTime, LastLoginIp, ExpireTime, UserType, FunIdList, IsHaveChildFun.ToString ());
			return OpInfo;
		}
	}
	/// <summary>
	/// Ticket操作工具类。实现加密、解密算法和HASH算法
	/// </summary>
	public class CTicketTool
	{
    
		//使用TripleDES加密
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

		//使用TripledDES解密
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

		//使用md5计算散列
		public static byte[] Hash(byte[] source )
		{
			if((source==null)||(source.Length ==0))
				throw new ArgumentException("source is not valid");

			MD5 m = MD5.Create ();
			return m.ComputeHash (source); 
		}

	
		//从secret生成加密的key
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

		//改进后的base64编码:能够通过http传递
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

		//改进的base64的解码
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

		//原始base64编码
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

		//原始base64解码
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
	
		//比较两个byte数组是否相同
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

		//根据规则还原字段长度
		public static int GetLength(byte[] length)
		{

			if ((length==null)||(length.Length ==0))
				throw new ArgumentException("Invalid Lenght");

			return System.Convert.ToInt16(length[0])* 256 + System.Convert.ToInt16(length[1]);
		}

		//根据规则计算字段长度，并将长度填写到byte数组中返回
		public static byte[] ConvertLength(int length)
		{
			byte[] ret = new byte[2];

			ret[0] =(byte)( length / 256);
			ret[1] = (byte)(length % 256);

			return ret;
		}

		//取出下一个字段的长度，返回下一个字段的内容
		public static int GetPart(byte[] source,int posStart,out byte[] dest)
		{
			if (source == null || source.Length == 0) 
			{
				throw new ArgumentException ("Invalid TicketRequest.");
			}

			int length; //lenght是字节数组的前两位，而且高位在前，低位在后
	
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
	/// 字符串加密解密类
	/// Encrypt方法加密字符串
	/// Decrypt方法解密字符串
	/// 系统中所有的密码字段都是对明文加密后存储，数据库中只存储密文。
	/// 密码验证时也应该调用加密方法对明文加密，比较密文是否相等。
	/// </summary>
	public class CSecretProcess
	{
		protected CSecretProcess()
		{
		}

		/// <summary>
		/// 加密方法
		/// </summary>
		/// <param name="content">需要加密的明文内容</param>
		/// <param name="secret">加密密钥</param>
		/// <returns>返回加密后密文字符串</returns>
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
		/// 解密方法
		/// </summary>
		/// <param name="content">需要解密的密文内容</param>
		/// <param name="secret">解密密钥</param>
		/// <returns>返回解密后明文字符串</returns>
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
