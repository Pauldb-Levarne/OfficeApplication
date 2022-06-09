using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OfficeAppLevarne.Models
{
    public class Person
    {
        [PrimaryKey]
        [System.Text.Json.Serialization.JsonIgnore]
        public int Id { get; set; }
        public string name { get; set; }

    }
}
