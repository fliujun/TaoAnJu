using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_PicInfoEntity_Op
    {
        private DsConnectionDB _db;

        public tb_PicInfoEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_PicInfoEntity[] GetAll()
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

        public tb_PicInfoEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_PicInfoEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_PicInfo";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_PicInfoEntity GetByPrimaryKey(int int_PId)
        {
            string whereSql = "";
            whereSql += "int_PId=@int_PId ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_PId", int_PId);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_PicInfoEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_PicInfoEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_PicInfoEntity value)
        {
            string sqlStr = "INSERT INTO tb_PicInfo(";
            if (!value.int_ItemIdNull)
                sqlStr += "int_ItemId,";
            if (null != value.vc_PicFile)
                sqlStr += "vc_PicFile,";
            if (null != value.vc_PicDesc)
                sqlStr += "vc_PicDesc,";
            if (null != value.vc_PicType)
                sqlStr += "vc_PicType,";
            if (null != value.vc_Pic1)
                sqlStr += "vc_Pic1,";
            if (null != value.vc_Pic2)
                sqlStr += "vc_Pic2,";
            if (null != value.vc_Pic3)
                sqlStr += "vc_Pic3,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate,";
            if (!value.int_IsViewNull)
                sqlStr += "int_IsView,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (!value.int_ItemIdNull)
                sqlStr += "@int_ItemId,";
            if (null != value.vc_PicFile)
                sqlStr += "@vc_PicFile,";
            if (null != value.vc_PicDesc)
                sqlStr += "@vc_PicDesc,";
            if (null != value.vc_PicType)
                sqlStr += "@vc_PicType,";
            if (null != value.vc_Pic1)
                sqlStr += "@vc_Pic1,";
            if (null != value.vc_Pic2)
                sqlStr += "@vc_Pic2,";
            if (null != value.vc_Pic3)
                sqlStr += "@vc_Pic3,";
            if (!value.dt_CreateDateNull)
                sqlStr += "@dt_CreateDate,";
            if (!value.int_IsViewNull)
                sqlStr += "@int_IsView,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_ItemIdNull)
                AddParameter(cmd, "int_ItemId", (object)value.int_ItemId);
            if (null != value.vc_PicFile)
                AddParameter(cmd, "vc_PicFile", value.vc_PicFile);
            if (null != value.vc_PicDesc)
                AddParameter(cmd, "vc_PicDesc", value.vc_PicDesc);
            if (null != value.vc_PicType)
                AddParameter(cmd, "vc_PicType", value.vc_PicType);
            if (null != value.vc_Pic1)
                AddParameter(cmd, "vc_Pic1", value.vc_Pic1);
            if (null != value.vc_Pic2)
                AddParameter(cmd, "vc_Pic2", value.vc_Pic2);
            if (null != value.vc_Pic3)
                AddParameter(cmd, "vc_Pic3", value.vc_Pic3);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_IsViewNull)
                AddParameter(cmd, "int_IsView", (object)value.int_IsView);

            value.int_PId = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_PicInfoEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_PicInfoEntity value)
        {
            string sqlStr = "UPDATE tb_PicInfo SET ";
            if (!value.int_ItemIdNull)
                sqlStr += "int_ItemId=@int_ItemId,";
            if (null != value.vc_PicFile)
                sqlStr += "vc_PicFile=@vc_PicFile,";
            if (null != value.vc_PicDesc)
                sqlStr += "vc_PicDesc=@vc_PicDesc,";
            if (null != value.vc_PicType)
                sqlStr += "vc_PicType=@vc_PicType,";
            if (null != value.vc_Pic1)
                sqlStr += "vc_Pic1=@vc_Pic1,";
            if (null != value.vc_Pic2)
                sqlStr += "vc_Pic2=@vc_Pic2,";
            if (null != value.vc_Pic3)
                sqlStr += "vc_Pic3=@vc_Pic3,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate=@dt_CreateDate,";
            if (!value.int_IsViewNull)
                sqlStr += "int_IsView=@int_IsView,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_PIdNull)
                sqlStr += "int_PId= @int_PId";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (!value.int_ItemIdNull)
                AddParameter(cmd, "int_ItemId", (object)value.int_ItemId);
            if (null != value.vc_PicFile)
                AddParameter(cmd, "vc_PicFile", value.vc_PicFile);
            if (null != value.vc_PicDesc)
                AddParameter(cmd, "vc_PicDesc", value.vc_PicDesc);
            if (null != value.vc_PicType)
                AddParameter(cmd, "vc_PicType", value.vc_PicType);
            if (null != value.vc_Pic1)
                AddParameter(cmd, "vc_Pic1", value.vc_Pic1);
            if (null != value.vc_Pic2)
                AddParameter(cmd, "vc_Pic2", value.vc_Pic2);
            if (null != value.vc_Pic3)
                AddParameter(cmd, "vc_Pic3", value.vc_Pic3);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (!value.int_IsViewNull)
                AddParameter(cmd, "int_IsView", (object)value.int_IsView);
            if (!value.int_PIdNull)
                AddParameter(cmd, "int_PId", (object)value.int_PId);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_PicInfoEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_PicInfoEntity value)
        {
            return DeleteByPrimaryKey(value.int_PId);
        }

        public virtual int DeleteByPrimaryKey(int int_PId)
        {
            string whereSql = "";
            whereSql += "int_PId=@int_PId ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_PId", int_PId);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_PicInfoEntity</c> records that match the specified criteria.
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
        /// to delete <c>tb_PicInfoEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_PicInfo";
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
        protected tb_PicInfoEntity[] MapRecords(SqlDataReader reader)
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
        protected virtual tb_PicInfoEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_PIdColumnIndex = reader.GetOrdinal("int_PId");
            int int_ItemIdColumnIndex = reader.GetOrdinal("int_ItemId");
            int vc_PicFileColumnIndex = reader.GetOrdinal("vc_PicFile");
            int vc_PicDescColumnIndex = reader.GetOrdinal("vc_PicDesc");
            int vc_PicTypeColumnIndex = reader.GetOrdinal("vc_PicType");
            int vc_Pic1ColumnIndex = reader.GetOrdinal("vc_Pic1");
            int vc_Pic2ColumnIndex = reader.GetOrdinal("vc_Pic2");
            int vc_Pic3ColumnIndex = reader.GetOrdinal("vc_Pic3");
            int dt_CreateDateColumnIndex = reader.GetOrdinal("dt_CreateDate");
            int int_IsViewColumnIndex = reader.GetOrdinal("int_IsView");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_PicInfoEntity record = new tb_PicInfoEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_PIdColumnIndex))
                        record.int_PId = Convert.ToInt32(reader.GetValue(int_PIdColumnIndex));
                    if (!reader.IsDBNull(int_ItemIdColumnIndex))
                        record.int_ItemId = Convert.ToInt32(reader.GetValue(int_ItemIdColumnIndex));
                    if (!reader.IsDBNull(vc_PicFileColumnIndex))
                        record.vc_PicFile = Convert.ToString(reader.GetValue(vc_PicFileColumnIndex));
                    if (!reader.IsDBNull(vc_PicDescColumnIndex))
                        record.vc_PicDesc = Convert.ToString(reader.GetValue(vc_PicDescColumnIndex));
                    if (!reader.IsDBNull(vc_PicTypeColumnIndex))
                        record.vc_PicType = Convert.ToString(reader.GetValue(vc_PicTypeColumnIndex));
                    if (!reader.IsDBNull(vc_Pic1ColumnIndex))
                        record.vc_Pic1 = Convert.ToString(reader.GetValue(vc_Pic1ColumnIndex));
                    if (!reader.IsDBNull(vc_Pic2ColumnIndex))
                        record.vc_Pic2 = Convert.ToString(reader.GetValue(vc_Pic2ColumnIndex));
                    if (!reader.IsDBNull(vc_Pic3ColumnIndex))
                        record.vc_Pic3 = Convert.ToString(reader.GetValue(vc_Pic3ColumnIndex));
                    if (!reader.IsDBNull(dt_CreateDateColumnIndex))
                        record.dt_CreateDate = Convert.ToDateTime(reader.GetValue(dt_CreateDateColumnIndex));
                    if (!reader.IsDBNull(int_IsViewColumnIndex))
                        record.int_IsView = Convert.ToInt32(reader.GetValue(int_IsViewColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_PicInfoEntity[])(recordList.ToArray(typeof(tb_PicInfoEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_PicInfoEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_PicInfoEntity"/> object.</returns>
        protected virtual tb_PicInfoEntity MapRow(DataRow row)
        {
            tb_PicInfoEntity mappedObject = new tb_PicInfoEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_PId
            dataColumn = dataTable.Columns["int_PId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_PId = (int)row[dataColumn];
            // Column int_ItemId
            dataColumn = dataTable.Columns["int_ItemId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_ItemId = (int)row[dataColumn];
            // Column vc_PicFile
            dataColumn = dataTable.Columns["vc_PicFile"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_PicFile = (string)row[dataColumn];
            // Column vc_PicDesc
            dataColumn = dataTable.Columns["vc_PicDesc"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_PicDesc = (string)row[dataColumn];
            // Column vc_PicType
            dataColumn = dataTable.Columns["vc_PicType"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_PicType = (string)row[dataColumn];
            // Column vc_Pic1
            dataColumn = dataTable.Columns["vc_Pic1"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Pic1 = (string)row[dataColumn];
            // Column vc_Pic2
            dataColumn = dataTable.Columns["vc_Pic2"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Pic2 = (string)row[dataColumn];
            // Column vc_Pic3
            dataColumn = dataTable.Columns["vc_Pic3"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Pic3 = (string)row[dataColumn];
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
        /// the <c>tb_PicInfoEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_PicInfoEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_PId", typeof(int));
            dataColumn = dataTable.Columns.Add("int_ItemId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_PicFile", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_PicDesc", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_PicType", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("vc_Pic1", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_Pic2", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_Pic3", typeof(string));
            dataColumn.MaxLength = 50;
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
                case "int_PId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "int_ItemId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_PicFile":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_PicDesc":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_PicType":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Pic1":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Pic2":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Pic3":
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
    } // End of  tb_PicInfoEntity_BaseOp class
}  // End of namespace

