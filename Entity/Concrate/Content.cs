using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete;

public class Content
{
    [Key]
    public int ContentId { get; set; }
    
    [StringLength(1000)]
    public string ContentVlue { get; set; }
    
    public DateTime ContentTime { get; set; }
    
    public bool ContentStatus { get; set; }
    
    public int HeadingId { get; set; }
    public virtual Heading Heading { get; set; }
    
    public int? WriterId { get; set; }
    public virtual Writer Writer { get; set; }  
}