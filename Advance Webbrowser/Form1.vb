Imports System.Net
Public Class Form1

    Private Sub Loading(ByVal sender As Object, ByVal e As Windows.Forms.WebBrowserProgressChangedEventArgs)
        Try
            ProgressBar1.Maximum = e.MaximumProgress
            ProgressBar1.Value = e.CurrentProgress
            Label1.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).StatusText

        Catch ex As Exception

        End Try

    End Sub
    Private Sub Done(ByVal sender As Object, ByVal e As Windows.Forms.WebBrowserDocumentCompletedEventArgs)
        Try
            TextBox1.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Url.ToString
            TabControl1.SelectedTab.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentTitle
            Me.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentTitle & " PSN AppZ"
            If TextBox1.Text = "about:blank" Then
                Me.Text = "PSNAppZ"
            End If
            Label1.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).StatusText
            ProgressBar1.Value = 0
            If Label1.Text = "Done" Then

            End If


        Catch ex As Exception

        End Try

    End Sub


    Private Sub NewWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewWindowToolStripMenuItem.Click
        Dim newform As New Form1 ' remember that form1 not form
        newform.Show()

    End Sub

    Private Sub NewTabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewTabToolStripMenuItem.Click
        Try
            Dim tab As New TabPage
            Dim brws As New WebBrowser
            brws.Dock = DockStyle.Fill
            tab.Text = "tab"
            tab.Controls.Add(brws)
            Me.TabControl1.TabPages.Add(tab)
            Me.TabControl1.SelectedTab = tab
            brws.Navigate("www.google.com")
            AddHandler CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ProgressChanged, AddressOf Loading
            AddHandler CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentCompleted, AddressOf Done

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim tab As New TabPage
            Dim brws As New WebBrowser
            brws.Dock = DockStyle.Fill
            tab.Text = "tab"
            tab.Controls.Add(brws)
            Me.TabControl1.TabPages.Add(tab)
            Me.TabControl1.SelectedTab = tab
            brws.Navigate("www.google.com")
            AddHandler CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ProgressChanged, AddressOf Loading
            AddHandler CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentCompleted, AddressOf Done

        Catch ex As Exception

        End Try


    End Sub

    Private Sub DeleteTabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteTabToolStripMenuItem.Click
        TabControl1.Controls.Remove(TabControl1.SelectedTab)

    End Sub

    Private Sub OpenFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFileToolStripMenuItem.Click
        Try
            Dim open As New OpenFileDialog
            open.ShowDialog()
            open.Title = "Open Local Webpage"
            open.CheckFileExists = True
            open.Filter = "All Files(*.*)|*.*"
            Try
                CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(open.FileName)

            Catch ex As Exception
                'Do nothing on Exception
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveFileToolStripMenuItem.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ShowSaveAsDialog()

    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ShowPrintDialog()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ShowPrintPreviewDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End

    End Sub

    Private Sub SourceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SourceToolStripMenuItem.Click
        Dim client As New WebClient
        Dim url As String
        Dim newform2 As New System.Windows.Forms.Form
        Dim textboxx1 As New TextBox
        url = TextBox1.Text
        Dim source As String = client.DownloadString(New Uri(url))
        newform2.Controls.Add(textboxx1)
        textboxx1.Multiline = True
        textboxx1.Dock = DockStyle.Fill
        url = textboxx1.Text
        textboxx1.Text = source
        newform2.Width = "900"
        newform2.Height = "700"
        newform2.Show()
    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ShowPropertiesDialog()
    End Sub

    Private Sub HtmlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HtmlToolStripMenuItem.Click
        Dim htmform As New Form
        Dim textbxo As New TextBox

        htmform.Icon = Me.Icon
        htmform.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentTitle & " PSN AppZ"
        htmform.Controls.Add(textbxo)
        textbxo.Multiline = True
        textbxo.Dock = DockStyle.Fill
        htmform.StartPosition = FormStartPosition.CenterScreen
        htmform.Width = "900"
        htmform.Height = "700"
        textbxo.ScrollBars = ScrollBars.Both
        textbxo.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Document.Body.InnerHtml.ToString

        htmform.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoBack()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoForward()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoHome()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Refresh()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Stop()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(TextBox1.Text)
            My.Settings.History.Add(CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Url.ToString)
            My.Settings.Save()
            AddHandler CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).ProgressChanged, AddressOf Loading
            AddHandler CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentCompleted, AddressOf Done

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BookmarkThisPageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BookmarkThisPageToolStripMenuItem.Click
        Try
            My.Settings.Bookmarks.Add(CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Url.ToString)
            My.Settings.Save()
            MsgBox(CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Url.ToString & " Has Been Bookmarked!", MsgBoxStyle.OkOnly, "PSNAppZ")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ViewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewToolStripMenuItem1.Click
        Bookmarks.ShowDialog()

    End Sub

    Private Sub HistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoryToolStripMenuItem.Click
        History.ShowDialog()
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
