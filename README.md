# Dotnew news

## Union types in C# 15

What if we now introduced a new TapResult type in the interface way? For
example, `CardMistake`? Here we see that the compiler does not warn us that we
forgot to handle the new type in the switch statement.

There are also no way to ensure that no other part of the assembly can
implement the `ITapResult` interface.

The compiler does not know all the different types that implement the
interface, so it cannot warn us if we forget to handle a new type.

With union types we defined a closed set of types. The compiler knows all the
different types in the union type, and warn us if we forget to handle one.

See [Claim API demo](./ClaimApiDemo/README.md) for unions in HTTP JSON
responses.

## Async validation in .NET 11

We can now use
[`AsyncValidationAttribute`](./ClaimApiDemo/KnownPolicyAttribute.cs) to perform
asynchronous validation in ASP.NET Core. This allows us to perform validation
that requires I/O, such as checking a database or calling an external service,
without blocking the request thread.

## OpenAPI 3.2 in .NET 11

OpenAPI 3.2 is now supported in .NET 11. This allows us to define our API
contracts using the latest version of the OpenAPI specification.

In the Claim API demo, you can view the OpenAPI document at
<http://localhost:5000/openapi/v1.json>. Here you see Union types are
represented using `anyOf` in the OpenAPI schema.

```json
"ClaimNeedsReview": {
        "required": [
          "reason"
        ],
        "type": "object",
        "properties": {
          "reason": {
            "type": "string"
          }
        }
      },
      "ClaimStatus": {
        "type": "object",
        "anyOf": [
          {
            "$ref": "#/components/schemas/ClaimApproved"
          },
          {
            "$ref": "#/components/schemas/ClaimNeedsReview"
          }
        ]
      },
      "ClaimValidationRequest": {
        "required": [
          "policyNumber"
        ],
        "type": "object",
        "properties": {
          "policyNumber": {
            "type": [
              "null",
              "string"
            ]
          }
        }
      },
```

Additionally, you will see support for server-side events type specified in
OpenAPI 3.2.

```json
...
"/todos/stream": {
      "get": {
        "tags": [
          "ClaimApiDemo"
        ],
        "operationId": "StreamTodos",
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/event-stream": {
                "itemSchema": {
                  "required": [
                    "data"
                  ],
                  "type": "object",
                  "properties": {
                    "data": {
                      "$ref": "#/components/schemas/Todo"
                    },
                    "event": {
                      "type": "string"
                    },
                    "id": {
                      "type": "string"
                    }
                  }
                }
              }
            }
          }
      ...
```

## Runtime Async in .NET 11

See [Runtime Async demo](RuntimeAsyncDemo/README.md) to compare live stack
traces and debugger call stacks with the feature off and on.
