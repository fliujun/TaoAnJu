using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Data.SqlClient ;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Web.Mail;
using System.Xml;
using System.Text.RegularExpressions;
/// <summary>
/// FHSystem 的摘要说明
/// </summary>
namespace TaoAnJu.Util
{
    public class RiSystem
    {
        public static string PwdSecret = "lkSDEuy!@#$1234@!#$CVBNDFRsdfQ@#4345asDF";
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string DBConnNormal = System.Configuration.ConfigurationManager.AppSettings["DBConnNormal"];
        protected static CUserTicket LoginInfo;
        /// <summary>
        /// 
        /// </summary>
        public RiSystem()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 获取当前页的DataTable
        /// </summary>
        /// <param name="db">数据库连接</param>
        /// <param name="TableName">表名</param>
        /// <param name="Fields">查取的字段</param>
        /// <param name="WhereExpression">查询条件</param>
        /// <param name="PageSize">单页记录数</param>
        /// <param name="PageNum">页数</param>
        /// <param name="strOrderFid">排序字段名</param>
        /// <param name="OrderType">排序类型：true为降序，false为升序</param>
        /// <returns>返回结果</returns>
        public static DataTable CurrentDataPage(DsConnectionDB db, string TableName, string Fields, string WhereExpression, int PageSize, int PageNum, string strOrderFid, bool OrderType)
        {
            int topSize = PageNum * PageSize;
            string SQLstr = string.Format("SELECT TOP {0} {1} FROM {2}", topSize, Fields, TableName);
            if (WhereExpression != "")
            {
                SQLstr += " where " + WhereExpression;
            }
            if (strOrderFid != "")
            {
                SQLstr += " order by " + strOrderFid;
                if (OrderType)
                {
                    SQLstr += " desc";
                }
                else
                {
                    SQLstr += " asc";
                }
            }
            DataSet ds = db.ExecuteQuery(SQLstr);
            DataTable dt = ds.Tables[0].Clone();
            DataRow dr;
            for (int i = (PageNum - 1) * PageSize; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[dt.Columns[j].ColumnName.ToString()] = ds.Tables[0].Rows[i][j];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        
        /// <summary>
        /// 字串截取函数
        /// </summary>
        /// <param name="OldStr">要截取的字串</param>
        /// <param name="MaxLen">最大字串长度</param>
        /// <returns>截短后的字串</returns>
        public static string GetShortStr(string OldStr, int MaxLen)
        {
            if (string.IsNullOrEmpty(OldStr)) return "";
            if (MaxLen > OldStr.Length) { return OldStr; }
            int len = 0;
            int mlen = (OldStr.Length <= MaxLen * 2) ? OldStr.Length : MaxLen * 2;
            for (int i = 0; i < mlen; i++)
            {
                if (OldStr[i] <= 255)
                {
                    ++len;
                }
            }
            MaxLen = (OldStr.Length <= MaxLen + len / 2) ? OldStr.Length : MaxLen + len / 2;
            if (MaxLen >= OldStr.Length)
            {
                return OldStr;
            }
            else
            {
                return OldStr.Substring(0, MaxLen - 2) + "...";
            }
        }
        /// <summary>
        /// 获取字符串实际长度
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int getStringLen(string str)
        {
            int i = 0;
            int len = 0;
            while (i < str.Length)
            {
                if ((int)str[i] > 127)
                {
                    len += 2;
                }
                else
                {
                    len++;
                }
                i++;
            }
            return len;
        }
        /// <summary>
        /// 对内容进行格式化
        /// </summary>
        /// <param name="str">要格式化的内容</param>
        /// <returns>返回格式化后的内容</returns>
        static public string FormatBody(string str)
        {
            str = str.Replace("\n　　", "\n");
            str = str.Replace("\n　", "\n");
            while (str.StartsWith("　"))
                str = str.Substring(2);

            string NewStr = str.Replace("\n", "<br>\n　　");
            return "　　" + NewStr;
        }
        /// <summary>
        /// 转换特殊字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EFormatContent(string str)
        {
            str = str.Replace("®", "&reg;");
            str = str.Replace("©", "&copy;");
            str = str.Replace("™", "&trade;");
            str = str.Replace("÷", "&divide;");
            str = str.Replace("§", "&sect;");
            str = str.Replace("½", "&frac12;");
            str = str.Replace("¼", "&frac14;");
            str = str.Replace("±", "&plusmn;");
            str = str.Replace("×", "&times;");
            str = str.Replace("¾", "&frac34;");
            str = str.Replace("€", "&euro;");
            str = str.Replace("¥", "&yen;");
            str = str.Replace("‰", "&permil;");
            str = str.Replace("∑", "&sum;");
            str = str.Replace("∞", "&infin;");
            str = str.Replace("≠", "&ne;");
            str = str.Replace("√", "&radic;");
            str = str.Replace("»", "&raquo;");
            str = str.Replace("•", "&#8226;");
            return str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DFormatContent(string str)
        {
            str = str.Replace("&reg;","®" );
            str = str.Replace("&copy;","©");
            str = str.Replace("&trade;","™");
            str = str.Replace("&divide;","÷");
            str = str.Replace("&sect;","§");
            str = str.Replace("&frac12;","½");
            str = str.Replace("&frac14;","¼");
            str = str.Replace("&plusmn;","±");
            str = str.Replace("&times;","×");
            str = str.Replace("&frac34;","¾");
            str = str.Replace("&euro;","€");
            str = str.Replace("&yen;","¥");
            str = str.Replace("&permil;","‰");
            str = str.Replace("&sum;","∑");
            str = str.Replace("&infin;","∞");
            str = str.Replace("&ne;","≠");
            str = str.Replace("&radic;","√");
            str = str.Replace( "&raquo;","»");
            str = str.Replace("&#8226;","•");
            return str;
        }
        /// <summary>
        /// 判断数据类型
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool IsDecimal(string values)
        {
            try
            {
                decimal temp = decimal.Parse(values);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 判断数据类型
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool IsInt(string values)
        {
            try
            {
                int temp = int.Parse(values);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// 格式化文件名称
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="FileExt"></param>
        /// <returns></returns>
        public static string FormatFileName(string FileName, string FileExt)
        {
            string tempfile = "";
            for (int i = 0; i < FileName.Length; i++)
            {
                tempfile += FileName[i];
                if (System.Web.HttpUtility.UrlEncode(tempfile + "." + FileExt).Length > int.Parse(System.Configuration.ConfigurationManager.AppSettings["FileMaxLength"]))
                {
                    break;
                }
            }
            return tempfile + "." + FileExt;
        }
        /// <summary>
        /// 格式化数字显示
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string FormatDecimal(decimal data)
        {
            //return decimal.Round (data,4).ToString ();
            string dec = decimal.Subtract(data, decimal.Truncate(data)).ToString();
            dec = dec.Replace("0", "");
            return decimal.Truncate(data).ToString() + dec;
        }
        /// <summary>
        /// 格式化数字
        /// </summary>
        /// <param name="data"></param>
        /// <param name="decs">小数位</param>
        /// <returns></returns>
        public static string FormatDecimal(decimal data, int decs)
        {
            decimal dec = decimal.Round(data, decs);
            if (dec.ToString().LastIndexOf(".") >= 0)
            {
                if (dec.ToString().Substring(dec.ToString().LastIndexOf(".") + 1).Length < decs)
                {
                    return dec.ToString().Substring(0, dec.ToString().LastIndexOf(".") + 1) + dec.ToString().Substring(dec.ToString().LastIndexOf(".") + 1).PadRight(decs, '0');
                }
                else
                {
                    return dec.ToString();
                }
            }
            else
            {
                return dec.ToString() + ".".PadRight(decs + 1, '0');
            }
        }
        
        /// <summary>
        /// IP地址转换成数字
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static Int64 FormatIpStrToInt(string ip)
        {
            string[] ipchar = ip.Split('.');
            string intip = "1";
            for (int i = 0; i < ipchar.Length; i++)
            {
                intip += ipchar[i].PadLeft(3, '0');
            }
            return Int64.Parse(intip);
        }
        /// <summary>
        /// 格式化上传文件名称
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string FormatUpLoadFileName(string Key, string FileName)
        {
            string sExtension = Path.GetExtension(FileName);
            Random oRan = new System.Random();
            string NewName = Key +
                DateTime.Now.ToString ("yyyyMMddHHmmss")+
                oRan.Next(9999).ToString() +
                sExtension;
            return NewName;
        }
        /// <summary>
        /// 上传文件，返回文件名
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="PostedFile"></param>
        /// <returns></returns>
        public static Boolean UpLoadFile(string FileName, System.Web.HttpPostedFile PostedFile)
        {
            Boolean IsUpLoad = false ;
            if (PostedFile != null && PostedFile.FileName.Length > 0)
            {
                try
                {
                    PostedFile.SaveAs(FileName);
                    IsUpLoad = true;
                }
                catch (Exception ex)
                {
                    Loger.logErr("失败", ex);
                }
            }
            return IsUpLoad;
        }
        /// <summary>
        /// 上传缩略图
        /// </summary>
        /// <param name="FileName">文件名称</param>
        /// <param name="PostedFile">原文件</param>
        /// <param name="desWidth">缩略图宽</param>
        /// <param name="desHeight">缩略图高</param>
        /// <returns>返回文件名</returns>
        public static Boolean UpLoadThumbnail(string FileName, System.Web.HttpPostedFile PostedFile, int desWidth, int desHeight)
        {
            //容器高与宽
            bool isUpLoad = false;
            string backcolor = "#FFFFFF";
            string borderColor = "#999999";
            desWidth = (desWidth == 0) ? 300 : desWidth;
            desHeight = (desHeight == 0) ? 200 : desHeight; 
            int penwidth = 0;
            int penhight = 0;
            int size = PostedFile.ContentLength;
            if (PostedFile.ContentLength < 1024000)
            {
                string filepath = PostedFile.FileName;
                string name = System.IO.Path.GetFileName(filepath);
                int num = filepath.LastIndexOf(".");
                string filetype = filepath.Substring(num).ToUpper().Trim();
                if (filetype == ".GIF" || filetype == ".PNG" || filetype == ".JPG" || filetype == ".JPEG" || filetype == ".BMP")
                {
                    Byte[] filebyte = new byte[PostedFile.ContentLength];
                    System.IO.Stream ostream = PostedFile.InputStream;
                    System.Drawing.Image oimage = System.Drawing.Image.FromStream(ostream);
                    int owidth = oimage.Width;
                    int oheight = oimage.Height;
                    string hw = GetImageSize(owidth, oheight, desWidth,desHeight);
                    string[] aryhw = hw.Split(';');
                    int twidth = Convert.ToInt32(aryhw[0]);
                    int theight = Convert.ToInt32(aryhw[1]);
                    //新建一个bmp图片                                          
                    System.Drawing.Bitmap timage = new System.Drawing.Bitmap(desWidth, desHeight);
                    //新建一个画板
                    System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(timage);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.Clear(System.Drawing.ColorTranslator.FromHtml(backcolor));
                    if (twidth < desWidth & theight == desHeight)
                    {
                        penwidth = desWidth - twidth;
                    }
                    else if (twidth == desWidth && theight < desHeight)
                    {
                        penhight = desHeight - theight;
                    }
                    else if (twidth < desWidth && theight < desHeight)
                    {
                        penwidth = desWidth - twidth;
                        penhight = desHeight - theight;
                    }
                    int top = penhight / 2;
                    int left = penwidth / 2;
                    g.DrawImage(oimage, new System.Drawing.Rectangle(left, top, twidth, theight), new System.Drawing.Rectangle(0, 0, owidth, oheight), System.Drawing.GraphicsUnit.Pixel);
                    System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.ColorTranslator.FromHtml(borderColor));
                    g.DrawRectangle(pen, 0, 0, desWidth - 2, desHeight - 2);
                    try
                    {
                        //缩图图保存
                        timage.Save(FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        isUpLoad = true;
                    }
                    catch (Exception ex)
                    {
                        Loger.logErr("失败", ex);
                    }
                    finally
                    {
                        g.Dispose();
                        timage.Dispose();
                    }
                    
                }
            }
            return isUpLoad ;
        }
        /// <summary>
        /// 删除项目文件
        /// </summary>
        /// <param name="db"></param>
        /// <param name="idList"></param>
        public static void DelItemFile(DsConnectionDB db, string idList)
        {
            string LoadFilePath = System.Configuration.ConfigurationManager.AppSettings["LoadFilePath"];
            LoadFilePath = System.Web.HttpContext.Current.Server.MapPath(LoadFilePath).Replace("admin\\", "");
            string LoadThumbnailPath = System.Configuration.ConfigurationManager.AppSettings["LoadThumbnailPath"];
            LoadThumbnailPath = System.Web.HttpContext.Current.Server.MapPath(LoadThumbnailPath).Replace("admin\\", "");
            string sql = "select int_ItemId,vc_PicFile1,vc_Thumb1,vc_PicFile2,vc_PicFile3 from tb_ItemInfo where int_ItemId in(" + idList + ")";
            DataTable dt = db.ExecuteQuery(sql).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string filename = dt.Rows[i]["vc_PicFile1"].ToString();
                if (filename != "")
                {
                    DelFile(LoadFilePath + filename);
                }
                filename = dt.Rows[i]["vc_PicFile2"].ToString();
                if (filename != "")
                {
                    DelFile(LoadFilePath + filename);
                }
                filename = dt.Rows[i]["vc_PicFile3"].ToString();
                if (filename != "")
                {
                    DelFile(LoadFilePath + filename);
                }
                filename = dt.Rows[i]["vc_Thumb1"].ToString();
                if (filename != "")
                {
                    DelFile(LoadThumbnailPath + filename);
                }
                DelDirectory(LoadFilePath + dt.Rows[i]["int_ItemId"] + "\\");
                DelDirectory(LoadThumbnailPath + dt.Rows[i]["int_ItemId"] + "\\");
            }
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static Boolean DelFile(string filepath)
        {
            Boolean ret = false;
            //获得文件对象
            System.IO.FileInfo file = new System.IO.FileInfo(filepath);
            if (file.Exists)
            {
                file.Delete();//删除
                ret = true;
            }
            return ret;
        }
        /// <summary>
        /// 删除文件夹及其目录下文件
        /// </summary>
        /// <param name="path"></param>
        public static void DelDirectory(string path)
        {
            //获取文件夹中所有图片  
            if (Directory.GetFileSystemEntries(path).Length > 0)
            {
                //遍历文件夹中所有文件  
                foreach (string file in Directory.GetFiles(path))
                {
                    //文件己存在  
                    if (File.Exists(file))
                    {
                        FileInfo fi = new FileInfo(file);
                        //判断当前文件属性是否是只读  
                        if (fi.Attributes.ToString().IndexOf("ReadyOnly") >= 0)
                        {
                            fi.Attributes = FileAttributes.Normal;
                        }
                        //删除文件  
                        File.Delete(file);
                    }
                }
                //删除文件夹  
                Directory.Delete(path);
            }  
        }
        /// <summary>
        /// 获取缩略图的高与宽
        /// </summary>
        /// <param name="LoadImgW"></param>
        /// <param name="LoadImgH"></param>
        /// <returns></returns>
        protected static string GetImageSize(int LoadImgW, int LoadImgH, int desWidth, int desHeight)
        {
            int xh = 0;
            int xw = 0;
            //容器高与宽
            int oldW = desWidth;
            int oldH = desHeight;
            //图片的高宽与容器的相同
            if (LoadImgH == oldH && LoadImgW == (oldW))
            {//1.正常显示 
                xh = LoadImgH;
                xw = LoadImgW;
            }
            if (LoadImgH == oldH && LoadImgW > (oldW))
            {//2、原高==容高，原宽>容宽 以原宽为基础 
                xw = (oldW);
                xh = LoadImgH * xw / LoadImgW;
            }
            if (LoadImgH == oldH && LoadImgW < (oldW))
            {//3、原高==容高，原宽<容宽  正常显示    
                xw = LoadImgW;
                xh = LoadImgH;
            }
            if (LoadImgH > oldH && LoadImgW == (oldW))
            {//4、原高>容高，原宽==容宽 以原高为基础    
                xh = oldH;
                xw = LoadImgW * xh / LoadImgH;
            }
            if (LoadImgH > oldH && LoadImgW > (oldW))
            {//5、原高>容高，原宽>容宽            
                if ((LoadImgH / oldH) > (LoadImgW / (oldW)))
                {//原高大的多，以原高为基础 
                    xh = oldH;
                    xw = LoadImgW * xh / LoadImgH;
                }
                else
                {//以原宽为基础 
                    xw = (oldW);
                    xh = LoadImgH * xw / LoadImgW;
                }
            }
            if (LoadImgH > oldH && LoadImgW < (oldW))
            {//6、原高>容高，原宽<容宽 以原高为基础         
                xh = oldH;
                xw = LoadImgW * xh / LoadImgH;
            }
            if (LoadImgH < oldH && LoadImgW == (oldW))
            {//7、原高<容高，原宽=容宽 正常显示        
                xh = LoadImgH;
                xw = LoadImgW;
            }
            if (LoadImgH < oldH && LoadImgW > (oldW))
            {//8、原高<容高，原宽>容宽 以原宽为基础     
                xw = (oldW);
                xh = LoadImgH * xw / LoadImgW;
            }
            if (LoadImgH < oldH && LoadImgW < (oldW))
            {//9、原高<容高，原宽<容宽//正常显示     
                xh = LoadImgH;
                xw = LoadImgW;
            }
            return xw + ";" + xh;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int getWeekOfCurrDay()
        {
            switch (DateTime.Now.DayOfWeek.ToString().ToLower())
            {
                case "monday":
                    return 1;
                case "tuesday":
                    return 2;
                case "wednesday":
                    return 3;
                case "thursday":
                    return 4;
                case "friday":
                    return 5;
                case "saturday":
                    return 6;
                default:
                    return 7;
            }
        }
        /// <summary>
        /// 根据编号获取表名称
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tbid"></param>
        /// <returns></returns>
        public static string getTableNameById(DsConnectionDB db, Int32 tbid)
        {
            if (tbid == 0)
            {
                return "";
            }
            string tbName = "";
            tb_TableInfoEntity_Op objo = new tb_TableInfoEntity_Op(db);
            tb_TableInfoEntity obj = objo.GetByPrimaryKey(tbid);
            if(obj!=null)
            {
                tbName = obj.vc_TableDesc.ToString();
                if (obj.int_ParentId > 0)
                {
                    obj = objo.GetByPrimaryKey(obj.int_ParentId);
                    if (obj != null)
                    {
                        tbName = obj.vc_TableDesc.ToString() + "\\" + tbName;
                    }
                }
            }
            return tbName;
        }
        
        /// <summary>
        /// 根据编号获取数据规范名称
        /// </summary>
        /// <param name="db"></param>
        /// <param name="did"></param>
        /// <returns></returns>
        public static string getDataNormalById(DsConnectionDB db, Int32 did)
        {
            if (did == 0)
            {
                return "";
            }
            string dName = "";
            tb_DataConfigInfoEntity_Op objo = new tb_DataConfigInfoEntity_Op(db);
            tb_DataConfigInfoEntity obj = objo.GetByPrimaryKey(did);
            if (obj != null)
            {
                dName =  obj.vc_Name.ToString();
            }
            return dName;
        }
        /// <summary>
        /// 获取数据结构树选择路径
        /// </summary>
        /// <param name="db"></param>
        /// <param name="did"></param>
        /// <returns></returns>
        public static string getDataNormalPath(DsConnectionDB db, Int32 did)
        {
            if (did == 0)
            {
                return "";
            }
            string sql = "select int_DId,vc_Name,int_ParentId from tb_DataConfigInfo";
            DataTable dt = db.ExecuteQuery(sql).Tables[0];
            string dPath = "";
            SearchDataNormalInfo(dt, did, out dPath, "");
            return dPath;
        }
        private static void SearchDataNormalInfo(DataTable dt, Int32 did, out string dPath, string tempd)
        {
            DataRow[] dr = dt.Select(" int_DId=" + did.ToString());
            if (dr.Length > 0)
            {
                dPath = dr[0][1].ToString() + tempd;
                if ((Int32)dr[0][2] != -1)
                {
                    dPath = "\\" + dPath;
                    SearchDataNormalInfo(dt, (Int32)dr[0][2], out dPath, dPath);
                }
            }
            else
            {
                dPath = "";
            }
        }
        /// <summary>
        /// 得到下一个编码
        /// </summary>
        /// <param name="parentid"></param>
        /// <returns></returns>
        public static string getNextCode(DsConnectionDB db, decimal parentid)
        {
            string sql = "select isnull(max(vc_code),'00000') from tb_Fun where num_ParentId =" + parentid.ToString();
            string codes = Convert.ToString(db.ExecuteScalar(sql));
            codes = codes.Substring(codes.Length - 5, 5);
            decimal retid = Convert.ToDecimal(codes) + 1;
            codes = StringTools.AddZero(retid.ToString());
            return codes;
        }
        
        /// <summary>
        /// 发送EMAIL
        /// </summary>
        /// <param name="To"></param>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        public static void SendMail(string To, string Subject, string Body)
        {
            string MailFrom = System.Configuration.ConfigurationManager.AppSettings["MailFrom"];
            string MailPWD = System.Configuration.ConfigurationManager.AppSettings["MailPWD"];
            string MailSer = System.Configuration.ConfigurationManager.AppSettings["MailSer"];
            System.Web.Mail.MailMessage Mail = new System.Web.Mail.MailMessage();
            Mail.To = To;
            Mail.From = MailFrom;
            Mail.Subject = Subject;
            Mail.BodyFormat = System.Web.Mail.MailFormat.Html;
            Mail.Body = Body;
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", MailFrom);
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", MailPWD);
            System.Web.Mail.SmtpMail.SmtpServer = MailSer;
            try
            {
                System.Web.Mail.SmtpMail.Send(Mail);
            }
            catch (Exception ee)
            {
                //throw ee;
            }
        }
        /// <summary>
        /// 发送EMAIL
        /// </summary>
        /// <param name="To"></param>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        public static void NetSendMail(string To, string Subject, string Body)
        {
            string MailSender = System.Configuration.ConfigurationManager.AppSettings["MailFrom"];
            string MailPWD = System.Configuration.ConfigurationManager.AppSettings["MailPWD"];
            string MailServer = System.Configuration.ConfigurationManager.AppSettings["MailSer"];
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(To);
            mail.From = new MailAddress(MailSender);
            mail.SubjectEncoding = System.Text.Encoding.GetEncoding("GB2312");
            mail.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");
            //邮件等级
            mail.Priority = System.Net.Mail.MailPriority.High;
            mail.IsBodyHtml = true;
            mail.Subject = Subject;
            mail.Body = Body;
            //设置smtp
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(MailServer);
            //设置帐户
            smtp.Credentials =new System.Net.NetworkCredential(MailSender , MailPWD );
            //发送Email
            object userState = mail;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ee)
            {
                //throw ee;
            }

        }
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="db"></param>
        /// <param name="LogType"></param>
        /// <param name="Ip"></param>
        /// <param name="Content"></param>
        /// <param name="UserId"></param>
        public static void AddLog(DsConnectionDB db, string LogType, string Content,string Ip,  int UserId)
        {
            tb_LogInfoEntity li = new tb_LogInfoEntity();
            tb_LogInfoEntity_Op lo = new tb_LogInfoEntity_Op(db);
            li.vc_LogType = LogType;
            li.vc_Content = Content;
            li.vc_Ip = Ip;
            li.int_UserId = UserId;
            li.dt_CreateDate = DateTime.Now;
            lo.Insert(li);
        }
        /// <summary>
        /// 根据编号获取权限名称
        /// </summary>
        /// <param name="db"></param>
        /// <param name="funid"></param>
        /// <returns></returns>
        public static string getFunNameById(DsConnectionDB db, Int32 funid)
        {
            string funName = "";
            if (funid == -1)
            {
                funName = "顶级权限";
            }
            else
            {
                tb_FunInfoEntity_Op objo = new tb_FunInfoEntity_Op(db);
                tb_FunInfoEntity obj = objo.GetByPrimaryKey(funid);
                if (obj != null)
                {
                    funName = obj.vc_Name.ToString();
                }
            }
            return funName;
        }
        /// <summary>
        /// 获取部门路径
        /// </summary>
        /// <param name="db"></param>
        /// <param name="DepId"></param>
        /// <param name="dtype">0：不限；1：到机构；2：到部门</param>
        /// <returns></returns>
        public static string getDepPath(DsConnectionDB db, Int32 DepId,Int32 dtype)
        {
            string sql = "select int_DepId,vc_Name,int_ParentId,int_Type from tb_DepInfo";
            DataTable dt = db.ExecuteQuery(sql).Tables[0];
            string depPath="";
            SearchDepInfo(dt, DepId, out depPath,"",dtype);
            return depPath;
        }
        private static void SearchDepInfo(DataTable dt, Int32 DepId, out string depPath,string tempDep, Int32 dtype)
        {
            DataRow[] dr = dt.Select(" int_DepId=" + DepId.ToString());
            if (dr.Length > 0)
            {
                depPath = dr[0][1].ToString() + tempDep;
                if ((Int32)dr[0][3] != dtype && (Int32)dr[0][2] != -1)
                {
                    depPath = "\\" + depPath;
                    SearchDepInfo(dt, (Int32)dr[0][2], out depPath,depPath, dtype);
                }
            }
            else
            {
                depPath = "";
            }
        }
        /// <summary>
        /// 获取权限路径
        /// </summary>
        /// <param name="db"></param>
        /// <param name="FunId"></param>
        /// <returns></returns>
        public static string getFunPath(DsConnectionDB db, Int32 FunId)
        {
            string sql = "select int_FunId,vc_Name,int_ParentId from tb_FunInfo";
            DataTable dt = db.ExecuteQuery(sql).Tables[0];
            string funPath = "";
            SearchFunInfo(dt, FunId, out funPath, "");
            return funPath;
        }
        private static void SearchFunInfo(DataTable dt, Int32 FunId, out string funPath, string tempfun)
        {
            DataRow[] dr = dt.Select(" int_FunId=" + FunId.ToString());
            if (dr.Length > 0)
            {
                funPath = dr[0][1].ToString() + tempfun;
                if ((Int32)dr[0][2] != -1)
                {
                    funPath = "\\" + funPath;
                    SearchFunInfo(dt, (Int32)dr[0][2], out funPath, funPath);
                }
            }
            else
            {
                funPath = "";
            }
        }
        /// <summary>
        /// 根据内容获取权限ID
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string getFunIdByValue(DsConnectionDB db, string value)
        {
            string sql = "select top 1 int_FunId from tb_FunInfo where vc_Value like '%" + value + "%'";
            DataTable dt = db.ExecuteQuery(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["int_FunId"].ToString();
            }
            else
            {
                return "-1000";
            }
        }
        /// <summary>
        /// 是否有子操作权限
        /// </summary>
        /// <param name="db"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Boolean IsHaveChildFun(DsConnectionDB db, string value)
        {
            bool result = false;
            string sql = "select top 1 int_FunId from tb_FunInfo where int_Type=3 and int_ParentId in(select int_FunId from tb_FunInfo where vc_Value like '%" + value + "%')";
            DataTable dt = db.ExecuteQuery(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 初始化提交按钮，防止重复提交
        /// </summary>
        /// <param name="curPage"></param>
        /// <param name="btnName"></param>
        public static void InitSubmitButton(System.Web.UI.Page curPage, string btnName)
        {
            System.Web.UI.WebControls.Button bn = (System.Web.UI.WebControls.Button)curPage.FindControl(btnName);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("window.document.getElementById(\"" + btnName + "\").disabled =true;");// disable按钮
            sb.Append(curPage.ClientScript.GetPostBackEventReference(bn, null));//用__doPostBack来提交，保证按钮的服务器端click事件执行
            sb.Append(";");
            bn.Attributes.Add("onclick", sb.ToString());
        }
    }
    /// <summary>
    /// 用户操作信息
    /// </summary>
    public class UserOpInfo
    {
        public string OpType;
        public string ModelName;
        public string OpSql;
        public string IdList;
        public UserOpInfo(string __OpType, string __ModelName, string __OpSql, string __IdList)
        {
            OpType = __OpType;
            ModelName = __ModelName;
            OpSql = __OpSql;
            IdList = __IdList;
        }
    }
}

