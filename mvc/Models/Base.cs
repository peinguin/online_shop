using Db4objects.Db4o;

	namespace mvc.Models{
		public class Base<T>{
			public static IObjectSet GetAll(){
				return DB.db.QueryByExample (typeof(Base<T>));
			}

			public void save(){
				DB.db.Store (this);
				DB.db.Commit ();
			}
		}
	}
