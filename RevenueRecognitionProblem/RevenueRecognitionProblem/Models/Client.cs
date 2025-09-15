using System.ComponentModel.DataAnnotations;

namespace RevenueRecognitionProblem.Models;

public abstract class Client
{   
    [Key]
    public int ClientId { get; set; }
    
    [Required]
    [StringLength(30)]
    public string Address { get; set; } = null!;
    
    [Required]
    [StringLength(30)]
    [EmailAddress]
    public string Email { get; set; } =  null!;
    
    [Required]
    [StringLength(12)]
    public string PhoneNumber { get; set; }  = null!;
}