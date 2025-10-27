using DataAcces.Abstract;
using DataAcces.Concrate.Repositories;
using Entity.Concrete;

namespace DataAcces.Concrate.EntityFramework;

public class EfMessageDal : GenericRepository<Message>, IMessageDal
{
    public EfMessageDal (ProjeContext context) : base(context)
    {
        
    }
}