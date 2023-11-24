Imports System.Data.OleDb

Public Class Form1
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = "Today is: " + Date.Now
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Do you want to close the system?", vbQuestion + vbYesNo) = vbYes Then
            MsgBox("Thankyou for using the system")
            Application.Exit()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Connection()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" And TextBox2.Text = "" Then
            MsgBox("Please enter your username and password.")
        Else
            Call Login()
        End If
    End Sub

    Private Sub Login()
        sql = "SELECT * FROM tblUsers WHERE username='" & TextBox1.Text & "' AND password='" & TextBox2.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader()
        If dr.Read = True Then
            frmMainDashboard.empName.Text = dr("lastname").ToString & ", " & dr("firstname").ToString
            frmMainDashboard.empPos.Text = dr("role").ToString
            MsgBox("Access Granted", MsgBoxStyle.Information)
            frmMainDashboard.Show()
        Else
            MsgBox("Access Denied", MsgBoxStyle.Critical)
        End If
        TextBox1.Select()
    End Sub

    Private Sub clearText()
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        sql = "SELECT [role] FROM tblUsers where username='" & TextBox1.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader()
        If dr.Read = True Then
            lblRole.Text = dr(0).ToString
        Else
            lblRole.Text = ""
        End If
    End Sub
End Class
