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
    public class licence : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(licenceEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@name", entity.name));
                sqlParameters.Add(new KeyValuePair<string, string>("@productkey", entity.productkey));
                sqlParameters.Add(new KeyValuePair<string, string>("@oscurrentuser", entity.oscurrentuser));
                sqlParameters.Add(new KeyValuePair<string, string>("@oslastuser", entity.oslastuser));
                var result = manageSQL.InsertData("Insertlicense", sqlParameters);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                //AuditLog.WriteError(ex.Message);
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
        [HttpGet]
        public string Get()
        {
            ManageSQLConnection manageSQL = new ManageSQLConnection();
            DataSet ds = new DataSet();
            ds = manageSQL.GetDataSetValues("Getlicense");
            return JsonConvert.SerializeObject(ds.Tables[0]);
        }
    }
    public class licenceEntity
    {
        public int sno { get; set; }
        public string name { get; set; }
        public string productkey { get; set; }
        public string oscurrentuser { get; set; }
        public string oslastuser { get; set; }


    }
}
