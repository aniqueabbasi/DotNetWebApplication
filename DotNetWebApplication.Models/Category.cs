using System.ComponentModel.DataAnnotations;

namespace DotNetWebApplication.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(18, 100)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public int DisplayOrder { get; set; }
    }
}