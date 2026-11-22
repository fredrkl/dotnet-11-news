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
different types that implement the union type, so it can warn us if we forget
to handle a new type.

See [Claim API demo](ClaimApiDemo/README.md) for unions in HTTP JSON responses.

## Async validation in .NET 11

We can now use `AsyncValidationAttribute` to perform asynchronous validation in
ASP.NET Core. This allows us to perform validation that requires I/O, such as
checking a database or calling an external service, without blocking the
request thread.

## Runtime Async in .NET 11

See [Runtime Async demo](RuntimeAsyncDemo/README.md) to compare live stack
traces and debugger call stacks with the feature off and on.
