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
    public class dongle : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(dongleEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@donglecompanyname", entity.donglecompanyname));
                sqlParameters.Add(new KeyValuePair<string, string>("@donglenumber", Convert.ToString(entity.donglenumber)));
                sqlParameters.Add(new KeyValuePair<string, string>("@dongleimeino", entity.dongleimeino));
                sqlParameters.Add(new KeyValuePair<string, string>("@donglepurchasedlocation", entity.donglepurchasedlocation));
                sqlParameters.Add(new KeyValuePair<string, string>("@users", entity.users));
                sqlParameters.Add(new KeyValuePair<string, string>("@donglelastuser", entity.donglelastuser));
                sqlParameters.Add(new KeyValuePair<string, string>("@donglestatus", entity.donglestatus));


                var result = manageSQL.InsertData("Insert", sqlParameters);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                //AuditLog.WriteError(ex.Message);
            }
            return "false";
        }
    }
    public class dongleEntity
    {
        public int sno { get; set; }
        public string donglecompanyname { get; set; }
        public int donglenumber { get; set; }
        public string dongleimeino { get; set; }
        public string donglepurchasedlocation { get; set; }

        public string users { get; set; }

        public string donglelastuser { get; set; }

        public string donglestatus { get; set; }
    }
}
