using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeAppLevarne.Models
{
    public class Weeks
    {
        [TextBlob("blobbedWeeks")]
        public List<Week> weeks { get; set;}
    }
}
