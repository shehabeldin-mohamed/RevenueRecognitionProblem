using System.ComponentModel.DataAnnotations;

namespace RevenueRecognitionProblem.Models;

public class IndividualClient : Client
{   
    [Required]
    [StringLength(30)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [StringLength(30)]
    public string LastName { get; set; }  = null!;
    
    [Required]
    [StringLength(11)]
    public string Pesel { get; set; }  = null!;
    
    public bool SoftDeleted { get; set; }  = false;
}