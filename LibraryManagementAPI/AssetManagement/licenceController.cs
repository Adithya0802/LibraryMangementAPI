using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                sqlParameters.Add(new KeyValuePair<string, string>("@machinename", entity.machinename));
                sqlParameters.Add(new KeyValuePair<string, string>("@oslastusers", entity.oslastusers));
                var result = manageSQL.InsertData("Insertlicence", sqlParameters);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                //AuditLog.WriteError(ex.Message);
            }
            return "false";
        }
    }
    public class licenceEntity
    {
        public int sno { get; set; }
        public string name { get; set; }
        public string productkey { get; set; }
        public string machinename { get; set; }
        public string oslastusers { get; set; }


    }
}
