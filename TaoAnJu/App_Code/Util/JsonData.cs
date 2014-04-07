using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Json操作类
/// </summary>
public class JsonData
{
    private Dictionary<string, object> Params;

    public JsonData()
    {
        this.Params = new Dictionary<string, object>();
        this.Params.Add("success", true);
    }

    public void Set(string key, object value)
    {
        if (Params.ContainsKey(key))
        {
            Params.Remove(key);
        }
        this.Params.Add(key, value);
    }



    public void SetError(object value)
    {
        Params.Remove("success");
        Params.Remove("error");
        this.Params.Add("success", false);
        this.Params.Add("error", value);
    }

    public bool GetBoolean(string key)
    {
        bool val = false;
        object data = this.Get(key);
        if (data != null)
        {
            bool.TryParse(data.ToString(), out val);
        }
        return val;
    }

    public string GetString(string key)
    {
        string val = null;
        object data = this.Get(key);
        if (data != null)
        {
            val = data.ToString();
        }
        return val;
    }

    public int GetInt(string key)
    {
        int val = 0;
        object data = this.Get(key);
        if (data != null)
        {
            int.TryParse(data.ToString(), out val);
        }
        return val;
    }

    public decimal GetDecimal(string key)
    {
        decimal val = 0;
        object data = this.Get(key);
        if (data != null)
        {
            decimal.TryParse(data.ToString(), out val);
        }
        return val;
    }

    public float GetFloat(string key)
    {
        float val = 0;
        object data = this.Get(key);
        if (data != null)
        {
            float.TryParse(data.ToString(), out val);
        }
        return val;
    }

    public double GetDouble(string key)
    {
        double val = 0;
        object data = this.Get(key);
        if (data != null)
        {
            double.TryParse(data.ToString(), out val);
        }
        return val;
    }

    public DateTime GetDateTime(string key)
    {
        DateTime val = default(DateTime);
        object data = this.Get(key);
        if (data != null)
        {
            DateTime.TryParse(data.ToString(), out val);
        }
        return val;
    }

    public object Get(string key)
    {
        object val = null;
        foreach (string k in this.Params.Keys)
        {
            if (k.Equals(key, StringComparison.OrdinalIgnoreCase))
            {
                val = this.Params[k];
                break;
            }
        }
        return val;
    }

    public T Get<T>(string key)
    {
        T val = default(T);
        string jsonStr = this.GetString(key);
        if (jsonStr != null)
        {
            val = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
        }
        return val;
    }

    public override string ToString()
    {
        return JsonData.JsonString(Params);
    }

    /// <summary>
    /// 将object转为Json字符串
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string JsonString(object obj)
    {
        DataSetConverter dataSetConverter = new DataSetConverter();
        DataTableConverter dataTableConverter = new DataTableConverter();

        JsonSerializer json = new JsonSerializer();
        json.ObjectCreationHandling = ObjectCreationHandling.Replace;
        json.MissingMemberHandling = MissingMemberHandling.Ignore;
        json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        json.Converters.Add(dataSetConverter);
        json.Converters.Add(dataTableConverter);
        StringBuilder sbJson = new StringBuilder();
        using (StringWriter writer = new StringWriter(sbJson))
        {
            json.Serialize(writer, obj);
        }
        string ps = sbJson.ToString();
        return ps;
    }

    /// <summary>
    /// 将Json字符串转为Dictionary
    /// </summary>
    /// <param name="jsonData"></param>
    /// <returns></returns>
    public static Dictionary<string, object> JsonToDictionary(string jsonData)
    {
        //实例化JavaScriptSerializer类的新实例
        JavaScriptSerializer jss = new JavaScriptSerializer();
        try
        {
            //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
            return jss.Deserialize<Dictionary<string, object>>(jsonData);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}