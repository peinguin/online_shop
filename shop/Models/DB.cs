using Db4objects.Db4o;
using System;
namespace shop.Models
{
    public class DB
    {
        public static string _file =
            AppDomain.CurrentDomain.GetData("DataDirectory").ToString() +
            @"\\store.db4o";
        private static IObjectContainer _db;

        public static IObjectContainer db
        {
            get
            {
                if (_db == null)
                {
                    _db = Db4oFactory.OpenFile(_file);
                }
                return _db;
            }
            set { _db = value; }
        }

        private DB() { }

        ~DB()
        {
            _db.Close();
        }
    }
}
