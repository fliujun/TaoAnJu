using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_TableInfoEntity_Op
    {
        private DsConnectionDB _db;

        public tb_TableInfoEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_TableInfoEntity[] GetAll()
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

        public tb_TableInfoEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_TableInfoEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_TableInfo";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_TableInfoEntity GetByPrimaryKey(int int_TbId)
        {
            string whereSql = "";
            whereSql += "int_TbId=@int_TbId ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_TbId", int_TbId);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_TableInfoEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_TableInfoEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_TableInfoEntity value)
        {
            string sqlStr = "INSERT INTO tb_TableInfo(";
            if (!value.int_TbIdNull)
                sqlStr += "int_TbId,";
            if (null != value.vc_TableName)
                sqlStr += "vc_TableName,";
            if (null != value.vc_TableDesc)
                sqlStr += "vc_TableDesc,";
            if (!value.int_ParentIdNull)
                sqlStr += "int_ParentId,";
            if (!value.int_LinkFiIdNull)
                sqlStr += "int_LinkFiId,";
            if (null != value.vc_GUID)
                sqlStr += "vc_GUID,";
            if (!value.int_OrderNull)
                sqlStr += "int_Order,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (!value.int_TbIdNull)
                sqlStr += "@int_TbId,";
            if (null != value.vc_TableName)
                sqlStr += "@vc_TableName,";
            if (null != value.vc_TableDesc)
                sqlStr += "@vc_TableDesc,";
            if (!value.int_ParentIdNull)
                sqlStr += "@int_ParentId,";
            if (!value.int_LinkFiIdNull)
                sqlStr += "@int_LinkFiId,";
            if (null != value.vc_GUID)
                sqlStr += "@vc_GUID,";
            if (!value.int_OrderNull)
                sqlStr += "@int_Order,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_TbIdNull)
                AddParameter(cmd, "int_TbId", (object)value.int_TbId);
            if (null != value.vc_TableName)
                AddParameter(cmd, "vc_TableName", value.vc_TableName);
            if (null != value.vc_TableDesc)
                AddParameter(cmd, "vc_TableDesc", value.vc_TableDesc);
            if (!value.int_ParentIdNull)
                AddParameter(cmd, "int_ParentId", (object)value.int_ParentId);
            if (!value.int_LinkFiIdNull)
                AddParameter(cmd, "int_LinkFiId", (object)value.int_LinkFiId);
            if (null != value.vc_GUID)
                AddParameter(cmd, "vc_GUID", value.vc_GUID);
            if (!value.int_OrderNull)
                AddParameter(cmd, "int_Order", (object)value.int_Order);

            value.int_TbId = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_TableInfoEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_TableInfoEntity value)
        {
            string sqlStr = "UPDATE tb_TableInfo SET ";
            if (null != value.vc_TableName)
                sqlStr += "vc_TableName=@vc_TableName,";
            if (null != value.vc_TableDesc)
                sqlStr += "vc_TableDesc=@vc_TableDesc,";
            if (!value.int_ParentIdNull)
                sqlStr += "int_ParentId=@int_ParentId,";
            if (!value.int_LinkFiIdNull)
                sqlStr += "int_LinkFiId=@int_LinkFiId,";
            if (null != value.vc_GUID)
                sqlStr += "vc_GUID=@vc_GUID,";
            if (!value.int_OrderNull)
                sqlStr += "int_Order=@int_Order,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_TbIdNull)
                sqlStr += "int_TbId= @int_TbId";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_TableName)
                AddParameter(cmd, "vc_TableName", value.vc_TableName);
            if (null != value.vc_TableDesc)
                AddParameter(cmd, "vc_TableDesc", value.vc_TableDesc);
            if (!value.int_ParentIdNull)
                AddParameter(cmd, "int_ParentId", (object)value.int_ParentId);
            if (!value.int_LinkFiIdNull)
                AddParameter(cmd, "int_LinkFiId", (object)value.int_LinkFiId);
            if (null != value.vc_GUID)
                AddParameter(cmd, "vc_GUID", value.vc_GUID);
            if (!value.int_OrderNull)
                AddParameter(cmd, "int_Order", (object)value.int_Order);
            if (!value.int_TbIdNull)
                AddParameter(cmd, "int_TbId", (object)value.int_TbId);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_TableInfoEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_TableInfoEntity value)
        {
            return DeleteByPrimaryKey(value.int_TbId);
        }

        public virtual int DeleteByPrimaryKey(int int_TbId)
        {
            string whereSql = "";
            whereSql += "int_TbId=@int_TbId ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_TbId", int_TbId);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_TableInfoEntity</c> records that match the specified criteria.
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
        /// to delete <c>tb_TableInfoEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_TableInfo";
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
        protected tb_TableInfoEntity[] MapRecords(SqlDataReader reader)
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
        protected virtual tb_TableInfoEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_TbIdColumnIndex = reader.GetOrdinal("int_TbId");
            int vc_TableNameColumnIndex = reader.GetOrdinal("vc_TableName");
            int vc_TableDescColumnIndex = reader.GetOrdinal("vc_TableDesc");
            int int_ParentIdColumnIndex = reader.GetOrdinal("int_ParentId");
            int int_LinkFiIdColumnIndex = reader.GetOrdinal("int_LinkFiId");
            int vc_GUIDColumnIndex = reader.GetOrdinal("vc_GUID");
            int int_OrderColumnIndex = reader.GetOrdinal("int_Order");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_TableInfoEntity record = new tb_TableInfoEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_TbIdColumnIndex))
                        record.int_TbId = Convert.ToInt32(reader.GetValue(int_TbIdColumnIndex));
                    if (!reader.IsDBNull(vc_TableNameColumnIndex))
                        record.vc_TableName = Convert.ToString(reader.GetValue(vc_TableNameColumnIndex));
                    if (!reader.IsDBNull(vc_TableDescColumnIndex))
                        record.vc_TableDesc = Convert.ToString(reader.GetValue(vc_TableDescColumnIndex));
                    if (!reader.IsDBNull(int_ParentIdColumnIndex))
                        record.int_ParentId = Convert.ToInt32(reader.GetValue(int_ParentIdColumnIndex));
                    if (!reader.IsDBNull(int_LinkFiIdColumnIndex))
                        record.int_LinkFiId = Convert.ToInt32(reader.GetValue(int_LinkFiIdColumnIndex));
                    if (!reader.IsDBNull(vc_GUIDColumnIndex))
                        record.vc_GUID = Convert.ToString(reader.GetValue(vc_GUIDColumnIndex));
                    if (!reader.IsDBNull(int_OrderColumnIndex))
                        record.int_Order = Convert.ToInt32(reader.GetValue(int_OrderColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_TableInfoEntity[])(recordList.ToArray(typeof(tb_TableInfoEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_TableInfoEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_TableInfoEntity"/> object.</returns>
        protected virtual tb_TableInfoEntity MapRow(DataRow row)
        {
            tb_TableInfoEntity mappedObject = new tb_TableInfoEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_TbId
            dataColumn = dataTable.Columns["int_TbId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_TbId = (int)row[dataColumn];
            // Column vc_TableName
            dataColumn = dataTable.Columns["vc_TableName"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_TableName = (string)row[dataColumn];
            // Column vc_TableDesc
            dataColumn = dataTable.Columns["vc_TableDesc"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_TableDesc = (string)row[dataColumn];
            // Column int_ParentId
            dataColumn = dataTable.Columns["int_ParentId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_ParentId = (int)row[dataColumn];
            // Column int_LinkFiId
            dataColumn = dataTable.Columns["int_LinkFiId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_LinkFiId = (int)row[dataColumn];
            // Column vc_GUID
            dataColumn = dataTable.Columns["vc_GUID"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_GUID = (string)row[dataColumn];
            // Column int_Order
            dataColumn = dataTable.Columns["int_Order"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_Order = (int)row[dataColumn];


            return mappedObject;
        }

        /// <summary>
        /// Creates a <see cref="System.Data.DataTable"/> object for 
        /// the <c>tb_TableInfoEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_TableInfoEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_TbId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_TableName", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_TableDesc", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("int_ParentId", typeof(int));
            dataColumn = dataTable.Columns.Add("int_LinkFiId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_GUID", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("int_Order", typeof(int));


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
                case "int_TbId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_TableName":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_TableDesc":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "int_ParentId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_LinkFiId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_GUID":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "int_Order":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;


                default:
                    throw new ArgumentException("Unknown parameter name (" + paramName + ").");
            }
            return parameter;
        }
    } // End of  tb_TableInfoEntity_BaseOp class
}  // End of namespace

