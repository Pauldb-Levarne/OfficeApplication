using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeAppLevarne.Models
{
    public class Day
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string note { get; set; }
        public bool available { get; set; }
        public string name { get; set; }
        public int capacity { get; set; }

        [TextBlob("blobbedPersons")]
        public List<Person> persons { get; set; }

    }
}
