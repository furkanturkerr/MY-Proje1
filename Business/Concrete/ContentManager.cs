using Business.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class ContentManager : IContentService
{
    private readonly IContentDal _contentDal;
    public ContentManager(IContentDal contentDal)
    {
        _contentDal = contentDal;
    }
    public void Insert(Content t)
    {
        _contentDal.Add(t);
    }

    public void Update(Content t)
    {
        _contentDal.Update(t);
    }

    public void Delete(Content t)
    {
        _contentDal.Delete(t);
    }

    public Content GetById(int id)
    {
        return _contentDal.GetById(id);
    }

    public List<Content> GetAll()
    {
        return _contentDal.GetAll();
    }

    public List<Content> GetAllByIdHeading(int id)
    {
        return _contentDal.GetListByHeadingIdWithWriter(id);
    }
}