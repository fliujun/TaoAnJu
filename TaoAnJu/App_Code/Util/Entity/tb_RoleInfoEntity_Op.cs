using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_RoleInfoEntity_Op
    {
        private DsConnectionDB _db;

        public tb_RoleInfoEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_RoleInfoEntity[] GetAll()
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

        public tb_RoleInfoEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_RoleInfoEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_RoleInfo";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_RoleInfoEntity GetByPrimaryKey(int int_RoleId)
        {
            string whereSql = "";
            whereSql += "int_RoleId=@int_RoleId ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_RoleId", int_RoleId);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_RoleInfoEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_RoleInfoEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_RoleInfoEntity value)
        {
            string sqlStr = "INSERT INTO tb_RoleInfo(";
            if (null != value.vc_RoleName)
                sqlStr += "vc_RoleName,";
            if (null != value.vc_Desc)
                sqlStr += "vc_Desc,";
            if (!value.int_TypeNull)
                sqlStr += "int_Type,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (null != value.vc_RoleName)
                sqlStr += "@vc_RoleName,";
            if (null != value.vc_Desc)
                sqlStr += "@vc_Desc,";
            if (!value.int_TypeNull)
                sqlStr += "@int_Type,";
            if (!value.dt_CreateDateNull)
                sqlStr += "@dt_CreateDate,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_RoleName)
                AddParameter(cmd, "vc_RoleName", value.vc_RoleName);
            if (null != value.vc_Desc)
                AddParameter(cmd, "vc_Desc", value.vc_Desc);
            if (!value.int_TypeNull)
                AddParameter(cmd, "int_Type", (object)value.int_Type);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);

            value.int_RoleId = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_RoleInfoEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_RoleInfoEntity value)
        {
            string sqlStr = "UPDATE tb_RoleInfo SET ";
            if (null != value.vc_RoleName)
                sqlStr += "vc_RoleName=@vc_RoleName,";
            if (null != value.vc_Desc)
                sqlStr += "vc_Desc=@vc_Desc,";
            if (!value.int_TypeNull)
                sqlStr += "int_Type=@int_Type,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate=@dt_CreateDate,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_RoleIdNull)
                sqlStr += "int_RoleId= @int_RoleId";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_RoleName)
                AddParameter(cmd, "vc_RoleName", value.vc_RoleName);
            if (null != value.vc_Desc)
                AddParameter(cmd, "vc_Desc", value.vc_Desc);
            if (!value.int_TypeNull)
                AddParameter(cmd, "int_Type", (object)value.int_Type);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_RoleIdNull)
                AddParameter(cmd, "int_RoleId", (object)value.int_RoleId);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_RoleInfoEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_RoleInfoEntity value)
        {
            return DeleteByPrimaryKey(value.int_RoleId);
        }

        public virtual int DeleteByPrimaryKey(int int_RoleId)
        {
            string whereSql = "";
            whereSql += "int_RoleId=@int_RoleId ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_RoleId", int_RoleId);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_RoleInfoEntity</c> records that match the specified criteria.
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
        /// to delete <c>tb_RoleInfoEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_RoleInfo";
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
        protected tb_RoleInfoEntity[] MapRecords(SqlDataReader reader)
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
        protected virtual tb_RoleInfoEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_RoleIdColumnIndex = reader.GetOrdinal("int_RoleId");
            int vc_RoleNameColumnIndex = reader.GetOrdinal("vc_RoleName");
            int vc_DescColumnIndex = reader.GetOrdinal("vc_Desc");
            int int_TypeColumnIndex = reader.GetOrdinal("int_Type");
            int dt_CreateDateColumnIndex = reader.GetOrdinal("dt_CreateDate");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_RoleInfoEntity record = new tb_RoleInfoEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_RoleIdColumnIndex))
                        record.int_RoleId = Convert.ToInt32(reader.GetValue(int_RoleIdColumnIndex));
                    if (!reader.IsDBNull(vc_RoleNameColumnIndex))
                        record.vc_RoleName = Convert.ToString(reader.GetValue(vc_RoleNameColumnIndex));
                    if (!reader.IsDBNull(vc_DescColumnIndex))
                        record.vc_Desc = Convert.ToString(reader.GetValue(vc_DescColumnIndex));
                    if (!reader.IsDBNull(int_TypeColumnIndex))
                        record.int_Type = Convert.ToInt32(reader.GetValue(int_TypeColumnIndex));
                    if (!reader.IsDBNull(dt_CreateDateColumnIndex))
                        record.dt_CreateDate = Convert.ToDateTime(reader.GetValue(dt_CreateDateColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_RoleInfoEntity[])(recordList.ToArray(typeof(tb_RoleInfoEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_RoleInfoEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_RoleInfoEntity"/> object.</returns>
        protected virtual tb_RoleInfoEntity MapRow(DataRow row)
        {
            tb_RoleInfoEntity mappedObject = new tb_RoleInfoEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_RoleId
            dataColumn = dataTable.Columns["int_RoleId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_RoleId = (int)row[dataColumn];
            // Column vc_RoleName
            dataColumn = dataTable.Columns["vc_RoleName"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_RoleName = (string)row[dataColumn];
            // Column vc_Desc
            dataColumn = dataTable.Columns["vc_Desc"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Desc = (string)row[dataColumn];
            // Column int_Type
            dataColumn = dataTable.Columns["int_Type"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_Type = (int)row[dataColumn];
            // Column dt_CreateDate
            dataColumn = dataTable.Columns["dt_CreateDate"];
            if (!row.IsNull(dataColumn))
                mappedObject.dt_CreateDate = (DateTime)row[dataColumn];


            return mappedObject;
        }

        /// <summary>
        /// Creates a <see cref="System.Data.DataTable"/> object for 
        /// the <c>tb_RoleInfoEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_RoleInfoEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_RoleId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_RoleName", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("vc_Desc", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("int_Type", typeof(int));
            dataColumn = dataTable.Columns.Add("dt_CreateDate", typeof(DateTime));


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
                case "int_RoleId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_RoleName":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Desc":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "int_Type":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "dt_CreateDate":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.DateTime, value);
                    break;


                default:
                    throw new ArgumentException("Unknown parameter name (" + paramName + ").");
            }
            return parameter;
        }
    } // End of  tb_RoleInfoEntity_BaseOp class
}  // End of namespace

