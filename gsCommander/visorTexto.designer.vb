Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VisorTexto
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VisorTexto))
        Me.rtbTexto = New System.Windows.Forms.RichTextBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statusLabelInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnGuardarComo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lvTar = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbVerHtml = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsLabelDireccion = New System.Windows.Forms.ToolStripLabel()
        Me.tsDireccion = New System.Windows.Forms.ToolStripTextBox()
        Me.tsbIr = New System.Windows.Forms.ToolStripButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbTexto
        '
        Me.rtbTexto.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbTexto.HideSelection = False
        Me.rtbTexto.Location = New System.Drawing.Point(318, 325)
        Me.rtbTexto.Name = "rtbTexto"
        Me.rtbTexto.Size = New System.Drawing.Size(300, 111)
        Me.rtbTexto.TabIndex = 0
        Me.rtbTexto.Text = ""
        Me.rtbTexto.WordWrap = False
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(349, 196)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(250, 111)
        Me.WebBrowser1.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabelInfo, Me.btnGuardarComo})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 487)
        Me.StatusStrip1.Margin = New System.Windows.Forms.Padding(0, 4, 0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.ShowItemToolTips = True
        Me.StatusStrip1.Size = New System.Drawing.Size(640, 28)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusLabelInfo
        '
        Me.statusLabelInfo.Name = "statusLabelInfo"
        Me.statusLabelInfo.Size = New System.Drawing.Size(566, 23)
        Me.statusLabelInfo.Spring = True
        Me.statusLabelInfo.Text = "ToolStripStatusLabel1"
        Me.statusLabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGuardarComo
        '
        Me.btnGuardarComo.AutoToolTip = True
        Me.btnGuardarComo.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.btnGuardarComo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardarComo.Image = CType(resources.GetObject("btnGuardarComo.Image"), System.Drawing.Image)
        Me.btnGuardarComo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGuardarComo.Name = "btnGuardarComo"
        Me.btnGuardarComo.Padding = New System.Windows.Forms.Padding(2)
        Me.btnGuardarComo.Size = New System.Drawing.Size(20, 20)
        Me.btnGuardarComo.Text = "Guardar como..."
        '
        'lvTar
        '
        Me.lvTar.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader2, Me.ColumnHeader4})
        Me.lvTar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvTar.FullRowSelect = True
        Me.lvTar.GridLines = True
        Me.lvTar.HideSelection = False
        Me.lvTar.Location = New System.Drawing.Point(7, 196)
        Me.lvTar.MultiSelect = False
        Me.lvTar.Name = "lvTar"
        Me.lvTar.Size = New System.Drawing.Size(192, 240)
        Me.lvTar.TabIndex = 3
        Me.lvTar.UseCompatibleStateImageBehavior = False
        Me.lvTar.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 250
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Tamaño"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Fecha"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 140
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Directorio"
        Me.ColumnHeader4.Width = 200
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbVerHtml, Me.ToolStripSeparator1, Me.tsLabelDireccion, Me.tsDireccion, Me.tsbIr})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(640, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbVerHtml
        '
        Me.tsbVerHtml.AutoToolTip = False
        Me.tsbVerHtml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbVerHtml.Image = CType(resources.GetObject("tsbVerHtml.Image"), System.Drawing.Image)
        Me.tsbVerHtml.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbVerHtml.Name = "tsbVerHtml"
        Me.tsbVerHtml.Size = New System.Drawing.Size(23, 22)
        Me.tsbVerHtml.Text = "ToolStripButton1"
        Me.tsbVerHtml.ToolTipText = "Ver contenido HTML (código fuente)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsLabelDireccion
        '
        Me.tsLabelDireccion.Name = "tsLabelDireccion"
        Me.tsLabelDireccion.Size = New System.Drawing.Size(60, 22)
        Me.tsLabelDireccion.Text = "Dirección:"
        '
        'tsDireccion
        '
        Me.tsDireccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tsDireccion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList
        Me.tsDireccion.AutoSize = False
        Me.tsDireccion.Name = "tsDireccion"
        Me.tsDireccion.Size = New System.Drawing.Size(400, 25)
        '
        'tsbIr
        '
        Me.tsbIr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbIr.Image = CType(resources.GetObject("tsbIr.Image"), System.Drawing.Image)
        Me.tsbIr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbIr.Name = "tsbIr"
        Me.tsbIr.Size = New System.Drawing.Size(23, 22)
        Me.tsbIr.Text = "Ir"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(212, 386)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rtbTexto)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.WebBrowser1)
        Me.Panel1.Controls.Add(Me.lvTar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(4)
        Me.Panel1.Size = New System.Drawing.Size(640, 462)
        Me.Panel1.TabIndex = 6
        '
        'VisorTexto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 515)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "VisorTexto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "visorTexto"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtbTexto As System.Windows.Forms.RichTextBox
    Private WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents tsLabelDireccion As ToolStripLabel
    Private WithEvents tsDireccion As ToolStripTextBox
    Private WithEvents lvTar As ListView
    Private WithEvents ToolStrip1 As ToolStrip
    Private WithEvents StatusStrip1 As StatusStrip
    Private WithEvents statusLabelInfo As ToolStripStatusLabel
    Private WithEvents PictureBox1 As PictureBox
    Private WithEvents Panel1 As Panel
    Private WithEvents ColumnHeader1 As ColumnHeader
    Private WithEvents ColumnHeader2 As ColumnHeader
    Private WithEvents ColumnHeader3 As ColumnHeader
    Private WithEvents ColumnHeader4 As ColumnHeader
    Private WithEvents ToolStripSeparator1 As ToolStripSeparator
    Private WithEvents tsbVerHtml As ToolStripButton
    Private WithEvents tsbIr As ToolStripButton
    Private WithEvents btnGuardarComo As ToolStripStatusLabel
End Class
