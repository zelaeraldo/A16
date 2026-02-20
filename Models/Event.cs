using System;
using System.ComponentModel.DataAnnotations;

namespace A16.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        public TimeSpan Time{ get; set; }
        public int Capacity { get; set; }
        public EventCategory Category { get; set; }
      

        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [MaxLength(200)]
        public Location Location { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
