using Business.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class AbautManager:IAbautService
{
    private readonly IAbautDal _abautDal;
    public AbautManager(IAbautDal abautDal)
    {
        _abautDal = abautDal;
    }
    public void Insert(Abaut t)
    {
        _abautDal.Add(t);
    }

    public void Update(Abaut t)
    {
        _abautDal.Update(t);
    }

    public void Delete(Abaut t)
    {
        _abautDal.Delete(t);
    }

    public Abaut GetById(int id)
    {
        return _abautDal.GetById(id);
    }

    public List<Abaut> GetAll()
    {
        return _abautDal.GetAll();
    }
}