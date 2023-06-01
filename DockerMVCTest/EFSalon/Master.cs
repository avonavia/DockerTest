using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFSalon
{
    [Table("Masters")]
    public class Master
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
