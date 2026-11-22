# Claim API demo

This .NET 11 Minimal API demonstrates a C# union in a JSON response body.
`ClaimStatus` describes the two possible shapes of a successful response;
`Results<Ok<ClaimStatus>, NotFound>` describes the HTTP outcomes.

Run the API from the repository root:

```sh
dotnet run --project ClaimApiDemo --urls http://localhost:5000
```

In another terminal, try the two response bodies and the not-found response:

```sh
curl -i http://localhost:5000/claims/1
curl -i http://localhost:5000/claims/2
curl -i http://localhost:5000/claims/3
```

The first two requests return `200 OK`, with `{"payoutAmount":5000}` and
`{"reason":"Additional information needed"}` respectively. The last returns
`404 Not Found`.

View the OpenAPI document at <http://localhost:5000/openapi/v1.json>. The
`ClaimStatus` schema uses `anyOf` to describe the two JSON shapes.

The response contains the active case without a union wrapper or discriminator.
For a new API contract, consider whether clients can reliably distinguish those
shapes; a closed hierarchy with an explicit discriminator may be preferable.
`Results<...>` and `TypedResults` existed before .NET 11; this demo combines them
with the new C# union and .NET 11 JSON support.

## Async validation

The `POST /claims/validate` endpoint uses .NET 11's `AsyncValidationAttribute`
to check a policy number before the handler runs. The injected `PolicyService`
simulates an asynchronous lookup; `POL-100` and `POL-200` are known policies.
The endpoint only validates the request and does not save a claim.

Try a known policy, an unknown policy, and a missing policy number:

```sh
curl -i -X POST http://localhost:5000/claims/validate \
  -H 'Content-Type: application/json' -d '{"policyNumber":"POL-100"}'
curl -i -X POST http://localhost:5000/claims/validate \
  -H 'Content-Type: application/json' -d '{"policyNumber":"POL-999"}'
curl -i -X POST http://localhost:5000/claims/validate \
  -H 'Content-Type: application/json' -d '{}'
```

The known policy returns `200 OK`. The other requests return `400 Bad Request`
with validation details. `[Required]` handles missing or blank values, while
`[KnownPolicy]` performs the async lookup. The delay simulates I/O; a real
service would query a database or remote API instead.
