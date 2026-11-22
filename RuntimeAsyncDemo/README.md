# Runtime Async stack trace demo

This .NET 11 console app compares the same async call chain with
compiler-generated state machines and Runtime Async. Both configurations target
.NET 11 and use debug symbols with optimizations disabled. Only `RuntimeAsync`
opts into the new implementation with `<Features>runtime-async=on</Features>`.

## Run in Neovim

"Old way" with the classic async state machine:

```sh
Dotnet debug -c Debug
```

"#New way with Runtime Async:"

```sh
Dotnet debug -c RuntimeAsync
```

The app prints which implementation was compiled, followed by a live stack
trace. In the classic version, look for additional async infrastructure such as
`AsyncMethodBuilderCore.Start`. In the Runtime Async version, the application
methods appear with fewer infrastructure frames. Exact frames can vary by SDK,
platform, and debugger.

Both launch configurations build their respective projects first and use
separate output directories. If your debugger groups or hides external code,
expand or show those frames; the printed live stack trace is another way to
compare them. Other C# debuggers can use the same breakpoint and build
configurations.

The completed awaits are deliberate: they let the nested calls execute together
on the live stack so the contrast is easy to see. An incomplete await can
suspend execution and change which physical frames are present. This demo shows
live stacks, not exception stack traces, which .NET already cleans up in both
implementations.
