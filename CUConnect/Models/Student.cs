using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CUConnect.Models
{
    public partial class Student
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("UID")]
        public int Uid { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("classes")]
        public List<string> Classes { get; set; }

        [JsonProperty("hobbies")]
        public List<string> Hobbies { get; set; }

        [JsonProperty("connections")]
        public List<object> Connections { get; set; }
    }
}
