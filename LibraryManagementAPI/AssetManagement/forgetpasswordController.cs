using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementAPI.AssetManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class forgetpassword : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(forgetpasswordEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@employeeid", Convert.ToString(entity.employeeid)));
                sqlParameters.Add(new KeyValuePair<string, string>("@name", entity.name));
                sqlParameters.Add(new KeyValuePair<string, string>("@oldpassword", entity.oldpassword));
                sqlParameters.Add(new KeyValuePair<string, string>("@newpasssword", entity.newpasssword));
                var result = manageSQL.InsertData("Insertforgetpassword", sqlParameters);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                //AuditLog.WriteError(ex.Message);
            }
            return "false";
        }
        [HttpGet]
        public string Get()
        {
            ManageSQLConnection manageSQL = new ManageSQLConnection();
            DataSet ds = new DataSet();
            ds = manageSQL.GetDataSetValues("Getfp");
            return JsonConvert.SerializeObject(ds.Tables[0]);
        }
    }
    public class forgetpasswordEntity
    {
        public int sno { get; set; }
        public int employeeid { get; set; }
        public string name { get; set; }
        public string oldpassword { get; set; }
        public string newpasssword { get; set; }
        
    }
}

