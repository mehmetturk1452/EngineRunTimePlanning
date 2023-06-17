Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports S7.Net
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Data.DataTable
Imports System.Configuration
Imports Microsoft.Office.Interop.Access.Dao
Imports System.Data.OleDb
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Access
Public Class calisma_parametreleri
    Public x(150) As Boolean
    Public r(150) As Color
    Public button(216) As Button
    Public accessbaglanti As New OleDb.OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=database.accdb")
    Public komut As New OleDb.OleDbCommand
    Public data As New DataTable

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Label1600.Text = MonthCalendar1.SelectionStart.DayOfWeek.ToString
        Call goster()
    End Sub



    Public Sub goster()
        Dim cb As String


        cb = ComboBox1.Text.Substring(0, 1) & ComboBox1.Text.Substring(ComboBox1.Text.Length - 1, 1)

        Dim adaptor As New OleDb.OleDbDataAdapter("Select * from " & cb & MonthCalendar1.SelectionStart.DayOfWeek.ToString, accessbaglanti)
        'accessbaglanti.Open()
        komut.CommandText = "select * from " & cb & MonthCalendar1.SelectionStart.DayOfWeek.ToString
        komut.Connection = accessbaglanti
        komut.CommandType = CommandType.Text

        data.Clear()

        Dim primaryKey(0) As DataColumn
        primaryKey(0) = data.Columns("numara")
        data.PrimaryKey = primaryKey
        Dim nmr As OleDbDataReader
        Dim i As Integer

        Try
            accessbaglanti.Open()
        Catch
            MsgBox("Bağlantı yapılamadı. Lütfen access dosyanızı kontrol ediniz")
            Exit Sub
        End Try
        nmr = komut.ExecuteReader()

        i = 1
        While (nmr.Read())

            data.Rows.Add(nmr("numara"), nmr("Saat"), nmr("Deger"))
            If nmr("Deger") = False Then
                r(i) = Color.LightSeaGreen
                x(i) = False
            Else
                r(i) = Color.LimeGreen
                x(i) = True
            End If
            i += 1
        End While

        accessbaglanti.Close()


        DataGridView1.AutoResizeColumn(0)
        DataGridView1.AutoResizeColumn(1)
        DataGridView1.AutoResizeColumn(2)
        'accessbaglanti.Close()
        DataGridView1.RowHeadersWidth = 30
        Call renkatama()
    End Sub

    Private Sub calisma_parametreleri_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Start()
        Call label_doldur()

        DataGridView1.DataSource = data

        data.Columns.Add("Numara")
        data.Columns.Add("Saat")
        data.Columns.Add("Deger")
        Call buton_atama()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cb As String

        If ComboBox1.Text <> "" Then

            cb = ComboBox1.Text.Substring(0, 1) & ComboBox1.Text.Substring(ComboBox1.Text.Length - 1, 1)
            If CheckBox1.Checked = True Then

                Try
                    accessbaglanti.Open()
                    Dim i As Integer
                    i = 1

                    Do While i < 145
                        komut.Connection = accessbaglanti
                        komut.CommandText = "UPDATE " & cb & "Monday SET Deger='" & x(i) & "' WHERE    Numara=" & i
                        komut.ExecuteNonQuery()
                        komut.CommandText = "UPDATE " & cb & "Tuesday SET Deger='" & x(i) & "' WHERE    Numara=" & i
                        komut.ExecuteNonQuery()
                        komut.CommandText = "UPDATE " & cb & "Wednesday SET Deger='" & x(i) & "' WHERE    Numara=" & i
                        komut.ExecuteNonQuery()
                        komut.CommandText = "UPDATE " & cb & "Thursday SET Deger='" & x(i) & "' WHERE    Numara=" & i
                        komut.ExecuteNonQuery()
                        komut.CommandText = "UPDATE " & cb & "Friday SET Deger='" & x(i) & "' WHERE    Numara=" & i
                        komut.ExecuteNonQuery()
                        komut.CommandText = "UPDATE " & cb & "Saturday SET Deger='" & x(i) & "' WHERE    Numara=" & i
                        komut.ExecuteNonQuery()
                        komut.CommandText = "UPDATE " & cb & "Sunday SET Deger='" & x(i) & "' WHERE    Numara=" & i
                        komut.ExecuteNonQuery()
                        i += 1
                    Loop
                    MsgBox("Haftalık Plan Değiştirildi.")
                    accessbaglanti.Close()
                Catch
                    MsgBox("Veriler Database'e Yazılamadı. Lütfen Planı Tekrar Gözden Geçiriniz")

                End Try
            Else
                Try

                    accessbaglanti.Open()
                    Dim i As Integer
                    i = 1

                    Do While i < 145
                        komut.Connection = accessbaglanti
                        komut.CommandText = "UPDATE " & cb & MonthCalendar1.SelectionStart.DayOfWeek.ToString & " SET Deger='" & x(i) & "' WHERE    Numara=" & i
                        komut.ExecuteNonQuery()

                        i += 1
                    Loop
                    MsgBox("Günlük Plan Değiştirildi.")
                    accessbaglanti.Close()
                Catch
                    MsgBox("Veriler Database'e Yazılamadı. Lütfen Planı Tekrar Gözden Geçiriniz")

                End Try
            End If
        Else
            MsgBox("lütfen Öncelikle Hangi Motorun Planını Yapmak İstediğinizi Seçiniz")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form1.Show()

    End Sub
    Private Sub toplu_click(sender As Object, e As EventArgs) Handles Button01.Click, Button02.Click,
    Button03.Click,
Button04.Click,
Button05.Click,
Button06.Click,
Button07.Click,
Button08.Click,
Button09.Click,
Button10.Click,
Button11.Click,
Button12.Click,
Button13.Click,
Button14.Click,
Button15.Click,
Button16.Click,
Button17.Click,
Button18.Click,
Button19.Click,
Button20.Click,
Button21.Click,
Button22.Click,
Button23.Click,
Button24.Click,
Button25.Click,
Button26.Click,
Button27.Click,
Button28.Click,
Button29.Click,
Button30.Click,
Button31.Click,
Button32.Click,
Button33.Click,
Button34.Click,
Button35.Click,
Button36.Click,
Button37.Click,
Button38.Click,
Button39.Click,
Button40.Click,
Button41.Click,
Button42.Click,
Button43.Click,
Button44.Click,
Button45.Click,
Button46.Click,
Button47.Click,
Button48.Click,
Button49.Click,
Button50.Click,
Button51.Click,
Button52.Click,
Button53.Click,
Button54.Click,
Button55.Click,
Button56.Click,
Button57.Click,
Button58.Click,
Button59.Click,
Button60.Click,
Button61.Click,
Button62.Click,
Button63.Click,
Button64.Click,
Button65.Click,
Button66.Click,
Button67.Click,
Button68.Click,
Button69.Click,
Button70.Click,
Button71.Click,
Button72.Click,
Button73.Click,
Button74.Click,
Button75.Click,
Button76.Click,
Button77.Click,
Button78.Click,
Button79.Click,
Button80.Click,
Button81.Click,
Button82.Click,
Button83.Click,
Button84.Click,
Button85.Click,
Button86.Click,
Button87.Click,
Button88.Click,
Button89.Click,
Button90.Click,
Button91.Click,
Button92.Click,
Button93.Click,
Button94.Click,
Button95.Click,
Button96.Click,
Button97.Click,
Button98.Click,
Button99.Click,
Button100.Click,
Button101.Click,
Button102.Click,
Button103.Click,
Button104.Click,
Button105.Click,
Button106.Click,
Button107.Click,
Button108.Click,
Button109.Click,
Button110.Click,
Button111.Click,
Button112.Click,
Button113.Click,
Button114.Click,
Button115.Click,
Button116.Click,
Button117.Click,
Button118.Click,
Button119.Click,
Button120.Click,
Button121.Click,
Button122.Click,
Button123.Click,
Button124.Click,
Button125.Click,
Button126.Click,
Button127.Click,
Button128.Click,
Button129.Click,
Button130.Click,
Button131.Click,
Button132.Click,
Button133.Click,
Button134.Click,
Button135.Click,
Button136.Click,
Button137.Click,
Button138.Click,
Button139.Click,
Button140.Click,
Button141.Click,
Button142.Click,
Button143.Click,
Button144.Click

        Dim i As String
        Dim a As String
        Dim b As String

        If CType(sender, Button).Name.ToString.Length < 9 Then
            a = CType(sender, Button).Name.ToString
            b = a.Substring(a.Length - 2, 2)
            i = Convert.ToDecimal(b)
        Else
            a = CType(sender, Button).Name.ToString
            b = a.Substring(a.Length - 3, 3)
            i = Convert.ToDecimal(b)

        End If
        If r(i) = Color.LightSeaGreen Then
            r(i) = Color.LimeGreen
            x(i) = True

            Dim bulunansatır As DataRow
            bulunansatır = data.Rows.Find(New Object() {i})

            If bulunansatır IsNot Nothing Then
                bulunansatır(2) = "True"
            End If

        Else
            r(i) = Color.LightSeaGreen
            x(i) = False
            Dim bulunansatır As DataRow
            bulunansatır = data.Rows.Find(New Object() {i})

            If bulunansatır IsNot Nothing Then
                bulunansatır(2) = "False"
            End If
        End If
        i += 1

        Call renkatama()
    End Sub

    Public Sub label_doldur()
        Label1.Text = "00:00-00:10"
        Label2.Text = "00:10-00:20"
        Label3.Text = "00:20-00:30"
        Label4.Text = "00:30-00:40"
        Label5.Text = "00:40-00:50"
        Label6.Text = "00:50-01:00"
        Label7.Text = "01:00-01:10"
        Label8.Text = "01:10-01:20"
        Label9.Text = "01:20-01:30"
        Label10.Text = "01:30-01:40"
        Label11.Text = "01:40-01:50"
        Label12.Text = "01:50-02:00"
        Label13.Text = "02:00-02:10"
        Label14.Text = "02:10-02:20"
        Label15.Text = "02:20-02:30"
        Label16.Text = "02:30-02:40"
        Label17.Text = "02:40-02:50"
        Label18.Text = "02:50-03:00"
        Label19.Text = "03:00-03:10"
        Label20.Text = "03:10-03:20"
        Label21.Text = "03:20-03:30"
        Label22.Text = "03:30-03:40"
        Label23.Text = "03:40-03:50"
        Label24.Text = "03:50-04:00"
        Label25.Text = "04:00-04:10"
        Label26.Text = "04:10-04:20"
        Label27.Text = "04:20-04:30"
        Label28.Text = "04:30-04:40"
        Label29.Text = "04:40-04:50"
        Label30.Text = "04:50-05:00"
        Label31.Text = "05:00-05:10"
        Label32.Text = "05:10-05:20"
        Label33.Text = "05:20-05:30"
        Label34.Text = "05:30-05:40"
        Label35.Text = "05:40-05:50"
        Label36.Text = "05:50-06:00"
        Label37.Text = "06:00-06:10"
        Label38.Text = "06:10-06:20"
        Label39.Text = "06:20-06:30"
        Label40.Text = "06:30-06:40"
        Label41.Text = "06:40-06:50"
        Label42.Text = "06:50-07:00"
        Label43.Text = "07:00-07:10"
        Label44.Text = "07:10-07:20"
        Label45.Text = "07:20-07:30"
        Label46.Text = "07:30-07:40"
        Label47.Text = "07:40-07:50"
        Label48.Text = "07:50-08:00"
        Label49.Text = "08:00-08:10"
        Label50.Text = "08:10-08:20"
        Label51.Text = "08:20-08:30"
        Label52.Text = "08:30-08:40"
        Label53.Text = "08:40-08:50"
        Label54.Text = "08:50-09:00"
        Label55.Text = "09:00-09:10"
        Label56.Text = "09:10-09:20"
        Label57.Text = "09:20-09:30"
        Label58.Text = "09:30-09:40"
        Label59.Text = "09:40-09:50"
        Label60.Text = "09:50-10:00"
        Label61.Text = "10:00-10:10"
        Label62.Text = "10:10-10:20"
        Label63.Text = "10:20-10:30"
        Label64.Text = "10:30-10:40"
        Label65.Text = "10:40-10:50"
        Label66.Text = "10:50-11:00"
        Label67.Text = "11:00-11:10"
        Label68.Text = "11:10-11:20"
        Label69.Text = "11:20-11:30"
        Label70.Text = "11:30-11:40"
        Label71.Text = "11:40-11:50"
        Label72.Text = "11:50-12:00"
        Label73.Text = "12:00-12:10"
        Label74.Text = "12:10-12:20"
        Label75.Text = "12:20-12:30"
        Label76.Text = "12:30-12:40"
        Label77.Text = "12:40-12:50"
        Label78.Text = "12:50-13:00"
        Label79.Text = "13:00-13:10"
        Label80.Text = "13:10-13:20"
        Label81.Text = "13:20-13:30"
        Label82.Text = "13:30-13:40"
        Label83.Text = "13:40-13:50"
        Label84.Text = "13:50-14:00"
        Label85.Text = "14:00-14:10"
        Label86.Text = "14:10-14:20"
        Label87.Text = "14:20-14:30"
        Label88.Text = "14:30-14:40"
        Label89.Text = "14:40-14:50"
        Label90.Text = "14:50-15:00"
        Label91.Text = "15:00-15:10"
        Label92.Text = "15:10-15:20"
        Label93.Text = "15:20-15:30"
        Label94.Text = "15:30-15:40"
        Label95.Text = "15:40-15:50"
        Label96.Text = "15:50-16:00"
        Label97.Text = "16:00-16:10"
        Label98.Text = "16:10-16:20"
        Label99.Text = "16:20-16:30"
        Label100.Text = "16:30-16:40"
        Label101.Text = "16:40-16:50"
        Label102.Text = "16:50-17:00"
        Label103.Text = "17:00-17:10"
        Label104.Text = "17:10-17:20"
        Label105.Text = "17:20-17:30"
        Label106.Text = "17:30-17:40"
        Label107.Text = "17:40-17:50"
        Label108.Text = "17:50-18:00"
        Label109.Text = "18:00-18:10"
        Label110.Text = "18:10-18:20"
        Label111.Text = "18:20-18:30"
        Label112.Text = "18:30-18:40"
        Label113.Text = "18:40-18:50"
        Label114.Text = "18:50-19:00"
        Label115.Text = "19:00-19:10"
        Label116.Text = "19:10-19:20"
        Label117.Text = "19:20-19:30"
        Label118.Text = "19:30-19:40"
        Label119.Text = "19:40-19:50"
        Label120.Text = "19:50-20:00"
        Label121.Text = "20:00-20:10"
        Label122.Text = "20:10-20:20"
        Label123.Text = "20:20-20:30"
        Label124.Text = "20:30-20:40"
        Label125.Text = "20:40-20:50"
        Label126.Text = "20:50-21:00"
        Label127.Text = "21:00-21:10"
        Label128.Text = "21:10-21:20"
        Label129.Text = "21:20-21:30"
        Label130.Text = "21:30-21:40"
        Label131.Text = "21:40-21:50"
        Label132.Text = "21:50-22:00"
        Label133.Text = "22:00-22:10"
        Label134.Text = "22:10-22:20"
        Label135.Text = "22:20-22:30"
        Label136.Text = "22:30-22:40"
        Label137.Text = "22:40-22:50"
        Label138.Text = "22:50-23:00"
        Label139.Text = "23:00-23:10"
        Label140.Text = "23:10-23:20"
        Label141.Text = "23:20-23:30"
        Label142.Text = "23:30-23:40"
        Label143.Text = "23:40-23:50"
        Label144.Text = "23:50-00:00"
        Label145.Text = "00:00-00:30"
        Label146.Text = "00:30-01:00"
        Label147.Text = "01:00-01:30"
        Label148.Text = "01:30-02:00"
        Label149.Text = "02:00-02:30"
        Label150.Text = "02:30-03:00"
        Label151.Text = "03:00-03:30"
        Label152.Text = "03:30-04:00"
        Label153.Text = "04:00-04:30"
        Label154.Text = "04:30-05:00"
        Label155.Text = "05:00-05:30"
        Label156.Text = "05:30-06:00"
        Label157.Text = "06:00-06:30"
        Label158.Text = "06:30-07:00"
        Label159.Text = "07:00-07:30"
        Label160.Text = "07:30-08:00"
        Label161.Text = "08:00-08:30"
        Label162.Text = "08:30-09:00"
        Label163.Text = "09:00-09:30"
        Label164.Text = "09:30-10:00"
        Label165.Text = "10:00-10:30"
        Label166.Text = "10:30-11:00"
        Label167.Text = "11:00-11:30"
        Label168.Text = "11:30-12:00"
        Label169.Text = "12:00-12:30"
        Label170.Text = "12:30-13:00"
        Label171.Text = "13:00-13:30"
        Label172.Text = "13:30-14:00"
        Label173.Text = "14:00-14:30"
        Label174.Text = "14:30-15:00"
        Label175.Text = "15:00-15:30"
        Label176.Text = "15:30-16:00"
        Label177.Text = "16:00-16:30"
        Label178.Text = "16:30-17:00"
        Label179.Text = "17:00-17:30"
        Label180.Text = "17:30-18:00"
        Label181.Text = "18:00-18:30"
        Label182.Text = "18:30-19:00"
        Label183.Text = "19:00-19:30"
        Label184.Text = "19:30-20:00"
        Label185.Text = "20:00-20:30"
        Label186.Text = "20:30-21:00"
        Label187.Text = "21:00-21:30"
        Label188.Text = "21:30-22:00"
        Label189.Text = "22:00-22:30"
        Label190.Text = "22:30-23:00"
        Label191.Text = "23:00-23:30"
        Label192.Text = "23:30-00:00"
        Label193.Text = "00:00-01:00"
        Label194.Text = "01:00-02:00"
        Label195.Text = "02:00-03:00"
        Label196.Text = "03:00-04:00"
        Label197.Text = "04:00-05:00"
        Label198.Text = "05:00-06:00"
        Label199.Text = "06:00-07:00"
        Label200.Text = "07:00-08:00"
        Label201.Text = "08:00-09:00"
        Label202.Text = "09:00-10:00"
        Label203.Text = "10:00-11:00"
        Label204.Text = "11:00-12:00"
        Label205.Text = "12:00-13:00"
        Label206.Text = "13:00-14:00"
        Label207.Text = "14:00-15:00"
        Label208.Text = "15:00-16:00"
        Label209.Text = "16:00-17:00"
        Label210.Text = "17:00-18:00"
        Label211.Text = "18:00-19:00"
        Label212.Text = "19:00-20:00"
        Label213.Text = "20:00-21:00"
        Label214.Text = "21:00-22:00"
        Label215.Text = "22:00-23:00"
        Label216.Text = "23:00-00:00"


    End Sub
    Public Sub renkatama()
        Button01.BackColor = r(1)
        Button02.BackColor = r(2)
        Button03.BackColor = r(3)
        Button04.BackColor = r(4)
        Button05.BackColor = r(5)
        Button06.BackColor = r(6)
        Button07.BackColor = r(7)
        Button08.BackColor = r(8)
        Button09.BackColor = r(9)
        Button10.BackColor = r(10)
        Button11.BackColor = r(11)
        Button12.BackColor = r(12)
        Button13.BackColor = r(13)
        Button14.BackColor = r(14)
        Button15.BackColor = r(15)
        Button16.BackColor = r(16)
        Button17.BackColor = r(17)
        Button18.BackColor = r(18)
        Button19.BackColor = r(19)
        Button20.BackColor = r(20)
        Button21.BackColor = r(21)
        Button22.BackColor = r(22)
        Button23.BackColor = r(23)
        Button24.BackColor = r(24)
        Button25.BackColor = r(25)
        Button26.BackColor = r(26)
        Button27.BackColor = r(27)
        Button28.BackColor = r(28)
        Button29.BackColor = r(29)
        Button30.BackColor = r(30)
        Button31.BackColor = r(31)
        Button32.BackColor = r(32)
        Button33.BackColor = r(33)
        Button34.BackColor = r(34)
        Button35.BackColor = r(35)
        Button36.BackColor = r(36)
        Button37.BackColor = r(37)
        Button38.BackColor = r(38)
        Button39.BackColor = r(39)
        Button40.BackColor = r(40)
        Button41.BackColor = r(41)
        Button42.BackColor = r(42)
        Button43.BackColor = r(43)
        Button44.BackColor = r(44)
        Button45.BackColor = r(45)
        Button46.BackColor = r(46)
        Button47.BackColor = r(47)
        Button48.BackColor = r(48)
        Button49.BackColor = r(49)
        Button50.BackColor = r(50)
        Button51.BackColor = r(51)
        Button52.BackColor = r(52)
        Button53.BackColor = r(53)
        Button54.BackColor = r(54)
        Button55.BackColor = r(55)
        Button56.BackColor = r(56)
        Button57.BackColor = r(57)
        Button58.BackColor = r(58)
        Button59.BackColor = r(59)
        Button60.BackColor = r(60)
        Button61.BackColor = r(61)
        Button62.BackColor = r(62)
        Button63.BackColor = r(63)
        Button64.BackColor = r(64)
        Button65.BackColor = r(65)
        Button66.BackColor = r(66)
        Button67.BackColor = r(67)
        Button68.BackColor = r(68)
        Button69.BackColor = r(69)
        Button70.BackColor = r(70)
        Button71.BackColor = r(71)
        Button72.BackColor = r(72)
        Button73.BackColor = r(73)
        Button74.BackColor = r(74)
        Button75.BackColor = r(75)
        Button76.BackColor = r(76)
        Button77.BackColor = r(77)
        Button78.BackColor = r(78)
        Button79.BackColor = r(79)
        Button80.BackColor = r(80)
        Button81.BackColor = r(81)
        Button82.BackColor = r(82)
        Button83.BackColor = r(83)
        Button84.BackColor = r(84)
        Button85.BackColor = r(85)
        Button86.BackColor = r(86)
        Button87.BackColor = r(87)
        Button88.BackColor = r(88)
        Button89.BackColor = r(89)
        Button90.BackColor = r(90)
        Button91.BackColor = r(91)
        Button92.BackColor = r(92)
        Button93.BackColor = r(93)
        Button94.BackColor = r(94)
        Button95.BackColor = r(95)
        Button96.BackColor = r(96)
        Button97.BackColor = r(97)
        Button98.BackColor = r(98)
        Button99.BackColor = r(99)
        Button100.BackColor = r(100)
        Button101.BackColor = r(101)
        Button102.BackColor = r(102)
        Button103.BackColor = r(103)
        Button104.BackColor = r(104)
        Button105.BackColor = r(105)
        Button106.BackColor = r(106)
        Button107.BackColor = r(107)
        Button108.BackColor = r(108)
        Button109.BackColor = r(109)
        Button110.BackColor = r(110)
        Button111.BackColor = r(111)
        Button112.BackColor = r(112)
        Button113.BackColor = r(113)
        Button114.BackColor = r(114)
        Button115.BackColor = r(115)
        Button116.BackColor = r(116)
        Button117.BackColor = r(117)
        Button118.BackColor = r(118)
        Button119.BackColor = r(119)
        Button120.BackColor = r(120)
        Button121.BackColor = r(121)
        Button122.BackColor = r(122)
        Button123.BackColor = r(123)
        Button124.BackColor = r(124)
        Button125.BackColor = r(125)
        Button126.BackColor = r(126)
        Button127.BackColor = r(127)
        Button128.BackColor = r(128)
        Button129.BackColor = r(129)
        Button130.BackColor = r(130)
        Button131.BackColor = r(131)
        Button132.BackColor = r(132)
        Button133.BackColor = r(133)
        Button134.BackColor = r(134)
        Button135.BackColor = r(135)
        Button136.BackColor = r(136)
        Button137.BackColor = r(137)
        Button138.BackColor = r(138)
        Button139.BackColor = r(139)
        Button140.BackColor = r(140)
        Button141.BackColor = r(141)
        Button142.BackColor = r(142)
        Button143.BackColor = r(143)
        Button144.BackColor = r(144)


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.Enabled = True
        Call goster()
        ComboBox2.Text = "10 DK"
    End Sub

    Private Sub toplu_Click_1(sender As Object, e As EventArgs) Handles Button145.Click,
Button146.Click,
Button147.Click,
Button148.Click,
Button149.Click,
Button150.Click,
Button151.Click,
Button152.Click,
Button153.Click,
Button154.Click,
Button155.Click,
Button156.Click,
Button157.Click,
Button158.Click,
Button159.Click,
Button160.Click,
Button161.Click,
Button162.Click,
Button163.Click,
Button164.Click,
Button165.Click,
Button166.Click,
Button167.Click,
Button168.Click,
Button169.Click,
Button170.Click,
Button171.Click,
Button172.Click,
Button173.Click,
Button174.Click,
Button175.Click,
Button176.Click,
Button177.Click,
Button178.Click,
Button179.Click,
Button180.Click,
Button181.Click,
Button182.Click,
Button183.Click,
Button184.Click,
Button185.Click,
Button186.Click,
Button187.Click,
Button188.Click,
Button189.Click,
Button190.Click,
Button191.Click,
Button192.Click



        Dim i As String
        Dim a As String
        Dim b As String


        a = CType(sender, Button).Name.ToString
        b = a.Substring(a.Length - 3, 3)
        i = Convert.ToDecimal(b) - 144
        button(i * 3).PerformClick()
        button(i * 3 - 1).PerformClick()
        button(i * 3 - 2).PerformClick()
        Dim y As Integer
        y = 1


        Do While y < 49
            If x(y * 3) = True And x(y * 3 - 1) = True And x(y * 3 - 2) = True Then
                button(y + 144).BackColor = Color.LimeGreen
            ElseIf x(y * 3) = False And x(y * 3 - 1) = False And x(y * 3 - 2) = False Then
                button(y + 144).BackColor = Color.LightSeaGreen
            Else
                button(y + 144).BackColor = Color.DarkSalmon
            End If
            y += 1
        Loop

    End Sub
    Private Sub toplu_Click_2(sender As Object, e As EventArgs) Handles Button193.Click,
Button194.Click,
Button195.Click,
Button196.Click,
Button197.Click,
Button198.Click,
Button199.Click,
Button200.Click,
Button201.Click,
Button202.Click,
Button203.Click,
Button204.Click,
Button205.Click,
Button206.Click,
Button207.Click,
Button208.Click,
Button209.Click,
Button210.Click,
Button211.Click,
Button212.Click,
Button213.Click,
Button214.Click,
Button215.Click,
Button216.Click




        Dim i As String
        Dim a As String
        Dim b As String


        a = CType(sender, Button).Name.ToString
        b = a.Substring(a.Length - 3, 3)
        i = Convert.ToDecimal(b) - 192
        button(i * 6).PerformClick()
        button(i * 6 - 1).PerformClick()
        button(i * 6 - 2).PerformClick()
        button(i * 6 - 3).PerformClick()
        button(i * 6 - 4).PerformClick()
        button(i * 6 - 5).PerformClick()
        Dim y As Integer

        y = 1
        Do While y < 25
            If x(y * 6) = True And x(y * 6 - 1) = True And x(y * 6 - 2) = True And x(y * 6 - 3) = True And x(y * 6 - 4) = True And x(y * 6 - 5) = True Then
                button(y + 192).BackColor = Color.LimeGreen
            ElseIf x(y * 6) = False And x(y * 6 - 1) = False And x(y * 6 - 2) = False And x(y * 6 - 3) = False And x(y * 6 - 4) = False And x(y * 6 - 5) = False Then
                button(y + 192).BackColor = Color.LightSeaGreen
            Else
                button(y + 192).BackColor = Color.DarkSalmon
            End If
            y += 1
        Loop
    End Sub
    Public Sub buton_atama()
        button(1) = Button01
        button(2) = Button02
        button(3) = Button03
        button(4) = Button04
        button(5) = Button05
        button(6) = Button06
        button(7) = Button07
        button(8) = Button08
        button(9) = Button09
        button(10) = Button10
        button(11) = Button11
        button(12) = Button12
        button(13) = Button13
        button(14) = Button14
        button(15) = Button15
        button(16) = Button16
        button(17) = Button17
        button(18) = Button18
        button(19) = Button19
        button(20) = Button20
        button(21) = Button21
        button(22) = Button22
        button(23) = Button23
        button(24) = Button24
        button(25) = Button25
        button(26) = Button26
        button(27) = Button27
        button(28) = Button28
        button(29) = Button29
        button(30) = Button30
        button(31) = Button31
        button(32) = Button32
        button(33) = Button33
        button(34) = Button34
        button(35) = Button35
        button(36) = Button36
        button(37) = Button37
        button(38) = Button38
        button(39) = Button39
        button(40) = Button40
        button(41) = Button41
        button(42) = Button42
        button(43) = Button43
        button(44) = Button44
        button(45) = Button45
        button(46) = Button46
        button(47) = Button47
        button(48) = Button48
        button(49) = Button49
        button(50) = Button50
        button(51) = Button51
        button(52) = Button52
        button(53) = Button53
        button(54) = Button54
        button(55) = Button55
        button(56) = Button56
        button(57) = Button57
        button(58) = Button58
        button(59) = Button59
        button(60) = Button60
        button(61) = Button61
        button(62) = Button62
        button(63) = Button63
        button(64) = Button64
        button(65) = Button65
        button(66) = Button66
        button(67) = Button67
        button(68) = Button68
        button(69) = Button69
        button(70) = Button70
        button(71) = Button71
        button(72) = Button72
        button(73) = Button73
        button(74) = Button74
        button(75) = Button75
        button(76) = Button76
        button(77) = Button77
        button(78) = Button78
        button(79) = Button79
        button(80) = Button80
        button(81) = Button81
        button(82) = Button82
        button(83) = Button83
        button(84) = Button84
        button(85) = Button85
        button(86) = Button86
        button(87) = Button87
        button(88) = Button88
        button(89) = Button89
        button(90) = Button90
        button(91) = Button91
        button(92) = Button92
        button(93) = Button93
        button(94) = Button94
        button(95) = Button95
        button(96) = Button96
        button(97) = Button97
        button(98) = Button98
        button(99) = Button99
        button(100) = Button100
        button(101) = Button101
        button(102) = Button102
        button(103) = Button103
        button(104) = Button104
        button(105) = Button105
        button(106) = Button106
        button(107) = Button107
        button(108) = Button108
        button(109) = Button109
        button(110) = Button110
        button(111) = Button111
        button(112) = Button112
        button(113) = Button113
        button(114) = Button114
        button(115) = Button115
        button(116) = Button116
        button(117) = Button117
        button(118) = Button118
        button(119) = Button119
        button(120) = Button120
        button(121) = Button121
        button(122) = Button122
        button(123) = Button123
        button(124) = Button124
        button(125) = Button125
        button(126) = Button126
        button(127) = Button127
        button(128) = Button128
        button(129) = Button129
        button(130) = Button130
        button(131) = Button131
        button(132) = Button132
        button(133) = Button133
        button(134) = Button134
        button(135) = Button135
        button(136) = Button136
        button(137) = Button137
        button(138) = Button138
        button(139) = Button139
        button(140) = Button140
        button(141) = Button141
        button(142) = Button142
        button(143) = Button143
        button(144) = Button144
        button(145) = Button145
        button(146) = Button146
        button(147) = Button147
        button(148) = Button148
        button(149) = Button149
        button(150) = Button150
        button(151) = Button151
        button(152) = Button152
        button(153) = Button153
        button(154) = Button154
        button(155) = Button155
        button(156) = Button156
        button(157) = Button157
        button(158) = Button158
        button(159) = Button159
        button(160) = Button160
        button(161) = Button161
        button(162) = Button162
        button(163) = Button163
        button(164) = Button164
        button(165) = Button165
        button(166) = Button166
        button(167) = Button167
        button(168) = Button168
        button(169) = Button169
        button(170) = Button170
        button(171) = Button171
        button(172) = Button172
        button(173) = Button173
        button(174) = Button174
        button(175) = Button175
        button(176) = Button176
        button(177) = Button177
        button(178) = Button178
        button(179) = Button179
        button(180) = Button180
        button(181) = Button181
        button(182) = Button182
        button(183) = Button183
        button(184) = Button184
        button(185) = Button185
        button(186) = Button186
        button(187) = Button187
        button(188) = Button188
        button(189) = Button189
        button(190) = Button190
        button(191) = Button191
        button(192) = Button192
        button(193) = Button193
        button(194) = Button194
        button(195) = Button195
        button(196) = Button196
        button(197) = Button197
        button(198) = Button198
        button(199) = Button199
        button(200) = Button200
        button(201) = Button201
        button(202) = Button202
        button(203) = Button203
        button(204) = Button204
        button(205) = Button205
        button(206) = Button206
        button(207) = Button207
        button(208) = Button208
        button(209) = Button209
        button(210) = Button210
        button(211) = Button211
        button(212) = Button212
        button(213) = Button213
        button(214) = Button214
        button(215) = Button215
        button(216) = Button216



    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        FlowLayoutPanel1.Enabled = True
        FlowLayoutPanel2.Enabled = True
        FlowLayoutPanel3.Enabled = True
        Dim yer1 As New Point
        Dim yer2 As New Point
        yer1.X = 446
        yer1.Y = 182
        yer2.X = 4460
        yer2.Y = 1820

        If ComboBox2.Text = "10 DK" Then
            FlowLayoutPanel1.Location = yer1
            FlowLayoutPanel2.Location = yer2
            FlowLayoutPanel3.Location = yer2
        ElseIf ComboBox2.Text = "30 DK" Then
            FlowLayoutPanel1.Location = yer2
            FlowLayoutPanel2.Location = yer1
            FlowLayoutPanel3.Location = yer2
        Else
            FlowLayoutPanel1.Location = yer2
            FlowLayoutPanel2.Location = yer2
            FlowLayoutPanel3.Location = yer1
        End If
        Dim i As Integer
        i = 1


        Do While i < 49
            If x(i * 3) = True And x(i * 3 - 1) = True And x(i * 3 - 2) = True Then
                button(i + 144).BackColor = Color.LimeGreen
            ElseIf x(i * 3) = False And x(i * 3 - 1) = False And x(i * 3 - 2) = False Then
                button(i + 144).BackColor = Color.LightSeaGreen
            Else
                button(i + 144).BackColor = Color.DarkSalmon
            End If
            i += 1
        Loop
        i = 1
        Do While i < 25
            If x(i * 6) = True And x(i * 6 - 1) = True And x(i * 6 - 2) = True And x(i * 6 - 3) = True And x(i * 6 - 4) = True And x(i * 6 - 5) = True Then
                button(i + 192).BackColor = Color.LimeGreen
            ElseIf x(i * 6) = False And x(i * 6 - 1) = False And x(i * 6 - 2) = False And x(i * 6 - 3) = False And x(i * 6 - 4) = False And x(i * 6 - 5) = False Then
                button(i + 192).BackColor = Color.LightSeaGreen
            Else
                button(i + 192).BackColor = Color.DarkSalmon
            End If
            i += 1
        Loop
        ''Call buton_atama()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ComboBox1.Text <> "" Then
            Dim result As DialogResult = MessageBox.Show("Seçtiğiniz Motor ve Gün İçin Çalışma Planı Sıfırlanacak!! Emin misiniz", "caption", MessageBoxButtons.YesNoCancel)

            If result = DialogResult.Yes Then
                If CheckBox1.Checked = False Then
                    Dim cb As String

                    cb = ComboBox1.Text.Substring(0, 1) & ComboBox1.Text.Substring(ComboBox1.Text.Length - 1, 1)
                    Try

                        accessbaglanti.Open()
                        Dim i As Integer
                        i = 1

                        Do While i < 145
                            komut.Connection = accessbaglanti
                            komut.CommandText = "UPDATE " & cb & MonthCalendar1.SelectionStart.DayOfWeek.ToString & " SET Deger='False' WHERE    Numara=" & i
                            komut.ExecuteNonQuery()
                            x(i) = False
                            r(i) = Color.LightSeaGreen
                            i += 1
                        Loop


                        MsgBox("Günlük Plan Değiştirildi.")
                        ComboBox2.Text = "10 DK"
                        accessbaglanti.Close()
                        Call goster()
                    Catch
                        MsgBox("Veriler Database'e Yazılamadı. Lütfen Planı Tekrar Gözden Geçiriniz")

                    End Try
                Else
                    Dim cb As String

                    cb = ComboBox1.Text.Substring(0, 1) & ComboBox1.Text.Substring(ComboBox1.Text.Length - 1, 1)
                    Try

                        accessbaglanti.Open()
                        Dim i As Integer
                        i = 1

                        Do While i < 145
                            komut.Connection = accessbaglanti
                            komut.CommandText = "UPDATE " & cb & "Monday SET Deger='False' WHERE    Numara=" & i
                            komut.ExecuteNonQuery()
                            komut.CommandText = "UPDATE " & cb & "Tuesday SET Deger='False' WHERE    Numara=" & i
                            komut.ExecuteNonQuery()
                            komut.CommandText = "UPDATE " & cb & "Wednesday SET Deger='False' WHERE    Numara=" & i
                            komut.ExecuteNonQuery()
                            komut.CommandText = "UPDATE " & cb & "Thursday SET Deger='False' WHERE    Numara=" & i
                            komut.ExecuteNonQuery()
                            komut.CommandText = "UPDATE " & cb & "Friday SET Deger='False' WHERE    Numara=" & i
                            komut.ExecuteNonQuery()
                            komut.CommandText = "UPDATE " & cb & "Saturday SET Deger='False' WHERE    Numara=" & i
                            komut.ExecuteNonQuery()
                            komut.CommandText = "UPDATE " & cb & "Sunday SET Deger='False' WHERE    Numara=" & i
                            komut.ExecuteNonQuery()
                            i += 1
                        Loop
                        MsgBox("Haftalık Plan Değiştirildi.")
                        ComboBox2.Text = "10 DK"
                        accessbaglanti.Close()
                        Call goster()
                    Catch
                        MsgBox("Veriler Database'e Yazılamadı. Lütfen Planı Tekrar Gözden Geçiriniz")

                    End Try
                End If
            Else
                    Exit Sub
            End If
        Else
            MsgBox("lütfen Öncelikle Bir Motor Tipi Seçiniz")
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        saat.Text = TimeString
        If saat.Text.Substring(4, 4) = "0:00" Then
            MsgBox("saat başı")

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form1.Close()
        k_girisi.Close()
    End Sub
End Class