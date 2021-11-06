Imports System.IO
Imports System.Reflection

Public NotInheritable Class AboutBox

    Private Sub AboutBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim asm = Process.GetCurrentProcess().MainModule

        ' Set the title of the form.
        Dim ApplicationTitle As String
        If asm.FileVersionInfo.ProductName <> "" Then
            ApplicationTitle = asm.FileVersionInfo.ProductName
        Else
            ApplicationTitle = Path.GetFileNameWithoutExtension(asm.FileName)
        End If
        Text = $"About {ApplicationTitle }"
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        LabelProductName.Text = asm.FileVersionInfo.ProductName
        LabelVersion.Text = $"Version {asm.FileVersionInfo.FileVersion}"
        LabelCopyright.Text = asm.FileVersionInfo.LegalCopyright
        LabelCompanyName.Text = asm.FileVersionInfo.CompanyName
        TextBoxDescription.Text = asm.FileVersionInfo.FileDescription
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel.LinkClicked
        System.Diagnostics.Process.Start("http://www.ltr-data.se")
    End Sub
End Class
