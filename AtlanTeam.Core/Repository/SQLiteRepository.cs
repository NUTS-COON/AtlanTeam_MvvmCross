using System.Linq;
using AtlanTeam.Core.Models;
using SQLite;

namespace AtlanTeam.Core.Repository
{
    public class SQLiteRepository : ISQLiteRepository
    {
        public const string DATABASE_NAME = "MyDatabase.db";

        ISQLite _sqlite;
        SQLiteConnection database;

        public SQLiteRepository(ISQLite SQLite)
        {
            _sqlite = SQLite;
            string databasePath = _sqlite.GetDatabasePath(DATABASE_NAME);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Post>();
            database.CreateTable<Comment>();
        }

        public T GetObject<T>() where T : new()
        {
            var list = (from i in database.Table<T>() select i).ToList();
            if (list.Count > 0) { return list[0]; }
            else return default(T);
        }

        public void SaveObject<T>(T obj)
        {
            database.DeleteAll<T>();
            database.Insert(obj);
        }
    }
}
