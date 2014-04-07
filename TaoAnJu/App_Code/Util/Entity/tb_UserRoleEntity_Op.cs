using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_UserRoleEntity_Op
    {
        private DsConnectionDB _db;

        public tb_UserRoleEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_UserRoleEntity[] GetAll()
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

        public tb_UserRoleEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_UserRoleEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_UserRole";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_UserRoleEntity GetByPrimaryKey(int int_Id)
        {
            string whereSql = "";
            whereSql += "int_Id=@int_Id ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_Id", int_Id);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_UserRoleEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_UserRoleEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_UserRoleEntity value)
        {
            string sqlStr = "INSERT INTO tb_UserRole(";
            if (!value.int_UserIdNull)
                sqlStr += "int_UserId,";
            if (!value.int_RoleIdNull)
                sqlStr += "int_RoleId,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (!value.int_UserIdNull)
                sqlStr += "@int_UserId,";
            if (!value.int_RoleIdNull)
                sqlStr += "@int_RoleId,";
            if (!value.dt_CreateDateNull)
                sqlStr += "@dt_CreateDate,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_UserIdNull)
                AddParameter(cmd, "int_UserId", (object)value.int_UserId);
            if (!value.int_RoleIdNull)
                AddParameter(cmd, "int_RoleId", (object)value.int_RoleId);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);

            value.int_Id = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_UserRoleEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_UserRoleEntity value)
        {
            string sqlStr = "UPDATE tb_UserRole SET ";
            if (!value.int_UserIdNull)
                sqlStr += "int_UserId=@int_UserId,";
            if (!value.int_RoleIdNull)
                sqlStr += "int_RoleId=@int_RoleId,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate=@dt_CreateDate,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_IdNull)
                sqlStr += "int_Id= @int_Id";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_UserIdNull)
                AddParameter(cmd, "int_UserId", (object)value.int_UserId);
            if (!value.int_RoleIdNull)
                AddParameter(cmd, "int_RoleId", (object)value.int_RoleId);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_IdNull)
                AddParameter(cmd, "int_Id", (object)value.int_Id);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_UserRoleEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_UserRoleEntity value)
        {
            return DeleteByPrimaryKey(value.int_Id);
        }

        public virtual int DeleteByPrimaryKey(int int_Id)
        {
            string whereSql = "";
            whereSql += "int_Id=@int_Id ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_Id", int_Id);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_UserRoleEntity</c> records that match the specified criteria.
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
        /// to delete <c>tb_UserRoleEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_UserRole";
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
        protected tb_UserRoleEntity[] MapRecords(SqlDataReader reader)
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
        protected virtual tb_UserRoleEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_IdColumnIndex = reader.GetOrdinal("int_Id");
            int int_UserIdColumnIndex = reader.GetOrdinal("int_UserId");
            int int_RoleIdColumnIndex = reader.GetOrdinal("int_RoleId");
            int dt_CreateDateColumnIndex = reader.GetOrdinal("dt_CreateDate");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_UserRoleEntity record = new tb_UserRoleEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_IdColumnIndex))
                        record.int_Id = Convert.ToInt32(reader.GetValue(int_IdColumnIndex));
                    if (!reader.IsDBNull(int_UserIdColumnIndex))
                        record.int_UserId = Convert.ToInt32(reader.GetValue(int_UserIdColumnIndex));
                    if (!reader.IsDBNull(int_RoleIdColumnIndex))
                        record.int_RoleId = Convert.ToInt32(reader.GetValue(int_RoleIdColumnIndex));
                    if (!reader.IsDBNull(dt_CreateDateColumnIndex))
                        record.dt_CreateDate = Convert.ToDateTime(reader.GetValue(dt_CreateDateColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_UserRoleEntity[])(recordList.ToArray(typeof(tb_UserRoleEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_UserRoleEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_UserRoleEntity"/> object.</returns>
        protected virtual tb_UserRoleEntity MapRow(DataRow row)
        {
            tb_UserRoleEntity mappedObject = new tb_UserRoleEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_Id
            dataColumn = dataTable.Columns["int_Id"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_Id = (int)row[dataColumn];
            // Column int_UserId
            dataColumn = dataTable.Columns["int_UserId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_UserId = (int)row[dataColumn];
            // Column int_RoleId
            dataColumn = dataTable.Columns["int_RoleId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_RoleId = (int)row[dataColumn];
            // Column dt_CreateDate
            dataColumn = dataTable.Columns["dt_CreateDate"];
            if (!row.IsNull(dataColumn))
                mappedObject.dt_CreateDate = (DateTime)row[dataColumn];


            return mappedObject;
        }

        /// <summary>
        /// Creates a <see cref="System.Data.DataTable"/> object for 
        /// the <c>tb_UserRoleEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_UserRoleEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_Id", typeof(int));
            dataColumn = dataTable.Columns.Add("int_UserId", typeof(int));
            dataColumn = dataTable.Columns.Add("int_RoleId", typeof(int));
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
                case "int_Id":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_UserId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_RoleId":
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
    } // End of  tb_UserRoleEntity_BaseOp class
}  // End of namespace

