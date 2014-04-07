using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_FileInfoEntity_Op
    {
        private DsConnectionDB _db;

        public tb_FileInfoEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_FileInfoEntity[] GetAll()
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

        public tb_FileInfoEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_FileInfoEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_FileInfo";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_FileInfoEntity GetByPrimaryKey(int int_FileId)
        {
            string whereSql = "";
            whereSql += "int_FileId=@int_FileId ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_FileId", int_FileId);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_FileInfoEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_FileInfoEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_FileInfoEntity value)
        {
            string sqlStr = "INSERT INTO tb_FileInfo(";
            if (null != value.vc_ShowName)
                sqlStr += "vc_ShowName,";
            if (null != value.vc_FileName)
                sqlStr += "vc_FileName,";
            if (!value.int_TbIdNull)
                sqlStr += "int_TbId,";
            if (!value.int_RecordIdNull)
                sqlStr += "int_RecordId,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate,";
            if (!value.int_UserIdNull)
                sqlStr += "int_UserId,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (null != value.vc_ShowName)
                sqlStr += "@vc_ShowName,";
            if (null != value.vc_FileName)
                sqlStr += "@vc_FileName,";
            if (!value.int_TbIdNull)
                sqlStr += "@int_TbId,";
            if (!value.int_RecordIdNull)
                sqlStr += "@int_RecordId,";
            if (!value.dt_CreateDateNull)
                sqlStr += "@dt_CreateDate,";
            if (!value.int_UserIdNull)
                sqlStr += "@int_UserId,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_ShowName)
                AddParameter(cmd, "vc_ShowName", value.vc_ShowName);
            if (null != value.vc_FileName)
                AddParameter(cmd, "vc_FileName", value.vc_FileName);
            if (!value.int_TbIdNull)
                AddParameter(cmd, "int_TbId", (object)value.int_TbId);
            if (!value.int_RecordIdNull)
                AddParameter(cmd, "int_RecordId", (object)value.int_RecordId);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_UserIdNull)
                AddParameter(cmd, "int_UserId", (object)value.int_UserId);

            value.int_FileId = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_FileInfoEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_FileInfoEntity value)
        {
            string sqlStr = "UPDATE tb_FileInfo SET ";
            if (null != value.vc_ShowName)
                sqlStr += "vc_ShowName=@vc_ShowName,";
            if (null != value.vc_FileName)
                sqlStr += "vc_FileName=@vc_FileName,";
            if (!value.int_TbIdNull)
                sqlStr += "int_TbId=@int_TbId,";
            if (!value.int_RecordIdNull)
                sqlStr += "int_RecordId=@int_RecordId,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate=@dt_CreateDate,";
            if (!value.int_UserIdNull)
                sqlStr += "int_UserId=@int_UserId,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_FileIdNull)
                sqlStr += "int_FileId= @int_FileId";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_ShowName)
                AddParameter(cmd, "vc_ShowName", value.vc_ShowName);
            if (null != value.vc_FileName)
                AddParameter(cmd, "vc_FileName", value.vc_FileName);
            if (!value.int_TbIdNull)
                AddParameter(cmd, "int_TbId", (object)value.int_TbId);
            if (!value.int_RecordIdNull)
                AddParameter(cmd, "int_RecordId", (object)value.int_RecordId);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_UserIdNull)
                AddParameter(cmd, "int_UserId", (object)value.int_UserId);
            if (!value.int_FileIdNull)
                AddParameter(cmd, "int_FileId", (object)value.int_FileId);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_FileInfoEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_FileInfoEntity value)
        {
            return DeleteByPrimaryKey(value.int_FileId);
        }

        public virtual int DeleteByPrimaryKey(int int_FileId)
        {
            string whereSql = "";
            whereSql += "int_FileId=@int_FileId ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_FileId", int_FileId);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_FileInfoEntity</c> records that match the specified criteria.
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
        /// to delete <c>tb_FileInfoEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_FileInfo";
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
        protected tb_FileInfoEntity[] MapRecords(SqlDataReader reader)
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
        protected virtual tb_FileInfoEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_FileIdColumnIndex = reader.GetOrdinal("int_FileId");
            int vc_ShowNameColumnIndex = reader.GetOrdinal("vc_ShowName");
            int vc_FileNameColumnIndex = reader.GetOrdinal("vc_FileName");
            int int_TbIdColumnIndex = reader.GetOrdinal("int_TbId");
            int int_RecordIdColumnIndex = reader.GetOrdinal("int_RecordId");
            int dt_CreateDateColumnIndex = reader.GetOrdinal("dt_CreateDate");
            int int_UserIdColumnIndex = reader.GetOrdinal("int_UserId");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_FileInfoEntity record = new tb_FileInfoEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_FileIdColumnIndex))
                        record.int_FileId = Convert.ToInt32(reader.GetValue(int_FileIdColumnIndex));
                    if (!reader.IsDBNull(vc_ShowNameColumnIndex))
                        record.vc_ShowName = Convert.ToString(reader.GetValue(vc_ShowNameColumnIndex));
                    if (!reader.IsDBNull(vc_FileNameColumnIndex))
                        record.vc_FileName = Convert.ToString(reader.GetValue(vc_FileNameColumnIndex));
                    if (!reader.IsDBNull(int_TbIdColumnIndex))
                        record.int_TbId = Convert.ToInt32(reader.GetValue(int_TbIdColumnIndex));
                    if (!reader.IsDBNull(int_RecordIdColumnIndex))
                        record.int_RecordId = Convert.ToInt32(reader.GetValue(int_RecordIdColumnIndex));
                    if (!reader.IsDBNull(dt_CreateDateColumnIndex))
                        record.dt_CreateDate = Convert.ToDateTime(reader.GetValue(dt_CreateDateColumnIndex));
                    if (!reader.IsDBNull(int_UserIdColumnIndex))
                        record.int_UserId = Convert.ToInt32(reader.GetValue(int_UserIdColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_FileInfoEntity[])(recordList.ToArray(typeof(tb_FileInfoEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_FileInfoEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_FileInfoEntity"/> object.</returns>
        protected virtual tb_FileInfoEntity MapRow(DataRow row)
        {
            tb_FileInfoEntity mappedObject = new tb_FileInfoEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_FileId
            dataColumn = dataTable.Columns["int_FileId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_FileId = (int)row[dataColumn];
            // Column vc_ShowName
            dataColumn = dataTable.Columns["vc_ShowName"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_ShowName = (string)row[dataColumn];
            // Column vc_FileName
            dataColumn = dataTable.Columns["vc_FileName"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_FileName = (string)row[dataColumn];
            // Column int_TbId
            dataColumn = dataTable.Columns["int_TbId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_TbId = (int)row[dataColumn];
            // Column int_RecordId
            dataColumn = dataTable.Columns["int_RecordId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_RecordId = (int)row[dataColumn];
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
        /// the <c>tb_FileInfoEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_FileInfoEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_FileId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_ShowName", typeof(string));
            dataColumn.MaxLength = 100;
            dataColumn = dataTable.Columns.Add("vc_FileName", typeof(string));
            dataColumn.MaxLength = 500;
            dataColumn = dataTable.Columns.Add("int_TbId", typeof(int));
            dataColumn = dataTable.Columns.Add("int_RecordId", typeof(int));
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
                case "int_FileId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_ShowName":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_FileName":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "int_TbId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_RecordId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
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
    } // End of  tb_FileInfoEntity_BaseOp class
}  // End of namespace

