using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingAssignment.Models
{
    public class Task
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
		[Display(Name = "Due Date")]
		[DataType(DataType.Date)]
        [Column("due_date")]
        public DateTime DueDate { get; set; }
		[Display(Name = "Assigned user")]
        [Column("assigned_user")]
        public string AssignedUser { get; set; }
		[Display(Name = "Project")]
        [Column("project_id")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
