using Business.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class WriterManager : IWriterService
{
    private readonly IWriterDal _writerDal;
    public WriterManager(IWriterDal writerDal)
    {
        _writerDal = writerDal;
    }
    public void Insert(Writer t)
    {
        _writerDal.Add(t);
    }

    public void Update(Writer t)
    {
        _writerDal.Update(t);
    }

    public void Delete(Writer t)
    {
        _writerDal.Delete(t);
    }

    public Writer GetById(int id)
    {
        return _writerDal.GetById(id);
    }

    public List<Writer> GetAll()
    {
        return _writerDal.GetAll();
    }
}