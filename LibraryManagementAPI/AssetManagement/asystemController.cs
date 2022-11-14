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
    public class asystem : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(asystemEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@assetid", Convert.ToString(entity.assetid)));
                sqlParameters.Add(new KeyValuePair<string, string>("@dateofpurchase", entity.dateofpurchase));
                sqlParameters.Add(new KeyValuePair<string, string>("@shopname", entity.shopname));
                sqlParameters.Add(new KeyValuePair<string, string>("@ram", Convert.ToString(entity.ram)));
                sqlParameters.Add(new KeyValuePair<string, string>("@harddisk", Convert.ToString(entity.harddisk)));
                sqlParameters.Add(new KeyValuePair<string, string>("@monitor", entity.monitor));
                sqlParameters.Add(new KeyValuePair<string, string>("@qty", Convert.ToString(entity.qty)));
                sqlParameters.Add(new KeyValuePair<string, string>("@state", entity.state));
                sqlParameters.Add(new KeyValuePair<string, string>("@amount", Convert.ToString(entity.amount)));
                sqlParameters.Add(new KeyValuePair<string, string>("@personusing", entity.personusing));
                sqlParameters.Add(new KeyValuePair<string, string>("@os", entity.os));
                sqlParameters.Add(new KeyValuePair<string, string>("@antivirusexpirydate", entity.antivirusexpirydate));
                sqlParameters.Add(new KeyValuePair<string, string>("@systemlastuser", entity.systemlastuser));
                var result = manageSQL.InsertData("Insertasystem", sqlParameters);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                //AuditLog.WriteError(ex.Message);
            }
            return "false";
        }
    }
    public class asystemEntity
    {
        public int sno { get; set; }
        public int assetid { get; set; }
        public string dateofpurchase { get; set; }
        public string shopname { get; set; }

        public int ram { get; set; }
        public int harddisk { get; set; }

        public string monitor { get; set; }

        public int qty { get; set; }

        public string state { get; set; }
        public int amount { get; set; }
        public string personusing { get; set; }

        public string os { get; set; }

        public string antivirusexpirydate { get; set; }

        public string systemlastuser { get; set; }


    }
}
