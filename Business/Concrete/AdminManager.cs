using System.Security.Cryptography;
using System.Text;
using Business.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class AdminManager : IAdminService
{
    private readonly IAdminDal _adminDal;
    public AdminManager(IAdminDal adminDal)
    {
        _adminDal = adminDal;
    }
    public void Insert(Admin t)
    {
        _adminDal.Add(t);
    }

    public void Update(Admin t)
    {
        _adminDal.Update(t);
    }

    public void Delete(Admin t)
    {
       _adminDal.Delete(t);
    }

    public Admin GetById(int id)
    {
        return _adminDal.GetById(id);
    }

    public List<Admin> GetAll()
    {
        return _adminDal.GetAll();
    }

    public Admin Login(string username, string password)
    {
        var admin = _adminDal.GetByName(username);
        if (admin == null) return null;
        
        var hashedInput = HashPassword(password);
        return admin.AdminPasword == hashedInput ? admin : null;
    }
    
    private string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        var sb = new StringBuilder();
        foreach (var b in bytes) sb.Append(b.ToString("x2"));
        return sb.ToString(); // ör: "5e884898da..."
    }
}