<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GraphView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GraphView))
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbExpression = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbXmin = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbYmin = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbXmax = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbYmax = New System.Windows.Forms.TextBox
        Me.pbSurface = New System.Windows.Forms.PictureBox
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RedrawGraphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearDrawingSurfaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveAsPictureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearSurfaceBeforeDrawingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DrawCalculatedderivativeGraphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DrawCalculatedantiderivativeGraphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.PrintDocument = New System.Drawing.Printing.PrintDocument
        Me.PrintPreviewDialog = New System.Windows.Forms.PrintPreviewDialog
        Me.PrintDialog = New System.Windows.Forms.PrintDialog
        Me.PageSetupDialog = New System.Windows.Forms.PageSetupDialog
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.pbSurface, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmbExpression, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 24)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(625, 24)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "y ="
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbExpression
        '
        Me.cmbExpression.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbExpression.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.GraphViewer.My.MySettings.Default, "Formula", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cmbExpression.FormattingEnabled = True
        Me.cmbExpression.Location = New System.Drawing.Point(30, 3)
        Me.cmbExpression.Name = "cmbExpression"
        Me.cmbExpression.Size = New System.Drawing.Size(592, 21)
        Me.cmbExpression.TabIndex = 0
        Me.cmbExpression.Text = Global.GraphViewer.My.MySettings.Default.Formula
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbXmin, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbYmin, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbXmax, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbYmax, 7, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 48)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(625, 30)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "x min:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbXmin
        '
        Me.tbXmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbXmin.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.GraphViewer.My.MySettings.Default, "Xmin", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tbXmin.Location = New System.Drawing.Point(48, 5)
        Me.tbXmin.Name = "tbXmin"
        Me.tbXmin.Size = New System.Drawing.Size(105, 20)
        Me.tbXmin.TabIndex = 1
        Me.tbXmin.Text = Global.GraphViewer.My.MySettings.Default.Xmin
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(320, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "y min:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbYmin
        '
        Me.tbYmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbYmin.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.GraphViewer.My.MySettings.Default, "Ymin", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tbYmin.Location = New System.Drawing.Point(360, 5)
        Me.tbYmin.Name = "tbYmin"
        Me.tbYmin.Size = New System.Drawing.Size(105, 20)
        Me.tbYmin.TabIndex = 3
        Me.tbYmin.Text = Global.GraphViewer.My.MySettings.Default.Ymin
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(161, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "x max:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbXmax
        '
        Me.tbXmax.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbXmax.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.GraphViewer.My.MySettings.Default, "Xmax", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tbXmax.Location = New System.Drawing.Point(204, 5)
        Me.tbXmax.Name = "tbXmax"
        Me.tbXmax.Size = New System.Drawing.Size(105, 20)
        Me.tbXmax.TabIndex = 2
        Me.tbXmax.Text = Global.GraphViewer.My.MySettings.Default.Xmax
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(473, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "y max:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbYmax
        '
        Me.tbYmax.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbYmax.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.GraphViewer.My.MySettings.Default, "Ymax", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tbYmax.Location = New System.Drawing.Point(516, 5)
        Me.tbYmax.Name = "tbYmax"
        Me.tbYmax.Size = New System.Drawing.Size(106, 20)
        Me.tbYmax.TabIndex = 4
        Me.tbYmax.Text = Global.GraphViewer.My.MySettings.Default.Ymax
        '
        'pbSurface
        '
        Me.pbSurface.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbSurface.Location = New System.Drawing.Point(0, 78)
        Me.pbSurface.Name = "pbSurface"
        Me.pbSurface.Size = New System.Drawing.Size(625, 403)
        Me.pbSurface.TabIndex = 4
        Me.pbSurface.TabStop = False
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(625, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RedrawGraphToolStripMenuItem, Me.ClearDrawingSurfaceToolStripMenuItem, Me.ToolStripMenuItem1, Me.SaveAsPictureToolStripMenuItem, Me.ToolStripMenuItem3, Me.PrintSetupToolStripMenuItem, Me.PrintToolStripMenuItem, Me.PrintPreviewToolStripMenuItem, Me.ToolStripMenuItem2, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'RedrawGraphToolStripMenuItem
        '
        Me.RedrawGraphToolStripMenuItem.Name = "RedrawGraphToolStripMenuItem"
        Me.RedrawGraphToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.RedrawGraphToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.RedrawGraphToolStripMenuItem.Text = "&Redraw"
        '
        'ClearDrawingSurfaceToolStripMenuItem
        '
        Me.ClearDrawingSurfaceToolStripMenuItem.Name = "ClearDrawingSurfaceToolStripMenuItem"
        Me.ClearDrawingSurfaceToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.ClearDrawingSurfaceToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.ClearDrawingSurfaceToolStripMenuItem.Text = "&Clear old graphs"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(207, 6)
        '
        'SaveAsPictureToolStripMenuItem
        '
        Me.SaveAsPictureToolStripMenuItem.Name = "SaveAsPictureToolStripMenuItem"
        Me.SaveAsPictureToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAsPictureToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.SaveAsPictureToolStripMenuItem.Text = "&Save as file..."
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(207, 6)
        '
        'PrintSetupToolStripMenuItem
        '
        Me.PrintSetupToolStripMenuItem.Name = "PrintSetupToolStripMenuItem"
        Me.PrintSetupToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.PrintSetupToolStripMenuItem.Text = "Printer page setup..."
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.PrintToolStripMenuItem.Text = "&Print..."
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.PrintPreviewToolStripMenuItem.Text = "Print previe&w..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(207, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearSurfaceBeforeDrawingToolStripMenuItem, Me.DrawCalculatedderivativeGraphToolStripMenuItem, Me.DrawCalculatedantiderivativeGraphToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'ClearSurfaceBeforeDrawingToolStripMenuItem
        '
        Me.ClearSurfaceBeforeDrawingToolStripMenuItem.Checked = True
        Me.ClearSurfaceBeforeDrawingToolStripMenuItem.CheckOnClick = True
        Me.ClearSurfaceBeforeDrawingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ClearSurfaceBeforeDrawingToolStripMenuItem.Name = "ClearSurfaceBeforeDrawingToolStripMenuItem"
        Me.ClearSurfaceBeforeDrawingToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.ClearSurfaceBeforeDrawingToolStripMenuItem.Text = "&Clear surface before drawing new graph"
        '
        'DrawCalculatedderivativeGraphToolStripMenuItem
        '
        Me.DrawCalculatedderivativeGraphToolStripMenuItem.Checked = True
        Me.DrawCalculatedderivativeGraphToolStripMenuItem.CheckOnClick = True
        Me.DrawCalculatedderivativeGraphToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DrawCalculatedderivativeGraphToolStripMenuItem.Name = "DrawCalculatedderivativeGraphToolStripMenuItem"
        Me.DrawCalculatedderivativeGraphToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.DrawCalculatedderivativeGraphToolStripMenuItem.Text = "Draw calculated &derivative graph"
        '
        'DrawCalculatedantiderivativeGraphToolStripMenuItem
        '
        Me.DrawCalculatedantiderivativeGraphToolStripMenuItem.CheckOnClick = True
        Me.DrawCalculatedantiderivativeGraphToolStripMenuItem.Name = "DrawCalculatedantiderivativeGraphToolStripMenuItem"
        Me.DrawCalculatedantiderivativeGraphToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.DrawCalculatedantiderivativeGraphToolStripMenuItem.Text = "Draw calculated &antiderivative graph"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.AboutToolStripMenuItem.Text = "&About..."
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.DefaultExt = "bmp"
        Me.SaveFileDialog.FileName = Global.GraphViewer.My.MySettings.Default.SaveFileName
        Me.SaveFileDialog.Filter = "Windows Bitmap (BMP)|*.bmp|GIF format|*.gif|JPEG format|*.jpg;*.jpeg|PNG format|*" & _
            ".png|Tagged Image File Format (TIFF)|*.tiff;*.tif"
        Me.SaveFileDialog.InitialDirectory = Global.GraphViewer.My.MySettings.Default.SaveFileDirectory
        Me.SaveFileDialog.Title = "Save as picture file"
        '
        'PrintDocument
        '
        Me.PrintDocument.DocumentName = "Graph"
        '
        'PrintPreviewDialog
        '
        Me.PrintPreviewDialog.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog.Document = Me.PrintDocument
        Me.PrintPreviewDialog.Enabled = True
        Me.PrintPreviewDialog.Icon = CType(resources.GetObject("PrintPreviewDialog.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog.Name = "PrintPreviewDialog"
        Me.PrintPreviewDialog.ShowIcon = False
        Me.PrintPreviewDialog.Visible = False
        '
        'PrintDialog
        '
        Me.PrintDialog.Document = Me.PrintDocument
        Me.PrintDialog.UseEXDialog = True
        '
        'PageSetupDialog
        '
        Me.PageSetupDialog.Document = Me.PrintDocument
        Me.PageSetupDialog.EnableMetric = True
        '
        'GraphView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = Global.GraphViewer.My.MySettings.Default.WindowSize
        Me.Controls.Add(Me.pbSurface)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.MenuStrip)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("ClientSize", Global.GraphViewer.My.MySettings.Default, "WindowSize", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.GraphViewer.My.MySettings.Default, "WindowPos", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = Global.GraphViewer.My.MySettings.Default.WindowPos
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "GraphView"
        Me.Text = "GraphViewer"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.pbSurface, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbYmax As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbXmax As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbYmin As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbXmin As System.Windows.Forms.TextBox
    Friend WithEvents cmbExpression As System.Windows.Forms.ComboBox
    Friend WithEvents pbSurface As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearDrawingSurfaceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveAsPictureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedrawGraphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearSurfaceBeforeDrawingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents DrawCalculatedderivativeGraphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DrawCalculatedantiderivativeGraphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDocument As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPreviewDialog As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents PageSetupDialog As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PrintSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
