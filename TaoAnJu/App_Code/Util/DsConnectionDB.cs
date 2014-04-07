using System;
using System.Data;
using System.Data.SqlClient;

namespace TaoAnJu.Util
{
	/// <summary>
	/// DsConnectionDB 
	/// 继承IDisposable接口
	/// 实现Close和Dispose
	/// </summary>
	public class DsConnectionDB:IDisposable
	{
		private string m_strConnectionString; //database connection string
		private bool m_boolConnected;	//if the database connection has been established
		private SqlConnection m_objDbConn;   //the database connection object

		#region 新增参数
		private SqlTransaction _transaction;
		private bool m_autoCloseConn=false;
		#endregion 新增参数

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
		/// 单次SQL执行调用构造函数。用于单次SQL操作调用
		/// 备注：如果autoCloseConnection=true,则构造时不打开Connection
		/// 当正式调用之前才打开Connection,并在调用一次执行之后自动关闭连接。
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

		#region 新增方法

		#region 事务部分
		/// <summary>
		/// 开始事务
		/// </summary>
		/// <returns>事务对象</returns>
		public SqlTransaction BeginTransaction()
		{
			CheckTransactionState(false);
			_transaction = m_objDbConn.BeginTransaction();
			return _transaction;
		}

		/// <summary>
		/// 完成事务
		/// </summary>
		public void CommitTransaction()
		{
			CheckTransactionState(true);
			_transaction.Commit();
			_transaction = null;
		}

		/// <summary>
		/// RollBack事务
		/// </summary>
		public void RollbackTransaction()
		{
			CheckTransactionState(true);
			_transaction.Rollback();
			_transaction = null;
		}

		/// <summary>
		/// 检查事务打开状态
		/// </summary>
		/// <param name="mustBeOpen">是否必须打开</param>
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
		#endregion 事务部分

		#region 初始化、关闭与释放
		
		/// <summary>
		/// 关闭方法
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
		/// 释放资源
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

		#endregion 关闭与释放

		#region 通用方法

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
		/// 创建通用Command对象
		/// </summary>
		/// <param name="sqlText">sql脚本</param>
		/// <returns>SqlCommand</returns>
		public SqlCommand CreateCommand(string sqlText)
		{
			return CreateCommand(sqlText, false);
		}

		/// <summary>
		/// 创建Command对象
		/// </summary>
		/// <param name="sqlText">sql脚本</param>
		/// <param name="procedure">是否存储过程</param>
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
		/// 执行通用查询
		/// </summary>
		/// <param name="sqlStmt">查询脚本</param>
		/// <returns>返回查询结果DataSet</returns>
		public DataSet ExecuteQuery(string sqlStmt)
		{
			return this.ExecSQLWithDataSet(sqlStmt,0,0,this._transaction);
		}

		/// <summary>
		/// 执行Scalar查询
		/// </summary>
		/// <param name="sqlStmt">查询对象</param>
		/// <returns>返回查询结果Object</returns>
		public object ExecuteScalar(string sqlStmt)
		{
			return this.ExecSQLWithScalar(sqlStmt,this._transaction);
		}

		/// <summary>
		/// 执行查询语句函数
		/// </summary>
		/// <param name="sqlStmt">查询语句</param>
		/// <returns>返回查询结果数据集</returns>
		public SqlDataReader ExecuteQueryReader(string sqlStmt)
		{
			return this.ExecSQLWithReader(sqlStmt,this._transaction,CommandBehavior.Default);
		}

		/// <summary>
		/// 执行非查询语句函数
		/// </summary>
		/// <param name="sqlStmt">非查询语句</param>
		/// <returns>返回语句所影响的行数</returns>
		public int ExecuteNonQuery(string sqlStmt)
		{
			return this.ExecSQL(sqlStmt,_transaction);
		}

		/// <summary>
		/// 执行存储过程查询语句函数
		/// </summary>
		/// <param name="arrPara">存储过程的参数数组</param>
		/// <param name="arrParaValue">存储过程之参数的值数组</param>
		/// <param name="procName">存储过程名称</param>
		/// <param name="tableName">存储过程操作的表名</param>
		/// <returns>返回查询结果数据集</returns>
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
		/// 执行存储过程非查询语句函数
		/// </summary>
		/// <param name="arrPara" >存储过程的参数数组</param>
		/// <param name="arrParaValue" >存储过程之参数的值数组</param>
		/// <param name="arrType" >存储过程之参数的类型数组</param>
		/// <param name="arrLen" >存储过程之参数的长度数组</param>
		/// <param name="procName">存储过程名称</param>
		/// <returns>返回语句所影响的行数(-1表示存在异常)</returns>
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
		#endregion 通用方法

		#endregion 新增方法

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
		/// 通过调用存储过程里的函数，得到表的当前页的数据集
		/// </summary>
		/// <param name="db">数据库连接</param>
		/// <param name="ProcedureName">存储过程</param>
		/// <param name="TableName">表名</param>
		/// <param name="GetFields">返回的列</param>
		/// <param name="OrderField">排序的列</param>
		/// <param name="PageSize">一页记录数</param>
		/// <param name="PageNum">页码</param>
		/// <param name="doCount">0值返回所有记录,1值则返回记录总数</param>
		/// <param name="OrderType">排序类型：0为升序,1为降序</param>
		/// <param name="strWhere">查询条件(注意:不要加 where)</param>
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
        /// 通过调用存储过程里的函数，得到表的当前页的数据集
        /// </summary>
        /// <param name="db">数据库连接</param>
        /// <param name="ProcedureName">存储过程</param>
        /// <param name="TableName">表名</param>
        /// <param name="GetFields">返回的列</param>
        /// <param name="OrderField">排序的列</param>
        /// <param name="PageSize">一页记录数</param>
        /// <param name="PageNum">页码</param>
        /// <param name="doCount">0值返回所有记录,1值则返回记录总数</param>
        /// <param name="OrderType">排序类型：0为升序,1为降序</param>
        /// <param name="strWhere">查询条件(注意:不要加 where)</param>
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
		/// 有主键的分页存储过程
		/// </summary>
		/// <param name="TableName">表名</param>
		/// <param name="PkName">主键字段名</param>
		/// <param name="GetFields">需获取的域</param>
		/// <param name="OrderStr">排序串</param>
		/// <param name="GroupStr">GroupBy串</param>
		/// <param name="FilterStr">过滤串</param>
		/// <param name="PageSize">页大小</param>
		/// <param name="PageNum">页号</param>
		/// <param name="RecordCount">记录总数</param>
		/// <param name="PageCount">页总数</param>
		/// <param name="NeedCount">是否需要返回总数0-不返回 1-返回</param>
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
