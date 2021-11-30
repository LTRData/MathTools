Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.Windows.Forms
Imports LTRLib.Forms.MathGraph
Imports LTRLib.MathExpression

#Disable Warning IDE1006 ' Naming Styles

Public Class GraphView

    Public Shared ReadOnly fntTimes As New Font("Times", 12)

    Public Shared ReadOnly sftRightAligned As New StringFormat With {
      .LineAlignment = StringAlignment.Center,
      .Alignment = StringAlignment.Far}

    Public Shared ReadOnly sftLeftAligned As New StringFormat With {
      .LineAlignment = StringAlignment.Center,
      .Alignment = StringAlignment.Near}

    Public Shared ReadOnly sftTopAligned As New StringFormat With {
      .LineAlignment = StringAlignment.Near,
      .Alignment = StringAlignment.Center}

    Public Shared ReadOnly sftBottomAligned As New StringFormat With {
      .LineAlignment = StringAlignment.Far,
      .Alignment = StringAlignment.Center}

    ' This is the object that provides formula evaluation functions
    Private ReadOnly ScriptControl As New ScriptControl(New MathExpressionParser(CultureInfo.InvariantCulture))

    ' This is the drawing surface instance for the form
    Private ReadOnly ScreenSurface As New Surface

    Private Property Ymax As Double
        Get
            Return Double.Parse(tbYmax.Text)
        End Get
        Set(value As Double)
            tbYmax.Text = value.ToString()
        End Set
    End Property

    Private Property Ymin As Double
        Get
            Return Double.Parse(tbYmin.Text)
        End Get
        Set(value As Double)
            tbYmin.Text = value.ToString()
        End Set
    End Property

    Private Property Xmax As Double
        Get
            Return Double.Parse(tbXmax.Text)
        End Get
        Set(value As Double)
            tbXmax.Text = value.ToString()
        End Set
    End Property

    Private Property Xmin As Double
        Get
            Return Double.Parse(tbXmin.Text)
        End Get
        Set(value As Double)
            tbXmin.Text = value.ToString()
        End Set
    End Property

    Private Sub NumericTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbXmin.KeyPress, tbXmax.KeyPress, tbYmin.KeyPress, tbYmax.KeyPress
        If _
          (Not Char.IsDigit(e.KeyChar)) AndAlso
          e.KeyChar <> Microsoft.VisualBasic.ControlChars.Back AndAlso
          e.KeyChar <> "." AndAlso
          Not (e.KeyChar = "-" AndAlso
               DirectCast(sender, TextBox).SelectionStart = 0 AndAlso
               Not DirectCast(sender, TextBox).Text.StartsWith("-")) Then

            e.Handled = True

        End If
    End Sub

    Private Sub cmbExpression_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbExpression.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ControlChars.Cr Then
            e.Handled = True

            cmbExpression.DroppedDown = False

            If cmbExpression.Text <> "" AndAlso Not cmbExpression.Items.Contains(cmbExpression.Text) Then
                cmbExpression.Items.Insert(0, cmbExpression.Text)
            End If

            RedrawGraphs()
        End If
    End Sub

    Public Sub RedrawGraphs()
        If Not Visible Then
            Exit Sub
        End If

        If ClearSurfaceBeforeDrawingToolStripMenuItem.Checked Then
            ScreenSurface.Clear()
        End If

        Try
            ScriptControl.Expression = cmbExpression.Text
            ScreenSurface.Refresh(ScriptControl)
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        pbSurface.Refresh()
    End Sub

    Private Sub TextBox_Leave(sender As Object, e As EventArgs) Handles tbXmin.Leave, tbXmax.Leave, tbYmin.Leave, tbYmax.Leave
        With CType(sender, TextBox)
            .SelectionStart = 0
            .SelectionLength = .Text.Length
        End With
    End Sub

    Private Sub ComboBox_Leave(sender As Object, e As EventArgs) Handles cmbExpression.Leave
        With CType(sender, ComboBox)
            .SelectionStart = 0
            .SelectionLength = .Text.Length
        End With
    End Sub

    Private Sub pbSurface_Layout(sender As Object, e As LayoutEventArgs) Handles pbSurface.Layout
        With ScreenSurface
            .Area.Size = CType(sender, PictureBox).ClientRectangle.Size

            .Clear()
        End With

        RedrawGraphs()
    End Sub

    Private Sub tbXmin_TextChanged(sender As Object, e As EventArgs) Handles tbXmin.TextChanged
        Try
            ScreenSurface.Xmin = Xmin
        Catch
            ScreenSurface.Xmin = 0
        End Try
    End Sub

    Private Sub tbXmax_TextChanged(sender As Object, e As EventArgs) Handles tbXmax.TextChanged
        Try
            ScreenSurface.Xmax = Xmax
        Catch
            ScreenSurface.Xmax = 0
        End Try
    End Sub

    Private Sub tbYmin_TextChanged(sender As Object, e As EventArgs) Handles tbYmin.TextChanged
        Try
            ScreenSurface.Ymin = Ymin
        Catch
            ScreenSurface.Ymin = 0
        End Try
    End Sub

    Private Sub tbYmax_TextChanged(sender As Object, e As EventArgs) Handles tbYmax.TextChanged
        Try
            ScreenSurface.Ymax = Ymax
        Catch
            ScreenSurface.Ymax = 0
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        My.Settings.DrawDerivative = DrawCalculatedderivativeGraphToolStripMenuItem.Checked
        My.Settings.DrawAntiderivative = DrawCalculatedantiderivativeGraphToolStripMenuItem.Checked
        My.Settings.ClearBeforeRedraw = ClearSurfaceBeforeDrawingToolStripMenuItem.Checked
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        PrintDocument.DefaultPageSettings.Landscape = True

        DrawCalculatedderivativeGraphToolStripMenuItem.Checked = My.Settings.DrawDerivative
        DrawCalculatedantiderivativeGraphToolStripMenuItem.Checked = My.Settings.DrawAntiderivative
        ClearSurfaceBeforeDrawingToolStripMenuItem.Checked = My.Settings.ClearBeforeRedraw
    End Sub

    Protected Overrides Sub OnShown(e As EventArgs)
        If cmbExpression.Text <> "" Then
            cmbExpression.Items.Add(cmbExpression.Text)
        End If

        RedrawGraphs()
    End Sub

    Private Sub ClearDrawingSurfaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearDrawingSurfaceToolStripMenuItem.Click
        ScreenSurface.Clear()
        RedrawGraphs()
    End Sub

    Private Sub RedrawGraphToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedrawGraphToolStripMenuItem.Click, DrawCalculatedderivativeGraphToolStripMenuItem.CheckedChanged, DrawCalculatedantiderivativeGraphToolStripMenuItem.CheckedChanged
        RedrawGraphs()
    End Sub

    Private Sub SaveAsPictureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsPictureToolStripMenuItem.Click
        Dim SelectedImageFormat As ImageFormat

        Try
            With SaveFileDialog
                If .ShowDialog(Me) = DialogResult.Cancel Then
                    Exit Sub
                End If

                Select Case SaveFileDialog.FilterIndex
                    Case 2
                        SelectedImageFormat = ImageFormat.Gif
                    Case 3
                        SelectedImageFormat = ImageFormat.Jpeg
                    Case 4
                        SelectedImageFormat = ImageFormat.Png
                    Case 5
                        SelectedImageFormat = ImageFormat.Tiff
                    Case Else
                        SelectedImageFormat = ImageFormat.Bmp
                End Select
            End With

            Dim Bitmap As New Bitmap(pbSurface.Width, pbSurface.Height)
            pbSurface.DrawToBitmap(Bitmap, pbSurface.ClientRectangle)
            Bitmap.Save(SaveFileDialog.FileName, SelectedImageFormat)
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub pbSurface_Paint(sender As Object, e As PaintEventArgs) Handles pbSurface.Paint
        Try
            e.Graphics.Clear(Color.DarkBlue)

            With ScreenSurface
                .DrawAxis(e.Graphics, Pens.DarkRed)

                If DrawCalculatedderivativeGraphToolStripMenuItem.Checked Then
                    .DrawDerivative(e.Graphics, Pens.DarkGreen)
                End If
                If DrawCalculatedantiderivativeGraphToolStripMenuItem.Checked Then
                    .DrawIntegral(e.Graphics, Pens.Blue)
                End If
                .DrawGraph(e.Graphics, Pens.Yellow)
            End With
        Catch
        End Try
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As Drawing.Printing.PrintPageEventArgs) Handles PrintDocument.PrintPage
        With New Surface
            .Xmin = ScreenSurface.Xmin
            .Xmax = ScreenSurface.Xmax
            .Ymin = ScreenSurface.Ymin
            .Ymax = ScreenSurface.Ymax

            .Area = e.MarginBounds

            ScriptControl.Expression = cmbExpression.Text
            .Refresh(ScriptControl)

            .DrawAxis(e.Graphics, Pens.Orange)

            If DrawCalculatedderivativeGraphToolStripMenuItem.Checked Then
                .DrawDerivative(e.Graphics, Pens.LightGray)
            End If
            If DrawCalculatedantiderivativeGraphToolStripMenuItem.Checked Then
                .DrawIntegral(e.Graphics, Pens.DarkGray)
            End If
            .DrawGraph(e.Graphics, Pens.DarkRed)
        End With

        With e.Graphics
            .DrawString("y = " & cmbExpression.Text, fntTimes, Brushes.DarkRed, New Rectangle(e.MarginBounds.Left, e.PageBounds.Top, e.MarginBounds.Width, e.MarginBounds.Top), sftLeftAligned)

            .DrawString(tbXmin.Text, fntTimes, Brushes.Black, New RectangleF(e.PageBounds.Left, e.MarginBounds.Top, e.MarginBounds.Left, CSng(Ymax * 2 * e.MarginBounds.Height / (Ymax - Ymin))), sftRightAligned)
            .DrawString(tbXmax.Text, fntTimes, Brushes.Black, New RectangleF(e.MarginBounds.Right, e.MarginBounds.Top, e.PageBounds.Right - e.MarginBounds.Right, CSng(Ymax * 2 * e.MarginBounds.Height / (Ymax - Ymin))), sftLeftAligned)

            .DrawString(tbYmin.Text, fntTimes, Brushes.Black, New RectangleF(e.MarginBounds.Left, e.MarginBounds.Bottom, CSng(Xmin * -2 * e.MarginBounds.Width / (Xmax - Xmin)), e.PageBounds.Bottom - e.MarginBounds.Bottom), sftTopAligned)
            .DrawString(tbYmax.Text, fntTimes, Brushes.Black, New RectangleF(e.MarginBounds.Left, e.PageBounds.Top, CSng(Xmin * -2 * e.MarginBounds.Width / (Xmax - Xmin)), e.MarginBounds.Top), sftBottomAligned)
        End With
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        If PrintDialog.ShowDialog() = DialogResult.OK Then
            PrintDocument.Print()
        End If
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        PrintPreviewDialog.ShowDialog(Me)
    End Sub

    Private Sub PrintPreviewDialog_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog.Load
        With PrintPreviewDialog
            .Left = Left + 10
            .Top = Top + 40
            .Width = ScreenSurface.Area.Width - 20
            .Height = ScreenSurface.Area.Height
        End With
    End Sub

    Private Sub PrintSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintSetupToolStripMenuItem.Click
        PageSetupDialog.ShowDialog(Me)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Using AboutBox As New AboutBox
            AboutBox.ShowDialog(Me)
        End Using
    End Sub
End Class