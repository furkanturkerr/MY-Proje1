using Entity.Concrete;

namespace DataAcces.Abstract;

public interface IAdminDal : IGenericDal<Admin>
{
    Admin GetByName(string adminName);
}