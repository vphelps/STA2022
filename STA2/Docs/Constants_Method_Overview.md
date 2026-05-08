Below is a **ready‑to‑save Markdown document** for the constants you provided.  
It matches the style, granularity, and tone of the other files you’ve documented.

You can save this directly as:

    /Docs/Constants_Method_Overview.md

***

# Constants — Method Overview and Responsibilities

*Last updated: 2026‑04‑22*

This file defines a small collection of **application‑wide constants and shared values** used to standardize UI appearance, command‑line arguments, and fixed configuration limits across the application.

These classes are intentionally simple and static in nature, serving as **single sources of truth** for commonly reused values.

***

## 1. TextboxColors

### `Public Class TextboxColors`

`TextboxColors` centralizes color values used when updating WinForms `TextBox` controls dynamically at runtime.

This avoids:

*   Magic color literals scattered throughout the UI
*   Repeated use of `System.Drawing.Color` directly
*   Inconsistent color selection in conditional UI logic

***

### Properties

*   **`Red`**  
    Default foreground/background color used to indicate errors or mismatches.

*   **`White`**  
    Standard background color for normal text boxes.

*   **`Black`**  
    Standard foreground (text) color.

*   **`Yellow`**  
    Highlight or warning color for attention‑requiring states.

*   **`Green`**  
    Positive or success indication color.

Each property is declared as `Shared`, allowing direct access without instantiation.

***

### Design Notes

*   Uses `Color` values directly from `System.Drawing`
*   Properties (rather than constants) allow future theming or runtime overrides
*   Intended primarily for UI state transitions and visual feedback

***

## 2. AdvUpgradeConstants

### `Public Class AdvUpgradeConstants`

Defines string constants used when launching **Advantage Upgrade** command‑line tools.

These values represent well‑known flags passed to `AdvUpgrade.exe`.

***

### Constants

*   **`Quiet`**  
    Suppresses interactive prompts during upgrade execution.

*   **`NoSetup`**  
    Skips setup-related operations.

*   **`NoBackup`**  
    Disables automatic backup creation during upgrade.

***

### Usage Context

These constants are combined dynamically based on user selection and passed to the upgrade process via `ProcessStartInfo.Arguments`.

Centralizing them ensures:

*   Consistent flag spelling
*   No duplication across UI handlers
*   Safer maintenance if flags change

***

## 3. GenericConstants

### `Public Class GenericConstants`

Holds general application‑wide constant values that do not belong to a specific subsystem.

***

### Constants

*   **`QUICKLAUNCH_SLOT_COUNT`**  
    Defines the maximum number of quick‑launch slots supported by the UI.

This value is used to:

*   Bound configuration storage
*   Size UI structures
*   Enforce limits when assigning quick‑launch programs

***

### Design Notes

*   Declared as `Const` to prevent runtime modification
*   Intended for fixed, non‑negotiable limits
*   Keeps numeric “magic values” out of business logic

***

## 4. Design Principles

These constants follow several intentional conventions:

*   **High visibility, low complexity**  
    Simple classes with no dependencies or logic.

*   **Centralization**  
    Values are defined once and referenced everywhere.

*   **Readability**  
    Class and member names are self‑describing.

*   **Maintenance‑friendly**  
    Changes occur in one place, reducing regression risk.

***

## Summary

This file provides a **lightweight, centralized definition of shared constants** that standardize UI appearance, command‑line parameters, and fixed configuration limits. While simple, these definitions play an important role in keeping the codebase consistent, readable, and easy to maintain.

***

If you’d like, I can next:

*   Merge these into a single `AppConstants` namespace
*   Add XML documentation comments to each member
*   Evaluate which values should be configurable vs constant
*   Generate a dependency map showing where each constant is used
