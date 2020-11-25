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
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(json);
            return students;
        }

        [HttpPost]
        public void Post([FromBody] Student student)
        {
            int x = 1;
            Console.WriteLine(student.ToString());
        }
    }
}
