using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddValidation();
builder.Services.AddSingleton<PolicyService>();

var app = builder.Build();
app.MapOpenApi();

app.MapGet("/claims/{id:int}", Results<Ok<ClaimStatus>, NotFound> (int id) =>
{
    if (id == 1)
    {
        ClaimStatus status = new ClaimApproved(5000m);
        return TypedResults.Ok(status);
    }

    if (id == 2)
    {
        ClaimStatus status = new ClaimNeedsReview("Additional information needed");
        return TypedResults.Ok(status);
    }

    return TypedResults.NotFound();
});

// Validation runs before this handler; no claim is saved by this demo.
app.MapPost("/claims/validate", (ClaimValidationRequest request) =>
    TypedResults.Ok(new { message = "Claim validation succeeded." }));

app.MapGet("/todos/stream", (CancellationToken ct) =>
    TypedResults.ServerSentEvents(GetTodosAsync(ct)))
    .WithName("StreamTodos");

static async IAsyncEnumerable<string> GetTodosAsync(
    [EnumeratorCancellation] CancellationToken ct = default)
{
    for (int i = 0; i < 10; i++)
    {
        yield return $"Todo {i + 1}";
        await Task.Delay(1000, ct);
    }
}

app.Run();

public record ClaimApproved(decimal PayoutAmount);
public record ClaimNeedsReview(string Reason);

public union ClaimStatus(ClaimApproved, ClaimNeedsReview);
