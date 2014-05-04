using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_RegInfoEntity_Op
    {
        private DsConnectionDB _db;

        public tb_RegInfoEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_RegInfoEntity[] GetAll()
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

        public tb_RegInfoEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_RegInfoEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_RegInfo";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_RegInfoEntity GetByPrimaryKey(int int_RId)
        {
            string whereSql = "";
            whereSql += "int_RId=@int_RId ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_RId", int_RId);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_RegInfoEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_RegInfoEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_RegInfoEntity value)
        {
            string sqlStr = "INSERT INTO tb_RegInfo(";
            if (!value.int_ItemIdNull)
                sqlStr += "int_ItemId,";
            if (null != value.vc_Name)
                sqlStr += "vc_Name,";
            if (null != value.vc_Mobile)
                sqlStr += "vc_Mobile,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate,";
            if (!value.int_UserIdNull)
                sqlStr += "int_UserId,";
            if (!string.IsNullOrEmpty(value.vc_From))
                sqlStr += "vc_From,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (!value.int_ItemIdNull)
                sqlStr += "@int_ItemId,";
            if (null != value.vc_Name)
                sqlStr += "@vc_Name,";
            if (null != value.vc_Mobile)
                sqlStr += "@vc_Mobile,";
            if (!value.dt_CreateDateNull)
                sqlStr += "@dt_CreateDate,";
            if (!value.int_UserIdNull)
                sqlStr += "@int_UserId,";
            if (!string.IsNullOrEmpty(value.vc_From))
                sqlStr += "@vc_From,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_ItemIdNull)
                AddParameter(cmd, "int_ItemId", (object)value.int_ItemId);
            if (null != value.vc_Name)
                AddParameter(cmd, "vc_Name", value.vc_Name);
            if (null != value.vc_Mobile)
                AddParameter(cmd, "vc_Mobile", value.vc_Mobile);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_UserIdNull)
                AddParameter(cmd, "int_UserId", (object)value.int_UserId);
            if (!string.IsNullOrEmpty(value.vc_From))
            {
                AddParameter(cmd, "vc_From", (object)value.vc_From);
            }
            value.int_RId = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_RegInfoEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_RegInfoEntity value)
        {
            string sqlStr = "UPDATE tb_RegInfo SET ";
            if (!value.int_ItemIdNull)
                sqlStr += "int_ItemId=@int_ItemId,";
            if (null != value.vc_Name)
                sqlStr += "vc_Name=@vc_Name,";
            if (null != value.vc_Mobile)
                sqlStr += "vc_Mobile=@vc_Mobile,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate=@dt_CreateDate,";
            if (!value.int_UserIdNull)
                sqlStr += "int_UserId=@int_UserId,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_RIdNull)
                sqlStr += "int_RId= @int_RId";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_ItemIdNull)
                AddParameter(cmd, "int_ItemId", (object)value.int_ItemId);
            if (null != value.vc_Name)
                AddParameter(cmd, "vc_Name", value.vc_Name);
            if (null != value.vc_Mobile)
                AddParameter(cmd, "vc_Mobile", value.vc_Mobile);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_UserIdNull)
                AddParameter(cmd, "int_UserId", (object)value.int_UserId);
            if (!value.int_RIdNull)
                AddParameter(cmd, "int_RId", (object)value.int_RId);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_RegInfoEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_RegInfoEntity value)
        {
            return DeleteByPrimaryKey(value.int_RId);
        }

        public virtual int DeleteByPrimaryKey(int int_RId)
        {
            string whereSql = "";
            whereSql += "int_RId=@int_RId ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_RId", int_RId);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_RegInfoEntity</c> records that match the specified criteria.
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
        /// to delete <c>tb_RegInfoEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_RegInfo";
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
        protected tb_RegInfoEntity[] MapRecords(SqlDataReader reader)
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
        protected virtual tb_RegInfoEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_RIdColumnIndex = reader.GetOrdinal("int_RId");
            int int_ItemIdColumnIndex = reader.GetOrdinal("int_ItemId");
            int vc_NameColumnIndex = reader.GetOrdinal("vc_Name");
            int vc_MobileColumnIndex = reader.GetOrdinal("vc_Mobile");
            int dt_CreateDateColumnIndex = reader.GetOrdinal("dt_CreateDate");
            int int_UserIdColumnIndex = reader.GetOrdinal("int_UserId");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_RegInfoEntity record = new tb_RegInfoEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_RIdColumnIndex))
                        record.int_RId = Convert.ToInt32(reader.GetValue(int_RIdColumnIndex));
                    if (!reader.IsDBNull(int_ItemIdColumnIndex))
                        record.int_ItemId = Convert.ToInt32(reader.GetValue(int_ItemIdColumnIndex));
                    if (!reader.IsDBNull(vc_NameColumnIndex))
                        record.vc_Name = Convert.ToString(reader.GetValue(vc_NameColumnIndex));
                    if (!reader.IsDBNull(vc_MobileColumnIndex))
                        record.vc_Mobile = Convert.ToString(reader.GetValue(vc_MobileColumnIndex));
                    if (!reader.IsDBNull(dt_CreateDateColumnIndex))
                        record.dt_CreateDate = Convert.ToDateTime(reader.GetValue(dt_CreateDateColumnIndex));
                    if (!reader.IsDBNull(int_UserIdColumnIndex))
                        record.int_UserId = Convert.ToInt32(reader.GetValue(int_UserIdColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_RegInfoEntity[])(recordList.ToArray(typeof(tb_RegInfoEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_RegInfoEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_RegInfoEntity"/> object.</returns>
        protected virtual tb_RegInfoEntity MapRow(DataRow row)
        {
            tb_RegInfoEntity mappedObject = new tb_RegInfoEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_RId
            dataColumn = dataTable.Columns["int_RId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_RId = (int)row[dataColumn];
            // Column int_ItemId
            dataColumn = dataTable.Columns["int_ItemId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_ItemId = (int)row[dataColumn];
            // Column vc_Name
            dataColumn = dataTable.Columns["vc_Name"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Name = (string)row[dataColumn];
            // Column vc_Mobile
            dataColumn = dataTable.Columns["vc_Mobile"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Mobile = (string)row[dataColumn];
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
        /// the <c>tb_RegInfoEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_RegInfoEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_RId", typeof(int));
            dataColumn = dataTable.Columns.Add("int_ItemId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_Name", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("vc_Mobile", typeof(string));
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
                case "int_RId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_ItemId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_Name":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Mobile":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "dt_CreateDate":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.DateTime, value);
                    break;
                case "int_UserId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_From":
                     parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;

                default:
                    throw new ArgumentException("Unknown parameter name (" + paramName + ").");
            }
            return parameter;
        }
    } // End of  tb_RegInfoEntity_BaseOp class
}  // End of namespace

