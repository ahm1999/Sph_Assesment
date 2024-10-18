

using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public  class Product
    {

        public Guid ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(150)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public bool IsActive { get; set; } 
    }
}
