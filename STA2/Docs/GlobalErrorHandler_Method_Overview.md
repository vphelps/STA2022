Below is a **ready‑to‑save Markdown document** for the `GlobalErrorHandler` module, consistent in tone, structure, and depth with your other `/Docs` files.

You can copy this verbatim into your solution as:

    /Docs/GlobalErrorHandler_Method_Overview.md

***

# GlobalErrorHandler — Method Overview and Responsibilities

*Last updated: 2026‑04‑22*

`GlobalErrorHandler` is a **centralized, application‑wide exception handling module** responsible for capturing unexpected runtime errors, persisting detailed diagnostic logs to disk, and presenting a consistent, user‑friendly error message.

This module is designed to be registered at application startup and acts as a **last‑resort safety net**, ensuring that unhandled exceptions are never silently ignored.

***

## 1. Logging Configuration

### `LogFolder`

Defines the directory used to store error logs:

    <Application Base Directory>\Logs

The folder is created lazily if it does not already exist.  
Log files are written on a **per‑day basis**.

***

## 2. UI Thread Exception Handling

### `HandleThreadException(sender As Object, e As ThreadExceptionEventArgs)`

Handles exceptions thrown on the **Windows Forms UI thread**.

Responsibilities:

*   Captures exceptions raised by UI event handlers
*   Writes a detailed log entry to disk
*   Displays a generic, user‑facing error message

This method is intended to be wired to:

    Application.ThreadException

***

## 3. Non‑UI / Background Exception Handling

### `HandleUnhandledException(sender As Object, e As UnhandledExceptionEventArgs)`

Handles exceptions thrown outside the UI thread, including:

*   Background worker threads
*   Timer callbacks
*   Domain‑level unhandled exceptions

Responsibilities:

*   Attempts to extract an `Exception` instance
*   Logs full exception details when possible
*   Logs fallback text when a non‑Exception object is thrown
*   Displays a user‑facing error message

This method is intended to be wired to:

    AppDomain.CurrentDomain.UnhandledException

***

## 4. Core Logging Logic

### `LogException(source As String, ex As Exception)`

Writes a structured error entry to a daily log file.

Each entry includes:

*   Timestamp
*   Exception source context
*   Machine name
*   User name
*   Operating system version
*   .NET CLR version
*   Full exception details (including inner exceptions)

Log file naming format:

    Error_yyyyMMdd.log

Multiple errors on the same day are appended to the same file.

***

### `WriteException(sw As StreamWriter, ex As Exception, Optional level As Integer = 0)`

Recursively writes exception details, supporting unlimited nested inner exceptions.

Responsibilities:

*   Outputs exception type, message, and stack trace
*   Indents inner exceptions for readability
*   Ensures clear visual hierarchy in logs

This method is deliberately isolated to keep recursive exception handling clean and reusable.

***

## 5. Fallback Logging

### `LogText(message As String)`

Writes a simple timestamped text entry to the daily error log.

Used when:

*   A non‑Exception object is thrown
*   Exception casting fails
*   Minimal diagnostic context is available

This method prevents loss of diagnostic signal in edge cases.

***

## 6. User‑Facing Error Messaging

### `ShowUserMessage()`

Displays a generic, non‑technical error dialog to the user.

Message intent:

*   Acknowledge that an unexpected error occurred
*   Reassure the user that the error was logged
*   Avoid exposing sensitive or confusing technical details

This method prioritizes **user trust and clarity** over diagnostic verbosity.

***

## 7. Design Principles

*   **Centralized error handling**  
    All unhandled exceptions flow through one module.

*   **Fail‑safe logging**  
    Logging never throws or blocks application execution.

*   **Separation of concerns**  
    Diagnostic detail is written to disk; users receive a simplified message.

*   **Thread‑agnostic safety**  
    Supports both UI and non‑UI exception contexts.

*   **Minimal dependencies**  
    No reliance on application‑specific logic beyond the message box.

***

## 8. Intended Usage Pattern

This module is typically registered during application startup:

```vb
AddHandler Application.ThreadException,
           AddressOf GlobalErrorHandler.HandleThreadException

AddHandler AppDomain.CurrentDomain.UnhandledException,
           AddressOf GlobalErrorHandler.HandleUnhandledException
```

Once registered, no additional integration is required.

***

## Summary

`GlobalErrorHandler` provides a **stable, defensive, and user‑safe error handling layer** for the application. By combining detailed logging with restrained user messaging, it ensures that unexpected failures are diagnosable by developers without overwhelming or alarming end users.

It acts as the **final guardrail** against silent crashes and untraceable failures.

***

If you’d like, I can next:

*   Add XML documentation comments directly to the module
*   Provide a production‑ready startup wiring snippet
*   Extend logging with correlation IDs or session identifiers
*   Add optional email or event‑log integration

Just tell me how far you want to take it.
