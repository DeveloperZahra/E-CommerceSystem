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


        // [EmailAddress, StringLength(200)] → Added validation for ContactEmail to ensure valid email format with max length 200

        [EmailAddress, StringLength(200)]
        public string? ContactEmail { get; set; }

    }
}
