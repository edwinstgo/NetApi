using CrudAPI.Datos;
using CrudAPI.Model;
using CrudAPI.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskController : ControllerBase
	{
		[HttpGet(Name = "GetTasks")]
		public ActionResult<Model.Dto.taskDto> GetTasks()
		{
			return Ok(taskStore.TaskList);
		}

		[HttpGet("id:int", Name = "GetTask")]
		[ProducesResponseType(statusCode:200)]

		public ActionResult<Model.Dto.taskDto> GetTask(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}
			var task = taskStore.TaskList.FirstOrDefault(t => t.Id == id);
			if (task==null) {
				return NotFound();
					};
		return Ok(task);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public ActionResult<taskDto> crearTask([FromBody] taskDto taskDtoNew)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (taskStore.TaskList.FirstOrDefault(t=>t.Titulo.ToLower() == taskDtoNew.Titulo.ToLower()) !=null )
			{
				ModelState.AddModelError("TaskExiste","La Tarea con ese nombre existe!!..");
				return BadRequest(ModelState);
			}
			if(taskDtoNew == null)
			{
				return BadRequest(taskDtoNew);
			}
			if (taskDtoNew.Id >0)
			{
				return StatusCode( StatusCodes.Status500InternalServerError);
			}
			taskDtoNew.Id = taskStore.TaskList.OrderByDescending(t => t.Id).FirstOrDefault().Id + 1;
			taskStore.TaskList.Add(taskDtoNew);
			return CreatedAtRoute("GetTask",new {id= taskDtoNew.Id });
		}
		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult DeleteTask(int id)
		{
			if (id==0)
			{
				return BadRequest();
			}
			var task = taskStore.TaskList.FirstOrDefault(t=>t.Id == id);
			if (task==null ) {
				return NotFound();
			}
			taskStore.TaskList.Remove(task);
			return NoContent();
		}

		[HttpPut("{id:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult UpdateTask(int id, [FromBody] taskDto taskUpdate)
		{
			
			var task = taskStore.TaskList.FirstOrDefault(t => t.Id == id);
			if (task == null)
			{
				return NotFound();
			}
			task = taskUpdate;
			return NoContent();
		}

	}
}
