Public Class frmMainDashboard
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Do you want to close the system?", vbQuestion + vbYesNo) = vbYes Then
            MsgBox("Thankyou for using the system")
            Application.Exit()
        End If
    End Sub
End Class