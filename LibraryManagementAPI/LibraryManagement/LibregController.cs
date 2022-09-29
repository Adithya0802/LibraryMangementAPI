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
    public class Libreg : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(LibregEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@yourname", entity.yourname));
                sqlParameters.Add(new KeyValuePair<string, string>("@youremail ", entity.youremail));
                sqlParameters.Add(new KeyValuePair<string, string>("@password ", entity.password));
                sqlParameters.Add(new KeyValuePair<string, string>("@repeatpassword ", entity.repeatpassword));
                var result = manageSQL.InsertData("insertintolibrarianreg", sqlParameters);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                //AuditLog.WriteError(ex.Message);
            }
            return "false";
        }
    }
    public class LibregEntity
    {
        public int sno { get; set; }
        public string yourname { get; set; }
        public string youremail { get; set; }

        public string password { get; set; }

        public string repeatpassword { get; set; }

    }
}
