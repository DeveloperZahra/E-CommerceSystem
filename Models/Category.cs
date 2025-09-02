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
    }
}
