namespace AtlanTeam.Core.Repository
{
    public interface ISQLiteRepository
    {
        T GetObject<T>() where T : new();
        void SaveObject<T>(T obj);
    }
}
