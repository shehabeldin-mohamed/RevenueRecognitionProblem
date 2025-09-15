using System.ComponentModel.DataAnnotations;

namespace RevenueRecognitionProblem.Models;

public class CompanyClient : Client
{   
    [Required]
    [StringLength(200)]
    public string CompanyName { get; set; } = null!;
    
    [Required]
    [StringLength(20)]
    public string Krs { get; set; } = null!;
}