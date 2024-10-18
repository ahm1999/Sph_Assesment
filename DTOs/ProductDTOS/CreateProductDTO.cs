

using System.ComponentModel.DataAnnotations;

namespace DTOs.ProductDTOS
{
    public class CreateProductDTO
    {
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
