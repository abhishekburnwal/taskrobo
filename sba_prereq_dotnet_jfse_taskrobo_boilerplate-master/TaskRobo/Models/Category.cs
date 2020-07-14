using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskRobo.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }

        public string UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}
