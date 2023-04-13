using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingAssignment.Models
{
	public class Project
	{
		[Column("id")]
		public int Id { get; set; }
		[Column("name")]
		public string Name { get; set; }
		[Column("description")]
		public string Description { get; set; }
		[Column("sale_price")]
		[Display(Name = "Sale Price")]
		public int SalePrice { get; set; }
		[Column("start_date")]
		[DataType(DataType.Date)]
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Column("end_date")]
		[DataType(DataType.Date)]
		[Display(Name = "End Date")]
		public DateTime EndDate { get; set; }
		public virtual ICollection<Task> ProjectTasks { get; set; }

	}
}
