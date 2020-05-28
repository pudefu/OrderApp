using Microsoft.AspNetCore.Mvc;
using OrderApp.Code;
using System;

namespace OrderApp.Controllers
{
    [ApiController]
    [Route("/")]
    public class FirstDockerController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello Jenkins Docker!";
        }

        [HttpGet("/getconfig")]
        public ActionResult GetConfig()
        {
            //读取Appsettings节点配置
            var config = AppConfigurtaionServices.GetSectionObject<Appsettings>("Appsettings");
            return new JsonResult(config);
            //返回：{"systemName":"PDF .NET CORE","date":"2017-07-23T00:00:00","author":"PDF"}
        }

        [HttpGet("/getAllConfig")]
        public ActionResult GetAllConfig()
        {
            //读取整个配置文件的配置
            var config = AppConfigurtaionServices.GetSectionObject<AppsettingConfig>();
            return new JsonResult(config);
            //返回：{"connectionStrings":{"cxyOrder":"Server=LAPTOP-AQUL6MDE\\MSSQLSERVERS;Database=CxyOrder;User ID=sa;Password=123456;Trusted_Connection=False;"},"appsettings":{"systemName":"PDF .NET CORE","date":"2017-07-23T00:00:00","author":"PDF"},"serviceUrl":"https://www.baidu.com/getnews"}
        }
    }
    public class Appsettings
    {
        public string SystemName { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
    }

    public class ConnectionStrings
    {
        public string CxyOrder { get; set; }
    }

    public class AppsettingConfig
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public Appsettings Appsettings { get; set; }

        public string ServiceUrl { get; set; }
    }
}
