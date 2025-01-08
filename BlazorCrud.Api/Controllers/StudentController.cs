using BlazorCrud.Api.Interface;
using BlazorCrud.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrud.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentRepository _repository;

		public StudentController(IStudentRepository repository)
		{
			_repository = repository;
		}
		[HttpGet]
		public async Task<IActionResult> GetByAll()
		{
			var students = await _repository.GetAllAsync();
			return Ok(students);

		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult>GetById(int id)
		{
			var student = await _repository.GetByIdAsync(id);
			return Ok(student);

		}
		[HttpPost]
		public async Task<IActionResult>AddStudent(Student student)
		{
			var newStudent = await _repository.CreateStudentAsync(student);
			return Ok(newStudent);
		}
		[HttpPut("{id:int}")]
		public async Task<IActionResult>UpdateStudent(Student student)
		{
			var updateStudent = await _repository.UpdateStudentAsync(student);
			return Ok(updateStudent);

		}
		[HttpDelete("{id:int}")]
		public async Task<bool>DeleteStudent(int id)
		{
			var deletedStudnet = await _repository.DeleteStudnet(id);
			return true;
		}

	}
}
