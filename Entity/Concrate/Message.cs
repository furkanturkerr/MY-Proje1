using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete;

public class Message
{
    [Key]
    public int MessageId { get; set; }
    
    [StringLength(50)]
    public string SenderMail { get; set; }
    
    [StringLength(50)]
    public string ReceiverMail { get; set; }
    
    [StringLength(50)]
    public string Subject { get; set; }
    
    [StringLength(100)]
    public string MessageContent { get; set; }
    
    
    public DateTime MessageDate { get; set; }
}