Below is a **ready‑to‑save Markdown document** for the `ProgressOverlayService` class, consistent with the style, clarity, and depth of the other files you’ve added to your `/Docs` folder.

You can copy this verbatim into your solution as:

    /Docs/ProgressOverlayService_Method_Overview.md

***

# ProgressOverlayService — Method Overview and Responsibilities

*Last updated: 2026‑04‑22*

`ProgressOverlayService` is a **reusable, UI‑focused utility class** that provides a non‑blocking progress overlay for long‑running operations in WinForms applications. It ensures that expensive or blocking work can be performed without freezing the UI, while clearly communicating busy state to the user.

This service abstracts away all overlay lifecycle management so callers only need to supply:

*   The owning form
*   A user‑friendly message
*   A `Task`‑based operation to execute

***

## 1. Purpose and Design Intent

The main goals of `ProgressOverlayService` are:

*   Prevent UI freezing during long‑running operations
*   Provide immediate visual feedback to users
*   Centralize overlay logic in one place
*   Enforce correct async usage patterns
*   Guarantee cleanup even when exceptions occur

The service is intentionally:

*   **Static‑only** (non‑instantiable)
*   **UI‑safe**
*   **Exception‑resilient**
*   **Reusable across multiple workflows**

***

## 2. Internal State

### `_overlay As ProgressOverlayForm`

A shared reference to the currently displayed `ProgressOverlayForm`.

*   Only one overlay may exist at a time
*   Prevents stacking or duplicate overlays
*   Set to `Nothing` after cleanup

This ensures predictable, singleton‑style overlay behavior.

***

## 3. Public API

### `RunWithOverlayAsync(owner As Form, message As String, work As Func(Of Task)) As Task`

The **primary entry point** for consumers of the service.

#### Responsibilities

1.  Validates input arguments
2.  Displays a progress overlay over the owner form
3.  Executes the supplied asynchronous operation
4.  Guarantees overlay cleanup via `Try…Finally`
5.  Propagates exceptions naturally to the caller

#### Parameters

*   **`owner`**  
    The form that owns the overlay. The overlay is sized and positioned to fully cover the owner’s client area.

*   **`message`**  
    Text displayed to the user while the operation is running.

*   **`work`**  
    A function returning a `Task` that represents the operation to perform.

#### Async Usage Rules

*   If the operation is **already async**, pass it directly.
*   If the operation is **synchronous or CPU‑bound**, wrap it in `Task.Run`.
*   Never wrap already‑async methods in `Task.Run`.

These rules ensure optimal performance and avoid unnecessary thread usage.

***

## 4. Overlay Lifecycle Management

### `Show(owner As Form, message As String)`

Displays the overlay on top of the specified owner form.

Behavior:

*   Aborts if an overlay is already visible
*   Creates a new `ProgressOverlayForm` with the provided message
*   Sizes the overlay to match the owner’s client area
*   Positions it correctly in screen coordinates
*   Brings it to the front and forces a repaint

This method ensures the overlay appears immediately and predictably.

***

### `Hide()`

Closes and disposes the overlay if it is currently displayed.

Behavior:

*   Safely closes and disposes the overlay
*   Swallows cleanup exceptions to avoid cascading failures
*   Resets the shared overlay reference to `Nothing`

Cleanup is **guaranteed** even if the background operation fails.

***

## 5. Threading and Safety Guarantees

*   The overlay is always created and destroyed on the UI thread
*   The supplied work runs asynchronously
*   UI repainting is never blocked by background work
*   Exceptions from the `work` function propagate normally
*   Overlay cleanup runs in a `Finally` block

These guarantees make `ProgressOverlayService` safe for:

*   Installer workflows
*   File system scanning
*   Process enumeration
*   Database checks
*   Any potentially expensive operation

***

## 6. Typical Usage Patterns

### Async Operation (Preferred)

Used when the called API already returns a `Task`.

```vb
Await ProgressOverlayService.RunWithOverlayAsync(
    Me,
    "Extracting setup files…",
    Async Function()
        Await InstallerTools.ExtractZipToVersionedDirectoryAsync(...)
    End Function
)
```

***

### Synchronous or CPU‑Bound Operation

Used when no async API exists.

```vb
Await ProgressOverlayService.RunWithOverlayAsync(
    Me,
    "Scanning installed versions…",
    Function()
        Return Task.Run(Sub()
                            InstallerTools.ApplyCleanupSafetyRules(...)
                        End Sub)
    End Function
)
```

***

## 7. Design Principles

*   **Single responsibility**  
    Only manages overlay display and lifetime.

*   **No business logic**  
    Callers retain complete control over the executed work.

*   **Defensive cleanup**  
    Overlay is always removed, even after errors.

*   **Centralized UX**  
    Ensures a consistent “busy state” experience across the application.

***

## 8. Limitations and Non‑Goals

`ProgressOverlayService` does **not**:

*   Track percent or granular progress
*   Provide cancellation controls
*   Manage multiple concurrent overlays
*   Display detailed diagnostics

These concerns are intentionally left to higher‑level workflows.

***

## Summary

`ProgressOverlayService` provides a **clean, reusable, and safe abstraction** for showing progress overlays during long‑running operations in WinForms. By enforcing correct async patterns and guaranteeing visual feedback without UI freezing, it significantly improves user experience while keeping calling code simple and readable.

***

If you’d like, I can next:

*   Add XML documentation comments directly to the class (if not already complete)
*   Extend the overlay to support cancelation
*   Add fade‑in / fade‑out animation
*   Provide a design document for `ProgressOverlayForm` itself
