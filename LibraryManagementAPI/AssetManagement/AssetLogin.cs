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
    public class AssetLogin : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(AssestEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.AssestID)));
                sqlParameters.Add(new KeyValuePair<string, string>("@EmployeeId", Convert.ToString(entity.EmployeeId)));
                sqlParameters.Add(new KeyValuePair<string, string>("@passwordp", entity.password));
                var result = manageSQL.InsertData("InsertAssetLogin", sqlParameters);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                //AuditLog.WriteError(ex.Message);
            }
            return "false";
        }
    }
    public class AssestEntity
    {
        public int EmployeeId { get; set; }
        public int AssestID { get; set; }
        public string password { get; set; }

    }
}
