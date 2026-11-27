# Close Hierarchies

This demo shows the new C# closed hierarchies feature in C# 15, which ships in
.NET 11. We see that we have a closed record called `Vehicle`, and that we are
able to create new records called `Car` and `Boat` that inherits from `Vehicle`
in the same assembly: `ClosedHierarchies.dll`.

However, if we try to inherit from `Vehicle` in a different assembly, we get a
compiler error. Also, if we change `Car` or `Boat` to public we get the warning
that they are less accessible than `Vehicle`.
