using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserMicroservice.Models
{
    [Table("User")]
    public class User
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        public string? Name { get; set; }

        [Column("Email")]
        [EmailAddress]
        public string? Email { get; set; }
    }
}