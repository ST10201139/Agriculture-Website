using System.ComponentModel.DataAnnotations;

namespace AgriConnectPlatformProject.Models
{
    public class Products
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        [Required]
        public int FarmerId { get; set; }

    }
}
