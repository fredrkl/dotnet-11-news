using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

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

app.Run();

public record ClaimApproved(decimal PayoutAmount);
public record ClaimNeedsReview(string Reason);

public union ClaimStatus(ClaimApproved, ClaimNeedsReview);
