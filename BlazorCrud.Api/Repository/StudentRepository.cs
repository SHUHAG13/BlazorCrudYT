using BlazorCrud.Api.Data;
using BlazorCrud.Api.Interface;
using BlazorCrud.Library;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Api.Repository
{
	public class StudentRepository : IStudentRepository
	{
		private readonly AppDbContext _context;
		public StudentRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Student> CreateStudentAsync(Student student)
		{
			try
			{
				await _context.Students.AddAsync(student);
				await _context.SaveChangesAsync();
				return student;
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Error :{ex.Message}");
				throw new ApplicationException("An error occurred while creating the student.", ex);
			}
		}

		public async Task<bool> DeleteStudnet(int id)
		{
			try
			{
				var student = await _context.Students.FindAsync(id);
				if(student==null)
				{
					Console.WriteLine($"Student with ID{id} not found.");
					return false;
				}
				_context.Students.Remove(student);
				await _context.SaveChangesAsync();
				return true;
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Error:{ex.Message}");
				throw new Exception("An unexpected error is occured while Deleting student.");
			}
		}

		public async Task<IEnumerable<Student>> GetAllAsync()
		{
			try
			{
				return await _context.Students.ToListAsync();
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Error :{ex.Message}");
				return new List<Student>();
			}
			
		}

		public async Task<Student> GetByIdAsync(int id)
		{
			try
			{
				var student = await _context.Students.FindAsync(id);
				if(student==null)
				{
					return null;
				}
				return student;
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Error :{ex.Message}");
				return null;
			}
			
		}

		public async Task<Student> UpdateStudentAsync(Student student)
		{
			try
			{
				var existStudnet = await _context.Students.FindAsync(student.Id);
				if(existStudnet==null)
				{
					Console.WriteLine($"Student with ID {student.Id} not found");
					return null;
				}
				existStudnet.Name = student.Name;
				existStudnet.Email = student.Email;
				existStudnet.RollNumber = student.RollNumber;
				existStudnet.MobileNumber = student.MobileNumber;
				existStudnet.FatherName = student.FatherName;
				await _context.SaveChangesAsync();
				return student;
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Error:{ex.Message}");
				throw new Exception("An error occured while updating the studnt.");
			}
		}
	}
}
