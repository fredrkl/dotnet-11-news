using System.ComponentModel.DataAnnotations;

public class ClaimValidationRequest
{
    [Required]
    [KnownPolicy]
    public string? PolicyNumber { get; set; }
}
