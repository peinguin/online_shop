using System;
using shop.Models;

namespace shop.Global
{
    public class Db4oRepository : IRepository
    {
        public User GetUser(string email)
        {
            return new User("sdfsf", "sdfasd");//Db.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0);
        }

        public User Login(string email, string password)
        {
            return new User(email, password); // Db.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0 && p.Password == password);
        }
    }
}

