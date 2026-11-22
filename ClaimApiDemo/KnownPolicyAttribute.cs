using System.ComponentModel.DataAnnotations;

public sealed class KnownPolicyAttribute : AsyncValidationAttribute
{
    protected override async Task<ValidationResult?> IsValidAsync(
        object? value,
        ValidationContext validationContext,
        CancellationToken cancellationToken)
    {
        // Required handles missing or blank policy numbers.
        if (value is not string policyNumber || string.IsNullOrWhiteSpace(policyNumber))
        {
            return ValidationResult.Success;
        }

        var policies = validationContext.GetRequiredService<PolicyService>();

        return await policies.ExistsAsync(policyNumber, cancellationToken)
            ? ValidationResult.Success
            : new ValidationResult(
                "The policy number is not known.",
                [validationContext.MemberName!]);
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) =>
        throw new InvalidOperationException("Synchronous validation is not supported.");
}
