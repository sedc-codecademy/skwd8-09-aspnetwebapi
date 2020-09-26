using First_Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace First_Api
{
    public static class Database
    {
        private static string _dbDirectory = Path.Combine(Directory.GetCurrentDirectory(), "DB");
        private static string _dbPath = Path.Combine(_dbDirectory, "Db.json");

        public static List<User> GetAllUsers()
        {
            List<User> users;
            using( StreamReader sr = new StreamReader(_dbPath))
            {
                string usersInJsonFormat = sr.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(usersInJsonFormat);
            }
            return users;
        }

        public static void UpdateDatabase(List<User> users)
        {
            var usersInJsonFormat = JsonConvert.SerializeObject(users);
            File.WriteAllText(_dbPath, usersInJsonFormat);
        }

    }
}
