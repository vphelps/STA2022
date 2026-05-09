Below is a **ready‑to‑save Markdown document** for the `UIHelpers` module, written to match the structure, tone, and depth of your existing `/Docs` files.

You can copy this verbatim into your solution as:

    /Docs/UIHelpers_Method_Overview.md

***

# UIHelpers — Method Overview and Responsibilities

*Last updated: 2026‑04‑22*

`UIHelpers` is a **WinForms utility module** that provides reusable, consistent dialog helpers for user interaction. It centralizes the creation of confirmation, information, warning, and error dialogs with support for:

*   Automatic sizing based on message content
*   Optional countdown timeouts
*   Owner‑aware dialog placement
*   Consistent keyboard semantics
*   Predictable, reusable UX patterns

All dialogs are built programmatically to avoid duplication and to ensure consistent behavior across the application.

***

## 1. Owner Resolution

### `ResolveOwner(owner As IWin32Window) As IWin32Window`

Determines the most appropriate owner window for a dialog.

Resolution order:

1.  Explicit owner (if provided)
2.  Currently active form
3.  First open form
4.  `Nothing` (no owner)

This ensures dialogs are always positioned sensibly, even when no explicit owner is supplied.

***

## 2. Timed Yes / No Prompts

The **Yes/No prompt family** provides confirmation dialogs with optional auto‑dismiss behavior.

### Overload Summary

*   With or without owner
*   With or without timeout
*   Configurable default choice

All overloads delegate to a single canonical implementation.

***

### `TimedYesNoPrompt(...) As DialogResult` (canonical implementation)

Displays a Yes/No confirmation dialog with optional timeout.

#### Behavior

*   Displays a message and title
*   Supports a countdown that auto‑selects the default choice
*   Applies keyboard semantics:
    *   **Enter** → Yes
    *   **Escape** → No
*   Returns the user’s choice or the default when timed out

#### Design Notes

*   The default choice is validated to prevent invalid values
*   Timeout values ≤ 0 disable the countdown entirely
*   Dialog auto‑sizes based on its content

***

## 3. Timed Informational Prompts

These prompts display **single‑button informational dialogs** with consistent styling and optional timeouts.

### `TimedInfoPrompt`

Displays an informational dialog using the system information icon.

***

### `TimedWarningPrompt`

Displays a warning dialog using the system warning icon.

***

### `TimedErrorPrompt`

Displays an error dialog using the system error icon.

Each prompt:

*   Accepts optional owner and timeout
*   Uses a shared internal implementation
*   Automatically closes when the timeout expires

***

## 4. Internal Single‑Button Prompt

### `ShowSingleButtonPrompt(...)`

Core implementation used by Info, Warning, and Error prompts.

#### Responsibilities

*   Builds a dialog with:
    *   Icon
    *   Message label
    *   Optional countdown
    *   Single **OK** button
*   Manages optional auto‑close countdown
*   Ensures consistent layout and sizing
*   Blocks until the dialog closes

This method isolates dialog construction logic from public APIs.

***

## 5. Shared Dialog Construction Helpers

These helpers encapsulate reusable UI patterns and layout logic.

***

### `ConfigureBaseDialog(dlg As Form, title As String, width As Integer)`

Applies consistent base configuration to all dialogs:

*   Fixed dialog border
*   No minimize/maximize buttons
*   Centered on owner
*   Removed control box and taskbar entry

***

### `CreateMessageLabel(text, left, top, width) As Label`

Creates a word‑wrapped label for dialog message text with automatic vertical sizing.

***

### `CreateCountdownLabel(top, visible) As Label`

Creates a label used to display countdown text when timeouts are enabled.

***

### `CreateButton(text, left, top) As Button`

Creates a standardized button with consistent width and positioning.

***

### `AutoSizeDialog(dlg As Form, bottomControl As Control, padding As Integer)`

Resizes the dialog vertically so that all content fits cleanly with configurable padding.

***

## 6. Countdown Timer Infrastructure

### `CreateCountdownTimer(...) As Timer`

Creates and starts a one‑second interval timer that:

*   Updates the countdown label text
*   Executes a callback when time reaches zero
*   Stops itself cleanly

The timer text is dynamically generated via a caller‑supplied function.

***

### `DisposeTimer(t As Timer)`

Safely stops and disposes of a timer, preventing leaks or double‑execution.

***

## 7. Keyboard and Accessibility Semantics

*   **Yes/No dialogs**
    *   `Enter` activates **Yes**
    *   `Escape` activates **No**
*   **Single‑button dialogs**
    *   `Enter` activates **OK**
*   All dialogs support keyboard navigation and standard WinForms accessibility behaviors

***

## 8. Design Principles

*   **Centralized UI logic**  
    All dialog construction lives in one module.

*   **Consistency**  
    Messages, sizing, icons, and behavior are uniform across the application.

*   **Fail‑safe timeouts**  
    Timeout logic never throws and never blocks user interaction.

*   **Owner‑aware placement**  
    Dialogs remain properly nested and centered.

*   **Zero designer dependency**  
    All dialogs are created programmatically for clarity and reuse.

***

## 9. Intended Usage

`UIHelpers` is appropriate for:

*   Confirmation prompts
*   Informational feedback
*   Warning and error messaging
*   Automated workflows where unattended prompts must auto‑resolve

It is **not intended** for complex, multi‑control dialogs or data entry workflows.

***

## Summary

`UIHelpers` provides a **robust, reusable dialog framework** for WinForms applications, ensuring predictable behavior, consistent appearance, and flexible timeout handling. By abstracting dialog construction into a centralized module, it reduces duplication, improves maintainability, and delivers a polished user experience across the application.

***

If you’d like, I can next:

*   Add XML documentation comments directly into `UIHelpers`
*   Provide example screenshots for documentation
*   Add localization support
*   Add a “Do not show again” option pattern

Just let me know.
