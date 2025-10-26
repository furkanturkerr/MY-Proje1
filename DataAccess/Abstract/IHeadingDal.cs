using Entity.Concrete;

namespace DataAcces.Abstract;

public interface IHeadingDal : IGenericDal<Heading>
{
    List<Heading> GetAllWithCategory();
}