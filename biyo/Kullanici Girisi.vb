''Public Class Kullanici_Girisi
''Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
''Me.Hide()
''Form1.Show()
''End Sub

''Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

''End Sub

''Private Sub Kullanici_Girisi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

''End Sub
''End Class
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient


Public Class Kullanici_Girisi

    'Public vardiya As String
    Public yetki As String
    Public accessbaglanti As New OleDb.OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=database.accdb")
    Public accessbaglanti1 As New OleDb.OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=database.accdb")
    Public accessbaglanti2 As New OleDb.OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=database.accdb")

    Public komut As New OleDb.OleDbCommand

    Public Sub isimcek()
            ComboBox1.Items.Clear()
        'Dim baglanti3 As New SqlClient.SqlConnection("Server=" & My.Settings.servernamea & "; Database= " & My.Settings.databasenamea & "; integrated security=true")

        komut.CommandText = "select * from kullanici_girisi"
        komut.Connection = accessbaglanti
        komut.CommandType = CommandType.Text

        Dim mr As OleDbDataReader
        Try
            accessbaglanti.Open()
        Catch
            MsgBox("Bağlantı yapılamadı. Lütfen access(veri dosyası) bağlantınızı kontrol ediniz")
            Exit Sub
            End Try
        mr = komut.ExecuteReader()
        While (mr.Read())

                ComboBox1.Items.Add(mr("isim"))
            End While
        accessbaglanti.Close()

    End Sub
        Private Sub ileri_Click(sender As Object, e As EventArgs) Handles ileri.Click
        Try
            accessbaglanti1.Open()
            accessbaglanti2.Open()
        Catch
            MsgBox("Bağlantı yapılamadı. Lütfen access(veri dosyası) bağlantınızı kontrol ediniz")
            Exit Sub
            End Try

            Dim sorgu1 As String
            Dim sorgu2 As String
            sorgu1 = "select * from kullanici_girisi"
            sorgu2 = "select COUNT (*) as c from kullanici_girisi"



        Dim okunan As OleDbDataReader
        Dim sayilan As OleDbDataReader
        Dim komut1 As New OleDbCommand(sorgu1, accessbaglanti1)
        Dim say As New OleDbCommand(sorgu2, accessbaglanti2)

        okunan = komut1.ExecuteReader
        sayilan = say.ExecuteReader

            Dim a As String
            If ComboBox1.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Kullanıcı adı veya şifre boş olamaz")
                Exit Sub
                'ElseIf ComboBox1.Text = "" Then
                'MsgBox("Vardiya alanı boş olamaz")
                'Exit Sub
            Else
                a = TextBox2.Text
                Dim b As Integer
                Do While sayilan.Read()
                    b = sayilan("c")
                    Exit Do
                Loop
                Dim data As New DataSet
                Dim i As Integer
                Dim bulundu As String
                bulundu = "bulunmadı"
                i = 0
                Do While okunan.Read()
                    i = i + 1


                    If (okunan("isim") = ComboBox1.Text) And (okunan("sifre") = a) And (okunan("yetki") = "admin") Then


                        MsgBox("Admin Kullanıcı Girişi Yapıldı")
                        bulundu = "tamam"
                        yetki = "admin"
                    'vardiya = ComboBox1.Text
                    Form1.Show()


                    Me.Hide()

                        Exit Do
                    ElseIf (okunan("isim") = ComboBox1.Text) And (okunan("sifre") = a And (okunan("yetki") = "operatör")) Then

                        Enabled = False

                    'vardiya = ComboBox1.Text
                    MsgBox("Operator Kullanıcı Girişi Yapıldı")
                    yetki = "operatör"
                        bulundu = "tamam"

                    Form1.Show()



                    Me.Hide()

                        Exit Do
                    ElseIf (i - 2 = b) Then
                        MsgBox("Kullanıcı adı veya şifre hatalıdır")
                        Exit Do

                    Else



                    End If

                Loop
                If bulundu = "tamam" Then

                Else
                    MsgBox("Kullanıcı adı veya şifre hatalıdır")


                End If
            End If
        accessbaglanti1.Close()
        accessbaglanti2.Close()

    End Sub

        Private Sub kapat_Click(sender As Object, e As EventArgs) Handles kapat.Click
            Close()

        End Sub



        Private Sub kullanici_girisi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Call isimcek()
            Dim a As Date
            a = Now
        ''If a > "15.12.2021 13:15:00" Then
        ''MsgBox("Programın Deneme Lisansı Bitmiştir. lütfen Lisanslayınız.")
        ''Me.Close()
        ''End If
        My.Settings.Reload()
            'ComboBox1.Text = ""
        End Sub



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
            TextBox2.PasswordChar = "*"
        End Sub


End Class
