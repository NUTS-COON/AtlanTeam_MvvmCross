using System;
using System.IO;
using AtlanTeam.Core.Repository;
namespace AtlanTeam.Droid
{
    public class SQLite_Android : ISQLite
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            Directory.CreateDirectory(documentsPath);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}