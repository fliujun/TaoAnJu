using System;
using System.Data;
using System.Data.SqlClient;
using TaoAnJu.Util;

namespace TaoAnJu.Util
{

    public class tb_CustomerEntity_Op
    {
        private DsConnectionDB _db;

        public tb_CustomerEntity_Op(DsConnectionDB db)
        {
            _db = db;
        }

        protected DsConnectionDB Database
        {
            get { return _db; }
        }

        public virtual tb_CustomerEntity[] GetAll()
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

        public tb_CustomerEntity[] GetAsArray(string whereSql, string orderBySql)
        {
            int totalRecordCount = -1;
            return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
        }

        public virtual tb_CustomerEntity[] GetAsArray(string whereSql, string orderBySql,
            int startIndex, int length, ref int totalRecordCount)
        {
            using (SqlDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
            {
                return MapRecords(reader, startIndex, length, ref totalRecordCount);
            }
        }

        protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
        {
            string sql = "SELECT * FROM tb_Customer";
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            return _db.CreateCommand(sql);
        }

        public virtual tb_CustomerEntity GetByPrimaryKey(int int_CId)
        {
            string whereSql = "";
            whereSql += "int_CId=@int_CId ";

            SqlCommand cmd = CreateGetCommand(whereSql, null);
            AddParameter(cmd, "int_CId", int_CId);

            using (SqlDataReader reader = _db.ExecuteReader(cmd))
            {
                tb_CustomerEntity[] tempArray = MapRecords(reader);
                return 0 == tempArray.Length ? null : tempArray[0];
            }
        }

        /// <summary>
        /// Adds a new record into the <c>WL_YEAR_WORK_MD</c> table.
        /// </summary>
        /// <param name="value">The <see cref="tb_CustomerEntity"/> object to be inserted.</param>
        public virtual void Insert(tb_CustomerEntity value)
        {
            string sqlStr = "INSERT INTO tb_Customer(";
            if (null != value.vc_Name)
                sqlStr += "vc_Name,";
            if (null != value.vc_Mobile)
                sqlStr += "vc_Mobile,";
            if (!value.int_AgeNull)
                sqlStr += "int_Age,";
            if (null != value.vc_Occupation)
                sqlStr += "vc_Occupation,";
            if (null != value.vc_WorkingPlace)
                sqlStr += "vc_WorkingPlace,";
            if (null != value.vc_LivePlace)
                sqlStr += "vc_LivePlace,";
            if (null != value.vc_Use)
                sqlStr += "vc_Use,";
            if (!value.dec_PriceNull)
                sqlStr += "dec_Price,";
            if (!value.dec_TotalPriceNull)
                sqlStr += "dec_TotalPrice,";
            if (null != value.vc_Referee)
                sqlStr += "vc_Referee,";
            if (!value.int_UserIdNull)
                sqlStr += "int_UserId,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate,";
            if (null != value.vc_Static)
                sqlStr += "vc_Static,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ")  VALUES (";
            if (null != value.vc_Name)
                sqlStr += "@vc_Name,";
            if (null != value.vc_Mobile)
                sqlStr += "@vc_Mobile,";
            if (!value.int_AgeNull)
                sqlStr += "@int_Age,";
            if (null != value.vc_Occupation)
                sqlStr += "@vc_Occupation,";
            if (null != value.vc_WorkingPlace)
                sqlStr += "@vc_WorkingPlace,";
            if (null != value.vc_LivePlace)
                sqlStr += "@vc_LivePlace,";
            if (null != value.vc_Use)
                sqlStr += "@vc_Use,";
            if (!value.dec_PriceNull)
                sqlStr += "@dec_Price,";
            if (!value.dec_TotalPriceNull)
                sqlStr += "@dec_TotalPrice,";
            if (null != value.vc_Referee)
                sqlStr += "@vc_Referee,";
            if (!value.int_UserIdNull)
                sqlStr += "@int_UserId,";
            if (!value.dt_CreateDateNull)
                sqlStr += "@dt_CreateDate,";
            if (null != value.vc_Static)
                sqlStr += "@vc_Static,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += ");SELECT @@IDENTITY";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_Name)
                AddParameter(cmd, "vc_Name", value.vc_Name);
            if (null != value.vc_Mobile)
                AddParameter(cmd, "vc_Mobile", value.vc_Mobile);
            if (!value.int_AgeNull)
                AddParameter(cmd, "int_Age", (object)value.int_Age);
            if (null != value.vc_Occupation)
                AddParameter(cmd, "vc_Occupation", value.vc_Occupation);
            if (null != value.vc_WorkingPlace)
                AddParameter(cmd, "vc_WorkingPlace", value.vc_WorkingPlace);
            if (null != value.vc_LivePlace)
                AddParameter(cmd, "vc_LivePlace", value.vc_LivePlace);
            if (null != value.vc_Use)
                AddParameter(cmd, "vc_Use", value.vc_Use);
            if (!value.dec_PriceNull)
                AddParameter(cmd, "dec_Price", (object)value.dec_Price);
            if (!value.dec_TotalPriceNull)
                AddParameter(cmd, "dec_TotalPrice", (object)value.dec_TotalPrice);
            if (null != value.vc_Referee)
                AddParameter(cmd, "vc_Referee", value.vc_Referee);
            if (!value.int_UserIdNull)
                AddParameter(cmd, "int_UserId", (object)value.int_UserId);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (null != value.vc_Static)
                AddParameter(cmd, "vc_Static", value.vc_Static);

            value.int_CId = Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// 更新部分字段操作.
        /// </summary>
        /// <param name="value"><see cref="tb_CustomerEntity"/>
        /// 如果传入的值为空,则不升级该字段</param>
        /// <returns>影响的行数</returns>
        public virtual int Update(tb_CustomerEntity value)
        {
            string sqlStr = "UPDATE tb_Customer SET ";
            if (null != value.vc_Name)
                sqlStr += "vc_Name=@vc_Name,";
            if (null != value.vc_Mobile)
                sqlStr += "vc_Mobile=@vc_Mobile,";
            if (!value.int_AgeNull)
                sqlStr += "int_Age=@int_Age,";
            if (null != value.vc_Occupation)
                sqlStr += "vc_Occupation=@vc_Occupation,";
            if (null != value.vc_WorkingPlace)
                sqlStr += "vc_WorkingPlace=@vc_WorkingPlace,";
            if (null != value.vc_LivePlace)
                sqlStr += "vc_LivePlace=@vc_LivePlace,";
            if (null != value.vc_Use)
                sqlStr += "vc_Use=@vc_Use,";
            if (!value.dec_PriceNull)
                sqlStr += "dec_Price=@dec_Price,";
            if (!value.dec_TotalPriceNull)
                sqlStr += "dec_TotalPrice=@dec_TotalPrice,";
            if (null != value.vc_Referee)
                sqlStr += "vc_Referee=@vc_Referee,";
            if (!value.int_UserIdNull)
                sqlStr += "int_UserId=@int_UserId,";
            if (!value.dt_CreateDateNull)
                sqlStr += "dt_CreateDate=@dt_CreateDate,";
            if (null != value.vc_Static)
                sqlStr += "vc_Static=@vc_Static,";
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 1);
            sqlStr += " WHERE   ";
            if (!value.int_CIdNull)
                sqlStr += "int_CId= @int_CId";
            SqlCommand cmd = _db.CreateCommand(sqlStr);
            if (null != value.vc_Name)
                AddParameter(cmd, "vc_Name", value.vc_Name);
            if (null != value.vc_Mobile)
                AddParameter(cmd, "vc_Mobile", value.vc_Mobile);
            if (!value.int_AgeNull)
                AddParameter(cmd, "int_Age", (object)value.int_Age);
            if (null != value.vc_Occupation)
                AddParameter(cmd, "vc_Occupation", value.vc_Occupation);
            if (null != value.vc_WorkingPlace)
                AddParameter(cmd, "vc_WorkingPlace", value.vc_WorkingPlace);
            if (null != value.vc_LivePlace)
                AddParameter(cmd, "vc_LivePlace", value.vc_LivePlace);
            if (null != value.vc_Use)
                AddParameter(cmd, "vc_Use", value.vc_Use);
            if (!value.dec_PriceNull)
                AddParameter(cmd, "dec_Price", (object)value.dec_Price);
            if (!value.dec_TotalPriceNull)
                AddParameter(cmd, "dec_TotalPrice", (object)value.dec_TotalPrice);
            if (null != value.vc_Referee)
                AddParameter(cmd, "vc_Referee", value.vc_Referee);
            if (!value.int_UserIdNull)
                AddParameter(cmd, "int_UserId", (object)value.int_UserId);
            if (!value.dt_CreateDateNull)
                AddParameter(cmd, "dt_CreateDate", (object)value.dt_CreateDate);
            if (null != value.vc_Static)
                AddParameter(cmd, "vc_Static", value.vc_Static);
            if (!value.int_CIdNull)
                AddParameter(cmd, "int_CId", (object)value.int_CId);

            return cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Deletes the specified object from the <c>tb_CustomerEntity</c> table.
        /// </summary>
        /// <param name="value">The <see cref="YearWorkChild"/> object to delete.</param>
        /// <returns>true if the record was deleted; otherwise, false.</returns>
        public int Delete(tb_CustomerEntity value)
        {
            return DeleteByPrimaryKey(value.int_CId);
        }

        public virtual int DeleteByPrimaryKey(int int_CId)
        {
            string whereSql = "";
            whereSql += "int_CId=@int_CId ";

            SqlCommand cmd = CreateDeleteCommand(whereSql);
            AddParameter(cmd, "int_CId", int_CId);

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes <c>tb_CustomerEntity</c> records that match the specified criteria.
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
        /// to delete <c>tb_CustomerEntity</c> records that match the specified criteria.
        /// </summary>
        /// <param name="whereSql">The SQL search condition. 
        /// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
        /// <returns>A reference to the <see cref="System.Data.SqlCommand"/> object.</returns>
        protected virtual SqlCommand CreateDeleteCommand(string whereSql)
        {
            string sql = "DELETE FROM tb_Customer";
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
        protected tb_CustomerEntity[] MapRecords(SqlDataReader reader)
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
        protected virtual tb_CustomerEntity[] MapRecords(SqlDataReader reader,
            int startIndex, int length, ref int totalRecordCount)
        {
            if (0 > startIndex)
                throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
            if (0 > length)
                throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
            int int_CIdColumnIndex = reader.GetOrdinal("int_CId");
            int vc_NameColumnIndex = reader.GetOrdinal("vc_Name");
            int vc_MobileColumnIndex = reader.GetOrdinal("vc_Mobile");
            int int_AgeColumnIndex = reader.GetOrdinal("int_Age");
            int vc_OccupationColumnIndex = reader.GetOrdinal("vc_Occupation");
            int vc_WorkingPlaceColumnIndex = reader.GetOrdinal("vc_WorkingPlace");
            int vc_LivePlaceColumnIndex = reader.GetOrdinal("vc_LivePlace");
            int vc_UseColumnIndex = reader.GetOrdinal("vc_Use");
            int dec_PriceColumnIndex = reader.GetOrdinal("dec_Price");
            int dec_TotalPriceColumnIndex = reader.GetOrdinal("dec_TotalPrice");
            int vc_RefereeColumnIndex = reader.GetOrdinal("vc_Referee");
            int int_UserIdColumnIndex = reader.GetOrdinal("int_UserId");
            int dt_CreateDateColumnIndex = reader.GetOrdinal("dt_CreateDate");
            int vc_StaticColumnIndex = reader.GetOrdinal("vc_Static");

            System.Collections.ArrayList recordList = new System.Collections.ArrayList();
            int ri = -startIndex;
            while (reader.Read())
            {
                ri++;
                if (ri > 0 && ri <= length)
                {
                    tb_CustomerEntity record = new tb_CustomerEntity();
                    recordList.Add(record); if (!reader.IsDBNull(int_CIdColumnIndex))
                        record.int_CId = Convert.ToInt32(reader.GetValue(int_CIdColumnIndex));
                    if (!reader.IsDBNull(vc_NameColumnIndex))
                        record.vc_Name = Convert.ToString(reader.GetValue(vc_NameColumnIndex));
                    if (!reader.IsDBNull(vc_MobileColumnIndex))
                        record.vc_Mobile = Convert.ToString(reader.GetValue(vc_MobileColumnIndex));
                    if (!reader.IsDBNull(int_AgeColumnIndex))
                        record.int_Age = Convert.ToInt32(reader.GetValue(int_AgeColumnIndex));
                    if (!reader.IsDBNull(vc_OccupationColumnIndex))
                        record.vc_Occupation = Convert.ToString(reader.GetValue(vc_OccupationColumnIndex));
                    if (!reader.IsDBNull(vc_WorkingPlaceColumnIndex))
                        record.vc_WorkingPlace = Convert.ToString(reader.GetValue(vc_WorkingPlaceColumnIndex));
                    if (!reader.IsDBNull(vc_LivePlaceColumnIndex))
                        record.vc_LivePlace = Convert.ToString(reader.GetValue(vc_LivePlaceColumnIndex));
                    if (!reader.IsDBNull(vc_UseColumnIndex))
                        record.vc_Use = Convert.ToString(reader.GetValue(vc_UseColumnIndex));
                    if (!reader.IsDBNull(dec_PriceColumnIndex))
                        record.dec_Price = Convert.ToDecimal(reader.GetValue(dec_PriceColumnIndex));
                    if (!reader.IsDBNull(dec_TotalPriceColumnIndex))
                        record.dec_TotalPrice = Convert.ToDecimal(reader.GetValue(dec_TotalPriceColumnIndex));
                    if (!reader.IsDBNull(vc_RefereeColumnIndex))
                        record.vc_Referee = Convert.ToString(reader.GetValue(vc_RefereeColumnIndex));
                    if (!reader.IsDBNull(int_UserIdColumnIndex))
                        record.int_UserId = Convert.ToInt32(reader.GetValue(int_UserIdColumnIndex));
                    if (!reader.IsDBNull(dt_CreateDateColumnIndex))
                        record.dt_CreateDate = Convert.ToDateTime(reader.GetValue(dt_CreateDateColumnIndex));
                    if (!reader.IsDBNull(vc_StaticColumnIndex))
                        record.vc_Static = Convert.ToString(reader.GetValue(vc_StaticColumnIndex));
                    if (ri == length && 0 != totalRecordCount)
                        break;
                }//end if
            }//end while
            totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
            return (tb_CustomerEntity[])(recordList.ToArray(typeof(tb_CustomerEntity)));


        }


        /// <summary>
        /// Converts <see cref="System.Data.DataRow"/> to <see cref="tb_CustomerEntity"/>.
        /// </summary>
        /// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
        /// <returns>A reference to the <see cref="tb_CustomerEntity"/> object.</returns>
        protected virtual tb_CustomerEntity MapRow(DataRow row)
        {
            tb_CustomerEntity mappedObject = new tb_CustomerEntity();
            DataTable dataTable = row.Table;
            DataColumn dataColumn;
            // Column int_CId
            dataColumn = dataTable.Columns["int_CId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_CId = (int)row[dataColumn];
            // Column vc_Name
            dataColumn = dataTable.Columns["vc_Name"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Name = (string)row[dataColumn];
            // Column vc_Mobile
            dataColumn = dataTable.Columns["vc_Mobile"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Mobile = (string)row[dataColumn];
            // Column int_Age
            dataColumn = dataTable.Columns["int_Age"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_Age = (int)row[dataColumn];
            // Column vc_Occupation
            dataColumn = dataTable.Columns["vc_Occupation"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Occupation = (string)row[dataColumn];
            // Column vc_WorkingPlace
            dataColumn = dataTable.Columns["vc_WorkingPlace"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_WorkingPlace = (string)row[dataColumn];
            // Column vc_LivePlace
            dataColumn = dataTable.Columns["vc_LivePlace"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_LivePlace = (string)row[dataColumn];
            // Column vc_Use
            dataColumn = dataTable.Columns["vc_Use"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Use = (string)row[dataColumn];
            // Column dec_Price
            dataColumn = dataTable.Columns["dec_Price"];
            if (!row.IsNull(dataColumn))
                mappedObject.dec_Price = (decimal)row[dataColumn];
            // Column dec_TotalPrice
            dataColumn = dataTable.Columns["dec_TotalPrice"];
            if (!row.IsNull(dataColumn))
                mappedObject.dec_TotalPrice = (decimal)row[dataColumn];
            // Column vc_Referee
            dataColumn = dataTable.Columns["vc_Referee"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Referee = (string)row[dataColumn];
            // Column int_UserId
            dataColumn = dataTable.Columns["int_UserId"];
            if (!row.IsNull(dataColumn))
                mappedObject.int_UserId = (int)row[dataColumn];
            // Column dt_CreateDate
            dataColumn = dataTable.Columns["dt_CreateDate"];
            if (!row.IsNull(dataColumn))
                mappedObject.dt_CreateDate = (DateTime)row[dataColumn];
            // Column vc_Static
            dataColumn = dataTable.Columns["vc_Static"];
            if (!row.IsNull(dataColumn))
                mappedObject.vc_Static = (string)row[dataColumn];


            return mappedObject;
        }

        /// <summary>
        /// Creates a <see cref="System.Data.DataTable"/> object for 
        /// the <c>tb_CustomerEntity</c> table.
        /// </summary>
        /// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tb_CustomerEntity";
            DataColumn dataColumn;
            dataColumn = dataTable.Columns.Add("int_CId", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_Name", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("vc_Mobile", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("int_Age", typeof(int));
            dataColumn = dataTable.Columns.Add("vc_Occupation", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("vc_WorkingPlace", typeof(string));
            dataColumn.MaxLength = 100;
            dataColumn = dataTable.Columns.Add("vc_LivePlace", typeof(string));
            dataColumn.MaxLength = 100;
            dataColumn = dataTable.Columns.Add("vc_Use", typeof(string));
            dataColumn.MaxLength = 50;
            dataColumn = dataTable.Columns.Add("dec_Price", typeof(decimal));
            dataColumn = dataTable.Columns.Add("dec_TotalPrice", typeof(decimal));
            dataColumn = dataTable.Columns.Add("vc_Referee", typeof(string));
            dataColumn.MaxLength = 20;
            dataColumn = dataTable.Columns.Add("int_UserId", typeof(int));
            dataColumn = dataTable.Columns.Add("dt_CreateDate", typeof(DateTime));
            dataColumn = dataTable.Columns.Add("vc_Static", typeof(string));
            dataColumn.MaxLength = 20;


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
                case "int_CId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_Name":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Mobile":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "int_Age":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "vc_Occupation":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_WorkingPlace":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_LivePlace":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "vc_Use":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "dec_Price":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Decimal, value);
                    break;
                case "dec_TotalPrice":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Decimal, value);
                    break;
                case "vc_Referee":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;
                case "int_UserId":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.Int, value);
                    break;
                case "dt_CreateDate":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.DateTime, value);
                    break;
                case "vc_Static":
                    parameter = _db.AddParameter(cmd, paramName, SqlDbType.NVarChar, value);
                    break;


                default:
                    throw new ArgumentException("Unknown parameter name (" + paramName + ").");
            }
            return parameter;
        }
    } // End of  tb_CustomerEntity_BaseOp class
}  // End of namespace

