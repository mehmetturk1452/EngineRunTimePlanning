Public Class Form1
    Public plc1 As New S7.Net.Plc(S7.Net.CpuType.S71200, "192.168.0.1", 0, 1)


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        calisma_parametreleri.Show()
        Me.Hide()
    End Sub
End Class
