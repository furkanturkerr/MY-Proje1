using Entity.Concrete;

namespace Business.Abstract;

public interface IAdminService : IGenericService<Admin>
{
    Admin Login(string username, string password);
}