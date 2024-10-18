using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [PrimaryKey(nameof(ClientCode),nameof(ProductId))]
    public class ClientProduct
    {
        public int ClientCode { get; set; }
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }
        public Client?  Client  { get; set; }

        [StringLength(255)]
        [Required]
        public string? License { get; set; }
        [Required]
        public DateOnly StartData { get; set; }
        [Required]
        public DateOnly EndData { get; set; }

    }
}
