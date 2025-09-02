using System.ComponentModel.DataAnnotations;

namespace E_CommerceSystem.Models
{
    public class Category
    {
        [Key] 
        public int CategoryId { get; set; }  // Marks CategoryId as the Primary Key for the Category table
    }
}
