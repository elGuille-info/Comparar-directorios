<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"--", "generarClaveSHA1.sln", "19/11/2020 21:16:30", "4.906.213"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"--", "generarClaveSHA1.sln", "19/11/2020 21:16:30", "4.906.213"}, -1)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lvDirIzq = New System.Windows.Forms.ListView()
        Me.chDirIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNombreIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFechaIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTamañoIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStripIzq = New System.Windows.Forms.ToolStrip()
        Me.btnAbrirDirIzq = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelIzq1 = New System.Windows.Forms.ToolStripLabel()
        Me.lvDirDer = New System.Windows.Forms.ListView()
        Me.chDirDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNombreDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFechaDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTamañoDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStripDer = New System.Windows.Forms.ToolStrip()
        Me.btnAbrirDirDer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelDer1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComparar = New System.Windows.Forms.ToolStrip()
        Me.btnComparar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnMostrar = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripInfo = New System.Windows.Forms.StatusStrip()
        Me.LabelInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCopiar = New System.Windows.Forms.ToolStripButton()
        Me.btnBorrar = New System.Windows.Forms.ToolStripButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStripIzq.SuspendLayout()
        Me.ToolStripDer.SuspendLayout()
        Me.ToolStripComparar.SuspendLayout()
        Me.StatusStripInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lvDirIzq)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStripIzq)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvDirDer)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStripDer)
        Me.SplitContainer1.Size = New System.Drawing.Size(1035, 505)
        Me.SplitContainer1.SplitterDistance = 515
        Me.SplitContainer1.TabIndex = 0
        '
        'lvDirIzq
        '
        Me.lvDirIzq.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDirIzq.BackColor = System.Drawing.SystemColors.Info
        Me.lvDirIzq.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chDirIzq, Me.chNombreIzq, Me.chFechaIzq, Me.chTamañoIzq})
        Me.lvDirIzq.FullRowSelect = True
        Me.lvDirIzq.GridLines = True
        Me.lvDirIzq.HideSelection = False
        ListViewItem7.StateImageIndex = 0
        Me.lvDirIzq.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem7})
        Me.lvDirIzq.Location = New System.Drawing.Point(6, 28)
        Me.lvDirIzq.Name = "lvDirIzq"
        Me.lvDirIzq.ShowItemToolTips = True
        Me.lvDirIzq.Size = New System.Drawing.Size(504, 474)
        Me.lvDirIzq.TabIndex = 1
        Me.lvDirIzq.UseCompatibleStateImageBehavior = False
        Me.lvDirIzq.View = System.Windows.Forms.View.Details
        '
        'chDirIzq
        '
        Me.chDirIzq.Text = "Dir"
        Me.chDirIzq.Width = 36
        '
        'chNombreIzq
        '
        Me.chNombreIzq.Text = "Nombre"
        Me.chNombreIzq.Width = 230
        '
        'chFechaIzq
        '
        Me.chFechaIzq.Text = "Fecha Modificación"
        Me.chFechaIzq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.chFechaIzq.Width = 120
        '
        'chTamañoIzq
        '
        Me.chTamañoIzq.Text = "Tamaño bytes"
        Me.chTamañoIzq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chTamañoIzq.Width = 80
        '
        'ToolStripIzq
        '
        Me.ToolStripIzq.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAbrirDirIzq, Me.ToolStripSeparator1, Me.LabelIzq1})
        Me.ToolStripIzq.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripIzq.Name = "ToolStripIzq"
        Me.ToolStripIzq.Size = New System.Drawing.Size(515, 25)
        Me.ToolStripIzq.TabIndex = 0
        Me.ToolStripIzq.Text = "ToolStrip2"
        '
        'btnAbrirDirIzq
        '
        Me.btnAbrirDirIzq.AutoToolTip = False
        Me.btnAbrirDirIzq.Image = CType(resources.GetObject("btnAbrirDirIzq.Image"), System.Drawing.Image)
        Me.btnAbrirDirIzq.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrirDirIzq.Name = "btnAbrirDirIzq"
        Me.btnAbrirDirIzq.Size = New System.Drawing.Size(107, 22)
        Me.btnAbrirDirIzq.Text = "Abrir directorio"
        Me.btnAbrirDirIzq.ToolTipText = "Abrir el directorio en el panel izquierdo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'LabelIzq1
        '
        Me.LabelIzq1.AutoSize = False
        Me.LabelIzq1.Name = "LabelIzq1"
        Me.LabelIzq1.Size = New System.Drawing.Size(87, 22)
        Me.LabelIzq1.Text = "ToolStripLabel1"
        Me.LabelIzq1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvDirDer
        '
        Me.lvDirDer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDirDer.BackColor = System.Drawing.SystemColors.Info
        Me.lvDirDer.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chDirDer, Me.chNombreDer, Me.chFechaDer, Me.chTamañoDer})
        Me.lvDirDer.FullRowSelect = True
        Me.lvDirDer.GridLines = True
        Me.lvDirDer.HideSelection = False
        ListViewItem8.StateImageIndex = 0
        Me.lvDirDer.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem8})
        Me.lvDirDer.Location = New System.Drawing.Point(6, 28)
        Me.lvDirDer.Name = "lvDirDer"
        Me.lvDirDer.ShowItemToolTips = True
        Me.lvDirDer.Size = New System.Drawing.Size(505, 474)
        Me.lvDirDer.TabIndex = 4
        Me.lvDirDer.UseCompatibleStateImageBehavior = False
        Me.lvDirDer.View = System.Windows.Forms.View.Details
        '
        'chDirDer
        '
        Me.chDirDer.Text = "Dir"
        Me.chDirDer.Width = 36
        '
        'chNombreDer
        '
        Me.chNombreDer.Text = "Nombre"
        Me.chNombreDer.Width = 230
        '
        'chFechaDer
        '
        Me.chFechaDer.Text = "Fecha Modificación"
        Me.chFechaDer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.chFechaDer.Width = 120
        '
        'chTamañoDer
        '
        Me.chTamañoDer.Text = "Tamaño bytes"
        Me.chTamañoDer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chTamañoDer.Width = 80
        '
        'ToolStripDer
        '
        Me.ToolStripDer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAbrirDirDer, Me.ToolStripSeparator2, Me.LabelDer1})
        Me.ToolStripDer.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripDer.Name = "ToolStripDer"
        Me.ToolStripDer.Size = New System.Drawing.Size(516, 25)
        Me.ToolStripDer.TabIndex = 1
        Me.ToolStripDer.Text = "ToolStrip1"
        '
        'btnAbrirDirDer
        '
        Me.btnAbrirDirDer.AutoToolTip = False
        Me.btnAbrirDirDer.Image = CType(resources.GetObject("btnAbrirDirDer.Image"), System.Drawing.Image)
        Me.btnAbrirDirDer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrirDirDer.Name = "btnAbrirDirDer"
        Me.btnAbrirDirDer.Size = New System.Drawing.Size(107, 22)
        Me.btnAbrirDirDer.Text = "Abrir directorio"
        Me.btnAbrirDirDer.ToolTipText = "Abrir directorio en el panel derecho"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'LabelDer1
        '
        Me.LabelDer1.AutoSize = False
        Me.LabelDer1.Name = "LabelDer1"
        Me.LabelDer1.Size = New System.Drawing.Size(87, 22)
        Me.LabelDer1.Text = "ToolStripLabel2"
        Me.LabelDer1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripComparar
        '
        Me.ToolStripComparar.AutoSize = False
        Me.ToolStripComparar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnComparar, Me.ToolStripSeparator3, Me.btnLimpiar, Me.ToolStripSeparator4, Me.btnMostrar, Me.ToolStripSeparator5, Me.btnCopiar, Me.btnBorrar})
        Me.ToolStripComparar.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripComparar.Name = "ToolStripComparar"
        Me.ToolStripComparar.Size = New System.Drawing.Size(1035, 25)
        Me.ToolStripComparar.TabIndex = 3
        Me.ToolStripComparar.Text = "ToolStripComparar"
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
        Me.btnLimpiar.Size = New System.Drawing.Size(59, 22)
        Me.btnLimpiar.Text = "Releer"
        Me.btnLimpiar.ToolTipText = "Volver a leer el contenido de los dos directorios"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnMostrar
        '
        Me.btnMostrar.AutoToolTip = False
        Me.btnMostrar.Image = CType(resources.GetObject("btnMostrar.Image"), System.Drawing.Image)
        Me.btnMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(43, 22)
        Me.btnMostrar.Text = "Ver"
        Me.btnMostrar.ToolTipText = "Abrir en el Notepad el primer fichero seleccionado"
        '
        'StatusStripInfo
        '
        Me.StatusStripInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelInfo})
        Me.StatusStripInfo.Location = New System.Drawing.Point(0, 536)
        Me.StatusStripInfo.Name = "StatusStripInfo"
        Me.StatusStripInfo.Size = New System.Drawing.Size(1035, 22)
        Me.StatusStripInfo.TabIndex = 1
        Me.StatusStripInfo.Text = "StatusStrip1"
        '
        'LabelInfo
        '
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(1020, 17)
        Me.LabelInfo.Spring = True
        Me.LabelInfo.Text = "ToolStripStatusLabel1"
        Me.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnCopiar
        '
        Me.btnCopiar.AutoToolTip = False
        Me.btnCopiar.Image = CType(resources.GetObject("btnCopiar.Image"), System.Drawing.Image)
        Me.btnCopiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(62, 22)
        Me.btnCopiar.Text = "Copiar"
        Me.btnCopiar.ToolTipText = "Copiar el primer fichero seleccionado al otro directorio"
        '
        'btnBorrar
        '
        Me.btnBorrar.AutoToolTip = False
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Image)
        Me.btnBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(59, 22)
        Me.btnBorrar.Text = "Borrar"
        Me.btnBorrar.ToolTipText = "Borrar el primer fichero seleccionado"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 558)
        Me.Controls.Add(Me.ToolStripComparar)
        Me.Controls.Add(Me.StatusStripInfo)
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
        Me.ToolStripDer.ResumeLayout(False)
        Me.ToolStripDer.PerformLayout()
        Me.ToolStripComparar.ResumeLayout(False)
        Me.ToolStripComparar.PerformLayout()
        Me.StatusStripInfo.ResumeLayout(False)
        Me.StatusStripInfo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStripIzq As ToolStrip
    Private WithEvents btnAbrirDirIzq As ToolStripButton
    Private WithEvents btnAbrirDirDer As ToolStripButton
    Private WithEvents lvDirIzq As ListView
    Private WithEvents chDirIzq As ColumnHeader
    Private WithEvents chNombreIzq As ColumnHeader
    Private WithEvents chFechaIzq As ColumnHeader
    Private WithEvents SplitContainer1 As SplitContainer
    Private WithEvents ToolStripComparar As ToolStrip
    Private WithEvents btnComparar As ToolStripButton
    Private WithEvents ToolStripDer As ToolStrip
    Private WithEvents ToolStripSeparator3 As ToolStripSeparator
    Private WithEvents btnLimpiar As ToolStripButton
    Private WithEvents chTamañoIzq As ColumnHeader
    Private WithEvents lvDirDer As ListView
    Private WithEvents chDirDer As ColumnHeader
    Private WithEvents chNombreDer As ColumnHeader
    Private WithEvents chFechaDer As ColumnHeader
    Private WithEvents chTamañoDer As ColumnHeader
    Friend WithEvents StatusStripInfo As StatusStrip
    Private WithEvents LabelInfo As ToolStripStatusLabel
    Private WithEvents LabelIzq1 As ToolStripLabel
    Private WithEvents LabelDer1 As ToolStripLabel
    Private WithEvents ToolStripSeparator4 As ToolStripSeparator
    Private WithEvents btnMostrar As ToolStripButton
    Private WithEvents ToolStripSeparator5 As ToolStripSeparator
    Private WithEvents btnCopiar As ToolStripButton
    Private WithEvents ToolStripSeparator1 As ToolStripSeparator
    Private WithEvents ToolStripSeparator2 As ToolStripSeparator
    Private WithEvents btnBorrar As ToolStripButton
End Class