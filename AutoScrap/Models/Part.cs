using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoScrap.Models
{
    public class Part
    {
        [Key]
        public int Part_Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string? Title { get; set; }

        [Display(Name = "Manufacture Date")]
        [DataType(DataType.Date)]
        public DateTime ManufactureeDate { get; set; }
        public string? System { get; set; }

        public string? Condition { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
