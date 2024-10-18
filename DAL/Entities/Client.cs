using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [PrimaryKey(nameof(Code))]
    public class Client
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        public CLientClass CLientClass { get; set; }
        [Required]
        public State State { get; set; }
        
        public ICollection<ClientProduct>? ClientProducts { get; set; }

    }


    public enum CLientClass { 
        A,
        B,
        C
    };

    public enum State { 
        ACTIVE,
        INACTIVE,
        PENDING
    }

}
