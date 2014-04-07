using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_FieldDataConfigEntity_Op
    {
        private DsConnectionDB _db;

        public tb_FieldDataConfigEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_FieldDataConfigEntity[] GetAll()
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

        public tb_FieldDataConfigEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_FieldDataConfigEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_FieldDataConfig";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_FieldDataConfigEntity GetByPrimaryKey(int int_FDID)
        {
            string whereSql = "";
            whereSql += "int_FDID=@int_FDID ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_FDID", int_FDID);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_FieldDataConfigEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_FieldDataConfigEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_FieldDataConfigEntity value)
        {
            string sqlStr = "INSERT INTO tb_FieldDataConfig(";
            if (!value.int_FiIdNull)
                sqlStr += "int_FiId,";
            if (!value.int_DataNormalNull)
                sqlStr += "int_DataNormal,";
            if (!value.int_DestFiIdNull)
                sqlStr += "int_DestFiId,";
            if (!value.int_SourTbIdNull)
                sqlStr += "int_SourTbId,";
            if (!value.int_SourFiIdNull)
                sqlStr += "int_SourFiId,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (!value.int_FiIdNull)
                sqlStr += "@int_FiId,";
            if (!value.int_DataNormalNull)
                sqlStr += "@int_DataNormal,";
            if (!value.int_DestFiIdNull)
                sqlStr += "@int_DestFiId,";
            if (!value.int_SourTbIdNull)
                sqlStr += "@int_SourTbId,";
            if (!value.int_SourFiIdNull)
                sqlStr += "@int_SourFiId,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_FiIdNull)
                AddParameter(cmd, "int_FiId", (object)value.int_FiId);
            if (!value.int_DataNormalNull)
                AddParameter(cmd, "int_DataNormal", (object)value.int_DataNormal);
            if (!value.int_DestFiIdNull)
                AddParameter(cmd, "int_DestFiId", (object)value.int_DestFiId);
            if (!value.int_SourTbIdNull)
                AddParameter(cmd, "int_SourTbId", (object)value.int_SourTbId);
            if (!value.int_SourFiIdNull)
                AddParameter(cmd, "int_SourFiId", (object)value.int_SourFiId);

            value.int_FDID = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_FieldDataConfigEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_FieldDataConfigEntity value)
        {
            string sqlStr = "UPDATE tb_FieldDataConfig SET ";
            if (!value.int_FiIdNull)
                sqlStr += "int_FiId=@int_FiId,";
            if (!value.int_DataNormalNull)
                sqlStr += "int_DataNormal=@int_DataNormal,";
            if (!value.int_DestFiIdNull)
                sqlStr += "int_DestFiId=@int_DestFiId,";
            if (!value.int_SourTbIdNull)
                sqlStr += "int_SourTbId=@int_SourTbId,";
            if (!value.int_SourFiIdNull)
                sqlStr += "int_SourFiId=@int_SourFiId,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_FDIDNull)
                sqlStr += "int_FDID= @int_FDID";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_FiIdNull)
                AddParameter(cmd, "int_FiId", (object)value.int_FiId);
            if (!value.int_DataNormalNull)
                AddParameter(cmd, "int_DataNormal", (object)value.int_DataNormal);
            if (!value.int_DestFiIdNull)
                AddParameter(cmd, "int_DestFiId", (object)value.int_DestFiId);
            if (!value.int_SourTbIdNull)
                AddParameter(cmd, "int_SourTbId", (object)value.int_SourTbId);
            if (!value.int_SourFiIdNull)
                AddParameter(cmd, "int_SourFiId", (object)value.int_SourFiId);
            if (!value.int_FDIDNull)
                AddParameter(cmd, "int_FDID", (object)value.int_FDID);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_FieldDataConfigEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_FieldDataConfigEntity value)
        {
            return DeleteByPrimaryKey(value.int_FDID);
        }

        public virtual int DeleteByPrimaryKey(int int_FDID)
        {
            string whereSql = "";
            whereSql += "int_FDID=@int_FDID ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_FDID", int_FDID);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_FieldDataConfigEntity</c> records that match the specified criteria.
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
        /// to delete <c>tb_FieldDataConfigEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_FieldDataConfig";
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
        protected tb_FieldDataConfigEntity[] MapRecords(SqlDataReader reader)
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
        protected virtual tb_FieldDataConfigEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_FDIDColumnIndex = reader.GetOrdinal("int_FDID");
            int int_FiIdColumnIndex = reader.GetOrdinal("int_FiId");
            int int_DataNormalColumnIndex = reader.GetOrdinal("int_DataNormal");
            int int_DestFiIdColumnIndex = reader.GetOrdinal("int_DestFiId");
            int int_SourTbIdColumnIndex = reader.GetOrdinal("int_SourTbId");
            int int_SourFiIdColumnIndex = reader.GetOrdinal("int_SourFiId");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_FieldDataConfigEntity record = new tb_FieldDataConfigEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_FDIDColumnIndex))
                        record.int_FDID = Convert.ToInt32(reader.GetValue(int_FDIDColumnIndex));
                    if (!reader.IsDBNull(int_FiIdColumnIndex))
                        record.int_FiId = Convert.ToInt32(reader.GetValue(int_FiIdColumnIndex));
                    if (!reader.IsDBNull(int_DataNormalColumnIndex))
                        record.int_DataNormal = Convert.ToInt32(reader.GetValue(int_DataNormalColumnIndex));
                    if (!reader.IsDBNull(int_DestFiIdColumnIndex))
                        record.int_DestFiId = Convert.ToInt32(reader.GetValue(int_DestFiIdColumnIndex));
                    if (!reader.IsDBNull(int_SourTbIdColumnIndex))
                        record.int_SourTbId = Convert.ToInt32(reader.GetValue(int_SourTbIdColumnIndex));
                    if (!reader.IsDBNull(int_SourFiIdColumnIndex))
                        record.int_SourFiId = Convert.ToInt32(reader.GetValue(int_SourFiIdColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_FieldDataConfigEntity[])(recordList.ToArray(typeof(tb_FieldDataConfigEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_FieldDataConfigEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_FieldDataConfigEntity"/> object.</returns>
        protected virtual tb_FieldDataConfigEntity MapRow(DataRow row)
        {
            tb_FieldDataConfigEntity mappedObject = new tb_FieldDataConfigEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_FDID
            dataColumn = dataTable.Columns["int_FDID"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_FDID = (int)row[dataColumn];
            // Column int_FiId
            dataColumn = dataTable.Columns["int_FiId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_FiId = (int)row[dataColumn];
            // Column int_DataNormal
            dataColumn = dataTable.Columns["int_DataNormal"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_DataNormal = (int)row[dataColumn];
            // Column int_DestFiId
            dataColumn = dataTable.Columns["int_DestFiId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_DestFiId = (int)row[dataColumn];
            // Column int_SourTbId
            dataColumn = dataTable.Columns["int_SourTbId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_SourTbId = (int)row[dataColumn];
            // Column int_SourFiId
            dataColumn = dataTable.Columns["int_SourFiId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_SourFiId = (int)row[dataColumn];


            return mappedObject;
        }

        /// <summary>
        /// Creates a <see cref="System.Data.DataTable"/> object for 
        /// the <c>tb_FieldDataConfigEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_FieldDataConfigEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_FDID", typeof(int));
            dataColumn = dataTable.Columns.Add("int_FiId", typeof(int));
            dataColumn = dataTable.Columns.Add("int_DataNormal", typeof(int));
            dataColumn = dataTable.Columns.Add("int_DestFiId", typeof(int));
            dataColumn = dataTable.Columns.Add("int_SourTbId", typeof(int));
            dataColumn = dataTable.Columns.Add("int_SourFiId", typeof(int));


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
                case "int_FDID":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_FiId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_DataNormal":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_DestFiId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_SourTbId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_SourFiId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;


                default:
                    throw new ArgumentException("Unknown parameter name (" + paramName + ").");
            }
            return parameter;
        }
    } // End of  tb_FieldDataConfigEntity_BaseOp class
}  // End of namespace

