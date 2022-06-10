using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Kingdee.BOS.App.Data;
using Kingdee.BOS.ServiceFacade.KDServiceFx;
using Kingdee.BOS.ServiceHelper;
using Kingdee.BOS.WebApi.ServicesStub;
using Newtonsoft.Json.Linq;

namespace KingdeeWebAPI
{
    public class Test : AbstractWebApiBusinessService

    {
        public Test(KDServiceContext context) : base(context)
        {
        }
        /// <summary>
        /// 拼接JSON返回体
        /// </summary>
        /// <param name="code">http状态</param>
        /// <param name="data">数据</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
		public JObject Result(string code,JArray data,string msg)
        {
            return new JObject
            {
                { "code", code },
                { "data", data },
                { "message", msg }
            };
        }
        /// <summary>
        ///返回C#数据集对象
        /// </summary>
        /// <param name="parameter">请求参数</param>
        /// <param name="sql">查询语句</param>
        /// <returns></returns>
        public object Execute(JObject parameter,string sql)
        {
            try
            {
                //返回内容
                if (MyConvert.ToString(parameter["msg"]) != "getdata")
                {
                    return Result("500", null, "请求参数为空 请重新输入");
                }
                else
                {
                    return DBServiceHelper.ExecuteDataSet(this.KDContext.Session.AppContext, string.Format("/*dialect*/" + sql, parameter["lasttime"]));
                }
            }
            catch (Exception)
            {
                return Result("501", null, "查询出错");
            }
        }
        
        /// <summary>
        /// 供应商
        /// </summary>
        /// <param name="parameter">json参数</param>
        /// <returns></returns>
        public object SupplierExecute(JObject parameter)
        {
            return Execute(parameter, SQL.Supplier);
        }
    }
}
