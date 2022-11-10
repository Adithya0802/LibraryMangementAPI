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
    public class BookIssues : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(BookIssuesEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@bookid", Convert.ToString(entity.bookid)));
                sqlParameters.Add(new KeyValuePair<string, string>("@bookname ", entity.bookname));
                sqlParameters.Add(new KeyValuePair<string, string>("@studentregno ", Convert.ToString(entity.studentregno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@issueinfo ", entity.issueinfo));
                sqlParameters.Add(new KeyValuePair<string, string>("@Borrowdate ", entity.Borrowdate));
                sqlParameters.Add(new KeyValuePair<string, string>("@issuedate ", entity.issuedate));
                sqlParameters.Add(new KeyValuePair<string, string>("@externdate ", entity.externdate));
                var result = manageSQL.InsertData("Insertintobookissues", sqlParameters);
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
            ds = manageSQL.GetDataSetValues("Getbookissues");
            return JsonConvert.SerializeObject(ds.Tables[0]);
        }
    }
    public class BookIssuesEntity
    {
        public int sno { get; set; }
        public int bookid { get; set; }
        public string bookname { get; set; }

        public int studentregno { get; set; }

        public string issueinfo { get; set; }
        public string Borrowdate { get; set; }
        public string issuedate { get; set; }
        public string externdate { get; set; }

    }
}
