<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class k_girisi
    Inherits System.Windows.Forms.Form

    'Form, bileşen listesini temizlemeyi bırakmayı geçersiz kılar.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form Tasarımcısı tarafından gerektirilir
    Private components As System.ComponentModel.IContainer

    'NOT: Aşağıdaki yordam Windows Form Tasarımcısı için gereklidir
    'Windows Form Tasarımcısı kullanılarak değiştirilebilir.  
    'Kod düzenleyicisini kullanarak değiştirmeyin.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.kapat = New System.Windows.Forms.Button()
        Me.ileri = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.kullanici = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(159, 160)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(222, 24)
        Me.ComboBox1.TabIndex = 15
        '
        'kapat
        '
        Me.kapat.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.kapat.Location = New System.Drawing.Point(173, 248)
        Me.kapat.Margin = New System.Windows.Forms.Padding(4)
        Me.kapat.Name = "kapat"
        Me.kapat.Size = New System.Drawing.Size(100, 28)
        Me.kapat.TabIndex = 19
        Me.kapat.Text = "Kapat"
        Me.kapat.UseVisualStyleBackColor = True
        '
        'ileri
        '
        Me.ileri.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ileri.Location = New System.Drawing.Point(281, 248)
        Me.ileri.Margin = New System.Windows.Forms.Padding(4)
        Me.ileri.Name = "ileri"
        Me.ileri.Size = New System.Drawing.Size(100, 28)
        Me.ileri.TabIndex = 17
        Me.ileri.Text = "İleri"
        Me.ileri.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 196)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 20)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Şifre"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'kullanici
        '
        Me.kullanici.AutoSize = True
        Me.kullanici.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.kullanici.Location = New System.Drawing.Point(28, 162)
        Me.kullanici.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.kullanici.Name = "kullanici"
        Me.kullanici.Size = New System.Drawing.Size(101, 20)
        Me.kullanici.TabIndex = 20
        Me.kullanici.Text = "Kullanıcı Adı"
        Me.kullanici.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(159, 196)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(222, 30)
        Me.TextBox2.TabIndex = 16
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.biyo.My.Resources.Resources.imgbin_data_warehouse_data_mining_big_data_online_analytical_processing_png
        Me.PictureBox2.Location = New System.Drawing.Point(-100, -106)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1113, 694)
        Me.PictureBox2.TabIndex = 23
        Me.PictureBox2.TabStop = False
        '
        'k_girisi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(897, 509)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.kapat)
        Me.Controls.Add(Me.ileri)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.kullanici)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Name = "k_girisi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kullanici_Girisi"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents kapat As Button
    Friend WithEvents ileri As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents kullanici As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents PictureBox2 As PictureBox
End Class
