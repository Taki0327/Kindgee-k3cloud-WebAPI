using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApplication.WebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoke();
        }
        private static void Invoke()
        {
            var result = InvokeHelper.Login();
            var iResult = JObject.Parse(result)["LoginResultType"].Value<int>();
            if (iResult == 1 || iResult == -5)
            {
                var result2 = InvokeHelper.AbstractWebApiBusinessService("KingdeeWebAPI.Test.SupplierExecute,KingdeeWebAPI", new List<object>
                        {
                            JsonConvert.SerializeObject(
                            new JObject
                            {
                                { "msg", "getdata" },
                                { "lasttime","2022-05-10 12:13:07.140" }
                            })
                        });
                var abc = JsonConvert.DeserializeObject<DataSet>(result2);
                Console.WriteLine(result2);
            }
            else
            {
                Console.WriteLine("login failed");
            }
            Console.ReadKey();
        }
    }
}
