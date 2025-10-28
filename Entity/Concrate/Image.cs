using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete;

public class Image
{
    [Key]
    public int ImageId { get; set; }
    
    [StringLength(100)]
    public string ImageName { get; set; }
    
    [StringLength(250)]
    public string ImagePath { get; set; }
}