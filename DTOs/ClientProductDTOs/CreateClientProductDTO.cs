using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.ClientProductDTOs
{
    public class CreateClientProductDTO
    {
        [Required]
        public int ClientCode { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [StringLength(255)]
        [Required]
        public string? License { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly StartData { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly EndData { get; set; }
    }
}
