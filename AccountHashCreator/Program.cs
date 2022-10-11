using EmployeeService.Utils;
using Microsoft.AspNetCore.Identity;

namespace AccountHashCreator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string password = "1";
			var result = PasswordUtils.CreatePasswordHash(password);
			Console.WriteLine($"PASSWORD = \t{password}");
			Console.WriteLine($"SALT = \t\t{result.passwordSalt}");
			Console.WriteLine($"HASH = \t\t{result.passwordHash}");

			Console.ReadKey();
		}
	}
}