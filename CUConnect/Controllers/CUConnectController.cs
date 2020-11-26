using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CUConnect.Models;
using Newtonsoft.Json;
using System.IO;

namespace CUConnect.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CUConnectController : ControllerBase
    {

        public List<Student> students = null;

        private readonly ILogger<CUConnectController> _logger;

        public CUConnectController(ILogger<CUConnectController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Student> Get()
        {
            StreamReader r = new StreamReader(@"C:\Users\corey\Desktop\CUConnect\CUConnect\Data\db.json");
            string json = r.ReadToEnd();
            students = JsonConvert.DeserializeObject<List<Student>>(json);
            return students;
        }

        [HttpPost]
        public List<Student> Post([FromBody] Student student)
        {
            StreamReader r = new StreamReader(@"C:\Users\corey\Desktop\CUConnect\CUConnect\Data\db.json");
            string json = r.ReadToEnd();
            students = JsonConvert.DeserializeObject<List<Student>>(json);
            List<DataStudent> newStudentList = new List<DataStudent>();
            foreach(Student s in students)
            {
                DataStudent data = new DataStudent(s.Uid, s.Username, 0, 0, s.Hobbies, s.Classes);
                newStudentList.Add(data);

            }
            DataStudent ds = new DataStudent(student.Uid, student.Username, 0, 0, student.Hobbies, student.Classes);
            CUConnect connector = new CUConnect(newStudentList, ds, students);
            return connector.MatchStudents();
        }
    }
}
