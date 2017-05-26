using SQLite;

namespace DataAccess.Domain
{
    public class History
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
