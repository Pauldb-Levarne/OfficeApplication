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
    public class Week
    {
        [PrimaryKey]
        [System.Text.Json.Serialization.JsonIgnore]
        public string id { get; set; }

        [JsonPropertyName("id")]
        public string WeekId { get; set; }

        [TextBlob("blobbedDays")]
        public List<Day> days { get; set; }

    }
}
