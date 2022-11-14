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
    public class printer : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(printerEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@printername", entity.printername));
                sqlParameters.Add(new KeyValuePair<string, string>("@printermodel", entity.printermodel));
                sqlParameters.Add(new KeyValuePair<string, string>("@dateofpurchased", entity.dateofpurchased));
                sqlParameters.Add(new KeyValuePair<string, string>("@printerstatus", entity.printerstatus));
                sqlParameters.Add(new KeyValuePair<string, string>("@printerlocation", entity.printerlocation));
                var result = manageSQL.InsertData("Insertprinter", sqlParameters);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                //AuditLog.WriteError(ex.Message);
            }
            return "false";
        }
    }
    public class printerEntity
    {
        public int sno { get; set; }
        public string printername { get; set; }
        public string printermodel { get; set; }
        
        public string dateofpurchased { get; set; }

        public string printerstatus { get; set; }

        public string printerlocation { get; set; }


    }
}
