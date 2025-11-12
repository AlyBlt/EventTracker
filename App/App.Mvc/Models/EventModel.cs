using System.ComponentModel.DataAnnotations;

namespace App.Mvc.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
