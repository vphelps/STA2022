Below is a **ready‑to‑save Markdown document** extracted from the explanation.  
You can copy this verbatim into your solution as:

    /Docs/FormMain_Method_Overview.md

***

# FormMain — Method Overview and Responsibilities

*Last updated: 2026‑04‑22*

`FormMain` is the **primary UI orchestration class** for the application.  
It coordinates startup, background services, installer management, database tools, repository actions, flavor execution, keyboard navigation, and high‑level user interactions across all tabs.

Business logic is intentionally delegated to manager and helper classes; `FormMain` focuses on **coordination, safety, and user experience**.

***

## 1. Construction & Core Utilities

### `New(options As AppOptions, launcher As LauncherConfig)`

Initializes the main form using pre‑loaded application options and launcher configuration. Sets the window title and populates launcher‑related UI without reloading configuration during `Load`.

***

### `GetServiceDisplayName(serviceName As String) As String`

Safely retrieves the Windows Service display name. If the service is unavailable or inaccessible, returns the service name as a fallback.

***

### `EnableDoubleBuffering(ctrl As Control)`

Enables internal WinForms double buffering via reflection to reduce flicker during redraws, especially for dynamically updated layouts (e.g., services table).

***

### `SetExecutionStatus(text As String, Optional force As Boolean = False)`

Updates the execution‑status label unless updates are explicitly locked. Used during long‑running operations such as installer execution and script runs.

***

## 2. Service Management UI

### `BuildServicesUI()`

Builds and lays out the service status table dynamically:

*   Resolves service display names
*   Sorts services alphabetically
*   Creates `ServiceRowControl` instances
*   Wires start, stop, and restart events

Layout updates are suspended during construction to prevent flicker.

***

### `WireServiceRow(row As ServiceRowControl)`

Utility method that wires service control events to action handlers. Functionally superseded by `BuildServicesUI`.

***

### `OnStartServiceRequested(serviceName As String)`

Starts a Windows service asynchronously and immediately updates the UI to show a pending state.

***

### `OnStopServiceRequested(serviceName As String)`

Stops a Windows service asynchronously with immediate visual feedback.

***

### `OnRestartServiceRequested(serviceName As String)`

Restarts a Windows service asynchronously, displaying a stop‑pending state during execution.

***

### `chkShowHiddenServices_CheckedChanged`

Toggles visibility of hidden or uninstalled services and forces the service table to recalculate layout and scroll height.

***

## 3. Form Lifecycle Events

### `MainForm_Load`

Performs one‑time initialization tasks:

*   Instantiates live‑output, quick‑launch, and flavor managers
*   Restores saved UI options
*   Detects Excel and Advantage components
*   Initializes visual tab‑switch hints
*   Evaluates database availability
*   Prepares background refresh logic

***

### `FormMain_Shown`

Runs after the form becomes visible:

*   Builds the services UI
*   Locks label column widths
*   Instantiates and wires `ServiceManager`
*   Starts background service polling
*   Derives flavor paths if required
*   Initializes flavor state and mirror lists

***

### `FormMain_Closing`

Performs shutdown cleanup:

*   Stops background service polling
*   Persists launcher and application options

***

## 4. Timer‑Driven Background Updates

### `tmr10Seconds_Tick`

Performs lightweight periodic updates:

*   Refreshes core service file version info
*   Re‑evaluates database availability asynchronously
*   Enables or disables database‑dependent tabs

***

### `tmr1Sec_Tick`

Updates installer version comparison UI and keeps setup options synchronized with current settings.

***

## 5. Database Tools & Logging

### `btnDbInfoRefresh_Click`

Executes selected database diagnostics (table size, fragmentation, deadlocks) and updates grid views using safe database access wrappers.

***

### `rbDbTableSize_CheckedChanged`

Triggers database info refresh when the selected diagnostic changes.

***

### `btnDbLogRefresh_Click`

Refreshes database logs for either WebCloud updates or message logs and populates summary and detail grids.

***

### `rbWebCloudUpdates_CheckedChanged`

Enables or disables log filter UI based on log type selection and refreshes the data.

***

## 6. Flavor Management

### `InitializeFlavors`

Loads SQL flavor files from the configured directory and applies saved default selections.

***

### `SyncFlavorsListMirror`

Synchronizes the read‑only flavor mirror list with the selectable checkbox list to support safe right‑click and double‑click operations.

***

### `ApplySelectedFlavorsAsync`

Builds flavor arguments from selected items and runs the PowerShell flavor script with live output streaming.

***

### `miApplySingleFlavor_Click`

Context‑menu entry point for applying one or more selected flavors.

***

### `lbFlavorsList_DoubleClick`

Double‑click shortcut for applying selected flavors.

***

## 7. Installer Management

### `btnSetupInstall_Click`

Coordinates the full setup installation workflow:

*   Resolves setup ZIP
*   Extracts versioned install folders
*   Tracks “Run Existing” selections
*   Runs the installer with elevation
*   Updates execution status safely

***

### `btnManageInstallerVersions_Click`

Handles the Manage Installer Versions workflow:

*   Discovers installed versions
*   Applies cleanup safety rules off the UI thread
*   Displays a progress overlay
*   Coordinates confirmation and cleanup execution
*   Displays a summary of cleanup results

***

### `ShowCleanupSummary(result As InstallerCleanupResult)`

Displays a detailed summary of deleted, skipped, and failed versions along with reclaimed disk space.

***

### `btnLaunchLatestInstaller_Click`

Finds and launches the most recent installer with elevation and configured setup arguments.

***

## 8. Progress Overlay & Tab Navigation

### `InitializeTabSwitchHint`

Initializes the label and timer used to display visual Ctrl+Tab tab‑switch hints.

***

### `ShowTabSwitchHint(forward As Boolean)`

Displays a short‑lived overlay indicating the active tab and navigation direction during keyboard tab switching.

***

### `ProcessCmdKey`

Intercepts `Ctrl+Tab` and `Ctrl+Shift+Tab` globally to cycle tabs regardless of which control has focus.

***

### `SelectNextSTATab(forward As Boolean)`

Selects the next or previous tab and triggers the visual switch hint.

***

## 9. Live Output Management

### `ForceLiveOutputRedraw`

Forces a layout and paint refresh of the live output RichTextBox to address WinForms redraw and scroll issues during tab switches.

***

### `AppendColoredOutput(text As String, color As Color)`

Thread‑safe method for appending colored text to the live output pane.

***

## 10. Launcher / Program Management

### `RefreshProgramsList(Optional preserveSelection As Boolean = False)`

Refreshes the program launcher list, optionally preserving the current selection.

***

### `FillComboFromListBox`

Populates the Quick Launch combo box with unassigned programs.

***

### `LaunchFromUI`

Launches a selected program from either the program list or the combo box.

***

### `SaveLauncher(Optional syncFromList As Boolean = False)`

Persists launcher configuration, optionally syncing from the UI first.

***

### `btnBatchLaunch_Click`

Runs all enabled programs as a batch with cursor feedback.

***

## 11. Repository & Git Operations

### `btnRepoFolder_Click`

Allows the user to browse for and save the repository folder path.

***

### `btnRepoDiscardChanges_Click`

Safely previews and discards uncommitted Git changes after timed user confirmation.

***

### `btnRepoMain_Click`

Switches the repository to the main branch, discarding local changes if required.

***

## 12. System Utilities & Tools

### `btnCalc_Click`

Launches common system utilities such as Calculator, Services, Event Viewer, and Devices.

***

### `btnAdvManager_Click`

Launches Advantage applications with correct architecture resolution.

***

### `btnAdvUpgrade_Click`

Runs the Advantage Upgrade tool with user‑selected command‑line flags.

***

## 13. Miscellaneous & Debug Utilities

### `DebugFormIdentity`

Displays identifying information about the current form instance for debugging purposes.

***

### `DumpParentChain`

Displays the parent control chain for UI layout diagnostics.

***

## Summary

`FormMain` acts as the **central coordinator** for user interactions and workflows, while relying on dedicated managers for business logic. Its responsibilities include initialization, UI orchestration, safety enforcement, asynchronous workflow coordination, and consistent user experience.

***

If you’d like, I can next:

*   Split this into multiple docs (Services, Installers, Flavors)
*   Add UML‑style section diagrams
*   Convert this into XML documentation comments
*   Produce a high‑level architecture diagram description
