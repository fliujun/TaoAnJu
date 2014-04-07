using System;
using System.Data;
using System.IO;
using System.Text;
using System.Data.SqlClient;

namespace TaoAnJu.Util
{
	public enum DbLobType {text, binary}
	public enum DBLobOperation {read, write, writenotruncate}
	/// <summary>
	/// DBLobAccess, used for database Lob field access¡£
	/// </summary>
	public class DBLobAccess
	{
		
		private const int BUFFER_LENGTH = 65536; // the default buffer length
		private DsConnectionDB m_objConn;
		private DbLobType m_lobType;  // "text" or "binary"
		private DBLobOperation m_lobOp; // read or write or truncatewrite
		private string m_strTable;
		private string m_strField;
		private string m_strCond;
		private bool m_boolLobInited;  //if the lob field has been initiated
		private SqlTransaction m_Trans;
		private long m_lLobLength;
		private long m_lCurrentOffset;
		private SqlCommand m_ocmdPointer;
		private SqlDataReader m_odrPointer;
		private bool m_boolWriteCommited;
		

		public DBLobAccess(DsConnectionDB oConn,
						   string strTable,
						   string strField,
						   string strCond,
						   DbLobType enumLobType, 
						   DBLobOperation enumLobOp)
		{
			m_objConn = oConn;
			m_lobType = enumLobType;
			m_lobOp = enumLobOp;
			m_strTable = strTable;
			m_strField = strField;
			m_strCond = strCond;
			m_boolLobInited = false;
			m_lLobLength = 0;
			m_lCurrentOffset = 0;
			m_boolWriteCommited = false;


		}

		/// <summary>
		/// preparing tht write task, initilize object used for fllowed write bytes/string operation
		/// 
		/// </summary>
		/// <param></param>
		/// <returns></returns>
		private void prepareLobWrite()
		{
			if(m_boolLobInited)
				return;
			m_Trans = m_objConn.getDbConnection().BeginTransaction(IsolationLevel.ReadCommitted);


			string strSQL;
			
			if(m_lobOp == DBLobOperation.writenotruncate)
			{
				strSQL = "SET NOCOUNT ON;UPDATE " + m_strTable + " SET " + m_strField + "=null WHERE " + m_strCond + "; SELECT @Pointer=TEXTPTR(" +
					m_strField + ") FROM " + m_strTable + " WHERE " + m_strCond;
			}
			else
			{
				// get the data length of the current field and store the value in m_lLobLength
				m_lLobLength = (long)m_objConn.ExecSQLWithScalar("select DATALENGTH(" + m_strField + ") FROM " + m_strTable + " WHERE " + m_strCond,null);
				strSQL = "SET NOCOUNT ON; SELECT @Pointer=TEXTPTR(" + m_strField + ") FROM " + m_strTable + " WHERE " + m_strCond;
			}

			SqlCommand cmdGetPointer = new SqlCommand(strSQL, m_objConn.getDbConnection());
			
			SqlParameter PointerOutParam = cmdGetPointer.Parameters.Add("@Pointer", SqlDbType.VarBinary, 100);
			PointerOutParam.Direction = ParameterDirection.Output;
			cmdGetPointer.ExecuteNonQuery();

			// Set up UPDATETEXT command, parameters, and open BinaryReader.

			SqlParameter PointerParam;
			SqlParameter BytesParam;
			SqlCommand cmdUploadBinary = new SqlCommand("UPDATETEXT " + m_strTable + "." + m_strField +" @Pointer @Offset @Delete WITH LOG @Bytes", m_objConn.getDbConnection());
			if(m_lobType == DbLobType.binary)
				PointerParam  = cmdUploadBinary.Parameters.Add("@Pointer", SqlDbType.Binary, 16);
			else
				PointerParam  = cmdUploadBinary.Parameters.Add("@Pointer", SqlDbType.Text, 16);
			PointerParam.Value= PointerOutParam.Value;
			SqlParameter OffsetParam= cmdUploadBinary.Parameters.Add("@Offset", SqlDbType.Int);
			SqlParameter DeleteParam = cmdUploadBinary.Parameters.Add("@Delete", SqlDbType.Int);
			DeleteParam.Value = 0;  // delete 0x0 character
			if(m_lobType == DbLobType.binary)
				BytesParam  = cmdUploadBinary.Parameters.Add("@Bytes", SqlDbType.Binary, BUFFER_LENGTH);
			else
				BytesParam  = cmdUploadBinary.Parameters.Add("@Bytes", SqlDbType.Text, BUFFER_LENGTH);
			m_ocmdPointer = cmdUploadBinary;


			
			m_boolLobInited = true;

		}
		/// <summary>
		/// preparing tht read task, initilize object used for fllowed read bytes/string operation
		/// 
		/// </summary>
		/// <param name="strRelative"></param>
		/// <returns></returns>
		private void prepareLobRead()
		{



			string strSQL;

			strSQL = "SELECT " + m_strField + " FORM " + m_strTable + " WHERE " + m_strCond;
			SqlCommand cmd = new SqlCommand(strSQL, m_objConn.getDbConnection());
			SqlDataReader dr  = m_objConn.ExecCMDWithReader(cmd,null,CommandBehavior.SequentialAccess);
			m_odrPointer = dr;
			m_odrPointer.Read();
			if( m_lobType == DbLobType.binary)
				m_lLobLength = m_odrPointer.GetBytes(0, 0,null,0,0);
			else
				m_lLobLength = m_odrPointer.GetChars(0, 0,null,0,0);
			


			m_boolLobInited = true;

		}

		public long getLobLength(){
			if( m_boolLobInited )
				return m_lLobLength;
			else
			{
				if(m_lobOp == DBLobOperation.read)
					prepareLobRead();
				else
					prepareLobWrite();
			}	
			return m_lLobLength;
		}
		/// <summary>
		/// get bytes
		/// 
		/// </summary>
		/// <param name="strRelative"></param>
		/// <returns>return the real data length in the byte array</returns>
		public int getLobBytes(ref byte[] bytesRead, long lOffset, long lLength)
		{
			long lRead;
			if(m_lobOp != DBLobOperation.read)
				throw new SysException("call read method on write lob type",  5, true);
			prepareLobRead();


			if(m_lobType == DbLobType.text)
				throw new SysException("text Lob field don't support bytes read method", 5, true);
			if(lOffset > m_lLobLength)
				throw new SysException(" the start offset exceed the data",3);
			if(lOffset+lLength > m_lLobLength)
				lRead = m_lLobLength - lOffset;
			else
				lRead = lLength;

			m_odrPointer.GetBytes(0,lOffset,bytesRead,0,(int)lRead);
			


			return (int)lRead;
		
		}
		/// <summary>
		/// get bytes
		/// 
		/// </summary>
		/// <param name="strRelative"></param>
		/// <returns>return the real data length in the byte array</returns>
		public int getLobString(ref char[] stringRead, long lOffset, long lLength)
		{
			long lRead;
			if(m_lobOp != DBLobOperation.read)
				throw new SysException("call read method on write lob type",  5, true);
			prepareLobRead();
			if(m_lobType == DbLobType.binary )
				throw new SysException("binary Lob field don't support string read method",  5, true);
			if(lOffset > m_lLobLength)
				throw new SysException(" the start offset exceed the data",3 );
			if(lOffset+lLength > m_lLobLength)
				lRead = m_lLobLength - lOffset;
			else
				lRead = lLength;

			m_odrPointer.GetChars(0,lOffset,stringRead,0,(int)lRead);


			return (int)lRead;
		
		}
		/// <summary>
		/// get bytes
		/// 
		/// </summary>
		/// <param name="strRelative"></param>
		/// <returns>return the real data length in the byte array</returns>

		public void writeLobBytes(byte[] bytesWrite, long lOffset, long lLength, bool boolCommit)
		{
			long lWrite;
			if(m_boolWriteCommited)
				throw new SysException("call write method after commit the write transaction", 5, true);
			if(m_lobOp != DBLobOperation.writenotruncate && m_lobOp != DBLobOperation.write)
				throw new SysException("call write method on read lob type",  5, true);
			prepareLobWrite();
			if(m_lobType == DbLobType.text)
				throw new SysException("text Lob field don't support bytes wirte method",  5, true);
			lWrite = bytesWrite.Length > lLength ? lLength : bytesWrite.Length;


			m_ocmdPointer.Parameters["@Bytes"].Size= (int)lWrite;
			m_ocmdPointer.Parameters["@Bytes"].Value=bytesWrite;
			m_ocmdPointer.Parameters["@Offset"].Value = lOffset;

			m_ocmdPointer.ExecuteNonQuery();
			m_lCurrentOffset = lOffset + lWrite;

			if(boolCommit)
				commitWrite();


		
		}

		/// <summary>
		/// get bytes
		/// 
		/// </summary>
		/// <param name="strRelative"></param>
		/// <returns>return the real data length in the byte array</returns>
		public void commitWrite()
		{
			if(m_boolWriteCommited)
				return;

			if(m_Trans != null)
			{
				m_Trans.Commit();
				m_Trans = null;
			}
			m_boolWriteCommited = true;


		}
		/// <summary>
		/// get bytes
		/// 
		/// </summary>
		/// <param name="strRelative"></param>
		/// <returns>return the real data length in the byte array</returns>
		public void endRead()
		{
			if(m_odrPointer != null)
			{
				m_odrPointer.Close();
				m_odrPointer = null;
			}
		}
		public void writeLobString(char[] stringWrite, long lOffset, long lLength, bool boolCommit){
			long lWrite;

			if(m_boolWriteCommited)
				throw new SysException("call write method after commit the write transaction", 5, true);

			if(m_lobOp != DBLobOperation.writenotruncate && m_lobOp != DBLobOperation.write)
				throw new SysException("call write method on read lob type",  5, true);

			if(m_lobType == DbLobType.binary)
				throw new SysException("binary Lob field don't support text wirte method",  5, true);
			lWrite = stringWrite.Length > lLength ? lLength : stringWrite.Length;

			m_ocmdPointer.Parameters["@Bytes"].Size= (int)lWrite;
			m_ocmdPointer.Parameters["@Bytes"].Value=stringWrite;
			m_ocmdPointer.Parameters["@Offset"].Value = lOffset;

			m_ocmdPointer.ExecuteNonQuery();
			m_lCurrentOffset = lOffset + lWrite;

			if(boolCommit)
				commitWrite();


		}
		/// <summary>
		/// get bytes
		/// 
		/// </summary>
		/// <param name="strRelative"></param>
		/// <returns>return the real data length in the byte array</returns>
		~DBLobAccess()
		{ 
			
			if(m_Trans != null)
			{
				m_Trans.Rollback();
				m_Trans = null;
			}
			if(m_odrPointer != null)
			{
				m_odrPointer.Close();
				m_odrPointer = null;
			}

		}

	}
}
