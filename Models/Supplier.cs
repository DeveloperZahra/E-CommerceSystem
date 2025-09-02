using System.ComponentModel.DataAnnotations;

namespace E_CommerceSystem.Models
{
    public class Supplier
    {
        // [Key] → Marked SupplierId as the Primary Key for the Supplier entity

        [Key]
        public int SupplierId { get; set; }
    }
}
