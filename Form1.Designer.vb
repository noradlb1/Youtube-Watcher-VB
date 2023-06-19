
Imports System

Namespace Watcherr
    Partial Class Form1
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
            components = New ComponentModel.Container()
            webBrowser1 = New Windows.Forms.WebBrowser()
            openFileDialog1 = New Windows.Forms.OpenFileDialog()
            button1 = New Windows.Forms.Button()
            statusStrip1 = New Windows.Forms.StatusStrip()
            toolStripStatusLabel1 = New Windows.Forms.ToolStripStatusLabel()
            toolStripStatusLabel2 = New Windows.Forms.ToolStripStatusLabel()
            toolStripStatusLabel4 = New Windows.Forms.ToolStripStatusLabel()
            toolStripStatusLabel5 = New Windows.Forms.ToolStripStatusLabel()
            toolStripStatusLabel3 = New Windows.Forms.ToolStripStatusLabel()
            timerzone = New Windows.Forms.ToolStripStatusLabel()
            toolStripStatusLabel6 = New Windows.Forms.ToolStripStatusLabel()
            label2 = New Windows.Forms.ToolStripStatusLabel()
            timer1 = New Windows.Forms.Timer(components)
            button2 = New Windows.Forms.Button()
            webBrowser2 = New Windows.Forms.WebBrowser()
            VideoTag = New Windows.Forms.TextBox()
            label1 = New Windows.Forms.Label()
            label3 = New Windows.Forms.Label()
            VideoLengths = New Windows.Forms.TextBox()
            button3 = New Windows.Forms.Button()
            richTextBox1 = New Windows.Forms.RichTextBox()
            statusStrip1.SuspendLayout()
            SuspendLayout()
            ' 
            ' webBrowser1
            ' 
            webBrowser1.Location = New Drawing.Point(4, 0)
            webBrowser1.MinimumSize = New Drawing.Size(20, 20)
            webBrowser1.Name = "webBrowser1"
            webBrowser1.Size = New Drawing.Size(796, 427)
            webBrowser1.TabIndex = 0
            AddHandler webBrowser1.DocumentCompleted, New Windows.Forms.WebBrowserDocumentCompletedEventHandler(AddressOf webBrowser1_DocumentCompleted)
            AddHandler webBrowser1.ProgressChanged, New Windows.Forms.WebBrowserProgressChangedEventHandler(AddressOf webBrowser1_ProgressChanged)
            ' 
            ' openFileDialog1
            ' 
            openFileDialog1.FileName = "openFileDialog1"
            ' 
            ' button1
            ' 
            button1.Location = New Drawing.Point(12, 521)
            button1.Name = "button1"
            button1.Size = New Drawing.Size(788, 70)
            button1.TabIndex = 1
            button1.Text = "Start"
            button1.UseVisualStyleBackColor = True
            AddHandler button1.Click, New EventHandler(AddressOf button1_Click)
            ' 
            ' statusStrip1
            ' 
            statusStrip1.ImageScalingSize = New Drawing.Size(20, 20)
            statusStrip1.Items.AddRange(New Windows.Forms.ToolStripItem() {toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel4, toolStripStatusLabel5, toolStripStatusLabel3, timerzone, toolStripStatusLabel6, label2})
            statusStrip1.Location = New Drawing.Point(0, 607)
            statusStrip1.Name = "statusStrip1"
            statusStrip1.Size = New Drawing.Size(808, 26)
            statusStrip1.TabIndex = 2
            statusStrip1.Text = "statusStrip1"
            ' 
            ' toolStripStatusLabel1
            ' 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1"
            toolStripStatusLabel1.Size = New Drawing.Size(58, 20)
            toolStripStatusLabel1.Text = "Views : "
            AddHandler toolStripStatusLabel1.Click, New EventHandler(AddressOf toolStripStatusLabel1_Click)
            ' 
            ' toolStripStatusLabel2
            ' 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2"
            toolStripStatusLabel2.Size = New Drawing.Size(17, 20)
            toolStripStatusLabel2.Text = "0"
            ' 
            ' toolStripStatusLabel4
            ' 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4"
            toolStripStatusLabel4.Size = New Drawing.Size(19, 20)
            toolStripStatusLabel4.Text = "/ "
            ' 
            ' toolStripStatusLabel5
            ' 
            toolStripStatusLabel5.Name = "toolStripStatusLabel5"
            toolStripStatusLabel5.Size = New Drawing.Size(17, 20)
            toolStripStatusLabel5.Text = "0"
            ' 
            ' toolStripStatusLabel3
            ' 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3"
            toolStripStatusLabel3.Size = New Drawing.Size(70, 20)
            toolStripStatusLabel3.Text = "| TicToc : "
            ' 
            ' timerzone
            ' 
            timerzone.Name = "timerzone"
            timerzone.Size = New Drawing.Size(17, 20)
            timerzone.Text = "0"
            ' 
            ' toolStripStatusLabel6
            ' 
            toolStripStatusLabel6.Name = "toolStripStatusLabel6"
            toolStripStatusLabel6.Size = New Drawing.Size(64, 20)
            toolStripStatusLabel6.Text = "| Proxy : "
            ' 
            ' label2
            ' 
            label2.Name = "label2"
            label2.Size = New Drawing.Size(0, 20)
            ' 
            ' timer1
            ' 
            timer1.Interval = 1000
            AddHandler timer1.Tick, New EventHandler(AddressOf timer1_Tick)
            ' 
            ' button2
            ' 
            button2.Location = New Drawing.Point(616, 458)
            button2.Name = "button2"
            button2.Size = New Drawing.Size(140, 51)
            button2.TabIndex = 4
            button2.Text = "Proxy Filter"
            button2.UseVisualStyleBackColor = True
            AddHandler button2.Click, New EventHandler(AddressOf button2_Click)
            ' 
            ' webBrowser2
            ' 
            webBrowser2.Location = New Drawing.Point(819, 446)
            webBrowser2.MinimumSize = New Drawing.Size(20, 20)
            webBrowser2.Name = "webBrowser2"
            webBrowser2.Size = New Drawing.Size(338, 158)
            webBrowser2.TabIndex = 3
            AddHandler webBrowser2.DocumentCompleted, New Windows.Forms.WebBrowserDocumentCompletedEventHandler(AddressOf webBrowser2_DocumentCompleted)
            ' 
            ' VideoTag
            ' 
            VideoTag.Location = New Drawing.Point(88, 446)
            VideoTag.Name = "VideoTag"
            VideoTag.Size = New Drawing.Size(235, 22)
            VideoTag.TabIndex = 5
            VideoTag.Text = "bnc51fSo8ng"
            ' 
            ' label1
            ' 
            label1.AutoSize = True
            label1.Location = New Drawing.Point(1, 447)
            label1.Name = "label1"
            label1.Size = New Drawing.Size(85, 17)
            label1.TabIndex = 6
            label1.Text = "Video Tag : "
            ' 
            ' label3
            ' 
            label3.AutoSize = True
            label3.Location = New Drawing.Point(1, 494)
            label3.Name = "label3"
            label3.Size = New Drawing.Size(163, 17)
            label3.TabIndex = 8
            label3.Text = "Video Lengh (seconds) :"
            ' 
            ' VideoLengths
            ' 
            VideoLengths.Location = New Drawing.Point(167, 492)
            VideoLengths.Name = "VideoLengths"
            VideoLengths.Size = New Drawing.Size(235, 22)
            VideoLengths.TabIndex = 7
            VideoLengths.Text = "seconds to watch (+lag time)"
            ' 
            ' button3
            ' 
            button3.Location = New Drawing.Point(426, 451)
            button3.Name = "button3"
            button3.Size = New Drawing.Size(177, 64)
            button3.TabIndex = 9
            button3.Text = "Load"
            button3.UseVisualStyleBackColor = True
            AddHandler button3.Click, New EventHandler(AddressOf button3_Click)
            ' 
            ' richTextBox1
            ' 
            richTextBox1.Location = New Drawing.Point(819, 12)
            richTextBox1.Name = "richTextBox1"
            richTextBox1.Size = New Drawing.Size(338, 415)
            richTextBox1.TabIndex = 10
            richTextBox1.Text = ""
            ' 
            ' Form1
            ' 
            AutoScaleDimensions = New Drawing.SizeF(8.0F, 16.0F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            ClientSize = New Drawing.Size(808, 633)
            Controls.Add(richTextBox1)
            Controls.Add(button3)
            Controls.Add(label3)
            Controls.Add(VideoLengths)
            Controls.Add(label1)
            Controls.Add(VideoTag)
            Controls.Add(button2)
            Controls.Add(webBrowser2)
            Controls.Add(statusStrip1)
            Controls.Add(button1)
            Controls.Add(webBrowser1)
            name = "Form1"
            Text = "Form1"
            AddHandler Load, New EventHandler(AddressOf Form1_Load)
            statusStrip1.ResumeLayout(False)
            statusStrip1.PerformLayout()
            ResumeLayout(False)
            PerformLayout()

        End Sub

#End Region

        Private webBrowser1 As Windows.Forms.WebBrowser
        Private openFileDialog1 As Windows.Forms.OpenFileDialog
        Private button1 As Windows.Forms.Button
        Private statusStrip1 As Windows.Forms.StatusStrip
        Private toolStripStatusLabel1 As Windows.Forms.ToolStripStatusLabel
        Private toolStripStatusLabel2 As Windows.Forms.ToolStripStatusLabel
        Private timer1 As Windows.Forms.Timer
        Private toolStripStatusLabel3 As Windows.Forms.ToolStripStatusLabel
        Private timerzone As Windows.Forms.ToolStripStatusLabel
        Private toolStripStatusLabel4 As Windows.Forms.ToolStripStatusLabel
        Private toolStripStatusLabel5 As Windows.Forms.ToolStripStatusLabel
        Private toolStripStatusLabel6 As Windows.Forms.ToolStripStatusLabel
        Private label2 As Windows.Forms.ToolStripStatusLabel
        Private button2 As Windows.Forms.Button
        Private webBrowser2 As Windows.Forms.WebBrowser
        Private VideoTag As Windows.Forms.TextBox
        Private label1 As Windows.Forms.Label
        Private label3 As Windows.Forms.Label
        Private VideoLengths As Windows.Forms.TextBox
        Private button3 As Windows.Forms.Button
        Private richTextBox1 As Windows.Forms.RichTextBox
    End Class
End Namespace
