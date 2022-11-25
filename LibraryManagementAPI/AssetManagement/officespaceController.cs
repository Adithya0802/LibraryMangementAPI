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
    public class officespace : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(officespaceEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@officelocation", entity.officelocation));
                sqlParameters.Add(new KeyValuePair<string, string>("@seatno", entity.seatno));
                sqlParameters.Add(new KeyValuePair<string, string>("@officename", entity.officename));
                sqlParameters.Add(new KeyValuePair<string, string>("@assetnumber ", Convert.ToString(entity.assetnumber)));
                sqlParameters.Add(new KeyValuePair<string, string>("@occupiedseat ", entity.occupiedseat));
                var result = manageSQL.InsertData("Insertofficespace", sqlParameters);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                //AuditLog.WriteError(ex.Message);
            }
            return "false";
        }
        [HttpGet]
        public string Get()
        {
            ManageSQLConnection manageSQL = new ManageSQLConnection();
            DataSet ds = new DataSet();
            ds = manageSQL.GetDataSetValues("Getofficespace");
            return JsonConvert.SerializeObject(ds.Tables[0]);
        }
    }
    public class officespaceEntity
    {
        public int sno { get; set; }
        public string officelocation { get; set; }
        public string seatno { get; set; }
        public string officename { get; set; }

        public int assetnumber { get; set; }

        public string occupiedseat { get; set; }



    }
}
