using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Songs
    {
        [Key]
        public int SongId { get; set; }
        public string SongName { get; set; }
    }
}