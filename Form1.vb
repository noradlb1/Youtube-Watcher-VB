Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms
Imports SetProxy

Namespace Watcherr
    Public Partial Class Form1
        Inherits Form
        Private counterfix As Double = 35
        Private counter As Double = 0
        Private name As String = ""
        Private m As Integer = 0
        Public file_text As List(Of String) = New List(Of String)()
        Private html As String = ""
        Private green As Boolean = False
        Private timeout As Integer = 0
        Public Sub New()
            InitializeComponent()
        End Sub
        Public Sub proxyCheck()

        End Sub
        Public Sub nav()
            webBrowser2.DocumentText = ""
            webBrowser1.DocumentText = ""
            green = False
            Dim proxy As String = file_text.First()
            file_text.RemoveAt(0)
            SetConnectionProxy(proxy)
            webBrowser1.DocumentText = html

            'webBrowser1.Refresh();
            'webBrowser1.Navigate("https://www.youtube.com/watch?v="+VideoTag);
            '  webBrowser2.Navigate("https://you-itech.fr/spencer/ModMenu/green.html");
            webBrowser2.Navigate(" https://www.youtube.com/watch?v=" & VideoTag.ToString())
            m += 1
            toolStripStatusLabel2.Text = m.ToString()
            label2.Text = proxy
            counter = counterfix
            timerzone.Text = counter.ToString()
            timer1.Start()
            timeout = 0
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'webBrowser1.Navigate("https://youtu.be/" + VideoTag + "?autoplay=1");
            nav()
        End Sub
        Private Sub webBrowser1_DocumentCompleted(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
        End Sub
        Private Sub toolStripStatusLabel1_Click(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Private Sub webBrowser1_ProgressChanged(ByVal sender As Object, ByVal e As WebBrowserProgressChangedEventArgs)
        End Sub
        Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs)

            'MessageBox.Show(webBrowser2.DocumentText);
            If webBrowser2.DocumentText.Contains("unusual traffic") OrElse webBrowser2.DocumentText.Contains("Refresh the page") OrElse webBrowser2.DocumentText.Contains("checkTLSError") OrElse webBrowser2.DocumentText.Contains("Secure") Then
                nav()
            Else
                'if (webBrowser2.DocumentText.Contains("green")) green = true;
                timeout += 1
            End If
            If timeout > Integer.Parse(VideoLengths.Text) Then nav()
            If webBrowser1.Document IsNot Nothing AndAlso green Then
                counter -= 1
                timerzone.Text = counter.ToString()
            End If
            If counter = 0 Then
                If file_text.Count() > 0 Then
                    nav()
                Else
                    timerzone.Text = counter.ToString()
                    timer1.Stop()
                    MessageBox.Show("Job Done :) ! ")

                End If
            End If
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            webBrowser1.DocumentText = ""
            webBrowser2.DocumentText = ""
            openFileDialog1.Title = "Choose Proxy List (.txt) / ip:port"
            If openFileDialog1.ShowDialog() = DialogResult.OK Then
            End If
            If True Then
                name = openFileDialog1.FileName
                file_text = File.ReadAllLines(name).ToList()
            End If
            toolStripStatusLabel5.Text = Enumerable.Count(file_text).ToString()
        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            proxyCheck()
        End Sub

        Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs)
            html = "<html><head>" & "<meta content='IE=Edge,chrome=1' http-equiv='X-UA-Compatible'/>" & "<iframe id='video' src= 'https://www.youtube.com/embed/" & VideoTag.Text & "' width='600' height='300' frameborder='0' allowfullscreen></iframe>" & "</body></html>"
            webBrowser1.DocumentText = html
            html = "<html><head>" & "<meta content='IE=Edge,chrome=1' http-equiv='X-UA-Compatible'/>" & "<iframe id='video' src= 'https://www.youtube.com/embed/" & VideoTag.Text & "?autoplay=1' width='600' height='300' frameborder='0' allowfullscreen></iframe>" & "</body></html>"
            counterfix = Double.Parse(VideoLengths.Text)
        End Sub

        Private Sub webBrowser2_DocumentCompleted(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)

            If webBrowser2.DocumentText.Contains("unusual traffic") OrElse webBrowser2.DocumentText.Contains("Refresh the page") OrElse webBrowser2.DocumentText.Contains("checkTLSError") OrElse webBrowser2.DocumentText.Contains("Secure") Then

                nav()
            Else
                green = True
            End If
        End Sub
    End Class
End Namespace
