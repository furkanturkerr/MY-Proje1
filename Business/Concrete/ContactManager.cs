using Business.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class ContactManager : IContactService
{
    private readonly IContactDal _contactDal;
    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }
    public void Insert(Contact t)
    {
        _contactDal.Add(t);
    }

    public void Update(Contact t)
    {
        _contactDal.Update(t);
    }

    public void Delete(Contact t)
    {
        _contactDal.Delete(t);
    }

    public Contact GetById(int id)
    {
        return _contactDal.GetById(id);
    }

    public List<Contact> GetAll()
    {
        return _contactDal.GetAll();
    }
}