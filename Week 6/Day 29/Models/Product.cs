using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
   
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

      [Required(ErrorMessage = "Please enter valid name")]
     
    [StringLength(15, MinimumLength=5) ]
    public string Name { get; set; }
    [Required]
    [StringLength(15, MinimumLength = 5)]
    public string Category { get; set; }
    [Required]
    public int Price { get; set; }

    }
}
