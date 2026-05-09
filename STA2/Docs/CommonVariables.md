Below is a **ready‑to‑save Markdown document** for the shared data and model definitions you provided.  
It matches the style, scope, and clarity of your other `/Docs` files.

You can copy this verbatim into your solution as:

    /Docs/SharedDataAndModels_Overview.md

***

# Shared Data and Models — Overview and Responsibilities

*Last updated: 2026‑04‑22*

This file defines a collection of **shared data containers and lightweight models** used throughout the application to hold global state, configuration values, runtime environment information, and launchable program metadata.

These classes and structures are deliberately simple and act as **centralized state holders**, not behavior‑heavy components.

***

## 1. AppData

### `Public Class AppData`

`AppData` acts as a **central application‑wide data container** for shared datasets and installation‑related paths. Its members are static (`Shared`) and accessible globally.

***

### Shared DataSets

*   **`dbAppOptions`**  
    Holds application options persisted in the database.

*   **`dbWebOptions`**  
    Holds web‑related configuration options retrieved from the database.

*   **`dbApplicationInfo`**  
    Holds general application metadata returned from database queries.

*   **`dbLicData`**  
    Stores license‑related data retrieved from the database.

These datasets are populated by database coordination logic and consumed by various UI layers.

***

### Shared Paths and Installation State

*   **`CEPath86`**  
    Default installation path for 32‑bit CenterEdge applications.

*   **`CEPath64`**  
    Default installation path for 64‑bit CenterEdge applications.

*   **`UpgradePath`**  
    Root path used for installer version storage and upgrade operations.

*   **`InstalledVersion`**  
    Numeric indicator representing the detected Advantage installation state.

***

### Design Notes

*   Acts as a central “data bus” for database‑backed information
*   Contains no logic — storage only
*   Values are populated and consumed by helper and coordinator classes

***

## 2. Variables

### `Public Class Variables`

`Variables` stores **global runtime flags** that describe the current application state.

***

### Shared Flags

*   **`LoggedIn`**  
    Indicates whether a user session is authenticated.

*   **`OfflineMode`**  
    Indicates the application is operating without database availability.

These flags are checked throughout the application to:

*   Disable or hide database‑dependent features
*   Short‑circuit expensive operations
*   Enforce safe‑mode behavior under error conditions

***

## 3. PCInfo

### `Public Structure PCInfo`

`PCInfo` is a **static system‑introspection structure** that holds information about the host machine, environment, and runtime capabilities.

All members are `Shared`, effectively making this a global state object.

***

### System and Environment Fields

*   **`Name`** – Machine name
*   **`OpSys`** – Operating system description
*   **`Ram`** – Total physical memory (human‑readable)
*   **`FreeSpace`** – Disk free/total space summary
*   **`Architecture`** – CPU architecture (`x86` / `x64`)

***

### Database and Platform Fields

*   **`DbSize`** – Current database size
*   **`SqlVersion`** – SQL Server version information
*   **`FrameworkVersion`** – Installed .NET framework version
*   **`AdvantageVersion`** – Detected Advantage software version

***

### Capability Flags

*   **`IsSQLInstalled`**  
    Indicates whether SQL Server is installed.

*   **`IsAdvantageInstalled`**  
    Indicates whether Advantage software is installed.

*   **`AreServicesInstalled`**  
    Indicates whether required Windows services are present.

*   **`ValidDatabase`**  
    Indicates whether database connectivity is currently valid.

*   **`ExcelInstalled`**  
    Indicates whether Microsoft Excel is detected on the system.

***

### Design Notes

*   Populated by system inspection and database queries
*   Read by UI, installers, and diagnostics
*   No mutation logic is contained here

***

## 4. ProgramEntry

### `Public Class ProgramEntry`

`ProgramEntry` represents a **single launchable program definition** used by:

*   Program lists
*   Quick Launch UI
*   Batch launcher workflows

***

### Properties

*   **`Id`**  
    Globally unique identifier generated at instantiation.

*   **`Name`**  
    Display name shown in the UI.

*   **`Path`**  
    Executable file path.

*   **`Arguments`**  
    Optional command‑line arguments.

*   **`WorkingDirectory`**  
    Optional working directory override.

*   **`RunAsAdmin`**  
    Indicates whether the process should be launched with elevation.

*   **`IconPath`**  
    Optional explicit icon source.

*   **`Enabled`**  
    Indicates whether the program is eligible for launching.

*   **`IncludeInBatch`**  
    Indicates whether the program participates in batch launches.

***

### Overrides

#### `ToString()`

Returns a descriptive string in the format:

    <Name> (<Path>)

Useful for debugging and list‑binding scenarios.

***

### Design Notes

*   Pure data object (no launch logic)
*   Mutable by design for UI editing
*   Persisted via launcher configuration management

***

## 5. ConfigValues

### `Public Class ConfigValues`

`ConfigValues` stores **database connection configuration values** resolved from configuration files, registry entries, or startup logic.

***

### Shared Configuration Fields

*   **`Server`** – Database server name
*   **`Database`** – Database name
*   **`UserID`** – Username (if not using integrated security)
*   **`StationNo`** – Logical station identifier
*   **`IntegratedSecurity`** – Integrated security flag
*   **`PasswordEncryption`** – Password encryption flag
*   **`Password`** – Database password
*   **`ConnectionString`** – Fully resolved connection string

***

### Design Notes

*   Used heavily by database coordinator and SafeDb logic
*   Centralizes connection‑sensitive values
*   No validation or construction logic lives here

***

## 6. Design Principles Across This File

*   **Global visibility, minimal behavior**  
    These classes store state; they do not implement workflows.

*   **Single sources of truth**  
    Values are defined once and referenced consistently.

*   **Separation of concerns**  
    System inspection, UI logic, and persistence are handled elsewhere.

*   **Backward compatibility**  
    Supports legacy configuration patterns and database structures.

***

## Summary

This file defines the **core shared data models and global state holders** for the application. Together, these classes and structures provide a stable foundation for configuration, system introspection, database interaction, and program launching without embedding business logic into the UI or workflow layers.

***

If you’d like, I can next:

*   Add XML documentation comments directly into these classes
*   Propose refactoring strategies to reduce global state
*   Identify which values could be made immutable or read‑only
*   Create a dependency map showing where each shared object is consumed
