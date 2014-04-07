using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using TaoAnJu.Util;
public partial class admin_Customer_Add : CAdminCookiePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lit_Msg.Text = "";
        lit_Script.Text = "";
        RiSystem.InitSubmitButton(this.Page, btnSubmit.ID);
        if (!Page.IsPostBack)
        {
            InitData();
        }
    }
    protected void InitData()
    {
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            if (!string.IsNullOrEmpty(Request["cid"]))
            {
                txt_CId.Text = Request["cid"];
                tb_CustomerEntity_Op objo = new tb_CustomerEntity_Op(db);
                tb_CustomerEntity obj = objo.GetByPrimaryKey(Convert.ToInt32(txt_CId.Text));
                if (obj != null)
                {
                    txt_Mobile.Text = obj.vc_Mobile.ToString();
                    txt_Name.Text = obj.vc_Name.ToString();
                    txt_Age.Text = (!obj.int_AgeNull && obj.int_Age > 0) ? obj.int_Age.ToString() : "";
                    txt_LivePlace.Text = obj.vc_LivePlace.ToString();
                    txt_Occupation.Text = obj.vc_Occupation.ToString();
                    txt_Price.Text = (!obj.dec_PriceNull && obj.dec_Price > 0) ? obj.dec_Price.ToString() : "";
                    txt_Referee.Text = obj.vc_Referee.ToString();
                    txt_TotalPrice.Text = (!obj.dec_TotalPriceNull && obj.dec_TotalPrice > 0) ? obj.dec_TotalPrice.ToString() : "";
                    txt_Use.Text = obj.vc_Use.ToString();
                    txt_WorkingPlace.Text = obj.vc_WorkingPlace.ToString();
                }
            }
        }
        catch (System.Exception ee)
        {
            Loger.logErr("失败", ee);
        }
        finally
        {
            if (null != db) { db.Close(); }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lit_Msg.Text = "";
        if (txt_Mobile.Text.Trim() == "")
        {
            lit_Msg.Text = "错误提示：手机号不能为空！";
            return;
        }
        if (txt_Name.Text.Trim() == "")
        {
            lit_Msg.Text = "错误提示：客户姓名不能为空！";
            return;
        }
        //匹配正整数
        Regex re = new Regex(@"^[0-9]*[0-9][0-9]*$");
        if (!string.IsNullOrEmpty(txt_Age.Text.Trim()) && !re.IsMatch(txt_Age.Text.Trim()))
        {
            lit_Msg.Text = "错误提示：年龄请输入整数！";
            txt_Age.Text = "";
            return;
        }
        //匹配正浮点数
        re = new Regex(@"^[0-9]+(.[0-9]{2})?$");
        if (!string.IsNullOrEmpty(txt_Price.Text.Trim()) && !re.IsMatch(txt_Price.Text.Trim()))
        {
            lit_Msg.Text = "错误提示：期望单价请输入数字！";
            txt_Price.Text = "";
            return;
        }
        if (!string.IsNullOrEmpty(txt_TotalPrice.Text.Trim()) && !re.IsMatch(txt_TotalPrice.Text.Trim()))
        {
            lit_Msg.Text = "错误提示：期望总价请输入数字！";
            txt_TotalPrice.Text = "";
            return;
        }
        
        DsConnectionDB db = new DsConnectionDB(RiSystem.DBConnNormal);
        try
        {
            string sql = "select count(*) from tb_Customer where vc_Mobile='" + txt_Mobile.Text + "'";
            if (txt_CId.Text != "")
            {
                sql += " and int_CId<>" + txt_CId.Text;
            }
            if ((int)db.ExecuteScalar(sql) > 0)
            {
                lit_Msg.Text = "错误提示：此手机号已存在，请重新输入！";
                txt_Mobile.Text = "";
                return;
            }
            tb_CustomerEntity obj = new tb_CustomerEntity();
            tb_CustomerEntity_Op objo = new tb_CustomerEntity_Op(db);
            obj.vc_Mobile= txt_Mobile.Text.Trim();
            obj.vc_Name = txt_Name.Text.Trim();
            obj.int_Age = (txt_Age.Text.Trim() != "") ? Convert.ToInt32(txt_Age.Text.Trim()) : 0;
            obj.dec_Price = (txt_Price.Text.Trim() != "") ? Convert.ToDecimal(txt_Price.Text.Trim()) : 0;
            obj.dec_TotalPrice = (txt_TotalPrice.Text.Trim() != "") ? Convert.ToDecimal(txt_TotalPrice.Text.Trim()) : 0;
            obj.vc_Occupation = txt_Occupation.Text.Trim();
            obj.vc_Referee = txt_Referee.Text.Trim();
            obj.vc_Static = "";
            obj.vc_Use = txt_Use.Text.Trim();
            obj.vc_WorkingPlace = txt_WorkingPlace.Text.Trim();
            obj.vc_LivePlace = txt_LivePlace.Text.Trim();
            if (txt_CId.Text == "")
            {
                obj.dt_CreateDate = DateTime.Now;
                obj.int_UserId =Convert.ToInt32 ( LoginInfo.UserId);
                objo.Insert(obj);
                RiSystem.AddLog(db, "添加", LoginInfo.RealName + "进行 客户 添加操作，相关编号为：" + obj.int_CId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }
            else
            {
                obj.int_CId = Convert.ToInt32(txt_CId.Text);
                objo.Update(obj);
                RiSystem.AddLog(db, "修改", LoginInfo.RealName + "进行 客户 修改操作，相关编号为：" + obj.int_CId.ToString(), Request.UserHostAddress, LoginInfo.UserId);
            }

            lit_Script.Text = StringTools.AddScript("window.parent.frames['mainFrame'].location=window.parent.frames['mainFrame'].location;JqueryDialog.Close();");
        }
        catch (System.Exception ee)
        {
            Loger.logErr("失败", ee);
        }
        finally
        {
            if (null != db) { db.Close(); }
        }
    }
}