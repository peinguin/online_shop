using Db4objects.Db4o;

	namespace mvc.Models{
		public class DB{

			static string _file = "store.db4o";
			private static IObjectContainer _db;

			public static IObjectContainer db
	        {
	            get
	            {
	                if (_db == null) {
						_db = Db4oFactory.OpenFile(_file);
					}
					return _db;
	            }
	        }

			private DB (){}
		}
	}