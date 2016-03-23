using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace XamarinFormsWithAzure.Models
{
    public class Users
    {
        [JsonProperty("Id")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
