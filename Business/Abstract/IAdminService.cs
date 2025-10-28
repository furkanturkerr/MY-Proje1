using Entity.Concrete;

namespace Business.Abstract;

public interface IAdminService : IGenericService<Admin>
{
    Admin? Login(string username, string password);
    Admin? Register(string username, string password, string role = "Writer");
}