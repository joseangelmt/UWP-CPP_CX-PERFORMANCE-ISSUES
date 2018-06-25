# UWP-CPP_CX-PERFORMANCE-ISSUES

This repository was created for the next question in StackOverflow: https://stackoverflow.com/questions/51018526/bad-performance-instantiating-winrt-objects-from-a-c-cx-windows-runtime-compon

The respository contains an application to measure the performance instantiating WinRT objects from C# and from a C++/CX Windows Runtime Component.

There are three projects in the solution:

* PerformanceTest (C# UWP application).
* WindowsRuntimeComponent1 (C++/CX WRC that exposes an empty `Class1` class).
* WindowsRuntimeComponent2 (C++/CX WRC that exposes a factory with a static method that returns a new `WindowsRuntimeComponent1.Class1` object.

When you run the application, you've a button to start the tests. When you press it the two tests starts:

* Creating 10000 `WindowsRuntimeComponent1.Class1` objects directly from C#. Because WindowsRuntimeComponent1 is a C++/CX project, there are cross-boundaries operations.
* Creating 10000 `WindowsRuntimeComponent1.Class1` objects indirectly using the factory `WindowsRuntimeComponent2.Factory` so there are cross-boundaries operations from the application to WindowsRuntimeComponent2 too, so the performance penalty because of the cross-boundaries operations should be the same.
* Creating 10000 `null` objects indirectly using the factory `WindowsRuntimeComponent2.Factory` so there are cross-boundaries operations from the application to WindowsRuntimeComponent2 too but there is not instantiation of any WinRT object from the component.

The result is that in my computer the first test takes about **0.39 seconds** to finish and the second one about **25 seconds** and the third one about **0.006 seconds**.
