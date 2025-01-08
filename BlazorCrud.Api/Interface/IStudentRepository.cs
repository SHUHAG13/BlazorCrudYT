using BlazorCrud.Library;

namespace BlazorCrud.Api.Interface
{
	public interface IStudentRepository
	{
		Task<IEnumerable<Student>> GetAllAsync();
		Task<Student> GetByIdAsync(int id);
		Task<Student> CreateStudentAsync(Student student);
		Task<Student> UpdateStudentAsync(Student student);
		Task<bool> DeleteStudnet(int id);
		


	}
}
