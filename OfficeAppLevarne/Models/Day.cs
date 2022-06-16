using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OfficeAppLevarne.Models
{
    public class Day
    {

        [PrimaryKey]
        [JsonIgnore]
        public int Id { get; set; }
        public string note { get; set; }
        public bool available { get; set; }
        public string name { get; set; }
        public int capacity { get; set; }

        [TextBlob("blobbedPersons")]
        public List<Person> persons { get; set; }

        [JsonIgnore]
        public int spotsAvailable => capacity - persons.Count;

        [JsonIgnore]
        public string ButtonText => $"{name} - ({spotsAvailable}) available spots";

        [JsonIgnore]
        public string weekId { get; set; }

    }
}
