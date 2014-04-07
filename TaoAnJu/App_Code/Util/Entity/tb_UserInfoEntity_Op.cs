using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_UserInfoEntity_Op
    {
        private DsConnectionDB _db;

        public tb_UserInfoEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_UserInfoEntity[] GetAll()
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetAllCommand()))
            {
                return MapRecords(reader);
            }
        }


        protected virtual SqlCommand CreateGetAllCommand()
        {
            return CreateGetCommand(null, null);
        }

        public tb_UserInfoEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_UserInfoEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_UserInfo";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_UserInfoEntity GetByPrimaryKey(int int_UserId)
        {
            string whereSql = "";
            whereSql += "int_UserId=@int_UserId ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_UserId", int_UserId);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_UserInfoEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_UserInfoEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_UserInfoEntity value)
        {
            string sqlStr = "INSERT INTO tb_UserInfo(";
            if (null != value.vc_LoginName)
                sqlStr += "vc_LoginName,";
            if (null != value.vc_RealName)
                sqlStr += "vc_RealName,";
            if (null != value.vc_LoginPwd)
                sqlStr += "vc_LoginPwd,";
            if (null != value.vc_LastLoginIp)
                sqlStr += "vc_LastLoginIp,";
            if (!value.dt_LastLoginTimeNull)
                sqlStr += "dt_LastLoginTime,";
            if (!value.int_UserTypeNull)
                sqlStr += "int_UserType,";
            if (!value.int_CCountNull)
                sqlStr += "int_CCount,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate,";
            if (!value.int_StatusNull)
                sqlStr += "int_Status,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (null != value.vc_LoginName)
                sqlStr += "@vc_LoginName,";
            if (null != value.vc_RealName)
                sqlStr += "@vc_RealName,";
            if (null != value.vc_LoginPwd)
                sqlStr += "@vc_LoginPwd,";
            if (null != value.vc_LastLoginIp)
                sqlStr += "@vc_LastLoginIp,";
            if (!value.dt_LastLoginTimeNull)
                sqlStr += "@dt_LastLoginTime,";
            if (!value.int_UserTypeNull)
                sqlStr += "@int_UserType,";
            if (!value.int_CCountNull)
                sqlStr += "@int_CCount,";
            if (!value.dt_CreateDateNull)
                sqlStr += "@dt_CreateDate,";
            if (!value.int_StatusNull)
                sqlStr += "@int_Status,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_LoginName)
                AddParameter(cmd, "vc_LoginName", value.vc_LoginName);
            if (null != value.vc_RealName)
                AddParameter(cmd, "vc_RealName", value.vc_RealName);
            if (null != value.vc_LoginPwd)
                AddParameter(cmd, "vc_LoginPwd", value.vc_LoginPwd);
            if (null != value.vc_LastLoginIp)
                AddParameter(cmd, "vc_LastLoginIp", value.vc_LastLoginIp);
            if (!value.dt_LastLoginTimeNull)
                AddParameter(cmd, "dt_LastLoginTime", (object)value.dt_LastLoginTime);
            if (!value.int_UserTypeNull)
                AddParameter(cmd, "int_UserType", (object)value.int_UserType);
            if (!value.int_CCountNull)
                AddParameter(cmd, "int_CCount", (object)value.int_CCount);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_StatusNull)
                AddParameter(cmd, "int_Status", (object)value.int_Status);

            value.int_UserId = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_UserInfoEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_UserInfoEntity value)
        {
            string sqlStr = "UPDATE tb_UserInfo SET ";
            if (null != value.vc_LoginName)
                sqlStr += "vc_LoginName=@vc_LoginName,";
            if (null != value.vc_RealName)
                sqlStr += "vc_RealName=@vc_RealName,";
            if (null != value.vc_LoginPwd)
                sqlStr += "vc_LoginPwd=@vc_LoginPwd,";
            if (null != value.vc_LastLoginIp)
                sqlStr += "vc_LastLoginIp=@vc_LastLoginIp,";
            if (!value.dt_LastLoginTimeNull)
                sqlStr += "dt_LastLoginTime=@dt_LastLoginTime,";
            if (!value.int_UserTypeNull)
                sqlStr += "int_UserType=@int_UserType,";
            if (!value.int_CCountNull)
                sqlStr += "int_CCount=@int_CCount,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate=@dt_CreateDate,";
            if (!value.int_StatusNull)
                sqlStr += "int_Status=@int_Status,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_UserIdNull)
                sqlStr += "int_UserId= @int_UserId";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_LoginName)
                AddParameter(cmd, "vc_LoginName", value.vc_LoginName);
            if (null != value.vc_RealName)
                AddParameter(cmd, "vc_RealName", value.vc_RealName);
            if (null != value.vc_LoginPwd)
                AddParameter(cmd, "vc_LoginPwd", value.vc_LoginPwd);
            if (null != value.vc_LastLoginIp)
                AddParameter(cmd, "vc_LastLoginIp", value.vc_LastLoginIp);
            if (!value.dt_LastLoginTimeNull)
                AddParameter(cmd, "dt_LastLoginTime", (object)value.dt_LastLoginTime);
            if (!value.int_UserTypeNull)
                AddParameter(cmd, "int_UserType", (object)value.int_UserType);
            if (!value.int_CCountNull)
                AddParameter(cmd, "int_CCount", (object)value.int_CCount);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_StatusNull)
                AddParameter(cmd, "int_Status", (object)value.int_Status);
            if (!value.int_UserIdNull)
                AddParameter(cmd, "int_UserId", (object)value.int_UserId);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_UserInfoEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_UserInfoEntity value)
        {
            return DeleteByPrimaryKey(value.int_UserId);
        }

        public virtual int DeleteByPrimaryKey(int int_UserId)
        {
            string whereSql = "";
            whereSql += "int_UserId=@int_UserId ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_UserId", int_UserId);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_UserInfoEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>The number of deleted records.</returns>
        public int Delete(string whereSql)
        {
            return CreateDeleteCommand(whereSql).ExecuteNonQuery();
        }

        /// <summary>
        /// Creates an <see cref="System.Data.SqlCommand"/> object that can be used 
        /// to delete <c>tb_UserInfoEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_UserInfo";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            return _db.CreateCommand(sql);
        }

        /// <summary>
        /// Reads data from the provided data reader and returns 
        /// an array of mapped objects.
        /// </summary>
        /// <param name="reader">The <see cref="System.Data.SqlDataReader"/> object to read data from the table.</param>
        /// <returns>An array of <see cref="YearWorkChild"/> objects.</returns>
        protected tb_UserInfoEntity[] MapRecords(SqlDataReader reader)
        {
            int totalRecordCount = -1;
            return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
        }

        /// <summary>
        /// Reads data from the provided data reader and returns 
        /// an array of mapped objects.
        /// </summary>
        /// <param name="reader">The <see cref="System.Data.SqlDataReader"/> object to read data from the table.</param>
        /// <param name="startIndex">The index of the first record to map.</param>
        /// <param name="length">The number of records to map.</param>
        /// <param name="totalRecordCount">A reference parameter that returns the total number 
        /// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
        /// <returns>An array of <see cref="YearWorkChild"/> objects.</returns>
        protected virtual tb_UserInfoEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_UserIdColumnIndex = reader.GetOrdinal("int_UserId");
            int vc_LoginNameColumnIndex = reader.GetOrdinal("vc_LoginName");
            int vc_RealNameColumnIndex = reader.GetOrdinal("vc_RealName");
            int vc_LoginPwdColumnIndex = reader.GetOrdinal("vc_LoginPwd");
            int vc_LastLoginIpColumnIndex = reader.GetOrdinal("vc_LastLoginIp");
            int dt_LastLoginTimeColumnIndex = reader.GetOrdinal("dt_LastLoginTime");
            int int_UserTypeColumnIndex = reader.GetOrdinal("int_UserType");
            int int_CCountColumnIndex = reader.GetOrdinal("int_CCount");
            int dt_CreateDateColumnIndex = reader.GetOrdinal("dt_CreateDate");
            int int_StatusColumnIndex = reader.GetOrdinal("int_Status");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_UserInfoEntity record = new tb_UserInfoEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_UserIdColumnIndex))
                        record.int_UserId = Convert.ToInt32(reader.GetValue(int_UserIdColumnIndex));
                    if (!reader.IsDBNull(vc_LoginNameColumnIndex))
                        record.vc_LoginName = Convert.ToString(reader.GetValue(vc_LoginNameColumnIndex));
                    if (!reader.IsDBNull(vc_RealNameColumnIndex))
                        record.vc_RealName = Convert.ToString(reader.GetValue(vc_RealNameColumnIndex));
                    if (!reader.IsDBNull(vc_LoginPwdColumnIndex))
                        record.vc_LoginPwd = Convert.ToString(reader.GetValue(vc_LoginPwdColumnIndex));
                    if (!reader.IsDBNull(vc_LastLoginIpColumnIndex))
                        record.vc_LastLoginIp = Convert.ToString(reader.GetValue(vc_LastLoginIpColumnIndex));
                    if (!reader.IsDBNull(dt_LastLoginTimeColumnIndex))
                        record.dt_LastLoginTime = Convert.ToDateTime(reader.GetValue(dt_LastLoginTimeColumnIndex));
                    if (!reader.IsDBNull(int_UserTypeColumnIndex))
                        record.int_UserType = Convert.ToInt32(reader.GetValue(int_UserTypeColumnIndex));
                    if (!reader.IsDBNull(int_CCountColumnIndex))
                        record.int_CCount = Convert.ToInt32(reader.GetValue(int_CCountColumnIndex));
                    if (!reader.IsDBNull(dt_CreateDateColumnIndex))
                        record.dt_CreateDate = Convert.ToDateTime(reader.GetValue(dt_CreateDateColumnIndex));
                    if (!reader.IsDBNull(int_StatusColumnIndex))
                        record.int_Status = Convert.ToInt32(reader.GetValue(int_StatusColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_UserInfoEntity[])(recordList.ToArray(typeof(tb_UserInfoEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_UserInfoEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_UserInfoEntity"/> object.</returns>
        protected virtual tb_UserInfoEntity MapRow(DataRow row)
        {
            tb_UserInfoEntity mappedObject = new tb_UserInfoEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_UserId
            dataColumn = dataTable.Columns["int_UserId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_UserId = (int)row[dataColumn];
            // Column vc_LoginName
            dataColumn = dataTable.Columns["vc_LoginName"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_LoginName = (string)row[dataColumn];
            // Column vc_RealName
            dataColumn = dataTable.Columns["vc_RealName"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_RealName = (string)row[dataColumn];
            // Column vc_LoginPwd
            dataColumn = dataTable.Columns["vc_LoginPwd"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_LoginPwd = (string)row[dataColumn];
            // Column vc_LastLoginIp
            dataColumn = dataTable.Columns["vc_LastLoginIp"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_LastLoginIp = (string)row[dataColumn];
            // Column dt_LastLoginTime
            dataColumn = dataTable.Columns["dt_LastLoginTime"];
            if (!row.IsNull(dataColumn))
                mappedObject.dt_LastLoginTime = (DateTime)row[dataColumn];
            // Column int_UserType
            dataColumn = dataTable.Columns["int_UserType"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_UserType = (int)row[dataColumn];
            // Column int_CCount
            dataColumn = dataTable.Columns["int_CCount"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_CCount = (int)row[dataColumn];
            // Column dt_CreateDate
            dataColumn = dataTable.Columns["dt_CreateDate"];
            if (!row.IsNull(dataColumn))
                mappedObject.dt_CreateDate = (DateTime)row[dataColumn];
            // Column int_Status
            dataColumn = dataTable.Columns["int_Status"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_Status = (int)row[dataColumn];


            return mappedObject;
        }

        /// <summary>
        /// Creates a <see cref="System.Data.DataTable"/> object for 
        /// the <c>tb_UserInfoEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_UserInfoEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_UserId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_LoginName", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_RealName", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("vc_LoginPwd", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_LastLoginIp", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("dt_LastLoginTime", typeof(DateTime));
            dataColumn = dataTable.Columns.Add("int_UserType", typeof(int));
            dataColumn = dataTable.Columns.Add("int_CCount", typeof(int));
            dataColumn = dataTable.Columns.Add("dt_CreateDate", typeof(DateTime));
            dataColumn = dataTable.Columns.Add("int_Status", typeof(int));


            return dataTable;
        }

        /// <summary>
        /// Adds a new parameter to the specified command.
        /// </summary>
        /// <param name="cmd">The <see cref="System.Data.SqlCommand"/> object to add the parameter to.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A reference to the added parameter.</returns>
        protected virtual SqlParameter AddParameter(SqlCommand cmd, string paramName, object value)
        {
            SqlParameter parameter;
            switch (paramName)
            {
                case "int_UserId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_LoginName":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_RealName":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_LoginPwd":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_LastLoginIp":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "dt_LastLoginTime":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.DateTime, value);
                    break;
                case "int_UserType":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_CCount":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "dt_CreateDate":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.DateTime, value);
                    break;
                case "int_Status":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;


                default:
                    throw new ArgumentException("Unknown parameter name (" + paramName + ").");
            }
            return parameter;
        }
    } // End of  tb_UserInfoEntity_BaseOp class
}  // End of namespace

