
Imports System

Namespace Watcherr
    Partial Class Proxy
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <paramname="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            richTextBox1 = New Windows.Forms.RichTextBox()
            SuspendLayout()
            ' 
            ' richTextBox1
            ' 
            richTextBox1.Location = New Drawing.Point(0, 0)
            richTextBox1.Name = "richTextBox1"
            richTextBox1.Size = New Drawing.Size(433, 297)
            richTextBox1.TabIndex = 0
            richTextBox1.Text = ""
            ' 
            ' Proxy
            ' 
            AutoScaleDimensions = New Drawing.SizeF(8.0F, 16.0F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            ClientSize = New Drawing.Size(433, 345)
            Controls.Add(richTextBox1)
            Name = "Proxy"
            Text = "Proxy"
            AddHandler Load, New EventHandler(AddressOf Proxy_Load)
            ResumeLayout(False)

        End Sub

#End Region

        Private richTextBox1 As Windows.Forms.RichTextBox
    End Class
End Namespace
