using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LibraryManagementAPI.LibraryManagement
{
    [Route("api/[controller]")]
    [ApiController]

    public class BookController : Controller
    {
        [HttpPost("{id}")]
        public string Post(bookEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@subject", entity.subject));
                sqlParameters.Add(new KeyValuePair<string, string>("@title", entity.title));
                sqlParameters.Add(new KeyValuePair<string, string>("@author", entity.author));
                sqlParameters.Add(new KeyValuePair<string, string>("@name", entity.name));
                sqlParameters.Add(new KeyValuePair<string, string>("@date", entity.date));
                sqlParameters.Add(new KeyValuePair<string, string>("@copies", Convert.ToString(entity.copies)));
                sqlParameters.Add(new KeyValuePair<string, string>("@shelf", Convert.ToString(entity.shelf)));
                


                var result = manageSQL.InsertData("insertintobook", sqlParameters);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
        [HttpGet]
        public string Get()
        {
            ManageSQLConnection manageSQL = new ManageSQLConnection();
            DataSet ds = new DataSet();
            ds = manageSQL.GetDataSetValues("Getbook");
            return JsonConvert.SerializeObject(ds.Tables[0]);
        }

    }


    public class bookEntity
    {
        public int sno { get; set; }

        public string subject { get; set; }

        public string title { get; set; }

        public string author { get; set; }

        public string name { get; set; }

        public string date { get; set; }

        public string copies { get; set; }

        public string shelf { get; set; }

       
    }
}

