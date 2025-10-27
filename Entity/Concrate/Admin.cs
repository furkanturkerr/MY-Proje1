using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete;

public class Admin
{
    [Key]
    public int AdminId { get; set; }
    
    [StringLength(50)]
    public string AdminName { get; set; }
    
    [StringLength(250)]
    public string AdminPasword { get; set; }
}