using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_FunInfoEntity_Op
    {
        private DsConnectionDB _db;

        public tb_FunInfoEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_FunInfoEntity[] GetAll()
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

        public tb_FunInfoEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_FunInfoEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_FunInfo";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_FunInfoEntity GetByPrimaryKey(int int_FunId)
        {
            string whereSql = "";
            whereSql += "int_FunId=@int_FunId ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_FunId", int_FunId);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_FunInfoEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_FunInfoEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_FunInfoEntity value)
        {
            string sqlStr = "INSERT INTO tb_FunInfo(";
            if (null != value.vc_Name)
                sqlStr += "vc_Name,";
            if (!value.int_ParentIdNull)
                sqlStr += "int_ParentId,";
            if (null != value.vc_Value)
                sqlStr += "vc_Value,";
            if (null != value.vc_Parameter)
                sqlStr += "vc_Parameter,";
            if (!value.int_TypeNull)
                sqlStr += "int_Type,";
            if (!value.int_OrderNull)
                sqlStr += "int_Order,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (null != value.vc_Name)
                sqlStr += "@vc_Name,";
            if (!value.int_ParentIdNull)
                sqlStr += "@int_ParentId,";
            if (null != value.vc_Value)
                sqlStr += "@vc_Value,";
            if (null != value.vc_Parameter)
                sqlStr += "@vc_Parameter,";
            if (!value.int_TypeNull)
                sqlStr += "@int_Type,";
            if (!value.int_OrderNull)
                sqlStr += "@int_Order,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_Name)
                AddParameter(cmd, "vc_Name", value.vc_Name);
            if (!value.int_ParentIdNull)
                AddParameter(cmd, "int_ParentId", (object)value.int_ParentId);
            if (null != value.vc_Value)
                AddParameter(cmd, "vc_Value", value.vc_Value);
            if (null != value.vc_Parameter)
                AddParameter(cmd, "vc_Parameter", value.vc_Parameter);
            if (!value.int_TypeNull)
                AddParameter(cmd, "int_Type", (object)value.int_Type);
            if (!value.int_OrderNull)
                AddParameter(cmd, "int_Order", (object)value.int_Order);

            value.int_FunId = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_FunInfoEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_FunInfoEntity value)
        {
            string sqlStr = "UPDATE tb_FunInfo SET ";
            if (null != value.vc_Name)
                sqlStr += "vc_Name=@vc_Name,";
            if (!value.int_ParentIdNull)
                sqlStr += "int_ParentId=@int_ParentId,";
            if (null != value.vc_Value)
                sqlStr += "vc_Value=@vc_Value,";
            if (null != value.vc_Parameter)
                sqlStr += "vc_Parameter=@vc_Parameter,";
            if (!value.int_TypeNull)
                sqlStr += "int_Type=@int_Type,";
            if (!value.int_OrderNull)
                sqlStr += "int_Order=@int_Order,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_FunIdNull)
                sqlStr += "int_FunId= @int_FunId";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_Name)
                AddParameter(cmd, "vc_Name", value.vc_Name);
            if (!value.int_ParentIdNull)
                AddParameter(cmd, "int_ParentId", (object)value.int_ParentId);
            if (null != value.vc_Value)
                AddParameter(cmd, "vc_Value", value.vc_Value);
            if (null != value.vc_Parameter)
                AddParameter(cmd, "vc_Parameter", value.vc_Parameter);
            if (!value.int_TypeNull)
                AddParameter(cmd, "int_Type", (object)value.int_Type);
            if (!value.int_OrderNull)
                AddParameter(cmd, "int_Order", (object)value.int_Order);
            if (!value.int_FunIdNull)
                AddParameter(cmd, "int_FunId", (object)value.int_FunId);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_FunInfoEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_FunInfoEntity value)
        {
            return DeleteByPrimaryKey(value.int_FunId);
        }

        public virtual int DeleteByPrimaryKey(int int_FunId)
        {
            string whereSql = "";
            whereSql += "int_FunId=@int_FunId ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_FunId", int_FunId);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_FunInfoEntity</c> records that match the specified criteria.
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
        /// to delete <c>tb_FunInfoEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_FunInfo";
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
        protected tb_FunInfoEntity[] MapRecords(SqlDataReader reader)
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
        protected virtual tb_FunInfoEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_FunIdColumnIndex = reader.GetOrdinal("int_FunId");
            int vc_NameColumnIndex = reader.GetOrdinal("vc_Name");
            int int_ParentIdColumnIndex = reader.GetOrdinal("int_ParentId");
            int vc_ValueColumnIndex = reader.GetOrdinal("vc_Value");
            int vc_ParameterColumnIndex = reader.GetOrdinal("vc_Parameter");
            int int_TypeColumnIndex = reader.GetOrdinal("int_Type");
            int int_OrderColumnIndex = reader.GetOrdinal("int_Order");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_FunInfoEntity record = new tb_FunInfoEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_FunIdColumnIndex))
                        record.int_FunId = Convert.ToInt32(reader.GetValue(int_FunIdColumnIndex));
                    if (!reader.IsDBNull(vc_NameColumnIndex))
                        record.vc_Name = Convert.ToString(reader.GetValue(vc_NameColumnIndex));
                    if (!reader.IsDBNull(int_ParentIdColumnIndex))
                        record.int_ParentId = Convert.ToInt32(reader.GetValue(int_ParentIdColumnIndex));
                    if (!reader.IsDBNull(vc_ValueColumnIndex))
                        record.vc_Value = Convert.ToString(reader.GetValue(vc_ValueColumnIndex));
                    if (!reader.IsDBNull(vc_ParameterColumnIndex))
                        record.vc_Parameter = Convert.ToString(reader.GetValue(vc_ParameterColumnIndex));
                    if (!reader.IsDBNull(int_TypeColumnIndex))
                        record.int_Type = Convert.ToInt32(reader.GetValue(int_TypeColumnIndex));
                    if (!reader.IsDBNull(int_OrderColumnIndex))
                        record.int_Order = Convert.ToInt32(reader.GetValue(int_OrderColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_FunInfoEntity[])(recordList.ToArray(typeof(tb_FunInfoEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_FunInfoEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_FunInfoEntity"/> object.</returns>
        protected virtual tb_FunInfoEntity MapRow(DataRow row)
        {
            tb_FunInfoEntity mappedObject = new tb_FunInfoEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_FunId
            dataColumn = dataTable.Columns["int_FunId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_FunId = (int)row[dataColumn];
            // Column vc_Name
            dataColumn = dataTable.Columns["vc_Name"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Name = (string)row[dataColumn];
            // Column int_ParentId
            dataColumn = dataTable.Columns["int_ParentId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_ParentId = (int)row[dataColumn];
            // Column vc_Value
            dataColumn = dataTable.Columns["vc_Value"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Value = (string)row[dataColumn];
            // Column vc_Parameter
            dataColumn = dataTable.Columns["vc_Parameter"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Parameter = (string)row[dataColumn];
            // Column int_Type
            dataColumn = dataTable.Columns["int_Type"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_Type = (int)row[dataColumn];
            // Column int_Order
            dataColumn = dataTable.Columns["int_Order"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_Order = (int)row[dataColumn];


            return mappedObject;
        }

        /// <summary>
        /// Creates a <see cref="System.Data.DataTable"/> object for 
        /// the <c>tb_FunInfoEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_FunInfoEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_FunId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_Name", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("int_ParentId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_Value", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_Parameter", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("int_Type", typeof(int));
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
                case "int_FunId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_Name":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "int_ParentId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_Value":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Parameter":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "int_Type":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_Order":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;


                default:
                    throw new ArgumentException("Unknown parameter name (" + paramName + ").");
            }
            return parameter;
        }
    } // End of  tb_FunInfoEntity_BaseOp class
}  // End of namespace

