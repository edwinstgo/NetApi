using CrudAPI.Model.Dto;

namespace CrudAPI.Datos
{
	public static  class taskStore
	{
		public static List<taskDto> TaskList = new List<taskDto> {
			new taskDto{ Id = 1,Titulo="Titulo 1"},
			new taskDto{ Id = 2,Titulo="Titulo 2"}

		};
	}
}
