public sealed class PolicyService
{
    public async Task<bool> ExistsAsync(string policyNumber, CancellationToken cancellationToken)
    {
        // Simulate an asynchronous database or remote service lookup.
        await Task.Delay(100, cancellationToken);

        return policyNumber is "POL-100" or "POL-200";
    }
}
