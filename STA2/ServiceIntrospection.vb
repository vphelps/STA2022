Imports System.Diagnostics
Imports System.Management
Imports Microsoft.Win32

Public Module ServiceIntrospection

    ' Entry: returns a tuple with:
    '  - Path: the resolved file path (EXE or ServiceDll)
    '  - IsDll: True if this is a shared svchost service and we resolved a ServiceDll
    '  - Version: FileVersion (or "" if not available)
    Public Function GetServiceFileInfo(serviceName As String) As (Path As String, IsDll As Boolean, Version As String)
        Dim path As String = ""
        Dim isDll As Boolean = False
        Dim version As String = ""

        Try
            ' 1) Query WMI for Win32_Service
            Using svc As New ManagementObject($"Win32_Service.Name='{serviceName.Replace("'", "''")}'")
                svc.Get()
                Dim pathName As String = TryCast(svc("PathName"), String)

                If String.IsNullOrWhiteSpace(pathName) Then
                    Return ("", False, "")
                End If

                ' 2) Extract executable from PathName
                Dim exePath As String = ExtractExecutablePath(pathName)

                ' Expand environment variables like %SystemRoot%
                exePath = Environment.ExpandEnvironmentVariables(exePath)

                ' 3) If it's an svchost-hosted shared service, resolve the ServiceDll
                '    NOTE: services.exe is the SCM itself; svchost.exe hosts DLL-based services
                Dim fileName = IO.Path.GetFileName(exePath).ToLowerInvariant()
                If fileName = "svchost.exe" Then
                    Dim dllPath = TryGetServiceDllFromRegistry(serviceName)
                    If Not String.IsNullOrWhiteSpace(dllPath) AndAlso IO.File.Exists(dllPath) Then
                        path = dllPath
                        isDll = True
                    Else
                        path = exePath   ' fallback to the host exe if we can't resolve ServiceDll
                    End If
                Else
                    path = exePath
                End If

                ' 4) Read FileVersion
                If Not String.IsNullOrWhiteSpace(path) AndAlso IO.File.Exists(path) Then
                    Dim fvi = FileVersionInfo.GetVersionInfo(path)
                    version = If(fvi.FileVersion, "")
                End If
            End Using

        Catch ex As ManagementException
            ' Handle WMI access issues or missing service
            ' You can log ex.Message if needed
        Catch ex As Exception
            ' Swallow or log; return blanks on failure
        End Try

        Return (path, isDll, version)
    End Function

    ' Extract the executable from the service PathName (command line)
    ' Examples:
    '  - "C:\Program Files\MySvc\svc.exe" -k foo
    '  - C:\Windows\System32\svchost.exe -k netsvcs -p
    '  - "C:\Path With Spaces\app.exe"
    Private Function ExtractExecutablePath(pathName As String) As String
        Dim s = pathName.Trim()

        If s.StartsWith("""") Then
            ' Quoted path → read until closing quote
            Dim endQuote = s.IndexOf("""", 1)
            If endQuote > 1 Then
                Return s.Substring(1, endQuote - 1)
            End If
        Else
            ' Unquoted → take up to first space
            Dim firstSpace = s.IndexOf(" "c)
            If firstSpace > 0 Then
                Return s.Substring(0, firstSpace)
            End If
        End If

        ' Fallback: return the raw string (may include args)
        Return s
    End Function

    ' For svchost-hosted services, resolve the DLL from:
    '   HKLM\SYSTEM\CurrentControlSet\Services\<ServiceName>\Parameters\ServiceDll
    ' ServiceDll can be REG_EXPAND_SZ; expand it.
    Private Function TryGetServiceDllFromRegistry(serviceName As String) As String
        Try
            Const basePath As String = "SYSTEM\CurrentControlSet\Services\"
            Dim keyPath = basePath & serviceName & "\Parameters"

            ' On 64-bit OS, services are in 64-bit view. Use OpenBaseKey with RegistryView.Registry64.
            Dim hive = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, If(Environment.Is64BitOperatingSystem, RegistryView.Registry64, RegistryView.Registry32))
            Using parametersKey = hive.OpenSubKey(keyPath, writable:=False)
                If parametersKey Is Nothing Then Return ""

                Dim raw = TryCast(parametersKey.GetValue("ServiceDll"), String)
                If String.IsNullOrWhiteSpace(raw) Then Return ""

                Dim expanded = Environment.ExpandEnvironmentVariables(raw)
                Return expanded
            End Using
        Catch
            Return ""
        End Try
    End Function

End Module