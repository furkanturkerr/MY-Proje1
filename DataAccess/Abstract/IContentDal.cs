using Entity.Concrete;

namespace DataAcces.Abstract;

public interface IContentDal : IGenericDal<Content>
{
    List<Content> GetListByHeadingIdWithWriter(int headingId);
}