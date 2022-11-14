using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementAPI.LibraryManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetails : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(BookDetailsEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@studentname", entity.studentname));
                sqlParameters.Add(new KeyValuePair<string, string>("@studentregno", Convert.ToString(entity.studentregno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@bookcategory", entity.bookcategory));
                sqlParameters.Add(new KeyValuePair<string, string>("@bookname ", entity.bookname));
                sqlParameters.Add(new KeyValuePair<string, string>("@authorname", entity.authorname));
                sqlParameters.Add(new KeyValuePair<string, string>("@publishdate", entity.publishdate));
                var result = manageSQL.InsertData("Insertintobookregisters", sqlParameters);
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
            ds = manageSQL.GetDataSetValues("Getbookdetails");
            return JsonConvert.SerializeObject(ds.Tables[0]);
        }
    }
    public class BookDetailsEntity
    {
        public int sno { get; set; }
        public string studentname { get; set; }
        public int studentregno { get; set; }
        public string bookcategory { get; set; }
        public string bookname { get; set; }
        public string authorname { get; set; }
        public string publishdate { get; set; }

    }
}
