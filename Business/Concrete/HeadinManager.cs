using Business.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class HeadinManager : IHeadinService
{
    private readonly IHeadingDal _headingDal;
    public HeadinManager(IHeadingDal headingDal)
    {
        _headingDal = headingDal;
    }
    public void Insert(Heading t)
    {
        _headingDal.Add(t);
    }

    public void Update(Heading t)
    {
        _headingDal.Update(t);
    }

    public void Delete(Heading t)
    {
        _headingDal.Delete(t);
    }

    public Heading GetById(int id)
    {
        return _headingDal.GetById(id);
    }

    public List<Heading> GetAll()
    {
        return _headingDal.GetAll();
    }

    public List<Heading> GetAllWithCategory()
    {
        return _headingDal.GetAllWithCategory();
    }
}