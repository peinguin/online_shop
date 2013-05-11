using System;
using shop.Models;

namespace shop.Global
{
    public interface IRepository
    {
        User Login(string email, string password);
        User GetUser(string email);
    }
}