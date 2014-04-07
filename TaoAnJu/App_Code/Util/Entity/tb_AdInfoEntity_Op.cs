using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_AdInfoEntity_Op
    {
        private DsConnectionDB _db;

        public tb_AdInfoEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_AdInfoEntity[] GetAll()
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

        public tb_AdInfoEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_AdInfoEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_AdInfo";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_AdInfoEntity GetByPrimaryKey(int int_AId)
        {
            string whereSql = "";
            whereSql += "int_AId=@int_AId ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_AId", int_AId);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_AdInfoEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_AdInfoEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_AdInfoEntity value)
        {
            string sqlStr = "INSERT INTO tb_AdInfo(";
            if (null != value.vc_Guid)
                sqlStr += "vc_Guid,";
            if (null != value.vc_AdTitle)
                sqlStr += "vc_AdTitle,";
            if (null != value.vc_AdDesc)
                sqlStr += "vc_AdDesc,";
            if (null != value.vc_AdPicFile)
                sqlStr += "vc_AdPicFile,";
            if (null != value.vc_AdLink)
                sqlStr += "vc_AdLink,";
            if (null != value.vc_AdType)
                sqlStr += "vc_AdType,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate,";
            if (!value.int_OrderNull)
                sqlStr += "int_Order,";
            if (!value.int_StatusNull)
                sqlStr += "int_Status,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (null != value.vc_Guid)
                sqlStr += "@vc_Guid,";
            if (null != value.vc_AdTitle)
                sqlStr += "@vc_AdTitle,";
            if (null != value.vc_AdDesc)
                sqlStr += "@vc_AdDesc,";
            if (null != value.vc_AdPicFile)
                sqlStr += "@vc_AdPicFile,";
            if (null != value.vc_AdLink)
                sqlStr += "@vc_AdLink,";
            if (null != value.vc_AdType)
                sqlStr += "@vc_AdType,";
            if (!value.dt_CreateDateNull)
                sqlStr += "@dt_CreateDate,";
            if (!value.int_OrderNull)
                sqlStr += "@int_Order,";
            if (!value.int_StatusNull)
                sqlStr += "@int_Status,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_Guid)
                AddParameter(cmd, "vc_Guid", value.vc_Guid);
            if (null != value.vc_AdTitle)
                AddParameter(cmd, "vc_AdTitle", value.vc_AdTitle);
            if (null != value.vc_AdDesc)
                AddParameter(cmd, "vc_AdDesc", value.vc_AdDesc);
            if (null != value.vc_AdPicFile)
                AddParameter(cmd, "vc_AdPicFile", value.vc_AdPicFile);
            if (null != value.vc_AdLink)
                AddParameter(cmd, "vc_AdLink", value.vc_AdLink);
            if (null != value.vc_AdType)
                AddParameter(cmd, "vc_AdType", value.vc_AdType);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_OrderNull)
                AddParameter(cmd, "int_Order", (object)value.int_Order);
            if (!value.int_StatusNull)
                AddParameter(cmd, "int_Status", (object)value.int_Status);

            value.int_AId = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_AdInfoEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_AdInfoEntity value)
        {
            string sqlStr = "UPDATE tb_AdInfo SET ";
            if (null != value.vc_Guid)
                sqlStr += "vc_Guid=@vc_Guid,";
            if (null != value.vc_AdTitle)
                sqlStr += "vc_AdTitle=@vc_AdTitle,";
            if (null != value.vc_AdDesc)
                sqlStr += "vc_AdDesc=@vc_AdDesc,";
            if (null != value.vc_AdPicFile)
                sqlStr += "vc_AdPicFile=@vc_AdPicFile,";
            if (null != value.vc_AdLink)
                sqlStr += "vc_AdLink=@vc_AdLink,";
            if (null != value.vc_AdType)
                sqlStr += "vc_AdType=@vc_AdType,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate=@dt_CreateDate,";
            if (!value.int_OrderNull)
                sqlStr += "int_Order=@int_Order,";
            if (!value.int_StatusNull)
                sqlStr += "int_Status=@int_Status,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_AIdNull)
                sqlStr += "int_AId= @int_AId";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_Guid)
                AddParameter(cmd, "vc_Guid", value.vc_Guid);
            if (null != value.vc_AdTitle)
                AddParameter(cmd, "vc_AdTitle", value.vc_AdTitle);
            if (null != value.vc_AdDesc)
                AddParameter(cmd, "vc_AdDesc", value.vc_AdDesc);
            if (null != value.vc_AdPicFile)
                AddParameter(cmd, "vc_AdPicFile", value.vc_AdPicFile);
            if (null != value.vc_AdLink)
                AddParameter(cmd, "vc_AdLink", value.vc_AdLink);
            if (null != value.vc_AdType)
                AddParameter(cmd, "vc_AdType", value.vc_AdType);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_OrderNull)
                AddParameter(cmd, "int_Order", (object)value.int_Order);
            if (!value.int_StatusNull)
                AddParameter(cmd, "int_Status", (object)value.int_Status);
            if (!value.int_AIdNull)
                AddParameter(cmd, "int_AId", (object)value.int_AId);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_AdInfoEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_AdInfoEntity value)
        {
            return DeleteByPrimaryKey(value.int_AId);
        }

        public virtual int DeleteByPrimaryKey(int int_AId)
        {
            string whereSql = "";
            whereSql += "int_AId=@int_AId ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_AId", int_AId);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_AdInfoEntity</c> records that match the specified criteria.
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
        /// to delete <c>tb_AdInfoEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_AdInfo";
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
        protected tb_AdInfoEntity[] MapRecords(SqlDataReader reader)
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
        protected virtual tb_AdInfoEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_AIdColumnIndex = reader.GetOrdinal("int_AId");
            int vc_GuidColumnIndex = reader.GetOrdinal("vc_Guid");
            int vc_AdTitleColumnIndex = reader.GetOrdinal("vc_AdTitle");
            int vc_AdDescColumnIndex = reader.GetOrdinal("vc_AdDesc");
            int vc_AdPicFileColumnIndex = reader.GetOrdinal("vc_AdPicFile");
            int vc_AdLinkColumnIndex = reader.GetOrdinal("vc_AdLink");
            int vc_AdTypeColumnIndex = reader.GetOrdinal("vc_AdType");
            int dt_CreateDateColumnIndex = reader.GetOrdinal("dt_CreateDate");
            int int_OrderColumnIndex = reader.GetOrdinal("int_Order");
            int int_StatusColumnIndex = reader.GetOrdinal("int_Status");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_AdInfoEntity record = new tb_AdInfoEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_AIdColumnIndex))
                        record.int_AId = Convert.ToInt32(reader.GetValue(int_AIdColumnIndex));
                    if (!reader.IsDBNull(vc_GuidColumnIndex))
                        record.vc_Guid = Convert.ToString(reader.GetValue(vc_GuidColumnIndex));
                    if (!reader.IsDBNull(vc_AdTitleColumnIndex))
                        record.vc_AdTitle = Convert.ToString(reader.GetValue(vc_AdTitleColumnIndex));
                    if (!reader.IsDBNull(vc_AdDescColumnIndex))
                        record.vc_AdDesc = Convert.ToString(reader.GetValue(vc_AdDescColumnIndex));
                    if (!reader.IsDBNull(vc_AdPicFileColumnIndex))
                        record.vc_AdPicFile = Convert.ToString(reader.GetValue(vc_AdPicFileColumnIndex));
                    if (!reader.IsDBNull(vc_AdLinkColumnIndex))
                        record.vc_AdLink = Convert.ToString(reader.GetValue(vc_AdLinkColumnIndex));
                    if (!reader.IsDBNull(vc_AdTypeColumnIndex))
                        record.vc_AdType = Convert.ToString(reader.GetValue(vc_AdTypeColumnIndex));
                    if (!reader.IsDBNull(dt_CreateDateColumnIndex))
                        record.dt_CreateDate = Convert.ToDateTime(reader.GetValue(dt_CreateDateColumnIndex));
                    if (!reader.IsDBNull(int_OrderColumnIndex))
                        record.int_Order = Convert.ToInt32(reader.GetValue(int_OrderColumnIndex));
                    if (!reader.IsDBNull(int_StatusColumnIndex))
                        record.int_Status = Convert.ToInt32(reader.GetValue(int_StatusColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_AdInfoEntity[])(recordList.ToArray(typeof(tb_AdInfoEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_AdInfoEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_AdInfoEntity"/> object.</returns>
        protected virtual tb_AdInfoEntity MapRow(DataRow row)
        {
            tb_AdInfoEntity mappedObject = new tb_AdInfoEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_AId
            dataColumn = dataTable.Columns["int_AId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_AId = (int)row[dataColumn];
            // Column vc_Guid
            dataColumn = dataTable.Columns["vc_Guid"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Guid = (string)row[dataColumn];
            // Column vc_AdTitle
            dataColumn = dataTable.Columns["vc_AdTitle"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_AdTitle = (string)row[dataColumn];
            // Column vc_AdDesc
            dataColumn = dataTable.Columns["vc_AdDesc"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_AdDesc = (string)row[dataColumn];
            // Column vc_AdPicFile
            dataColumn = dataTable.Columns["vc_AdPicFile"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_AdPicFile = (string)row[dataColumn];
            // Column vc_AdLink
            dataColumn = dataTable.Columns["vc_AdLink"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_AdLink = (string)row[dataColumn];
            // Column vc_AdType
            dataColumn = dataTable.Columns["vc_AdType"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_AdType = (string)row[dataColumn];
            // Column dt_CreateDate
            dataColumn = dataTable.Columns["dt_CreateDate"];
            if (!row.IsNull(dataColumn))
                mappedObject.dt_CreateDate = (DateTime)row[dataColumn];
            // Column int_Order
            dataColumn = dataTable.Columns["int_Order"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_Order = (int)row[dataColumn];
            // Column int_Status
            dataColumn = dataTable.Columns["int_Status"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_Status = (int)row[dataColumn];


            return mappedObject;
        }

        /// <summary>
        /// Creates a <see cref="System.Data.DataTable"/> object for 
        /// the <c>tb_AdInfoEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_AdInfoEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_AId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_Guid", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_AdTitle", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_AdDesc", typeof(string));
            dataColumn.MaxLength = 100;
            dataColumn = dataTable.Columns.Add("vc_AdPicFile", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_AdLink", typeof(string));
            dataColumn.MaxLength = 500;
            dataColumn = dataTable.Columns.Add("vc_AdType", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("dt_CreateDate", typeof(DateTime));
            dataColumn = dataTable.Columns.Add("int_Order", typeof(int));
            dataColumn = dataTable.Columns.Add("int_Status", typeof(int));


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
                case "int_AId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_Guid":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_AdTitle":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_AdDesc":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_AdPicFile":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_AdLink":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_AdType":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "dt_CreateDate":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.DateTime, value);
                    break;
                case "int_Order":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_Status":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;


                default:
                    throw new ArgumentException("Unknown parameter name (" + paramName + ").");
            }
            return parameter;
        }
    } // End of  tb_AdInfoEntity_BaseOp class
}  // End of namespace

