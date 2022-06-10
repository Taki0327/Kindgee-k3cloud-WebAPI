using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleApplication.WebAPI
{
    public static class InvokeHelper
    {
        private static string CloudUrl = "http://127.0.1/K3Cloud/";//K/3 Cloud 业务站点地址

        /// <summary>
        /// 登陆
        /// </summary>
        public static string Login()
        {
            HttpClient httpClient = new HttpClient();
            //第三方授权登录
            //httpClient.Url = string.Concat(CloudUrl, "Kingdee.BOS.WebApi.ServicesStub.AuthService.LoginByAppSecret.common.kdsvc");
            //账号密码登录
            httpClient.Url = string.Concat(CloudUrl, "Kingdee.BOS.WebApi.ServicesStub.AuthService.ValidateUser.common.kdsvc");


            List<object> Parameters = new List<object>
            {
                "efnsklfheo",//账套标示
                "administrator",//用户名
                "",//密码
                //"",//应用ID
                //"",//应用秘钥
                2052//2052代表中文
            };
            httpClient.Content = JsonConvert.SerializeObject(Parameters);

            return httpClient.SysncRequest();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Save(string formId, string content)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Url = string.Concat(CloudUrl, "Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save.common.kdsvc");

            List<object> Parameters = new List<object>
            {
                //业务对象Id 
                formId,
                //Json字串
                content
            };
            httpClient.Content = JsonConvert.SerializeObject(Parameters);
            return httpClient.SysncRequest();
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Submit(string formId, string content)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Url = string.Concat(CloudUrl, "Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Submit.common.kdsvc");

            List<object> Parameters = new List<object>();
            //业务对象Id 
            Parameters.Add(formId);
            //Json字串
            Parameters.Add(content);
            httpClient.Content = JsonConvert.SerializeObject(Parameters);
            return httpClient.SysncRequest();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Delete(string formId, string content)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Url = string.Concat(CloudUrl, "Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Delete.common.kdsvc");

            List<object> Parameters = new List<object>();
            //业务对象Id 
            Parameters.Add(formId);
            //Json字串
            Parameters.Add(content);
            httpClient.Content = JsonConvert.SerializeObject(Parameters);
            return httpClient.SysncRequest();
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Audit(string formId, string content)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Url = string.Concat(CloudUrl, "Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Audit.common.kdsvc");

            List<object> Parameters = new List<object>();
            //业务对象Id 
            Parameters.Add(formId);
            //Json字串
            Parameters.Add(content);
            httpClient.Content = JsonConvert.SerializeObject(Parameters);
            return httpClient.SysncRequest();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string View(string formId, string content)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Url = string.Concat(CloudUrl, "Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.View.common.kdsvc");

            List<object> Parameters = new List<object>
            {
                //业务对象Id 
                formId,
                //Json字串
                content
            };
            httpClient.Content = JsonConvert.SerializeObject(Parameters);
            return httpClient.SysncRequest();
        }

        /// <summary>
        /// 自定义
        /// </summary>
        /// <param name="key">自定义方法标识</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public static string AbstractWebApiBusinessService(string key, List<object> args)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Url = string.Concat(CloudUrl, key, ".common.kdsvc");

            httpClient.Content = JsonConvert.SerializeObject(args);
            return httpClient.SysncRequest();
        }
    }
}
