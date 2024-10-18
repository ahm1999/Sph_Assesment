using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace DTOs.ClientDTOS
{
    public class CreateCLientDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public CLientClass CLientClass { get; set; } = CLientClass.A;
        [Required]
        public State State { get; set; } = State.ACTIVE;
    }
}
