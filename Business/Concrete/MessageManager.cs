using Business.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class MessageManager : IMessageService
{
    private IMessageDal _messageDal;
    public MessageManager(IMessageDal messageDal)
    {
        _messageDal = messageDal;
    }
    public void Insert(Message t)
    {
        _messageDal.Add(t);
    }

    public void Update(Message t)
    {
        _messageDal.Update(t);
    }

    public void Delete(Message t)
    {
        _messageDal.Delete(t);
    }

    public Message GetById(int id)
    {
        return _messageDal.GetById(id);
    }

    public List<Message> GetAll()
    {
        return _messageDal.GetAll();
    }
}