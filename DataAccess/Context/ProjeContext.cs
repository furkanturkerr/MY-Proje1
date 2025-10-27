using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.Concrate.Repositories;

public class ProjeContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-2QRUQ1N\\MSSQLSERVER01;Database=Proje1;Integrated Security=True;TrustServerCertificate=True");
    }
    
    public DbSet<Abaut>  Abauts { get; set; }
    public DbSet<Heading> Headings { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Writer>  Writers { get; set; }
    public DbSet<Category>  Categories { get; set; }
    public DbSet<Message>  Messages { get; set; }
    public DbSet<Admin>  Admins { get; set; }
}