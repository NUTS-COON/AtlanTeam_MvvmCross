using SQLite;

namespace AtlanTeam.Core.Models
{
    [Table("Posts")]
    public class Post
    {
        [PrimaryKey]
        public int UserId { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
