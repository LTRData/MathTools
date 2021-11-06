<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompilerOutput
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    Me.TextBox = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'TextBox
    '
    Me.TextBox.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TextBox.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox.Location = New System.Drawing.Point(0, 0)
    Me.TextBox.Multiline = True
    Me.TextBox.Name = "TextBox"
    Me.TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.TextBox.Size = New System.Drawing.Size(772, 502)
    Me.TextBox.TabIndex = 0
    '
    'FormCompilerOutput
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(772, 502)
    Me.Controls.Add(Me.TextBox)
    Me.Name = "FormCompilerOutput"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "CompilerOutput"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TextBox As System.Windows.Forms.TextBox
End Class
