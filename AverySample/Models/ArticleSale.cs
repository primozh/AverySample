using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AverySample.Models
{
    public class ArticleSale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(32)]
        [Required]
        public string ArticleId { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Currency { get; set; } = "EUR";
    }
}
