using System;
using shop.Models;
using Db4objects.Db4o;

namespace shop.Global
{
    public class Db4oRepository : IRepository
    {
        public shop.Models.User GetUser(string email)
        {
            shop.Models.User emptyUser = new shop.Models.User(email, null);
            IObjectSet res = DB.db.QueryByExample(emptyUser);
            return (shop.Models.User)res.Next();
        }

        public shop.Models.User Login(string email, string password)
        {

            /* create admin if not exists */
            shop.Models.User admin = new shop.Models.User("admin", "admin");
            admin.roles.Add("admin");
            IObjectSet result = DB.db.QueryByExample(admin);
            if (result.Count == 0)
            {
                DB.db.Store(admin);
            }

            result = DB.db.QueryByExample(new shop.Models.User(email, password));
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result.Next() as shop.Models.User;
            }
        }
    }
}

