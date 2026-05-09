Below is a **ready‑to‑save Markdown document** for the `CodeHelper` module, matching the style and level of detail you used for `FormMain`.

You can copy this verbatim into your solution as:

    /Docs/CodeHelper_Method_Overview.md

***

# CodeHelper — Method Overview and Responsibilities

*Last updated: 2026‑04‑22*

`CodeHelper` is a **shared utility module** that centralizes system introspection, database refresh logic, version detection, flavor argument construction, execution‑status helpers, and low‑level environment checks.

Unlike `FormMain`, `CodeHelper` contains **no UI orchestration logic of its own**. Instead, it gathers data, performs safe queries, and applies results to the UI in a controlled and thread‑safe manner.

***

## 1. Enums & Constants

### `AppInstallState`

Represents the installation state of an Advantage executable:

*   `NotInstalled`
*   `InstalledX86`
*   `InstalledX64`

Used throughout the application to resolve correct executable paths and detect installed components.

***

## 2. Application Initialization & Refresh Logic

### `FirstLoad()`

Performs **initial system and database discovery** during application startup.

Responsibilities:

*   Detects offline mode early and exits safely if active
*   Collects PC information (OS, RAM, disk, architecture)
*   Determines installed .NET and Advantage versions
*   Executes initial database statistics queries via `SafeDb`
*   Updates `PCInfo` and reflects values into the main form
*   Switches the UI into offline mode when database connectivity is lost

This method is intended to run **once per application lifetime**.

***

### `Refresher()`

Performs **periodic UI and system refreshes** in a safe, repeatable way.

Responsibilities:

1.  Refresh Advantage version information
2.  Update license and location data from the database
3.  Re‑evaluate database health
4.  Refresh system clock, framework versions, and PC info
5.  Update UI fields on the correct thread
6.  Trigger offline mode on database connectivity failures

This method is designed to be **idempotent** and is frequently invoked by timers.

***

## 3. UI Update Helpers

### `ApplyPcInfoToForm(form As FormMain)`

Copies stored `PCInfo` values into the appropriate fields on the main form.

This method exists to keep **UI updates isolated and reusable**, and is always invoked on the UI thread.

***

### `SetExecutionStatus(owner As Control, statusLabel As ToolStripLabel, text As String)`

Thread‑safe helper used to update execution‑status text in the UI.

Responsibilities:

*   Marshals calls to the UI thread when required
*   Shows or hides the label based on content
*   Centralizes execution‑status behavior across the app

***

## 4. Database & Parsing Helpers

### `IsNumericLike(value As String) As Boolean`

Determines whether a string resembles a numeric value using invariant culture parsing.

Used to decide how database values (e.g., size fields) should be displayed.

***

### `ExtractYearFromVersion(versionText As String) As String`

Attempts to extract a four‑digit year (e.g., `2019`, `2022`) from a SQL Server version string.

Used to render human‑friendly SQL edition labels in the UI.

***

## 5. System & Environment Introspection

### `GetPcInfo()`

Populates the `PCInfo` structure with local system details:

*   Machine name
*   Operating system
*   Total RAM
*   Disk free space and total capacity
*   CPU architecture (x86 / x64)

This method performs no UI updates directly.

***

### `CeInfo() As String`

Determines the installed Advantage version by inspecting `AdvCommon.dll`.

Responsibilities:

*   Resolves correct installation path based on architecture
*   Extracts the file version
*   Sets `PCInfo.IsAdvantageInstalled` accordingly
*   Returns a formatted version string or a fallback message if missing

***

### `AdvExeCheck(executable As String) As AppInstallState`

Checks for the presence of an Advantage executable in both x86 and x64 paths and returns its installation state.

Used by:

*   Program launch logic
*   Installer resolution
*   UI enable/disable rules

***

## 6. Message Log & Query Builders

### `MsgLogBuilder(Optional errValue, Optional limit, Optional daterange)`

Constructs formatted SQL queries for message log retrieval based on filter parameters.

Centralizes query generation to avoid duplication and inconsistent SQL formatting across the UI.

***

## 7. Flavor Argument Utility

### `BuildFlavorsArgument(flavorNames As IEnumerable(Of String)) As String`

Builds a PowerShell‑compatible argument string for applying SQL flavors.

Rules enforced:

*   Input must not be empty
*   Flavor names are comma‑separated
*   No spaces are allowed
*   Output is safe for PowerShell parsing

Throws an exception if no valid flavors are supplied.

***

## 8. Design Notes

*   All database access in this module goes through **`SafeDb`**
*   UI updates are **never performed without thread checks**
*   Offline mode is treated as a **first‑class operational state**
*   Parsing and formatting logic is intentionally centralized
*   No state is stored locally — all shared state flows through `PCInfo`, `AppData`, or `Variables`

***

## Summary

`CodeHelper` acts as a **support backbone** for the application by providing:

*   Safe system and database introspection
*   Centralized refresh orchestration
*   Robust version detection
*   Consistent argument and query construction
*   UI‑safe execution‑status and data updates

It enables `FormMain` and other UI components to remain focused on **orchestration and user experience**, while isolating sensitive logic and error handling in a single, reusable module.

***

If you’d like, I can next:

*   Add XML documentation comments directly to `CodeHelper`
*   Produce a dependency map (`CodeHelper` → `PCInfo`, `SafeDb`, `FormMain`)
*   Split this into smaller docs (System Info / Database / Installers)
*   Add a developer onboarding note explaining *when* to use CodeHelper vs managers
