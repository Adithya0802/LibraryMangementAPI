using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementAPI.LibraryManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class setting : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(SettingEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@firstname", entity.firstname));
                sqlParameters.Add(new KeyValuePair<string, string>("@lastname  ", entity.lastname));
                sqlParameters.Add(new KeyValuePair<string, string>("@email ", entity.email));
                sqlParameters.Add(new KeyValuePair<string, string>("@phoneno ", Convert.ToString(entity.phoneno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@oldpassword ", entity.oldpassword));
                sqlParameters.Add(new KeyValuePair<string, string>("@newpassword ", entity.newpassword));
                sqlParameters.Add(new KeyValuePair<string, string>("@confirmpassword ", entity.confirmpassword));

                var result = manageSQL.InsertData("Insertintosettings", sqlParameters);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                //AuditLog.WriteError(ex.Message);
            }
            return "false";
        }
    }
    public class SettingEntity
    {
        public int sno { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public string email { get; set; }

        public int phoneno { get; set; }

        public string oldpassword { get; set; }

        public string newpassword { get; set; }

        public string confirmpassword { get; set; }

    }
}
