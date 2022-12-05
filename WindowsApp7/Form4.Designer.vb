<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.PdfDocumentViewer1 = New Spire.PdfViewer.Forms.PdfDocumentViewer()
        Me.SuspendLayout()
        '
        'PdfDocumentViewer1
        '
        Me.PdfDocumentViewer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.PdfDocumentViewer1.Location = New System.Drawing.Point(0, 0)
        Me.PdfDocumentViewer1.MultiPagesThreshold = 60
        Me.PdfDocumentViewer1.Name = "PdfDocumentViewer1"
        Me.PdfDocumentViewer1.Size = New System.Drawing.Size(1118, 710)
        Me.PdfDocumentViewer1.TabIndex = 0
        Me.PdfDocumentViewer1.Text = "PdfDocumentViewer1"
        Me.PdfDocumentViewer1.Threshold = 60
        Me.PdfDocumentViewer1.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.[Default]
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1119, 712)
        Me.Controls.Add(Me.PdfDocumentViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form4"
        Me.Text = "Visualisation De Facture"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PdfDocumentViewer1 As Spire.PdfViewer.Forms.PdfDocumentViewer
End Class
