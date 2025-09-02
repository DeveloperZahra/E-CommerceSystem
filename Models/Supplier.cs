using System.ComponentModel.DataAnnotations;

namespace E_CommerceSystem.Models
{
    public class Supplier
    {
        // [Key] → Marked SupplierId as the Primary Key for the Supplier entity

        [Key]
        public int SupplierId { get; set; }

        // [Required, StringLength(150)] → Made Name mandatory (NOT NULL) with max length 150 characters

        [Required, StringLength(150)]
        public string Name { get; set; } = null!;
    }
}
