using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementAPI.LibraryManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class Forget : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(ForgetEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@email", entity.email));
                
                var result = manageSQL.InsertData("insertintoforget", sqlParameters);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
        [HttpGet]
        public string Get()
        {
            ManageSQLConnection manageSQL = new ManageSQLConnection();
            DataSet ds = new DataSet();
            ds = manageSQL.GetDataSetValues("Getforget");
            return JsonConvert.SerializeObject(ds.Tables[0]);
        }
    }
    public class ForgetEntity
    {
        public int sno { get; set; }
        public string email { get; set; }
       

    }
}
