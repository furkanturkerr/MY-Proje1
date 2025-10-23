using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete;

public class Abaut
{
    [Key]
    public int AbautId{ get; set; }
    
    [StringLength(1000)]
    public string AbautDetails1 { get; set; }
    
    [StringLength(1000)]
    public string AbautDetails2 { get; set; }
    
    [StringLength(100)]
    public string AbautImage { get; set; }
    
    [StringLength(100)]
    public string AbautImage2 { get; set; }
}