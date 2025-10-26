using Entity.Concrete;

namespace Business.Abstract;

public interface IContentService : IGenericService<Content>
{
    List<Content> GetAllByIdHeading(int id);
}