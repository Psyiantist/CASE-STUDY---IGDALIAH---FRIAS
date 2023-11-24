Imports System.Data.OleDb

Module DatabaseConnection
    Public cn As New OleDbConnection
    Public cmd As OleDbCommand
    Public dr As OleDbDataReader
    Public sql As String

    Public Sub Connection()
        Try
            cn.Close()
            cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & System.IO.Path.Combine(Application.StartupPath, "POSdb.mdb") & ";"
            cn.Open()
            MsgBox("Connection Success.")
        Catch ex As Exception
            MsgBox("Error connecting to the database: " & ex.Message)
        End Try
    End Sub
End Module