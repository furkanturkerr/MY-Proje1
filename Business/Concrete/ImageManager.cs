using Business.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class ImageManager : IImageService
{
    private readonly IImageDal _imageDal;
    public ImageManager(IImageDal imageDal)
    {
        _imageDal = imageDal;
    }
    public void Insert(Image t)
    {
        throw new NotImplementedException();
    }

    public void Update(Image t)
    {
        throw new NotImplementedException();
    }

    public void Delete(Image t)
    {
        throw new NotImplementedException();
    }

    public Image GetById(int id)
    {
        return _imageDal.GetById(id);
    }

    public List<Image> GetAll()
    {
        return _imageDal.GetAll();
    }
}