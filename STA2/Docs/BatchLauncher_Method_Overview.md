Below is a **ready‑to‑save Markdown document** for the `BatchLauncher` module, written in the same style and level of detail as your previous `/Docs` files.

You can copy this verbatim into your solution as:

    /Docs/BatchLauncher_Method_Overview.md

***

# BatchLauncher — Method Overview and Responsibilities

*Last updated: 2026‑04‑22*

`BatchLauncher` is a **headless execution module** responsible for launching multiple configured applications as a single batch operation. It provides structured results, resilient logging, and safe execution semantics without any direct UI dependencies.

This module is intentionally UI‑agnostic and is designed to be callable from:

*   UI actions (e.g., “Batch Launch” button)
*   Startup automation
*   Command‑line or scheduled workflows

***

## 1. Result Model

### `Class BatchResult`

Represents the outcome of a batch execution run.

**Properties**

*   `Total` – Total number of programs selected for the batch.
*   `Launched` – Number of programs successfully launched.
*   `Skipped` – Number of programs skipped due to validation failures (e.g., missing executable).
*   `Failed` – Number of programs that failed to launch due to runtime exceptions.
*   `Failures` – A list of descriptive error messages for skipped or failed launches.

**Methods**

*   `ToString()`  
    Returns a concise summary string suitable for logs and diagnostics.

The `BatchResult` object is the **authoritative summary** returned to callers.

***

## 2. Logging Infrastructure

### Log Rotation Strategy

Logs are written to:

    %AppData%\STA2\Logs\

with the following rotation scheme:

    batch-launch-1.log  (newest)
    batch-launch-2.log
    batch-launch-3.log
    batch-launch-4.log
    batch-launch-5.log  (oldest)

Rotation ensures bounded disk usage while preserving recent execution history.

***

### `RotateLogs(logDir As String)`

Performs safe log rotation before each batch run.

Responsibilities:

*   Deletes the oldest log file
*   Shifts existing logs up one index
*   Uses copy‑and‑delete semantics for framework compatibility
*   Swallows all exceptions to ensure batch execution is never blocked by logging failures

This method is intentionally defensive and failure‑tolerant.

***

### `_logSync`

A private synchronization object used to enforce thread‑safe log writes.

***

### `LogLine(path As String, line As String)`

Appends a timestamped log entry to the specified log file in a thread‑safe manner using a `SyncLock`.

This is the **only method that writes to disk logs**, centralizing file I/O behavior.

***

### `NormalizeCaller(caller As String) As String`

Normalizes and sanitizes the caller identifier supplied to `RunBatch`.

Returns a trimmed string or a default `(unknown)` marker when no caller is provided.

This ensures logs always include a meaningful source identifier.

***

## 3. Batch Execution Entry Point

### \`RunBatch(launcherConfig As LauncherConfig,

              Optional caller As String = Nothing,
              Optional includeDisabled As Boolean = False,
              Optional silent As Boolean = True) As BatchResult`

This is the **primary entry point** for batch execution.

***

### Responsibilities

1.  **Initialize Logging**
    *   Creates the log directory if needed
    *   Rotates previous batch logs
    *   Writes a batch header with:
        *   Timestamp
        *   Caller identity
        *   User and machine information
        *   Execution flags

2.  **Validate Inputs**
    *   Ensures `LauncherConfig` is present
    *   Ensures program list is available
    *   Fails fast with logged errors if configuration is invalid

3.  **Build Batch Candidate List**
    *   Selects programs where:
        *   `IncludeInBatch = True`
        *   Program is enabled (unless `includeDisabled = True`)
    *   Records total count

4.  **Launch Programs**
    *   Verifies the executable path exists
    *   Determines working directory safely
    *   Constructs `ProcessStartInfo`
    *   Applies elevation (`runas`) when configured
    *   Launches via `Process.Start`
    *   Records success, skip, or failure with full logging

5.  **Finalize Execution**
    *   Writes a batch footer with completion timestamp
    *   Returns a populated `BatchResult`

***

### Error Handling Philosophy

*   Per‑program failures do **not** stop the batch
*   Exceptions are logged and isolated
*   Catastrophic errors are logged as `FATAL` and safely terminated
*   Logging failures never prevent execution

This design ensures **maximum resiliency** during batch operations.

***

## 4. Execution Semantics

### Silent vs Non‑Silent Mode

*   `silent = True`  
    Intended for background execution or startup automation.  
    No UI feedback is expected.

*   `silent = False`  
    Intended for interactive usage where the caller may present results to the user.

The `BatchLauncher` itself does not make UI decisions; it only records intent and outcome.

***

## 5. Design Notes

*   No UI dependencies or references
*   No shared mutable state outside method scope
*   Thread‑safe logging
*   Fail‑safe log rotation
*   Compatible with legacy .NET frameworks
*   Designed for deterministic, replayable execution

***

## Summary

`BatchLauncher` provides a **reliable, auditable, and UI‑independent mechanism** for executing groups of configured applications. Its structured result model and resilient logging make it suitable for both interactive use and automated workflows, while its defensive design ensures failures are isolated and recoverable.

***

If you would like, I can next:

*   Add XML documentation comments directly into `BatchLauncher`
*   Provide example log file output
*   Document the launcher configuration schema
*   Add a sequence diagram description for batch execution

Just tell me how far you want to take it.
