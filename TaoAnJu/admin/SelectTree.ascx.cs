using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_SelectTree : System.Web.UI.UserControl
{
    protected string AppPath = "";
    bool SelectedDisabled = false;
    public string btnDisabled = "false";
    public string CClientId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        AppPath = Request.ApplicationPath;
        txtText.Enabled = !SelectedDisabled;
        CClientId = this.ClientID;
        if (SelectedDisabled)
        {
            btnDisabled = "true";
        }
        else
        {
            btnDisabled = "false";
        }
    }
    /// <summary>
    /// 名称
    /// </summary>
    public string SelectedText
    {
        get
        {
            return txtText.Text;
        }
        set
        {
            txtText.Text = value;
        }
    }
    /// <summary>
    /// 值
    /// </summary>
    public string SelectedValue
    {
        get
        {
            return txtValue.Text;
        }
        set
        {
            txtValue.Text = value;
        }
    }
    /// <summary>
    /// 值
    /// </summary>
    public string SelectedType
    {
        get
        {
            return txtType.Text;
        }
        set
        {
            txtType.Text = value;
        }
    }
    /// <summary>
    /// 状态
    /// </summary>
    public bool SelectedEnabled
    {
        get
        {
            return !SelectedDisabled;
        }
        set
        {
            SelectedDisabled = !value;
        }
    }
    /// <summary>
    /// 只读
    /// </summary>
    public bool TextReadOnly
    {
        get
        {
            return txtText.ReadOnly;
        }
        set
        {
            txtText.ReadOnly = value;
        }
    }
    /// <summary>
    /// Enabled
    /// </summary>
    public bool TextEnabled
    {
        get
        {
            return txtText.Enabled;
        }
        set
        {
            txtText.Enabled = value;
            if (txtText.Enabled == false)
            {
                txtText.BackColor = System.Drawing.Color.LightGray;
            }
            else
            {
                txtText.BackColor = System.Drawing.Color.White;
            }
        }
    }
    /// <summary>
    /// 宽度
    /// </summary>
    public Unit TextWidth
    {
        get
        {
            return txtText.Width;
        }
        set
        {
            txtText.Width = value;
        }
    }
}