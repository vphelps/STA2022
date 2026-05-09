Below is a **ready‑to‑save Markdown document** for the `IniFile` class, aligned in style, depth, and clarity with the other `/Docs` documentation you’ve created.

You can copy this verbatim into your solution as:

    /Docs/IniFile_Method_Overview.md

***

# IniFile — Method Overview and Responsibilities

*Last updated: 2026‑04‑22*

`IniFile` is a **managed, dataset‑backed INI file reader/writer** used to load, query, modify, and persist configuration values stored in traditional `.ini` files.

Rather than using Windows API calls, this implementation parses INI files into an in‑memory `DataSet`, where:

*   **Each INI section** is represented as a `DataTable`
*   **Each key** is represented as a `DataColumn`
*   **Each section contains a single row** holding key values

This design provides structured access while preserving compatibility with legacy INI formats.

***

## 1. Internal State

### `_fileName As String`

Stores the full path of the currently loaded INI file.

***

### `_ds As DataSet`

Holds the in‑memory representation of the INI file contents.

*   DataSet name is derived from the INI filename
*   Each table corresponds to a section
*   Each table has exactly one row

***

## 2. Constructors

### `New()`

Creates an empty `IniFile` instance without loading a file.

***

### `New(iniFileName As String)`

Creates an `IniFile` instance and immediately loads the specified INI file into memory.

Setting the filename triggers parsing via `LoadIniToDataSet`.

***

## 3. Read Operations

### `ReadString(section As String, key As String)`

Reads a string value from the given section and key.

*   Returns an empty string if the key or section does not exist
*   Delegates to the overload with a default value

***

### `ReadString(section As String, key As String, defaultValue As String)`

Reads a string value and returns the provided default value if the key or section is missing.

***

### `ReadString(section As String, key As String, defaultValue As String, iniFileName As String)`

Loads the specified INI file and then reads the string value using the given defaults.

***

### `ReadInteger(section As String, key As String)`

Reads an integer value, defaulting to `0` if missing or invalid.

***

### `ReadInteger(section As String, key As String, defaultValue As Integer)`

Reads an integer value with a caller‑supplied default.

*   Internally reads as a string
*   Performs safe conversion
*   Returns `0` if conversion fails

***

### `ReadInteger(section As String, key As String, defaultValue As Integer, iniFileName As String)`

Loads the specified INI file and reads an integer value with a default.

***

### `SectionNames() As ArrayList`

Returns a list of all section names in the loaded INI file.

Each section corresponds to a `DataTable` name in the internal `DataSet`.

***

## 4. Write Operations

### `WriteString(section As String, key As String, value As String)`

Writes or updates a string value in memory and persists the dataset back to disk.

***

### `WriteString(section As String, key As String, value As String, iniFileName As String)`

Loads the specified INI file, writes the key/value pair, and saves the file.

***

### `WriteInteger(section As String, key As String, value As Integer)`

Writes an integer value by converting it to a string and delegating to `WriteString`.

***

### `WriteInteger(section As String, key As String, value As Integer, iniFileName As String)`

Loads the specified INI file and writes an integer value.

***

### `DeleteSection(section As String)`

Removes an entire INI section from memory and persists the change to disk if the section exists.

***

### `DeleteSection(section As String, iniFileName As String)`

Loads the specified INI file and deletes the given section.

***

## 5. Public Properties

### `FileName As String`

Gets or sets the currently loaded INI file.

Setting this property:

*   Updates `_fileName`
*   Reloads the INI contents into `_ds`

Repeated assignments of the same filename do not re‑load the file.

***

### `DataSet As DataSet`

Exposes the internal `DataSet` representation as read‑only for inspection or advanced usage.

***

## 6. Core Internal Logic

### `Read(section As String, key As String, defaultValue As String)`

Internal helper used by all read operations.

*   Safely retrieves a value from the dataset
*   Falls back to the default if section or key does not exist

***

### `Write(section As String, key As String, value As String)`

Internal helper used by all write operations.

Responsibilities:

*   Creates sections and keys when missing
*   Ensures that each section has a single row
*   Updates values in memory without immediately persisting

***

### `LoadIniToDataSet()`

Parses the INI file into an in‑memory `DataSet`.

Parsing rules:

*   Empty lines and comment lines (`;`) are ignored
*   `[Section]` creates a new `DataTable`
*   `key=value` pairs become columns and row values
*   Duplicate sections or keys are ignored
*   Each section stores values in a single row

The method is resilient to malformed input and skips invalid structures.

***

### `DumpDatasetToIni()`

Writes the current dataset state back to an INI file.

Behavior:

*   Deletes the existing INI file if it exists
*   Writes sections and keys in dataset order
*   Ensures clean, normalized INI formatting

This method is called after all write and delete operations.

***

## 7. Design Characteristics

*   **Dataset‑based storage**  
    Simplifies querying, updating, and persistence.

*   **Fail‑safe reads**  
    Missing sections or keys never throw.

*   **Immediate persistence**  
    All writes are flushed to disk immediately.

*   **Strict legacy compatibility**  
    Output format remains compatible with traditional INI readers.

*   **Single‑row section model**  
    Enforces a straightforward key/value structure.

***

## 8. Intended Usage

The `IniFile` class is well suited for:

*   Legacy configuration files
*   Lightweight application settings
*   Transitional systems not yet migrated to JSON or XML
*   Backwards‑compatible tooling

It is **not optimized** for:

*   High‑frequency concurrent writes
*   Large hierarchical data
*   Multi‑row per‑section INI semantics

***

## Summary

`IniFile` provides a **robust, structured abstraction over legacy INI files** using modern .NET constructs. By mapping INI content into a `DataSet`, it enables safe reading, controlled writing, and predictable persistence while maintaining backward compatibility with existing configuration formats.

***

If you want, I can next:

*   Add XML documentation comments to the class
*   Modernize it for `Dictionary(Of String, String)`–based storage
*   Add unit tests for parsing edge cases
*   Document a migration path from INI → JSON

Just let me know.
