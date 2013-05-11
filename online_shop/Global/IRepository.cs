using System;
using mvc.Models;

namespace mvc.Global{
	public interface IRepository
	{
		User Login(string email, string password);
		User GetUser(string email);
	}
}