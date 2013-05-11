using System.Web;
using mvc.Models;
using System.Security.Principal;

namespace mvc.Global.Auth
{
	public interface IAuthentication
	{
	    /// <summary>
	    /// Конекст (тут мы получаем доступ к запросу и кукисам)
	    /// </summary>
	    HttpContext HttpContext { get; set; }

	    User Login(string login, string password, bool isPersistent);

	    User Login(string login);

	    void LogOut();

	    IPrincipal CurrentUser { get; }
	}
}