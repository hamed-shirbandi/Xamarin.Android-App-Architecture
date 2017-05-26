using SQLite;

namespace DataAccess.Domain
{
    public class Setting
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool SyncEnabled { get; set; }
    }
}
