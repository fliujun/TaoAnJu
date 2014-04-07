using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_LogInfoEntity_Op
    {
        private DsConnectionDB _db;

        public tb_LogInfoEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_LogInfoEntity[] GetAll()
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

        public tb_LogInfoEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_LogInfoEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_LogInfo";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_LogInfoEntity GetByPrimaryKey(int int_LogId)
        {
            string whereSql = "";
            whereSql += "int_LogId=@int_LogId ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_LogId", int_LogId);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_LogInfoEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_LogInfoEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_LogInfoEntity value)
        {
            string sqlStr = "INSERT INTO tb_LogInfo(";
            if (null != value.vc_LogType)
                sqlStr += "vc_LogType,";
            if (null != value.vc_Content)
                sqlStr += "vc_Content,";
            if (null != value.vc_Ip)
                sqlStr += "vc_Ip,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate,";
            if (!value.int_UserIdNull)
                sqlStr += "int_UserId,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (null != value.vc_LogType)
                sqlStr += "@vc_LogType,";
            if (null != value.vc_Content)
                sqlStr += "@vc_Content,";
            if (null != value.vc_Ip)
                sqlStr += "@vc_Ip,";
            if (!value.dt_CreateDateNull)
                sqlStr += "@dt_CreateDate,";
            if (!value.int_UserIdNull)
                sqlStr += "@int_UserId,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_LogType)
                AddParameter(cmd, "vc_LogType", value.vc_LogType);
            if (null != value.vc_Content)
                AddParameter(cmd, "vc_Content", value.vc_Content);
            if (null != value.vc_Ip)
                AddParameter(cmd, "vc_Ip", value.vc_Ip);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_UserIdNull)
                AddParameter(cmd, "int_UserId", (object)value.int_UserId);

            value.int_LogId = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_LogInfoEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_LogInfoEntity value)
        {
            string sqlStr = "UPDATE tb_LogInfo SET ";
            if (null != value.vc_LogType)
                sqlStr += "vc_LogType=@vc_LogType,";
            if (null != value.vc_Content)
                sqlStr += "vc_Content=@vc_Content,";
            if (null != value.vc_Ip)
                sqlStr += "vc_Ip=@vc_Ip,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate=@dt_CreateDate,";
            if (!value.int_UserIdNull)
                sqlStr += "int_UserId=@int_UserId,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_LogIdNull)
                sqlStr += "int_LogId= @int_LogId";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_LogType)
                AddParameter(cmd, "vc_LogType", value.vc_LogType);
            if (null != value.vc_Content)
                AddParameter(cmd, "vc_Content", value.vc_Content);
            if (null != value.vc_Ip)
                AddParameter(cmd, "vc_Ip", value.vc_Ip);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_UserIdNull)
                AddParameter(cmd, "int_UserId", (object)value.int_UserId);
            if (!value.int_LogIdNull)
                AddParameter(cmd, "int_LogId", (object)value.int_LogId);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_LogInfoEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_LogInfoEntity value)
        {
            return DeleteByPrimaryKey(value.int_LogId);
        }

        public virtual int DeleteByPrimaryKey(int int_LogId)
        {
            string whereSql = "";
            whereSql += "int_LogId=@int_LogId ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_LogId", int_LogId);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_LogInfoEntity</c> records that match the specified criteria.
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
        /// to delete <c>tb_LogInfoEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_LogInfo";
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
        protected tb_LogInfoEntity[] MapRecords(SqlDataReader reader)
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
        protected virtual tb_LogInfoEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_LogIdColumnIndex = reader.GetOrdinal("int_LogId");
            int vc_LogTypeColumnIndex = reader.GetOrdinal("vc_LogType");
            int vc_ContentColumnIndex = reader.GetOrdinal("vc_Content");
            int vc_IpColumnIndex = reader.GetOrdinal("vc_Ip");
            int dt_CreateDateColumnIndex = reader.GetOrdinal("dt_CreateDate");
            int int_UserIdColumnIndex = reader.GetOrdinal("int_UserId");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_LogInfoEntity record = new tb_LogInfoEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_LogIdColumnIndex))
                        record.int_LogId = Convert.ToInt32(reader.GetValue(int_LogIdColumnIndex));
                    if (!reader.IsDBNull(vc_LogTypeColumnIndex))
                        record.vc_LogType = Convert.ToString(reader.GetValue(vc_LogTypeColumnIndex));
                    if (!reader.IsDBNull(vc_ContentColumnIndex))
                        record.vc_Content = Convert.ToString(reader.GetValue(vc_ContentColumnIndex));
                    if (!reader.IsDBNull(vc_IpColumnIndex))
                        record.vc_Ip = Convert.ToString(reader.GetValue(vc_IpColumnIndex));
                    if (!reader.IsDBNull(dt_CreateDateColumnIndex))
                        record.dt_CreateDate = Convert.ToDateTime(reader.GetValue(dt_CreateDateColumnIndex));
                    if (!reader.IsDBNull(int_UserIdColumnIndex))
                        record.int_UserId = Convert.ToInt32(reader.GetValue(int_UserIdColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_LogInfoEntity[])(recordList.ToArray(typeof(tb_LogInfoEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_LogInfoEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_LogInfoEntity"/> object.</returns>
        protected virtual tb_LogInfoEntity MapRow(DataRow row)
        {
            tb_LogInfoEntity mappedObject = new tb_LogInfoEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_LogId
            dataColumn = dataTable.Columns["int_LogId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_LogId = (int)row[dataColumn];
            // Column vc_LogType
            dataColumn = dataTable.Columns["vc_LogType"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_LogType = (string)row[dataColumn];
            // Column vc_Content
            dataColumn = dataTable.Columns["vc_Content"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Content = (string)row[dataColumn];
            // Column vc_Ip
            dataColumn = dataTable.Columns["vc_Ip"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Ip = (string)row[dataColumn];
            // Column dt_CreateDate
            dataColumn = dataTable.Columns["dt_CreateDate"];
            if (!row.IsNull(dataColumn))
                mappedObject.dt_CreateDate = (DateTime)row[dataColumn];
            // Column int_UserId
            dataColumn = dataTable.Columns["int_UserId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_UserId = (int)row[dataColumn];


            return mappedObject;
        }

        /// <summary>
        /// Creates a <see cref="System.Data.DataTable"/> object for 
        /// the <c>tb_LogInfoEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_LogInfoEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_LogId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_LogType", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("vc_Content", typeof(string));
            dataColumn.MaxLength = 500;
            dataColumn = dataTable.Columns.Add("vc_Ip", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("dt_CreateDate", typeof(DateTime));
            dataColumn = dataTable.Columns.Add("int_UserId", typeof(int));


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
                case "int_LogId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_LogType":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Content":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Ip":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "dt_CreateDate":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.DateTime, value);
                    break;
                case "int_UserId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;


                default:
                    throw new ArgumentException("Unknown parameter name (" + paramName + ").");
            }
            return parameter;
        }
    } // End of  tb_LogInfoEntity_BaseOp class
}  // End of namespace

