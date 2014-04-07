using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_FieldInfoEntity_Op
    {
        private DsConnectionDB _db;

        public tb_FieldInfoEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_FieldInfoEntity[] GetAll()
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

        public tb_FieldInfoEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_FieldInfoEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_FieldInfo";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_FieldInfoEntity GetByPrimaryKey(int int_FiId)
        {
            string whereSql = "";
            whereSql += "int_FiId=@int_FiId ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_FiId", int_FiId);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_FieldInfoEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_FieldInfoEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_FieldInfoEntity value)
        {
            string sqlStr = "INSERT INTO tb_FieldInfo(";
            if (!value.int_TbIdNull)
                sqlStr += "int_TbId,";
            if (null != value.vc_FieldName)
                sqlStr += "vc_FieldName,";
            if (null != value.vc_FieldDesc)
                sqlStr += "vc_FieldDesc,";
            if (!value.int_MaxLengthNull)
                sqlStr += "int_MaxLength,";
            if (null != value.vc_SqlDbType)
                sqlStr += "vc_SqlDbType,";
            if (null != value.vc_DataType)
                sqlStr += "vc_DataType,";
            if (!value.int_DataNormalNull)
                sqlStr += "int_DataNormal,";
            if (!value.int_IsPKNull)
                sqlStr += "int_IsPK,";
            if (!value.int_IsSEQNull)
                sqlStr += "int_IsSEQ,";
            if (!value.int_IsRequiredNull)
                sqlStr += "int_IsRequired,";
            if (!value.int_IsViewNull)
                sqlStr += "int_IsView,";
            if (!value.int_IsEditNull)
                sqlStr += "int_IsEdit,";
            if (!value.int_ShowOrderNull)
                sqlStr += "int_ShowOrder,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (!value.int_TbIdNull)
                sqlStr += "@int_TbId,";
            if (null != value.vc_FieldName)
                sqlStr += "@vc_FieldName,";
            if (null != value.vc_FieldDesc)
                sqlStr += "@vc_FieldDesc,";
            if (!value.int_MaxLengthNull)
                sqlStr += "@int_MaxLength,";
            if (null != value.vc_SqlDbType)
                sqlStr += "@vc_SqlDbType,";
            if (null != value.vc_DataType)
                sqlStr += "@vc_DataType,";
            if (!value.int_DataNormalNull)
                sqlStr += "@int_DataNormal,";
            if (!value.int_IsPKNull)
                sqlStr += "@int_IsPK,";
            if (!value.int_IsSEQNull)
                sqlStr += "@int_IsSEQ,";
            if (!value.int_IsRequiredNull)
                sqlStr += "@int_IsRequired,";
            if (!value.int_IsViewNull)
                sqlStr += "@int_IsView,";
            if (!value.int_IsEditNull)
                sqlStr += "@int_IsEdit,";
            if (!value.int_ShowOrderNull)
                sqlStr += "@int_ShowOrder,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_TbIdNull)
                AddParameter(cmd, "int_TbId", (object)value.int_TbId);
            if (null != value.vc_FieldName)
                AddParameter(cmd, "vc_FieldName", value.vc_FieldName);
            if (null != value.vc_FieldDesc)
                AddParameter(cmd, "vc_FieldDesc", value.vc_FieldDesc);
            if (!value.int_MaxLengthNull)
                AddParameter(cmd, "int_MaxLength", (object)value.int_MaxLength);
            if (null != value.vc_SqlDbType)
                AddParameter(cmd, "vc_SqlDbType", value.vc_SqlDbType);
            if (null != value.vc_DataType)
                AddParameter(cmd, "vc_DataType", value.vc_DataType);
            if (!value.int_DataNormalNull)
                AddParameter(cmd, "int_DataNormal", (object)value.int_DataNormal);
            if (!value.int_IsPKNull)
                AddParameter(cmd, "int_IsPK", (object)value.int_IsPK);
            if (!value.int_IsSEQNull)
                AddParameter(cmd, "int_IsSEQ", (object)value.int_IsSEQ);
            if (!value.int_IsRequiredNull)
                AddParameter(cmd, "int_IsRequired", (object)value.int_IsRequired);
            if (!value.int_IsViewNull)
                AddParameter(cmd, "int_IsView", (object)value.int_IsView);
            if (!value.int_IsEditNull)
                AddParameter(cmd, "int_IsEdit", (object)value.int_IsEdit);
            if (!value.int_ShowOrderNull)
                AddParameter(cmd, "int_ShowOrder", (object)value.int_ShowOrder);

            value.int_FiId = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_FieldInfoEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_FieldInfoEntity value)
        {
            string sqlStr = "UPDATE tb_FieldInfo SET ";
            if (!value.int_TbIdNull)
                sqlStr += "int_TbId=@int_TbId,";
            if (null != value.vc_FieldName)
                sqlStr += "vc_FieldName=@vc_FieldName,";
            if (null != value.vc_FieldDesc)
                sqlStr += "vc_FieldDesc=@vc_FieldDesc,";
            if (!value.int_MaxLengthNull)
                sqlStr += "int_MaxLength=@int_MaxLength,";
            if (null != value.vc_SqlDbType)
                sqlStr += "vc_SqlDbType=@vc_SqlDbType,";
            if (null != value.vc_DataType)
                sqlStr += "vc_DataType=@vc_DataType,";
            if (!value.int_DataNormalNull)
                sqlStr += "int_DataNormal=@int_DataNormal,";
            if (!value.int_IsPKNull)
                sqlStr += "int_IsPK=@int_IsPK,";
            if (!value.int_IsSEQNull)
                sqlStr += "int_IsSEQ=@int_IsSEQ,";
            if (!value.int_IsRequiredNull)
                sqlStr += "int_IsRequired=@int_IsRequired,";
            if (!value.int_IsViewNull)
                sqlStr += "int_IsView=@int_IsView,";
            if (!value.int_IsEditNull)
                sqlStr += "int_IsEdit=@int_IsEdit,";
            if (!value.int_ShowOrderNull)
                sqlStr += "int_ShowOrder=@int_ShowOrder,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_FiIdNull)
                sqlStr += "int_FiId= @int_FiId";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_TbIdNull)
                AddParameter(cmd, "int_TbId", (object)value.int_TbId);
            if (null != value.vc_FieldName)
                AddParameter(cmd, "vc_FieldName", value.vc_FieldName);
            if (null != value.vc_FieldDesc)
                AddParameter(cmd, "vc_FieldDesc", value.vc_FieldDesc);
            if (!value.int_MaxLengthNull)
                AddParameter(cmd, "int_MaxLength", (object)value.int_MaxLength);
            if (null != value.vc_SqlDbType)
                AddParameter(cmd, "vc_SqlDbType", value.vc_SqlDbType);
            if (null != value.vc_DataType)
                AddParameter(cmd, "vc_DataType", value.vc_DataType);
            if (!value.int_DataNormalNull)
                AddParameter(cmd, "int_DataNormal", (object)value.int_DataNormal);
            if (!value.int_IsPKNull)
                AddParameter(cmd, "int_IsPK", (object)value.int_IsPK);
            if (!value.int_IsSEQNull)
                AddParameter(cmd, "int_IsSEQ", (object)value.int_IsSEQ);
            if (!value.int_IsRequiredNull)
                AddParameter(cmd, "int_IsRequired", (object)value.int_IsRequired);
            if (!value.int_IsViewNull)
                AddParameter(cmd, "int_IsView", (object)value.int_IsView);
            if (!value.int_IsEditNull)
                AddParameter(cmd, "int_IsEdit", (object)value.int_IsEdit);
            if (!value.int_ShowOrderNull)
                AddParameter(cmd, "int_ShowOrder", (object)value.int_ShowOrder);
            if (!value.int_FiIdNull)
                AddParameter(cmd, "int_FiId", (object)value.int_FiId);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_FieldInfoEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_FieldInfoEntity value)
        {
            return DeleteByPrimaryKey(value.int_FiId);
        }

        public virtual int DeleteByPrimaryKey(int int_FiId)
        {
            string whereSql = "";
            whereSql += "int_FiId=@int_FiId ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_FiId", int_FiId);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_FieldInfoEntity</c> records that match the specified criteria.
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
        /// to delete <c>tb_FieldInfoEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_FieldInfo";
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
        protected tb_FieldInfoEntity[] MapRecords(SqlDataReader reader)
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
        protected virtual tb_FieldInfoEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_FiIdColumnIndex = reader.GetOrdinal("int_FiId");
            int int_TbIdColumnIndex = reader.GetOrdinal("int_TbId");
            int vc_FieldNameColumnIndex = reader.GetOrdinal("vc_FieldName");
            int vc_FieldDescColumnIndex = reader.GetOrdinal("vc_FieldDesc");
            int int_MaxLengthColumnIndex = reader.GetOrdinal("int_MaxLength");
            int vc_SqlDbTypeColumnIndex = reader.GetOrdinal("vc_SqlDbType");
            int vc_DataTypeColumnIndex = reader.GetOrdinal("vc_DataType");
            int int_DataNormalColumnIndex = reader.GetOrdinal("int_DataNormal");
            int int_IsPKColumnIndex = reader.GetOrdinal("int_IsPK");
            int int_IsSEQColumnIndex = reader.GetOrdinal("int_IsSEQ");
            int int_IsRequiredColumnIndex = reader.GetOrdinal("int_IsRequired");
            int int_IsViewColumnIndex = reader.GetOrdinal("int_IsView");
            int int_IsEditColumnIndex = reader.GetOrdinal("int_IsEdit");
            int int_ShowOrderColumnIndex = reader.GetOrdinal("int_ShowOrder");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_FieldInfoEntity record = new tb_FieldInfoEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_FiIdColumnIndex))
                        record.int_FiId = Convert.ToInt32(reader.GetValue(int_FiIdColumnIndex));
                    if (!reader.IsDBNull(int_TbIdColumnIndex))
                        record.int_TbId = Convert.ToInt32(reader.GetValue(int_TbIdColumnIndex));
                    if (!reader.IsDBNull(vc_FieldNameColumnIndex))
                        record.vc_FieldName = Convert.ToString(reader.GetValue(vc_FieldNameColumnIndex));
                    if (!reader.IsDBNull(vc_FieldDescColumnIndex))
                        record.vc_FieldDesc = Convert.ToString(reader.GetValue(vc_FieldDescColumnIndex));
                    if (!reader.IsDBNull(int_MaxLengthColumnIndex))
                        record.int_MaxLength = Convert.ToInt32(reader.GetValue(int_MaxLengthColumnIndex));
                    if (!reader.IsDBNull(vc_SqlDbTypeColumnIndex))
                        record.vc_SqlDbType = Convert.ToString(reader.GetValue(vc_SqlDbTypeColumnIndex));
                    if (!reader.IsDBNull(vc_DataTypeColumnIndex))
                        record.vc_DataType = Convert.ToString(reader.GetValue(vc_DataTypeColumnIndex));
                    if (!reader.IsDBNull(int_DataNormalColumnIndex))
                        record.int_DataNormal = Convert.ToInt32(reader.GetValue(int_DataNormalColumnIndex));
                    if (!reader.IsDBNull(int_IsPKColumnIndex))
                        record.int_IsPK = Convert.ToInt32(reader.GetValue(int_IsPKColumnIndex));
                    if (!reader.IsDBNull(int_IsSEQColumnIndex))
                        record.int_IsSEQ = Convert.ToInt32(reader.GetValue(int_IsSEQColumnIndex));
                    if (!reader.IsDBNull(int_IsRequiredColumnIndex))
                        record.int_IsRequired = Convert.ToInt32(reader.GetValue(int_IsRequiredColumnIndex));
                    if (!reader.IsDBNull(int_IsViewColumnIndex))
                        record.int_IsView = Convert.ToInt32(reader.GetValue(int_IsViewColumnIndex));
                    if (!reader.IsDBNull(int_IsEditColumnIndex))
                        record.int_IsEdit = Convert.ToInt32(reader.GetValue(int_IsEditColumnIndex));
                    if (!reader.IsDBNull(int_ShowOrderColumnIndex))
                        record.int_ShowOrder = Convert.ToInt32(reader.GetValue(int_ShowOrderColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_FieldInfoEntity[])(recordList.ToArray(typeof(tb_FieldInfoEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_FieldInfoEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_FieldInfoEntity"/> object.</returns>
        protected virtual tb_FieldInfoEntity MapRow(DataRow row)
        {
            tb_FieldInfoEntity mappedObject = new tb_FieldInfoEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_FiId
            dataColumn = dataTable.Columns["int_FiId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_FiId = (int)row[dataColumn];
            // Column int_TbId
            dataColumn = dataTable.Columns["int_TbId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_TbId = (int)row[dataColumn];
            // Column vc_FieldName
            dataColumn = dataTable.Columns["vc_FieldName"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_FieldName = (string)row[dataColumn];
            // Column vc_FieldDesc
            dataColumn = dataTable.Columns["vc_FieldDesc"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_FieldDesc = (string)row[dataColumn];
            // Column int_MaxLength
            dataColumn = dataTable.Columns["int_MaxLength"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_MaxLength = (int)row[dataColumn];
            // Column vc_SqlDbType
            dataColumn = dataTable.Columns["vc_SqlDbType"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_SqlDbType = (string)row[dataColumn];
            // Column vc_DataType
            dataColumn = dataTable.Columns["vc_DataType"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_DataType = (string)row[dataColumn];
            // Column int_DataNormal
            dataColumn = dataTable.Columns["int_DataNormal"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_DataNormal = (int)row[dataColumn];
            // Column int_IsPK
            dataColumn = dataTable.Columns["int_IsPK"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_IsPK = (int)row[dataColumn];
            // Column int_IsSEQ
            dataColumn = dataTable.Columns["int_IsSEQ"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_IsSEQ = (int)row[dataColumn];
            // Column int_IsRequired
            dataColumn = dataTable.Columns["int_IsRequired"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_IsRequired = (int)row[dataColumn];
            // Column int_IsView
            dataColumn = dataTable.Columns["int_IsView"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_IsView = (int)row[dataColumn];
            // Column int_IsEdit
            dataColumn = dataTable.Columns["int_IsEdit"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_IsEdit = (int)row[dataColumn];
            // Column int_ShowOrder
            dataColumn = dataTable.Columns["int_ShowOrder"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_ShowOrder = (int)row[dataColumn];


            return mappedObject;
        }

        /// <summary>
        /// Creates a <see cref="System.Data.DataTable"/> object for 
        /// the <c>tb_FieldInfoEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_FieldInfoEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_FiId", typeof(int));
            dataColumn = dataTable.Columns.Add("int_TbId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_FieldName", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_FieldDesc", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("int_MaxLength", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_SqlDbType", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_DataType", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("int_DataNormal", typeof(int));
            dataColumn = dataTable.Columns.Add("int_IsPK", typeof(int));
            dataColumn = dataTable.Columns.Add("int_IsSEQ", typeof(int));
            dataColumn = dataTable.Columns.Add("int_IsRequired", typeof(int));
            dataColumn = dataTable.Columns.Add("int_IsView", typeof(int));
            dataColumn = dataTable.Columns.Add("int_IsEdit", typeof(int));
            dataColumn = dataTable.Columns.Add("int_ShowOrder", typeof(int));


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
                case "int_FiId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_TbId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_FieldName":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_FieldDesc":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "int_MaxLength":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_SqlDbType":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_DataType":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "int_DataNormal":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_IsPK":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_IsSEQ":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_IsRequired":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_IsView":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_IsEdit":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_ShowOrder":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;


                default:
                    throw new ArgumentException("Unknown parameter name (" + paramName + ").");
            }
            return parameter;
        }
    } // End of  tb_FieldInfoEntity_BaseOp class
}  // End of namespace

