using Entity.Concrete;

namespace Business.Abstract;

public interface IHeadinService : IGenericService<Heading>
{
    List<Heading> GetAllWithCategory();
}