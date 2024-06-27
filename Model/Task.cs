namespace CrudAPI.Model
{
	public class Task
	{
		public int Id { get; set; }
		public   string Titulo { get; set; }
		public string Descripcion { get; set; }
		public DateTime Fecha { get; set; }
		public bool  Estado { get; set; }
	}
}
