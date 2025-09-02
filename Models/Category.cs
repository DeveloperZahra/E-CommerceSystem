using System.ComponentModel.DataAnnotations;

namespace E_CommerceSystem.Models
{
    public class Category
    {
        [Key] 
        public int CategoryId { get; set; }  // Marks CategoryId as the Primary Key for the Category table

        // Makes Name a required field (NOT NULL) 
        // and limits the string length to 100 characters

        [Required, StringLength(100)]
        public string Name { get; set; } = null!;

        // Optional (nullable) field for Description 
        // with a maximum length of 500 characters

        [StringLength(500)]
        public string? Description { get; set; }

        // Navigation property:
        // Defines a one-to-many relationship 
        // (One Category can have many Products)
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
