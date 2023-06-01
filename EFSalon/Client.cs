using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFSalon
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("surname")]
        public string surname { get; set; }
        [Column("gender")]
        public string gender { get; set; }
    }
}
