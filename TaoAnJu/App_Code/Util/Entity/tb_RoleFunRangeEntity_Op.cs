using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_RoleFunRangeEntity_Op
    {
        private DsConnectionDB _db;

        public tb_RoleFunRangeEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_RoleFunRangeEntity[] GetAll()
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

        public tb_RoleFunRangeEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_RoleFunRangeEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_RoleFunRange";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_RoleFunRangeEntity GetByPrimaryKey(int int_Id)
        {
            string whereSql = "";
            whereSql += "int_Id=@int_Id ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_Id", int_Id);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_RoleFunRangeEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_RoleFunRangeEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_RoleFunRangeEntity value)
        {
            string sqlStr = "INSERT INTO tb_RoleFunRange(";
            if (!value.int_RFIdNull)
                sqlStr += "int_RFId,";
            if (!value.int_RangeNull)
                sqlStr += "int_Range,";
            if (!value.int_DepIdNull)
                sqlStr += "int_DepId,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (!value.int_RFIdNull)
                sqlStr += "@int_RFId,";
            if (!value.int_RangeNull)
                sqlStr += "@int_Range,";
            if (!value.int_DepIdNull)
                sqlStr += "@int_DepId,";
            if (!value.dt_CreateDateNull)
                sqlStr += "@dt_CreateDate,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_RFIdNull)
                AddParameter(cmd, "int_RFId", (object)value.int_RFId);
            if (!value.int_RangeNull)
                AddParameter(cmd, "int_Range", (object)value.int_Range);
            if (!value.int_DepIdNull)
                AddParameter(cmd, "int_DepId", (object)value.int_DepId);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);

            value.int_Id = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_RoleFunRangeEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_RoleFunRangeEntity value)
        {
            string sqlStr = "UPDATE tb_RoleFunRange SET ";
            if (!value.int_RFIdNull)
                sqlStr += "int_RFId=@int_RFId,";
            if (!value.int_RangeNull)
                sqlStr += "int_Range=@int_Range,";
            if (!value.int_DepIdNull)
                sqlStr += "int_DepId=@int_DepId,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate=@dt_CreateDate,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_IdNull)
                sqlStr += "int_Id= @int_Id";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_RFIdNull)
                AddParameter(cmd, "int_RFId", (object)value.int_RFId);
            if (!value.int_RangeNull)
                AddParameter(cmd, "int_Range", (object)value.int_Range);
            if (!value.int_DepIdNull)
                AddParameter(cmd, "int_DepId", (object)value.int_DepId);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_IdNull)
                AddParameter(cmd, "int_Id", (object)value.int_Id);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_RoleFunRangeEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_RoleFunRangeEntity value)
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
        /// Deletes <c>tb_RoleFunRangeEntity</c> records that match the specified criteria.
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
        /// to delete <c>tb_RoleFunRangeEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_RoleFunRange";
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
        protected tb_RoleFunRangeEntity[] MapRecords(SqlDataReader reader)
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
        protected virtual tb_RoleFunRangeEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_IdColumnIndex = reader.GetOrdinal("int_Id");
            int int_RFIdColumnIndex = reader.GetOrdinal("int_RFId");
            int int_RangeColumnIndex = reader.GetOrdinal("int_Range");
            int int_DepIdColumnIndex = reader.GetOrdinal("int_DepId");
            int dt_CreateDateColumnIndex = reader.GetOrdinal("dt_CreateDate");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_RoleFunRangeEntity record = new tb_RoleFunRangeEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_IdColumnIndex))
                        record.int_Id = Convert.ToInt32(reader.GetValue(int_IdColumnIndex));
                    if (!reader.IsDBNull(int_RFIdColumnIndex))
                        record.int_RFId = Convert.ToInt32(reader.GetValue(int_RFIdColumnIndex));
                    if (!reader.IsDBNull(int_RangeColumnIndex))
                        record.int_Range = Convert.ToInt32(reader.GetValue(int_RangeColumnIndex));
                    if (!reader.IsDBNull(int_DepIdColumnIndex))
                        record.int_DepId = Convert.ToInt32(reader.GetValue(int_DepIdColumnIndex));
                    if (!reader.IsDBNull(dt_CreateDateColumnIndex))
                        record.dt_CreateDate = Convert.ToDateTime(reader.GetValue(dt_CreateDateColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_RoleFunRangeEntity[])(recordList.ToArray(typeof(tb_RoleFunRangeEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_RoleFunRangeEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_RoleFunRangeEntity"/> object.</returns>
        protected virtual tb_RoleFunRangeEntity MapRow(DataRow row)
        {
            tb_RoleFunRangeEntity mappedObject = new tb_RoleFunRangeEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_Id
            dataColumn = dataTable.Columns["int_Id"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_Id = (int)row[dataColumn];
            // Column int_RFId
            dataColumn = dataTable.Columns["int_RFId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_RFId = (int)row[dataColumn];
            // Column int_Range
            dataColumn = dataTable.Columns["int_Range"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_Range = (int)row[dataColumn];
            // Column int_DepId
            dataColumn = dataTable.Columns["int_DepId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_DepId = (int)row[dataColumn];
            // Column dt_CreateDate
            dataColumn = dataTable.Columns["dt_CreateDate"];
            if (!row.IsNull(dataColumn))
                mappedObject.dt_CreateDate = (DateTime)row[dataColumn];


            return mappedObject;
        }

        /// <summary>
        /// Creates a <see cref="System.Data.DataTable"/> object for 
        /// the <c>tb_RoleFunRangeEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_RoleFunRangeEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_Id", typeof(int));
            dataColumn = dataTable.Columns.Add("int_RFId", typeof(int));
            dataColumn = dataTable.Columns.Add("int_Range", typeof(int));
            dataColumn = dataTable.Columns.Add("int_DepId", typeof(int));
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
                case "int_RFId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_Range":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_DepId":
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
    } // End of  tb_RoleFunRangeEntity_BaseOp class
}  // End of namespace

