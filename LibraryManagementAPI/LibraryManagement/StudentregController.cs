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
    public class Studentreg : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(StudentregEntity entity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                List<KeyValuePair<string, string>> sqlParameters = new List<KeyValuePair<string, string>>();
                sqlParameters.Add(new KeyValuePair<string, string>("@sno", Convert.ToString(entity.sno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@firstname", entity.firstname));
                sqlParameters.Add(new KeyValuePair<string, string>("@lastname", entity.lastname));
                sqlParameters.Add(new KeyValuePair<string, string>("@regno", Convert.ToString(entity.regno)));
                sqlParameters.Add(new KeyValuePair<string, string>("@fathername", entity.fathername));
                sqlParameters.Add(new KeyValuePair<string, string>("@gender", entity.gender));
                sqlParameters.Add(new KeyValuePair<string, string>("@dataofbirth", entity.dataofbirth));
                sqlParameters.Add(new KeyValuePair<string, string>("@age", entity.age));
                sqlParameters.Add(new KeyValuePair<string, string>("@address", entity.address));
                sqlParameters.Add(new KeyValuePair<string, string>("@pincode", Convert.ToString(entity.pincode)));
                sqlParameters.Add(new KeyValuePair<string, string>("@collegename", entity.collegename));
                sqlParameters.Add(new KeyValuePair<string, string>("@course", entity.course));
                sqlParameters.Add(new KeyValuePair<string, string>("@department", entity.department));
                sqlParameters.Add(new KeyValuePair<string, string>("@emailid", entity.emailid));
                sqlParameters.Add(new KeyValuePair<string, string>("@password", entity.password));
                sqlParameters.Add(new KeyValuePair<string, string>("@confirmpassword", entity.confirmpassword));
                var result = manageSQL.InsertData("Insertintostudentreg", sqlParameters);
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
            ds = manageSQL.GetDataSetValues("Getstudentregs");
            return JsonConvert.SerializeObject(ds.Tables[0]);
        }
    }
    public class StudentregEntity
    {
        public int sno { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public int regno { get; set; }

        public string fathername { get; set; }
        public string gender { get; set; }
        public string dataofbirth { get; set; }
        public string age { get; set; }
        public string address { get; set; }
        public int pincode { get; set; }
        public string collegename { get; set; }
        public string course { get; set; }
        public string department { get; set; }
        public string emailid { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
    }
}




