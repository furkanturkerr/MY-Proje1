using DataAcces.Abstract;
using DataAcces.Concrate.Repositories;
using Entity.Concrete;

namespace DataAcces.Concrate.EntityFramework;

public class EfAdminDal : GenericRepository<Admin>, IAdminDal
{
    
    private readonly ProjeContext _context;
    public EfAdminDal(ProjeContext context) : base(context)
    {
        _context = context;
    }

    public Admin? GetByName(string adminName)
    {
        return _context.Admins.FirstOrDefault(x => x.AdminName == adminName);
    }
}
