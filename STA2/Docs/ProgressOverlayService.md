Below is a **copy‑ready usage document** for **`ProgressOverlayService`** that you can save directly into your solution’s **Docs** folder.

It is written as internal developer documentation: clear, practical, and aligned with how your codebase actually uses the service.

You can save this exactly as:

    Docs/ProgressOverlayService.md

***

# ProgressOverlayService Usage Guide

*Last updated: 2026‑04‑22*

## Purpose

`ProgressOverlayService` provides a **simple, reusable way to display a non‑blocking progress overlay** over a WinForms UI while long‑running operations are executed asynchronously.

Its goals are to:

*   Keep the UI responsive
*   Prevent the application from appearing frozen
*   Give immediate visual feedback to the user
*   Centralize overlay logic to avoid duplicated UI code
*   Enforce correct async usage patterns

This service is intended for **operations longer than \~200 ms** that would otherwise block the UI thread.

***

## When to Use ProgressOverlayService

Use `ProgressOverlayService` when:

*   Scanning the filesystem
*   Enumerating processes
*   Running installer checks
*   Performing network or database checks
*   Running CPU‑bound or legacy synchronous operations
*   Executing async operations that need user feedback

Do **not** use the overlay for trivial or instant operations.

***

## Core API

```vb
Await ProgressOverlayService.RunWithOverlayAsync(
    ownerForm,
    message,
    workFunction
)
```

### Parameters

| Parameter      | Description                                                       |
| -------------- | ----------------------------------------------------------------- |
| `ownerForm`    | The WinForms `Form` that owns the overlay                         |
| `message`      | Message displayed to the user while work runs                     |
| `workFunction` | A function that returns a `Task` representing the work to perform |

The overlay is shown **before** the work starts and guaranteed to close **after** the work completes (even if an exception occurs).

***

## Usage Patterns

### Pattern 1: Wrapping Already‑Async Work (Preferred)

Use this pattern **when the API you are calling already returns a Task**.

```vb
Await ProgressOverlayService.RunWithOverlayAsync(
    Me,
    "Extracting setup files…",
    Async Function()
        Await InstallerTools.ExtractZipToVersionedDirectoryAsync(...)
    End Function
)
```

#### Why this is correct

*   No unnecessary threads are created
*   Async I/O scales efficiently
*   Exceptions flow naturally through `Await`

✅ **Always prefer this pattern when available**

***

### Pattern 2: Wrapping Synchronous / Blocking Work

Use this pattern **only when the work is synchronous or CPU‑bound** and has no async version.

```vb
Await ProgressOverlayService.RunWithOverlayAsync(
    Me,
    "Checking database status…",
    Function()
        Return Task.Run(Sub()
                            HeavyCheck()
                        End Sub)
    End Function
)
```

#### Why this is required

*   `HeavyCheck()` blocks a thread
*   Running it directly would freeze the UI
*   `Task.Run` moves the work to a background thread

⚠️ This consumes a ThreadPool thread — use sparingly.

***

## Common Mistakes to Avoid

### ❌ Wrapping Async Code in Task.Run

```vb
' ❌ Incorrect — double wrapping async work
Function()
    Return Task.Run(Async Sub()
                        Await SomeAsyncMethod()
                    End Sub)
End Function
```

This:

*   Wastes threads
*   Complicates debugging
*   Adds latency

**Rule:** If it is already async, do not use `Task.Run`.

***

### ❌ Blocking Inside an Async Function

```vb
Async Function()
    HeavyCheck() ' ❌ Still blocks the UI thread
End Function
```

`Async` does nothing unless `Await` is used on an asynchronous operation.

***

## Threading & UI Safety Rules

*   UI controls must only be accessed on the UI thread
*   Code inside `Task.Run` **must not touch UI controls**
*   The overlay service handles UI marshaling automatically

***

## Error Handling

*   Exceptions thrown inside the `workFunction` propagate naturally
*   The overlay is always closed in a `Finally` block
*   You should catch and report exceptions **outside** the overlay call

Example:

```vb
Try
    Await ProgressOverlayService.RunWithOverlayAsync(...)
Catch ex As Exception
    MessageBox.Show(ex.Message, "Error")
End Try
```

***

## Example: Real Use Case from the Application

```vb
Await ProgressOverlayService.RunWithOverlayAsync(
    Me,
    "Scanning installed installer versions…",
    Function()
        Return Task.Run(Sub()
                            InstallerTools.ApplyCleanupSafetyRules(
                                versions,
                                runExistingVersionPath:=_runExistingVersionPath)
                        End Sub)
    End Function
)
```

This pattern:

*   Keeps the UI responsive
*   Prevents form‑show delays
*   Avoids “Application Not Responding”
*   Makes long system inspection operations user‑friendly

***

## Design Notes

*   The overlay is **modeless but modal‑like** (blocks interaction)
*   Only one overlay can be shown at a time
*   The overlay automatically matches the owner form size and position
*   Cleanup is guaranteed even if work throws exceptions

***

## Summary Rules (Quick Reference)

    If the API already returns Task → await it directly
    If the API is synchronous → wrap it in Task.Run
    Never block the UI thread
    Never wrap async APIs in Task.Run
    Use ProgressOverlayService for any long operation

***

## Related Documentation

*   `Docs/AsyncGuidelines.md`
*   Inline XML documentation on `ProgressOverlayService.RunWithOverlayAsync`

***

**ProgressOverlayService exists to enforce correct async behavior and consistent UX.  
Use it whenever long work and a responsive UI are both required.**
