using System;
using System.Data;
using System.Data.SqlClient;

namespace TaoAnJu.Util
{
	/// <summary>
	/// DsConnectionDB 
	/// �̳�IDisposable�ӿ�
	/// ʵ��Close��Dispose
	/// </summary>
	public class DsConnectionDB:IDisposable
	{
		private string m_strConnectionString; //database connection string
		private bool m_boolConnected;	//if the database connection has been established
		private SqlConnection m_objDbConn;   //the database connection object

		#region ��������
		private SqlTransaction _transaction;
		private bool m_autoCloseConn=false;
		#endregion ��������

		public DsConnectionDB()
		{
			m_boolConnected = false;
			m_strConnectionString = "";
		}
		public DsConnectionDB(string strConn)
		{
			m_boolConnected = false;
            //strConn = System.Configuration.ConfigurationManager.AppSettings[strConn];
			Connect(strConn);
		}

		/// <summary>
		/// ����SQLִ�е��ù��캯�������ڵ���SQL��������
		/// ��ע�����autoCloseConnection=true,����ʱ����Connection
		/// ����ʽ����֮ǰ�Ŵ�Connection,���ڵ���һ��ִ��֮���Զ��ر����ӡ�
		/// </summary>
		/// <param name="strConn"></param>
		/// <param name="autoCloseConnection"></param>
		public DsConnectionDB(string strConn,bool autoCloseConnection)
		{
			m_autoCloseConn=autoCloseConnection;
			m_boolConnected = false;
			this.m_strConnectionString=strConn;
			if (!autoCloseConnection)
			{
				Connect(strConn);
			}
		}

		/// <summary>
		/// close the database connection before object destoried
		/// </summary>
		/// <returns></returns>
		~DsConnectionDB()
		{
			DisConnect();
		}
		/// <summary>
		/// open the database according to the connection string, return the connection object
		/// </summary>
		/// <returns></returns>
		public SqlConnection Connect(string strConn)
		{
			if(m_boolConnected && strConn == m_strConnectionString)
				return m_objDbConn;
			else
			{
				if(m_boolConnected)
					DisConnect();
			}
			try
			{
				m_objDbConn = new SqlConnection(strConn);
				//m_objDbConn.ConnectionString = ;
				m_objDbConn.Open();
				m_strConnectionString = strConn;
				m_boolConnected = true;
			}
			catch(System.Exception e)
			{
				throw new SysException("Database connection failed with '" + strConn + "'", e, 5, true);
			}
			return m_objDbConn;

		}

		public void DisConnect()
		{
			if(m_boolConnected && m_objDbConn != null)
			{
				try
				{
					m_objDbConn.Close();
				}
				catch{}
				m_boolConnected = false;
				m_objDbConn = null;
			}
		}

		public SqlTransaction BeginTrans(System.Data.IsolationLevel enumIsoLevel)
		{
			if(!m_boolConnected)
				throw new SysException("call BeginTrans before connection established",5);
			_transaction = m_objDbConn.BeginTransaction(enumIsoLevel);
			return _transaction;
		}

		public void CommitTrans(SqlTransaction oTrans)
		{
			if(!m_boolConnected)
				throw new SysException("call BeginTrans before connection established",5);
			oTrans.Commit();
		}

		public void RollbackTrans(SqlTransaction oTrans)
		{
			if(!m_boolConnected)
				throw new SysException("call BeginTrans before connection established",5);
			oTrans.Rollback();
		}

		#region ��������

		#region ���񲿷�
		/// <summary>
		/// ��ʼ����
		/// </summary>
		/// <returns>�������</returns>
		public SqlTransaction BeginTransaction()
		{
			CheckTransactionState(false);
			_transaction = m_objDbConn.BeginTransaction();
			return _transaction;
		}

		/// <summary>
		/// �������
		/// </summary>
		public void CommitTransaction()
		{
			CheckTransactionState(true);
			_transaction.Commit();
			_transaction = null;
		}

		/// <summary>
		/// RollBack����
		/// </summary>
		public void RollbackTransaction()
		{
			CheckTransactionState(true);
			_transaction.Rollback();
			_transaction = null;
		}

		/// <summary>
		/// ��������״̬
		/// </summary>
		/// <param name="mustBeOpen">�Ƿ�����</param>
		private void CheckTransactionState(bool mustBeOpen)
		{
			if(mustBeOpen)
			{
				if(null == _transaction)
					throw new InvalidOperationException("Transaction is not open.");
			}
			else
			{
				if(null != _transaction)
					throw new InvalidOperationException("Transaction is already open.");
			}
		}
		#endregion ���񲿷�

		#region ��ʼ�����ر����ͷ�
		
		/// <summary>
		/// �رշ���
		/// </summary>
		public virtual void Close()
		{
			if(null != m_objDbConn)
			{
				try
				{
					m_objDbConn.Close();
				}
				catch{}
				finally
				{
					this.m_boolConnected=false;
				}
			}
		}

		public virtual void CloseDb(SqlCommand cmd)
		{
			if(null != cmd)
			{
				try
				{
					cmd.Dispose();
				}
				catch{}
			}
		}

		public virtual void CloseDb(SqlDataAdapter sda)
		{
			if(null != sda)
			{
				try
				{
					sda.Dispose();
				}
				catch{}
			}
		}


		public virtual void CloseDb(SqlCommand cmd,SqlDataAdapter sda)
		{
			
			CloseDb(cmd);
			CloseDb(sda);
			this.Close();
		}

		/// <summary>
		/// �ͷ���Դ
		/// </summary>
		public virtual void Dispose()
		{
			try
			{
				Close();
			}
			catch {}
			if(null != m_objDbConn)
				m_objDbConn.Dispose();
		}

		#endregion �ر����ͷ�

		#region ͨ�÷���

		public SqlParameter AddParameter(SqlCommand cmd, string paramName,SqlDbType dbType, object value)
		{
			SqlParameter parameter = cmd.CreateParameter();
			parameter.ParameterName = "@" +paramName;
			parameter.SqlDbType = dbType;
			parameter.Value = null == value ? DBNull.Value : value;
			cmd.Parameters.Add(parameter);
			return parameter;
		}

		/// <summary>
		/// ����ͨ��Command����
		/// </summary>
		/// <param name="sqlText">sql�ű�</param>
		/// <returns>SqlCommand</returns>
		public SqlCommand CreateCommand(string sqlText)
		{
			return CreateCommand(sqlText, false);
		}

		/// <summary>
		/// ����Command����
		/// </summary>
		/// <param name="sqlText">sql�ű�</param>
		/// <param name="procedure">�Ƿ�洢����</param>
		/// <returns>SqlCommand</returns>
		public SqlCommand CreateCommand(string sqlText, bool procedure)
		{
			SqlCommand cmd = getDbConnection().CreateCommand();
            string CTimeout = System.Configuration.ConfigurationManager.AppSettings["CommandTimeout"];
            if (CTimeout == "")
            {
                CTimeout = "180";
            }
            cmd.CommandTimeout = int.Parse(CTimeout);
			cmd.CommandText = sqlText;
			cmd.Transaction = _transaction;
			if(procedure)
				cmd.CommandType = CommandType.StoredProcedure;
			return cmd;
		}

		/// <summary>
		/// ִ��ͨ�ò�ѯ
		/// </summary>
		/// <param name="sqlStmt">��ѯ�ű�</param>
		/// <returns>���ز�ѯ���DataSet</returns>
		public DataSet ExecuteQuery(string sqlStmt)
		{
			return this.ExecSQLWithDataSet(sqlStmt,0,0,this._transaction);
		}

		/// <summary>
		/// ִ��Scalar��ѯ
		/// </summary>
		/// <param name="sqlStmt">��ѯ����</param>
		/// <returns>���ز�ѯ���Object</returns>
		public object ExecuteScalar(string sqlStmt)
		{
			return this.ExecSQLWithScalar(sqlStmt,this._transaction);
		}

		/// <summary>
		/// ִ�в�ѯ��亯��
		/// </summary>
		/// <param name="sqlStmt">��ѯ���</param>
		/// <returns>���ز�ѯ������ݼ�</returns>
		public SqlDataReader ExecuteQueryReader(string sqlStmt)
		{
			return this.ExecSQLWithReader(sqlStmt,this._transaction,CommandBehavior.Default);
		}

		/// <summary>
		/// ִ�зǲ�ѯ��亯��
		/// </summary>
		/// <param name="sqlStmt">�ǲ�ѯ���</param>
		/// <returns>���������Ӱ�������</returns>
		public int ExecuteNonQuery(string sqlStmt)
		{
			return this.ExecSQL(sqlStmt,_transaction);
		}

		/// <summary>
		/// ִ�д洢���̲�ѯ��亯��
		/// </summary>
		/// <param name="arrPara">�洢���̵Ĳ�������</param>
		/// <param name="arrParaValue">�洢����֮������ֵ����</param>
		/// <param name="procName">�洢��������</param>
		/// <param name="tableName">�洢���̲����ı���</param>
		/// <returns>���ز�ѯ������ݼ�</returns>
		public DataSet ExecuteQueryProc(string[] arrPara,string[] arrParaValue,string procName,string tableName)
		{
			SqlDataAdapter sqlDA = new SqlDataAdapter (procName,getDbConnection());
			sqlDA.SelectCommand.CommandTimeout =999999;
			sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure ;
			
			int lenForPara = arrPara.Length ;
			int lenForValue =arrParaValue.Length ;
			if (lenForPara==lenForValue&&lenForPara>0)
			{
				for (int i=0;i<lenForPara;i++)
				{				
					string parai = arrPara[i].ToString().Trim();
					string valuei= arrParaValue[i].ToString().Trim();
					sqlDA.SelectCommand.Parameters.Add(parai,valuei);
				}	
			}
			DataSet ds = new DataSet ();
			try
			{
				sqlDA.Fill(ds,tableName);
			}
			catch(SqlException ee)
			{
				throw new SysException("execute QueryProc '" + procName + ":" + tableName + "'failed", ee, 5, true);
			}
			finally
			{
			}
			return ds;
		}

		/// <summary>
		/// ִ�д洢���̷ǲ�ѯ��亯��
		/// </summary>
		/// <param name="arrPara" >�洢���̵Ĳ�������</param>
		/// <param name="arrParaValue" >�洢����֮������ֵ����</param>
		/// <param name="arrType" >�洢����֮��������������</param>
		/// <param name="arrLen" >�洢����֮�����ĳ�������</param>
		/// <param name="procName">�洢��������</param>
		/// <returns>���������Ӱ�������(-1��ʾ�����쳣)</returns>
		public int ExecuteNonProc(string[] arrPara,string[] arrParaValue,SqlDbType[] arrType,int[] arrLen,string procName)
		{			
			SqlCommand sqlCmd = new SqlCommand(procName,getDbConnection());
            string CTimeout = System.Configuration.ConfigurationManager.AppSettings["CommandTimeout"];
            if (CTimeout == "")
            {
                CTimeout = "180";
            }
            sqlCmd.CommandTimeout = int.Parse(CTimeout);
			sqlCmd.CommandType = CommandType.StoredProcedure ;
			int retVal=-1;
			int lenForPara = arrPara.Length ;
			int lenForValue =arrParaValue.Length ;
			int lenForType = arrType.Length ;
			int lenForLen = arrLen.Length ;
			if (lenForPara==lenForType&&lenForPara==lenForLen&&lenForPara==lenForValue&&lenForPara>0)
			{
				for (int i=0;i<lenForPara;i++)
				{				
					string parai = arrPara[i].ToString().Trim();
					string valuei= arrParaValue[i].ToString().Trim();
					SqlDbType typei = arrType[i];
					int leni;
					if(arrLen[i].ToString().Trim()=="")
					{
						leni=0;
					}
					else
					{
						leni = Convert.ToInt32 (arrLen[i].ToString().Trim());
					}
					sqlCmd.Parameters.Add(new SqlParameter(parai,typei,leni));
					if(i+1==lenForPara)
					{
						sqlCmd.Parameters[i].Direction=ParameterDirection.Output ;
					}
					sqlCmd.Parameters[i].Value=valuei;
				}	
				try
				{
					//SqlParameter objParam = sqlCmd.Parameters.Add("@retVal",SqlType.SmallInt ,1);		
					//objParam.Direction= ParameterDirection.ReturnValue ;
					sqlCmd.ExecuteNonQuery();
					retVal = (int)sqlCmd.Parameters [lenForPara-1].Value ;
				}
				catch(SqlException ee)
				{
					retVal=-1;
					throw new SysException("execute QueryProc '" + procName + "'failed", ee, 5, true);
				}
				finally
				{
				}
			}
			return retVal;
		}
		#endregion ͨ�÷���

		#endregion ��������

		public virtual SqlDataReader ExecuteReader(SqlCommand command)
		{
			return command.ExecuteReader();
		}

		public  SqlConnection getDbConnection()
		{
			/*
			if(!m_boolConnected)
				throw new SysException("call getDbConnection before connection established",5);
			*/
			if (!m_boolConnected)
			{
				if (this.m_autoCloseConn)
				{
					this.Connect(this.m_strConnectionString);
				}
				else
				{
					throw new SysException("call getDbConnection before connection established",5);
				}
			}
			return m_objDbConn;
		}

		/// <summary>
		/// execute the sql string with no return
		/// </summary>
		/// <param name="strSQL">the Sql string will be execute</param>
		///  <param name="oTrans">the transaction object, pass null if no transaction</param>
		/// <returns>the key string value</returns>
		public int ExecSQL(string strSQL,SqlTransaction oTrans)
		{
			SqlCommand oCmd;

			int iRowsEffected = 0;

			if(oTrans == null)
				oCmd = new SqlCommand(strSQL, getDbConnection());
			else
				oCmd = new SqlCommand(strSQL, getDbConnection(),oTrans);
			try
			{
                string CTimeout = System.Configuration.ConfigurationManager.AppSettings["CommandTimeout"];
                if (CTimeout == "")
                {
                    CTimeout = "180";
                }
                oCmd.CommandTimeout = int.Parse(CTimeout);
				iRowsEffected = oCmd.ExecuteNonQuery();
			}
			catch(System.Exception e)
			{
				m_objDbConn.Close();
				m_boolConnected = false;
				Loger.logErr("DsConnectionDB","ExecSQL",e,5,"SQL=" + strSQL);
				throw new SysException("execute SQL '" + strSQL + "'failed", e, 5, true);
			}
			finally
			{
				if (this.m_autoCloseConn)
				{
					this.Close();
				}
			}

			return iRowsEffected;
				
		}
		public SqlDataReader ExecSQLWithReader(string strSQL,SqlTransaction oTrans, CommandBehavior enumBehavior)
		{
			SqlCommand oCmd;
			
			
			if(oTrans == null)
				oCmd = new SqlCommand(strSQL, getDbConnection());
			else
				oCmd = new SqlCommand(strSQL, getDbConnection(),oTrans);
			try
			{
                string CTimeout = System.Configuration.ConfigurationManager.AppSettings["CommandTimeout"];
                
                if (CTimeout == "")
                {
                    CTimeout = "180";
                }
                oCmd.CommandTimeout = int.Parse(CTimeout);
				return oCmd.ExecuteReader(enumBehavior);
			}
			catch(System.Exception e)
			{
				m_objDbConn.Close();
				m_boolConnected = false;

				Loger.logErr("DsConnectionDB","ExecSQLWithReader",e,5,"SQL=" + strSQL);
				throw new SysException("execute SQL '" + strSQL + "'failed", e, 5, true);
			}
			finally
			{
				if (this.m_autoCloseConn)
				{
					this.Close();
				}
			}

			
				
		}
		public DataSet ExecSQLWithDataSet(string strSQL,int iPageNumber, int iPageSize, SqlTransaction oTrans)
		{
			SqlCommand oCmd;
			SqlDataAdapter oAdapter;
			DataSet oDataSet;
			
			if(oTrans == null)
				oCmd = new SqlCommand(strSQL, getDbConnection());
			else
				oCmd = new SqlCommand(strSQL, getDbConnection(),oTrans);
			try
			{
                string CTimeout = System.Configuration.ConfigurationManager.AppSettings["CommandTimeout"];
                if (!string.IsNullOrEmpty (CTimeout))
                {
                    CTimeout = "180";
                }
                oCmd.CommandTimeout = int.Parse(CTimeout);
				oAdapter = new SqlDataAdapter();
				oAdapter.SelectCommand = oCmd;
				oDataSet = new DataSet();
				if(iPageSize != 0)
					oAdapter.Fill(oDataSet,iPageNumber * iPageSize, iPageSize,"searchresult");
				else
					oAdapter.Fill(oDataSet,"searchresult");

				oAdapter.Dispose();
				return oDataSet;
			}
			catch(System.Exception e)
			{
				m_objDbConn.Close();
				m_boolConnected = false;

				Loger.logErr("DsConnectionDB","ExecSQLWithDataSet",e,5,"SQL=" + strSQL);
				throw new SysException("execute SQL '" + strSQL + "'failed", e, 5, true);
			}
			finally
			{
				if (this.m_autoCloseConn)
				{
					this.Close();
				}
			}

		}

		public object ExecSQLWithScalar(string strSQL,  SqlTransaction oTrans)
		{
			SqlCommand oCmd;
			
			if(oTrans == null)
				oCmd = new SqlCommand(strSQL, getDbConnection());
			else
				oCmd = new SqlCommand(strSQL, getDbConnection(),oTrans);
			try
			{
                string CTimeout = System.Configuration.ConfigurationManager.AppSettings["CommandTimeout"];
                if (CTimeout == "")
                {
                    CTimeout = "180";
                }
                oCmd.CommandTimeout = int.Parse(CTimeout);
				return oCmd.ExecuteScalar();
			}
			catch(System.Exception e)
			{
				m_objDbConn.Close();
				m_boolConnected = false;

				Loger.logErr("DsConnectionDB","ExecSQLWithScalar",e,5,"SQL=" + strSQL);

				throw new SysException("execute SQL '" + strSQL + "'failed", e, 5, true);
			}
			finally
			{
				if (this.m_autoCloseConn)
				{
					this.Close();
				}
			}
		}
		/// <summary>
		/// execute the command  with no return
		/// </summary>
		/// <param name="strSQL">the command object will be execute</param>
		///  <param name="oTrans">the transaction object, pass null if no transaction</param>
		/// <returns>the key string value</returns>
		public int ExecCMD(SqlCommand oCmd,SqlTransaction oTrans)
		{

			if(!m_boolConnected)
				throw new SysException("call ExecSQL before connection established",5);

			int iRowsEffected = 0;

			oCmd.Connection = getDbConnection();
			if(oTrans != null)
				oCmd.Transaction = oTrans;
			try
			{
				iRowsEffected = oCmd.ExecuteNonQuery();
			}
			catch(System.Exception e)
			{
				m_objDbConn.Close();
				m_boolConnected = false;
				throw new SysException("execute Cmd '" + oCmd.CommandText + "'failed", e, 5, true);
			}
			finally
			{
				if (this.m_autoCloseConn)
				{
					this.Close();
				}
			}
			return iRowsEffected;
				
		}
		public SqlDataReader ExecCMDWithReader(SqlCommand oCmd,SqlTransaction oTrans, CommandBehavior enumBehavior)
		{
			if(!m_boolConnected)
				throw new SysException("call ExecCMDWithReader before connection established",5);


			oCmd.Connection = getDbConnection();
			if(oTrans != null)
				oCmd.Transaction = oTrans;
			try
			{
				return oCmd.ExecuteReader(enumBehavior);
			}
			catch(System.Exception e)
			{
				m_objDbConn.Close();
				m_boolConnected = false;
				throw new SysException("execute Cmd '" + oCmd.CommandText + "'failed", e, 5, true);
			}
			finally
			{
				if (this.m_autoCloseConn)
				{
					this.Close();
				}
			}

			
				
		}
		public DataSet ExecCMDWithDataSet(SqlCommand oCmd,int iPageNumber, int iPageSize, SqlTransaction oTrans)
		{
			SqlDataAdapter oAdapter;
			DataSet oDataSet;
			
			if(!m_boolConnected)
				throw new SysException("call ExecCMDWithDataSet before connection established",5);


			oCmd.Connection = getDbConnection();
			if(oTrans != null)
				oCmd.Transaction = oTrans;
			try
			{
				oAdapter = new SqlDataAdapter();
				oAdapter.SelectCommand = oCmd;
				oDataSet = new DataSet();
				if(iPageSize != 0)
					oAdapter.Fill(oDataSet,iPageNumber * iPageSize, iPageSize,"searchresult");
				else
					oAdapter.Fill(oDataSet,"searchresult");

				oAdapter.Dispose();
				return oDataSet;
			}
			catch(System.Exception e)
			{
				m_objDbConn.Close();
				m_boolConnected = false;
				throw new SysException("execute CMD '" + oCmd.CommandText + "'failed", e, 5, true);
			}
			finally
			{
				if (this.m_autoCloseConn)
				{
					this.Close();
				}
			}

				
		}
		public object ExecCMDWithScalar(SqlCommand oCmd,  SqlTransaction oTrans)
		{
			if(!m_boolConnected)
				throw new SysException("call ExecCMDWithReader before connection established",5);

			oCmd.Connection = getDbConnection();
			if(oTrans != null)
				oCmd.Transaction = oTrans;
			try
			{
				return oCmd.ExecuteScalar();
			}
			catch(System.Exception e)
			{
				m_objDbConn.Close();
				m_boolConnected = false;
				throw new SysException("execute CMD '" + oCmd.CommandText + "'failed", e, 5, true);
			}
			finally
			{
				if (this.m_autoCloseConn)
				{
					this.Close();
				}
			}

		}
		/// <summary>
		/// ͨ�����ô洢������ĺ������õ���ĵ�ǰҳ�����ݼ�
		/// </summary>
		/// <param name="db">���ݿ�����</param>
		/// <param name="ProcedureName">�洢����</param>
		/// <param name="TableName">����</param>
		/// <param name="GetFields">���ص���</param>
		/// <param name="OrderField">�������</param>
		/// <param name="PageSize">һҳ��¼��</param>
		/// <param name="PageNum">ҳ��</param>
		/// <param name="doCount">0ֵ�������м�¼,1ֵ�򷵻ؼ�¼����</param>
		/// <param name="OrderType">�������ͣ�0Ϊ����,1Ϊ����</param>
		/// <param name="strWhere">��ѯ����(ע��:��Ҫ�� where)</param>
		public DataSet GetCurrentPageDataSet(string ProcedureName,string TableName,string GetFields,string OrderField,int PageSize,int PageNum,bool OrderType,string strWhere)
		{
			SqlCommand cmd = this.CreateCommand(ProcedureName,true);
            string CTimeout = System.Configuration.ConfigurationManager.AppSettings["CommandTimeout"];
            if (CTimeout == "")
            {
                CTimeout = "180";
            }
            cmd.CommandTimeout = int.Parse(CTimeout);
			SqlParameter parm = new SqlParameter("@tblName",SqlDbType.VarChar);
			parm.Value = TableName;
			cmd.Parameters.Add(parm);

			parm = new SqlParameter("@strGetFields",SqlDbType.VarChar);
			parm.Value =GetFields;
			cmd.Parameters.Add(parm);

			parm = new SqlParameter("@fldName",SqlDbType.VarChar);
			parm.Value =OrderField;
			cmd.Parameters.Add(parm);

			parm = new SqlParameter("@PageSize",SqlDbType.Int);
			parm.Value =PageSize;
			cmd.Parameters.Add(parm);
			
			parm = new SqlParameter("@PageIndex",SqlDbType.Int);
			parm.Value =PageNum;
			cmd.Parameters.Add(parm);

			parm = new SqlParameter("@OrderType",SqlDbType.Bit);
			parm.Value =OrderType;
			cmd.Parameters.Add(parm);

			parm = new SqlParameter("@strWhere",SqlDbType.VarChar);
			parm.Value =strWhere;
			cmd.Parameters.Add(parm);


			SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			sqlDA.Fill(ds);

			return ds;
		}

        /// <summary>
        /// ͨ�����ô洢������ĺ������õ���ĵ�ǰҳ�����ݼ�
        /// </summary>
        /// <param name="db">���ݿ�����</param>
        /// <param name="ProcedureName">�洢����</param>
        /// <param name="TableName">����</param>
        /// <param name="GetFields">���ص���</param>
        /// <param name="OrderField">�������</param>
        /// <param name="PageSize">һҳ��¼��</param>
        /// <param name="PageNum">ҳ��</param>
        /// <param name="doCount">0ֵ�������м�¼,1ֵ�򷵻ؼ�¼����</param>
        /// <param name="OrderType">�������ͣ�0Ϊ����,1Ϊ����</param>
        /// <param name="strWhere">��ѯ����(ע��:��Ҫ�� where)</param>
        public DataSet GetCurrentPageDataSet(string ProcedureName, string TableName, string GetFields, string OrderField, int PageSize, int PageNum, bool OrderType, string strWhere, ref int RecordCount, ref int PageCount)
        {
            SqlCommand cmd = this.CreateCommand(ProcedureName, true);
            string CTimeout = System.Configuration.ConfigurationManager.AppSettings["CommandTimeout"];
            if (CTimeout == "")
            {
                CTimeout = "180";
            }
            cmd.CommandTimeout = int.Parse(CTimeout);
            SqlParameter parm = new SqlParameter("@tblName", SqlDbType.VarChar);
            parm.Value = TableName;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@strGetFields", SqlDbType.VarChar);
            parm.Value = GetFields;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@fldName", SqlDbType.VarChar);
            parm.Value = OrderField;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@PageSize", SqlDbType.Int);
            parm.Value = PageSize;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@PageIndex", SqlDbType.Int);
            parm.Value = PageNum;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@RecordCount", SqlDbType.Int);
            parm.Direction = ParameterDirection.Output;
            parm.Value = RecordCount;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@PageCount", SqlDbType.Int);
            parm.Direction = ParameterDirection.Output;
            parm.Value = PageCount;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@OrderType", SqlDbType.Bit);
            parm.Value = OrderType;
            cmd.Parameters.Add(parm);

            parm = new SqlParameter("@strWhere", SqlDbType.VarChar);
            parm.Value = strWhere;
            cmd.Parameters.Add(parm);


            SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDA.Fill(ds);

            RecordCount = (int)cmd.Parameters["@RecordCount"].Value;
            PageCount = (int)cmd.Parameters["@PageCount"].Value;
            return ds;
        }
		/// <summary>
		/// �������ķ�ҳ�洢����
		/// </summary>
		/// <param name="TableName">����</param>
		/// <param name="PkName">�����ֶ���</param>
		/// <param name="GetFields">���ȡ����</param>
		/// <param name="OrderStr">����</param>
		/// <param name="GroupStr">GroupBy��</param>
		/// <param name="FilterStr">���˴�</param>
		/// <param name="PageSize">ҳ��С</param>
		/// <param name="PageNum">ҳ��</param>
		/// <param name="RecordCount">��¼����</param>
		/// <param name="PageCount">ҳ����</param>
		/// <param name="NeedCount">�Ƿ���Ҫ��������0-������ 1-����</param>
		/// <returns></returns>
		public DataSet GetCurrentPageDataSet(string TableName,string PkName,string GetFields,string OrderStr,string GroupStr,string FilterStr,int PageSize,int PageNum,ref int RecordCount,ref int PageCount,int NeedCount)
		{
			SqlCommand cmd = this.CreateCommand("profuser.dbo.p_PageSubQuery",true);
            string CTimeout = System.Configuration.ConfigurationManager.AppSettings["CommandTimeout"];
            if (CTimeout == "")
            {
                CTimeout = "180";
            }
            cmd.CommandTimeout = int.Parse(CTimeout);
			SqlParameter parm = new SqlParameter("@Tables",SqlDbType.VarChar);
			parm.Value = TableName;
			cmd.Parameters.Add(parm);

			parm = new SqlParameter("@PK",SqlDbType.VarChar);
			parm.Value =PkName;
			cmd.Parameters.Add(parm);

			parm = new SqlParameter("@Sort",SqlDbType.VarChar);
			parm.Value =OrderStr;
			cmd.Parameters.Add(parm);

			parm = new SqlParameter("@Fields",SqlDbType.VarChar);
			parm.Value =GetFields;
			cmd.Parameters.Add(parm);

			parm = new SqlParameter("@Group",SqlDbType.VarChar);
			parm.Value =GroupStr;
			cmd.Parameters.Add(parm);

			parm = new SqlParameter("@PageSize",SqlDbType.Int);
			parm.Value =PageSize;
			cmd.Parameters.Add(parm);
			
			parm = new SqlParameter("@PageNumber",SqlDbType.Int);
			parm.Value =PageNum;
			cmd.Parameters.Add(parm);

			parm = new SqlParameter("@RecordCount",SqlDbType.Int );
			parm.Direction=ParameterDirection.Output;
			parm.Value =RecordCount;
			cmd.Parameters.Add(parm);

			parm = new SqlParameter("@PageCount",SqlDbType.Int);
			parm.Direction=ParameterDirection.Output;
			parm.Value =PageCount;
			cmd.Parameters.Add(parm);

			parm = new SqlParameter("@Filter",SqlDbType.VarChar);
			parm.Value =FilterStr;
			cmd.Parameters.Add(parm);

			parm = new SqlParameter("@NeedCount",SqlDbType.Int);
			parm.Value =NeedCount;
			cmd.Parameters.Add(parm);

			SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			sqlDA.Fill(ds);

			RecordCount = (int)cmd.Parameters["@RecordCount"].Value;
			PageCount = (int)cmd.Parameters["@PageCount"].Value;
			return ds;
		}
	}
}
