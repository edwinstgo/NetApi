using System.ComponentModel.DataAnnotations;

namespace CrudAPI.Model.Dto
{
	public class taskDto
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(20)]
		public string Titulo { get; set; }
		public string Descripcion { get; set; }
		public DateTime Fecha { get; set; }
		public bool Estado { get; set; }
	}
}
