<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"--", "generarClaveSHA1.sln", "19/11/2020 21:16:30", "4.906.213"}, -1)
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"--", "generarClaveSHA1.sln", "19/11/2020 21:16:30", "4.906.213"}, -1)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ToolStripIzq = New System.Windows.Forms.ToolStrip()
        Me.btnAbrirDirIzquierdo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripComparar = New System.Windows.Forms.ToolStrip()
        Me.btnComparar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LabelIzq = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lvDirIzq = New System.Windows.Forms.ListView()
        Me.chDir = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStripDer = New System.Windows.Forms.ToolStrip()
        Me.btnAbrirDirDerecho = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.LabelDer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.chTamaño = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvDirDer = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStripIzq.SuspendLayout()
        Me.ToolStripComparar.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStripDer.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStripComparar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStripIzq)
        Me.SplitContainer1.Panel1.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lvDirIzq)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvDirDer)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStripDer)
        Me.SplitContainer1.Panel2.Controls.Add(Me.StatusStrip2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1035, 558)
        Me.SplitContainer1.SplitterDistance = 515
        Me.SplitContainer1.TabIndex = 0
        '
        'ToolStripIzq
        '
        Me.ToolStripIzq.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStripIzq.AutoSize = False
        Me.ToolStripIzq.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripIzq.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAbrirDirIzquierdo})
        Me.ToolStripIzq.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripIzq.Name = "ToolStripIzq"
        Me.ToolStripIzq.Size = New System.Drawing.Size(324, 25)
        Me.ToolStripIzq.TabIndex = 0
        Me.ToolStripIzq.Text = "ToolStrip2"
        '
        'btnAbrirDirIzquierdo
        '
        Me.btnAbrirDirIzquierdo.Image = CType(resources.GetObject("btnAbrirDirIzquierdo.Image"), System.Drawing.Image)
        Me.btnAbrirDirIzquierdo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrirDirIzquierdo.Name = "btnAbrirDirIzquierdo"
        Me.btnAbrirDirIzquierdo.Size = New System.Drawing.Size(159, 22)
        Me.btnAbrirDirIzquierdo.Text = "Abrir directorio Izquierdo"
        '
        'ToolStripComparar
        '
        Me.ToolStripComparar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStripComparar.AutoSize = False
        Me.ToolStripComparar.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripComparar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnComparar, Me.ToolStripSeparator3, Me.btnLimpiar})
        Me.ToolStripComparar.Location = New System.Drawing.Point(324, 0)
        Me.ToolStripComparar.Name = "ToolStripComparar"
        Me.ToolStripComparar.Size = New System.Drawing.Size(184, 25)
        Me.ToolStripComparar.TabIndex = 3
        Me.ToolStripComparar.Text = "ToolStrip1"
        '
        'btnComparar
        '
        Me.btnComparar.Image = CType(resources.GetObject("btnComparar.Image"), System.Drawing.Image)
        Me.btnComparar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnComparar.Name = "btnComparar"
        Me.btnComparar.Size = New System.Drawing.Size(80, 22)
        Me.btnComparar.Text = "Comparar"
        Me.btnComparar.ToolTipText = "Comparar el contenido de los dos directorios"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(67, 22)
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.ToolTipText = "Limpiar la comparación"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelIzq})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 536)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.ShowItemToolTips = True
        Me.StatusStrip1.Size = New System.Drawing.Size(515, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LabelIzq
        '
        Me.LabelIzq.Name = "LabelIzq"
        Me.LabelIzq.Size = New System.Drawing.Size(500, 17)
        Me.LabelIzq.Spring = True
        Me.LabelIzq.Text = "ToolStripStatusLabel1"
        Me.LabelIzq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvDirIzq
        '
        Me.lvDirIzq.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDirIzq.BackColor = System.Drawing.SystemColors.Info
        Me.lvDirIzq.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chDir, Me.chNombre, Me.chFecha, Me.chTamaño})
        Me.lvDirIzq.FullRowSelect = True
        Me.lvDirIzq.GridLines = True
        Me.lvDirIzq.HideSelection = False
        ListViewItem7.StateImageIndex = 0
        Me.lvDirIzq.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem7})
        Me.lvDirIzq.Location = New System.Drawing.Point(6, 28)
        Me.lvDirIzq.MultiSelect = False
        Me.lvDirIzq.Name = "lvDirIzq"
        Me.lvDirIzq.ShowItemToolTips = True
        Me.lvDirIzq.Size = New System.Drawing.Size(504, 505)
        Me.lvDirIzq.TabIndex = 1
        Me.lvDirIzq.UseCompatibleStateImageBehavior = False
        Me.lvDirIzq.View = System.Windows.Forms.View.Details
        '
        'chDir
        '
        Me.chDir.Text = "Dir"
        Me.chDir.Width = 36
        '
        'chNombre
        '
        Me.chNombre.Text = "Nombre"
        Me.chNombre.Width = 230
        '
        'chFecha
        '
        Me.chFecha.Text = "Fecha / Hora"
        Me.chFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.chFecha.Width = 120
        '
        'ToolStripDer
        '
        Me.ToolStripDer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAbrirDirDerecho})
        Me.ToolStripDer.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripDer.Name = "ToolStripDer"
        Me.ToolStripDer.Size = New System.Drawing.Size(516, 25)
        Me.ToolStripDer.TabIndex = 1
        Me.ToolStripDer.Text = "ToolStrip1"
        '
        'btnAbrirDirDerecho
        '
        Me.btnAbrirDirDerecho.Image = CType(resources.GetObject("btnAbrirDirDerecho.Image"), System.Drawing.Image)
        Me.btnAbrirDirDerecho.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrirDirDerecho.Name = "btnAbrirDirDerecho"
        Me.btnAbrirDirDerecho.Size = New System.Drawing.Size(153, 22)
        Me.btnAbrirDirDerecho.Text = "Abrir directorio derecho"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelDer})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 536)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.ShowItemToolTips = True
        Me.StatusStrip2.Size = New System.Drawing.Size(516, 22)
        Me.StatusStrip2.TabIndex = 3
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'LabelDer
        '
        Me.LabelDer.Name = "LabelDer"
        Me.LabelDer.Size = New System.Drawing.Size(501, 17)
        Me.LabelDer.Spring = True
        Me.LabelDer.Text = "ToolStripStatusLabel2"
        Me.LabelDer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chTamaño
        '
        Me.chTamaño.Text = "Tamaño"
        Me.chTamaño.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chTamaño.Width = 80
        '
        'lvDirDer
        '
        Me.lvDirDer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDirDer.BackColor = System.Drawing.SystemColors.Info
        Me.lvDirDer.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvDirDer.FullRowSelect = True
        Me.lvDirDer.GridLines = True
        Me.lvDirDer.HideSelection = False
        ListViewItem8.StateImageIndex = 0
        Me.lvDirDer.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem8})
        Me.lvDirDer.Location = New System.Drawing.Point(6, 28)
        Me.lvDirDer.MultiSelect = False
        Me.lvDirDer.Name = "lvDirDer"
        Me.lvDirDer.ShowItemToolTips = True
        Me.lvDirDer.Size = New System.Drawing.Size(505, 505)
        Me.lvDirDer.TabIndex = 4
        Me.lvDirDer.UseCompatibleStateImageBehavior = False
        Me.lvDirDer.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Dir"
        Me.ColumnHeader1.Width = 36
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width = 230
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Fecha / Hora"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Tamaño"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 80
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 558)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1040, 500)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mostrar el contenido de 2 directorios y compararlos"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStripIzq.ResumeLayout(False)
        Me.ToolStripIzq.PerformLayout()
        Me.ToolStripComparar.ResumeLayout(False)
        Me.ToolStripComparar.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStripDer.ResumeLayout(False)
        Me.ToolStripDer.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ToolStripIzq As ToolStrip
    Private WithEvents btnAbrirDirIzquierdo As ToolStripButton
    Private WithEvents btnAbrirDirDerecho As ToolStripButton
    Private WithEvents lvDirIzq As ListView
    Private WithEvents chDir As ColumnHeader
    Private WithEvents chNombre As ColumnHeader
    Private WithEvents chFecha As ColumnHeader
    Private WithEvents SplitContainer1 As SplitContainer
    Private WithEvents LabelIzq As ToolStripStatusLabel
    Private WithEvents LabelDer As ToolStripStatusLabel
    Private WithEvents StatusStrip1 As StatusStrip
    Private WithEvents StatusStrip2 As StatusStrip
    Private WithEvents ToolStripComparar As ToolStrip
    Private WithEvents btnComparar As ToolStripButton
    Private WithEvents ToolStripDer As ToolStrip
    Private WithEvents ToolStripSeparator3 As ToolStripSeparator
    Private WithEvents btnLimpiar As ToolStripButton
    Private WithEvents chTamaño As ColumnHeader
    Private WithEvents lvDirDer As ListView
    Private WithEvents ColumnHeader1 As ColumnHeader
    Private WithEvents ColumnHeader2 As ColumnHeader
    Private WithEvents ColumnHeader3 As ColumnHeader
    Private WithEvents ColumnHeader4 As ColumnHeader
End Class
