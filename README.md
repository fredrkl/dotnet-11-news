# Dotnew news

## Install .NET 11

## Union types in C# 11

- What if we now introduced a new TapResult type in the interface
  way? For example, `CardMistake`. Looking at the `if` checks we
  see that the result will still be `Unknown tap result`.

There are also no way to ensure that no other part of the assembly
can implement the `ITapResult` interface. This is a problem because
we want to ensure that only the types we define are used as tap
results.
