using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskRobo.Models
{
    public class UserTask
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskContent { get; set; }
        public string TaskStatus { get; set; }      
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
