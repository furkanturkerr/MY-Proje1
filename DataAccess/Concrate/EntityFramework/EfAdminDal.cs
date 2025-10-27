using DataAcces.Abstract;
using DataAcces.Concrate.Repositories;
using Entity.Concrete;

namespace DataAcces.Concrate.EntityFramework;

public class EfAdminDal : GenericRepository<Admin>, IAdminDal
{
    
    public EfAdminDal(ProjeContext context) : base(context)
    {
        
    }
    private IAdminDal _adminDalImplementation;

    public Admin GetByName(string adminName)
    {
        using (var context = new ProjeContext())
        {
            return context.Admins
                .FirstOrDefault(x => x.AdminName == adminName);
        }
    }
}
