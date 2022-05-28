using OfficeAppLevarne;
using OfficeAppLevarne.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeAppLevarne.Repository
{
    public class Database
    {
        private readonly SQLiteConnection _database;

        public Database()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "levarne-office-app.db");
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Week>();
        }

        public List<Week> List()
        {
            return _database.Table<Week>().ToList();
        }

        public int Create(Week entity)
        {
            return _database.Insert(entity);
        }

        public int Update(Week entity)
        {
            return _database.Update(entity);
        }

        public int Delete(Week entity)
        {
            return _database.Delete(entity);
        }
    }
}
