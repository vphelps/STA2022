Option Explicit On
Option Strict On

Imports System

Public Class IniFile
    ' Managed IniFile Class

#Region "Private variables"
    ' =======================================================================
    ' Private variables used in the class

    Private _fileName As String = ""
    Private _ds As DataSet
#End Region

#Region "Contructors"
    ' =======================================================================
    ' Constructors

    Public Sub New()
        'Nothing here
    End Sub

    Public Sub New(ByVal iniFileName As String)
        ' Open the IniFile
        FileName = iniFileName
    End Sub

#End Region

#Region "Methodes"
    ' =======================================================================
    ' Methodes

    Public Overloads Function ReadString(ByVal section As String, ByVal key As String) As String
        ' Function ReadString Number 1

        ' Read string from INI Dataset

        ' Use function number 2
        ' Use an empty string as defaultvalue
        Return ReadString(section, key, "")
    End Function

    Public Overloads Function ReadString(ByVal section As String, ByVal key As String, ByVal defaultValue As String) As String
        ' Function ReadString Number 2

        ' Read string from INI Dataset
        Return Read(section, key, defaultValue)
    End Function

    Public Overloads Function ReadString(ByVal section As String, ByVal key As String, ByVal defaultValue As String, ByVal iniFileName As String) As String
        ' Function ReadString Number 3

        ' Open the IniFile
        FileName = iniFileName

        ' Read string from INI Dataset

        ' Use function number 2
        Return ReadString(section, key, defaultValue)
    End Function

    Public Overloads Function ReadInteger(ByVal section As String, ByVal key As String) As Integer
        ' Function ReadInteger Number 1

        ' Store return value

        ' Use function number 2
        ' Use 0 as defaultvalue
        Return ReadInteger(section, key, 0)
    End Function

    Public Overloads Function ReadInteger(ByVal section As String, ByVal key As String, ByVal defaultValue As Integer) As Integer
        ' Function ReadInteger Number 2

        ' Store return value
        Dim ret As Integer
        Dim tmpRet As String

        ' Read string from INI Dataset
        ' First convert DefaultValue to a string to use the Common Read function
        tmpRet = Read(section, key, CType(defaultValue, String))

        Try
            ' Convert the Value to an Integer
            ret = CType(tmpRet, Integer)

        Catch
            ' When the value couldn't convert to a integer, return zero
            ret = 0
        End Try

        Return ret
    End Function

    Public Overloads Function ReadInteger(ByVal section As String, ByVal key As String, ByVal defaultValue As Integer, ByVal iniFileName As String) As Integer
        ' Function ReadInteger Number 3

        ' Open the IniFile
        FileName = iniFileName

        ' Use ReadInteger function number 2
        Return ReadInteger(section, key, defaultValue)
    End Function

    Public Function SectionNames() As ArrayList
        ' Store return value in an arraylist
        Dim ret As New ArrayList()

        Dim table As DataTable

        ' Loop through all the Tables
        For Each table In _ds.Tables
            ' Add tablename to the ArrayList
            ret.Add(table.TableName)
        Next

        Return ret
    End Function

    Public Overloads Sub WriteString(ByVal section As String, ByVal key As String, ByVal value As String)
        ' Function WriteString Number 1

        ' Store data in dataset
        Write(section, key, value)

        ' Write dataset back to disk
        DumpDatasetToIni()
    End Sub

    Public Overloads Sub WriteString(ByVal section As String, ByVal key As String, ByVal value As String, ByVal iniFileName As String)
        ' Function WriteString Number 2

        ' Open the IniFile
        FileName = iniFileName

        ' Use WriteString function number 1
        WriteString(section, key, value)
    End Sub

    Public Overloads Sub WriteInteger(ByVal section As String, ByVal key As String, ByVal value As Integer)
        ' Function WriteInteger Number 1

        ' First convert Value to a string to use the WriteString function number 1
        WriteString(section, key, value.ToString)
    End Sub

    Public Overloads Sub WriteInteger(ByVal section As String, ByVal key As String, ByVal value As Integer, ByVal iniFileName As String)
        ' Function WriteInteger Number 2

        ' First convert Value to a string to use the WriteString function number 2
        WriteString(section, key, value.ToString, iniFileName)
    End Sub

    Public Overloads Sub DeleteSection(ByVal section As String)
        ' Function DeleteSection Number 1

        ' Delete 'Section' Table from Dataset
        ' First check if section exists
        If Not (_ds.Tables(section) Is Nothing) Then
            ' Section is found, so kill it
            _ds.Tables.Remove(section)

            ' Write dataset back to disk
            DumpDatasetToIni()
        End If
    End Sub

    Public Overloads Sub DeleteSection(ByVal section As String, ByVal iniFileName As String)
        ' Function DeleteSection Number 2

        ' Open the IniFile
        FileName = iniFileName

        ' Use DeleteSection function number 1
        DeleteSection(section)
    End Sub
#End Region

#Region "Properties"
    ' =======================================================================
    ' Properties

    Public Property FileName() As String
        Get
            ' Return Filename
            Return _fileName
        End Get
        Set(ByVal value As String)
            ' Check if File is allready open
            If value.Trim <> _fileName Then
                ' If not, open it
                _fileName = value

                LoadIniToDataSet()
            End If
        End Set
    End Property

    Public ReadOnly Property DataSet() As DataSet
        Get
            ' Return Dataset
            Return _ds
        End Get
    End Property

#End Region

#Region "Private Section"
    ' =======================================================================
    ' Private Section

    Private Function Read(ByVal section As String, ByVal key As String, ByVal defaultValue As String) As String
        ' Store return value
        Dim ret As String

        Try
            ' Section = TableName
            ' Key = ColumnName
            ' Row = 0, because there is only one row for each table
            ' Get the value from the dataset
            ret = _ds.Tables(section).Rows(0).Item(key).ToString

        Catch
            ' If the Section or Key isn't found return the DefaultValue
            ret = defaultValue
        End Try

        Return ret
    End Function

    Private Sub Write(ByVal section As String, ByVal key As String, ByVal value As String)
        ' Section = Table
        ' Key = Column
        ' Row = 0, because there is only one row for each table

        ' Look for section in Dataset
        If (_ds.Tables(section) Is Nothing) Then
            ' Section is not found
            ' Add section to the dataset
            _ds.Tables.Add(section)

            ' Add Key to Section
            _ds.Tables(section).Columns.Add(key)

            ' We must add a new row to the dataset
            Dim row As DataRow
            row = _ds.Tables(section).NewRow

            ' Add Value to Key
            row.Item(key) = value
            _ds.Tables(section).Rows.Add(row)

        Else
            ' Section was found, now look for key in section
            If (_ds.Tables(section).Columns(key) Is Nothing) Then
                ' Key is not found
                ' Add key to the section
                _ds.Tables(section).Columns.Add(key)
            End If

            ' Update Value for key
            _ds.Tables(section).Rows(0).Item(key) = value

        End If
    End Sub

    Private Overloads Sub LoadIniToDataSet()
        ' Initialise Dataset
        _ds = New DataSet()

        ' Open the File
        Dim file As New IO.FileInfo(_fileName)

        ' Create DatasetName from IniFileName by removing the file extention
        _ds.DataSetName = file.Name.Remove(file.Name.IndexOf(file.Extension, StringComparison.OrdinalIgnoreCase), file.Extension.Length)

        ' Check if inifile exists on specified path
        If file.Exists() Then
            ' Store each Section as a Table in the Dataset
            Dim table As DataTable = Nothing

            ' Define row to fill with KeyValue
            Dim row As DataRow = Nothing

            ' A switch to keep track when we have add the row to the table
            Dim addRow As Boolean = False

            ' A switch to keep track when we have add the row to the table
            Dim skipSection As Boolean = False

            ' Use a filestream to read the IniFile
            Dim fileStream As New IO.StreamReader(_fileName)
            Dim readLine As String

            ' Read the first line
            readLine = fileStream.ReadLine

            ' Loop to the end of the File
            Do While Not (readLine Is Nothing)
                ' Trim all leading en ending spaces
                readLine = readLine.Trim()

                ' Skip empty lines and commented lines
                If readLine <> "" And Not readLine.StartsWith(";") Then

                    ' Check if the line is a Section Header
                    If readLine.StartsWith("[") AndAlso readLine.EndsWith("]") Then
                        ' A new Section means a new Table

                        ' Before we create a new table
                        ' add all the values to the previous created table
                        If addRow Then
                            table.Rows.Add(row)
                        End If

                        ' remove brackets from readline
                        readLine = readLine.TrimStart("["c)
                        readLine = readLine.TrimEnd("]"c)

                        ' Tablename is SectionName
                        ' Check if table allready exists
                        ' If so, skip the rest of the section
                        ' An iniFile can't have double sections

                        ' First set it to True, will be corrected a few lines below
                        skipSection = True

                        table = _ds.Tables(readLine)
                        If (table Is Nothing) Then
                            ' If not, Create new table
                            table = New DataTable(readLine)

                            ' Add Table to Dataset
                            _ds.Tables.Add(table)

                            ' Adds a new row to the table
                            row = table.NewRow

                            skipSection = False
                        End If

                        ' Clear switch
                        addRow = False
                    Else

                        If Not skipSection Then
                            Dim index As Integer = readLine.IndexOf("="c)
                            Dim column As String
                            If index < 0 Then
                                column = readLine
                            Else
                                column = readLine.Substring(0, index)
                            End If

                            ' Columnname is Key
                            ' Check if Key allready exists
                            ' if so Skip it, a section can't have double keys
                            If (table.Columns(column) Is Nothing) Then
                                ' Add Key as a new column to the table
                                table.Columns.Add(column)

                                ' Check if line is splitted ok
                                If index >= 0 Then
                                    ' Fill Key-column with KeyValue 
                                    row.Item(column) = readLine.Substring(index + 1)

                                Else
                                    ' Fill Key-column with empty string 
                                    row.Item(column) = ""
                                End If

                                ' Set switch for adding row
                                addRow = True
                            End If

                        End If
                    End If
                End If

                ' Read next Line
                readLine = fileStream.ReadLine
            Loop

            ' Don't forget the last entries
            If addRow Then
                table.Rows.Add(row)
            End If

            ' Close file
            fileStream.Close()

        End If
    End Sub

    Private Sub DumpDatasetToIni()
        ' Check if inifile exists on specified path
        If IO.File.Exists(_fileName) Then
            ' if, so....delete it
            IO.File.Delete(_fileName)
        End If

        ' Use a StreamWriter to make a new inifile
        Dim file As IO.StreamWriter = IO.File.CreateText(_fileName)

        ' Section = TableName
        ' Key = ColumnName
        ' Row = 0, because there is only one row for each table
        Dim table As DataTable
        Dim col As DataColumn
        Dim value As String

        ' Loop through all sections
        For Each table In _ds.Tables
            ' Write section name
            file.WriteLine("[" & table.TableName & "]")

            ' Loop through all key's in section
            For Each col In table.Columns
                ' Find value for key
                value = table.Rows(0).Item(col).ToString

                ' Write Key and Value
                file.WriteLine(col.ColumnName & "=" & value)
            Next

            ' Make an empty line between the sections
            file.WriteLine("")
        Next

        ' Close IniFile
        file.Close()

    End Sub

#End Region

End Class