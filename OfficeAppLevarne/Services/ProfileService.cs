using OfficeAppLevarne;
using OfficeAppLevarne.Models;
using OfficeAppLevarne.Repository;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OfficeAppLevarne.Services
{


    public class ProfileService
    {
        Database db = new();
        public Person GetPerson()
        {
            return db.getPerson();
        }
        public void updatePerson(Person person)
        {
            db.UpdatePerson(person);
        }
    }
}
