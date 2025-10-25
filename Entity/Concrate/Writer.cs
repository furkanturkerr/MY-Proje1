using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete;

public class Writer
{
    [Key]
    public int WriterId { get; set; }
    
    [StringLength(50)]
    public string WriterName { get; set; }
    
    
    [StringLength(50)]
    public string WriterSurname { get; set; }
    
    [StringLength(100)]
    public string WriterImage { get; set; }
    
    [StringLength(50)]
    public string WriterTitle { get; set; }
    
    [StringLength(100)]
    public string WriterAbaut { get; set; }
    
    [StringLength(200)]
    public string WriterEmail { get; set; }
    
    [StringLength(200)]
    public string WriterPassword { get; set; }

    public ICollection<Heading> Headings { get; set; } 
    
    public ICollection<Content> Contents { get; set; }
}