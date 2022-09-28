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
    public class ItRegister : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(ItRegistrationEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.Sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@name", entity.Name));
                sqlParameters.Add(new KeyValuePair<string, string>("@employeeid", Convert.ToString(entity.EmployeeId)));
                sqlParameters.Add(new KeyValuePair<string, string>("@email", entity.Email));
                sqlParameters.Add(new KeyValuePair<string, string>("@ppassword",entity.ppassword));
                sqlParameters.Add(new KeyValuePair<string, string>("@cpassword", entity.cpassword));
                var result = manageSQL.InsertData("Insertitregistration", sqlParameters);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                //AuditLog.WriteError(ex.Message);
            }
            return "false";
        }
    }
    public class ItRegistrationEntity
    {
        public int EmployeeId { get; set; }
        public int Sno { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ppassword { get; set; }
        public string cpassword { get; set; }

    }
}
