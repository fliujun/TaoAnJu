using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_ViewInfoEntity_Op
    {
        private DsConnectionDB _db;

        public tb_ViewInfoEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_ViewInfoEntity[] GetAll()
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

        public tb_ViewInfoEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_ViewInfoEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_ViewInfo";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_ViewInfoEntity GetByPrimaryKey(int int_VId)
        {
            string whereSql = "";
            whereSql += "int_VId=@int_VId ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_VId", int_VId);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_ViewInfoEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_ViewInfoEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_ViewInfoEntity value)
        {
            string sqlStr = "INSERT INTO tb_ViewInfo(";
            if (!value.int_ItemIdNull)
                sqlStr += "int_ItemId,";
            if (null != value.vc_ViewFile)
                sqlStr += "vc_ViewFile,";
            if (null != value.vc_ViewDesc)
                sqlStr += "vc_ViewDesc,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate,";
            if (!value.int_IsViewNull)
                sqlStr += "int_IsView,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (!value.int_ItemIdNull)
                sqlStr += "@int_ItemId,";
            if (null != value.vc_ViewFile)
                sqlStr += "@vc_ViewFile,";
            if (null != value.vc_ViewDesc)
                sqlStr += "@vc_ViewDesc,";
            if (!value.dt_CreateDateNull)
                sqlStr += "@dt_CreateDate,";
            if (!value.int_IsViewNull)
                sqlStr += "@int_IsView,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_ItemIdNull)
                AddParameter(cmd, "int_ItemId", (object)value.int_ItemId);
            if (null != value.vc_ViewFile)
                AddParameter(cmd, "vc_ViewFile", value.vc_ViewFile);
            if (null != value.vc_ViewDesc)
                AddParameter(cmd, "vc_ViewDesc", value.vc_ViewDesc);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_IsViewNull)
                AddParameter(cmd, "int_IsView", (object)value.int_IsView);

            value.int_VId = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_ViewInfoEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_ViewInfoEntity value)
        {
            string sqlStr = "UPDATE tb_ViewInfo SET ";
            if (!value.int_ItemIdNull)
                sqlStr += "int_ItemId=@int_ItemId,";
            if (null != value.vc_ViewFile)
                sqlStr += "vc_ViewFile=@vc_ViewFile,";
            if (null != value.vc_ViewDesc)
                sqlStr += "vc_ViewDesc=@vc_ViewDesc,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate=@dt_CreateDate,";
            if (!value.int_IsViewNull)
                sqlStr += "int_IsView=@int_IsView,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_VIdNull)
                sqlStr += "int_VId= @int_VId";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_ItemIdNull)
                AddParameter(cmd, "int_ItemId", (object)value.int_ItemId);
            if (null != value.vc_ViewFile)
                AddParameter(cmd, "vc_ViewFile", value.vc_ViewFile);
            if (null != value.vc_ViewDesc)
                AddParameter(cmd, "vc_ViewDesc", value.vc_ViewDesc);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_IsViewNull)
                AddParameter(cmd, "int_IsView", (object)value.int_IsView);
            if (!value.int_VIdNull)
                AddParameter(cmd, "int_VId", (object)value.int_VId);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_ViewInfoEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_ViewInfoEntity value)
        {
            return DeleteByPrimaryKey(value.int_VId);
        }

        public virtual int DeleteByPrimaryKey(int int_VId)
        {
            string whereSql = "";
            whereSql += "int_VId=@int_VId ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_VId", int_VId);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_ViewInfoEntity</c> records that match the specified criteria.
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
        /// to delete <c>tb_ViewInfoEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_ViewInfo";
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
        protected tb_ViewInfoEntity[] MapRecords(SqlDataReader reader)
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
        protected virtual tb_ViewInfoEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_VIdColumnIndex = reader.GetOrdinal("int_VId");
            int int_ItemIdColumnIndex = reader.GetOrdinal("int_ItemId");
            int vc_ViewFileColumnIndex = reader.GetOrdinal("vc_ViewFile");
            int vc_ViewDescColumnIndex = reader.GetOrdinal("vc_ViewDesc");
            int dt_CreateDateColumnIndex = reader.GetOrdinal("dt_CreateDate");
            int int_IsViewColumnIndex = reader.GetOrdinal("int_IsView");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_ViewInfoEntity record = new tb_ViewInfoEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_VIdColumnIndex))
                        record.int_VId = Convert.ToInt32(reader.GetValue(int_VIdColumnIndex));
                    if (!reader.IsDBNull(int_ItemIdColumnIndex))
                        record.int_ItemId = Convert.ToInt32(reader.GetValue(int_ItemIdColumnIndex));
                    if (!reader.IsDBNull(vc_ViewFileColumnIndex))
                        record.vc_ViewFile = Convert.ToString(reader.GetValue(vc_ViewFileColumnIndex));
                    if (!reader.IsDBNull(vc_ViewDescColumnIndex))
                        record.vc_ViewDesc = Convert.ToString(reader.GetValue(vc_ViewDescColumnIndex));
                    if (!reader.IsDBNull(dt_CreateDateColumnIndex))
                        record.dt_CreateDate = Convert.ToDateTime(reader.GetValue(dt_CreateDateColumnIndex));
                    if (!reader.IsDBNull(int_IsViewColumnIndex))
                        record.int_IsView = Convert.ToInt32(reader.GetValue(int_IsViewColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_ViewInfoEntity[])(recordList.ToArray(typeof(tb_ViewInfoEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_ViewInfoEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_ViewInfoEntity"/> object.</returns>
        protected virtual tb_ViewInfoEntity MapRow(DataRow row)
        {
            tb_ViewInfoEntity mappedObject = new tb_ViewInfoEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_VId
            dataColumn = dataTable.Columns["int_VId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_VId = (int)row[dataColumn];
            // Column int_ItemId
            dataColumn = dataTable.Columns["int_ItemId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_ItemId = (int)row[dataColumn];
            // Column vc_ViewFile
            dataColumn = dataTable.Columns["vc_ViewFile"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_ViewFile = (string)row[dataColumn];
            // Column vc_ViewDesc
            dataColumn = dataTable.Columns["vc_ViewDesc"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_ViewDesc = (string)row[dataColumn];
            // Column dt_CreateDate
            dataColumn = dataTable.Columns["dt_CreateDate"];
            if (!row.IsNull(dataColumn))
                mappedObject.dt_CreateDate = (DateTime)row[dataColumn];
            // Column int_IsView
            dataColumn = dataTable.Columns["int_IsView"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_IsView = (int)row[dataColumn];


            return mappedObject;
        }

        /// <summary>
        /// Creates a <see cref="System.Data.DataTable"/> object for 
        /// the <c>tb_ViewInfoEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_ViewInfoEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_VId", typeof(int));
            dataColumn = dataTable.Columns.Add("int_ItemId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_ViewFile", typeof(string));
            dataColumn.MaxLength = 200;
            dataColumn = dataTable.Columns.Add("vc_ViewDesc", typeof(string));
            dataColumn.MaxLength = 200;
            dataColumn = dataTable.Columns.Add("dt_CreateDate", typeof(DateTime));
            dataColumn = dataTable.Columns.Add("int_IsView", typeof(int));


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
                case "int_VId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_ItemId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_ViewFile":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_ViewDesc":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "dt_CreateDate":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.DateTime, value);
                    break;
                case "int_IsView":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;


                default:
                    throw new ArgumentException("Unknown parameter name (" + paramName + ").");
            }
            return parameter;
        }
    } // End of  tb_ViewInfoEntity_BaseOp class
}  // End of namespace

