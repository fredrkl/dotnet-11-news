using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

var method = typeof(ClaimProcessor).GetMethod(nameof(ClaimProcessor.ProcessClaimAsync))!;
Console.WriteLine($"Compiler-generated state machine: {method.IsDefined(typeof(AsyncStateMachineAttribute))}");
Console.WriteLine($"Runtime Async: {method.MethodImplementationFlags.HasFlag(MethodImplAttributes.Async)}");
Console.WriteLine();

await ClaimProcessor.ProcessClaimAsync();

public static class ClaimProcessor
{
    public static async Task ProcessClaimAsync()
    {
        await Task.CompletedTask; // Simulate some asynchronous work. Force async state machine behavior
        await CheckCoverageAsync();
    }

    private static async Task CheckCoverageAsync()
    {
        await Task.CompletedTask; // Simulate some asynchronous work. Force async state machine behavior
        await RecordDecisionAsync();
    }

    private static async Task RecordDecisionAsync()
    {
        await Task.CompletedTask; // Simulate some asynchronous work. Force async state machine behavior

        // Set a breakpoint on the next line and inspect the debugger's Call Stack.
        Console.WriteLine(new StackTrace(fNeedFileInfo: true));
    }
}
