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
    public class office : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(officeEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@computername", entity.computername));
                sqlParameters.Add(new KeyValuePair<string, string>("@username", entity.username));
                sqlParameters.Add(new KeyValuePair<string, string>("@installeddate", entity.installeddate));
                sqlParameters.Add(new KeyValuePair<string, string>("@officelastuser", entity.officelastuser));
                var result = manageSQL.InsertData("Insertoffice", sqlParameters);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                //AuditLog.WriteError(ex.Message);
            }
            return "false";
        }
    }
    public class officeEntity
    {
        public int sno { get; set; }
        public string computername { get; set; }
        public string username { get; set; }
        public string installeddate { get; set; }
        public string officelastuser { get; set; }


    }
}
