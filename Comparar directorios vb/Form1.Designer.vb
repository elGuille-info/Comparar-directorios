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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"--", "generarClaveSHA1.sln", "4.906.213", "19/11/2020 21:16:30"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lvDirIzq = New System.Windows.Forms.ListView()
        Me.chInfoIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNombreIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTamañoIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFechaIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStripIzq = New System.Windows.Forms.ToolStrip()
        Me.btnAbrirDirIzq = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelIzq1 = New System.Windows.Forms.ToolStripLabel()
        Me.lvDirDer = New System.Windows.Forms.ListView()
        Me.chInfoDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNombreDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTamañoDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFechaDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevoFichero = New System.Windows.Forms.ToolStripButton()
        Me.btnCopiar = New System.Windows.Forms.ToolStripButton()
        Me.btnMover = New System.Windows.Forms.ToolStripButton()
        Me.btnBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnMkDir = New System.Windows.Forms.ToolStripButton()
        Me.btnCopiarDir = New System.Windows.Forms.ToolStripButton()
        Me.btnMoverDir = New System.Windows.Forms.ToolStripButton()
        Me.btnBorrarDir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripInfo = New System.Windows.Forms.StatusStrip()
        Me.LabelInfo = New System.Windows.Forms.ToolStripStatusLabel()
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
        Me.lvDirIzq.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chInfoIzq, Me.chNombreIzq, Me.chTamañoIzq, Me.chFechaIzq})
        Me.lvDirIzq.FullRowSelect = True
        Me.lvDirIzq.GridLines = True
        Me.lvDirIzq.HideSelection = False
        ListViewItem1.StateImageIndex = 0
        Me.lvDirIzq.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvDirIzq.Location = New System.Drawing.Point(6, 28)
        Me.lvDirIzq.Name = "lvDirIzq"
        Me.lvDirIzq.ShowItemToolTips = True
        Me.lvDirIzq.Size = New System.Drawing.Size(504, 474)
        Me.lvDirIzq.TabIndex = 1
        Me.lvDirIzq.UseCompatibleStateImageBehavior = False
        Me.lvDirIzq.View = System.Windows.Forms.View.Details
        '
        'chInfoIzq
        '
        Me.chInfoIzq.Text = "Info"
        Me.chInfoIzq.Width = 36
        '
        'chNombreIzq
        '
        Me.chNombreIzq.Text = "Nombre"
        Me.chNombreIzq.Width = 230
        '
        'chTamañoIzq
        '
        Me.chTamañoIzq.Text = "Tamaño bytes"
        Me.chTamañoIzq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chTamañoIzq.Width = 80
        '
        'chFechaIzq
        '
        Me.chFechaIzq.Text = "Fecha Modificación"
        Me.chFechaIzq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.chFechaIzq.Width = 120
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
        Me.btnAbrirDirIzq.Size = New System.Drawing.Size(62, 22)
        Me.btnAbrirDirIzq.Text = "Abrir..."
        Me.btnAbrirDirIzq.ToolTipText = "Seleccionar el directorio a abrir en el panel izquierdo"
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
        Me.lvDirDer.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chInfoDer, Me.chNombreDer, Me.chTamañoDer, Me.chFechaDer})
        Me.lvDirDer.FullRowSelect = True
        Me.lvDirDer.GridLines = True
        Me.lvDirDer.HideSelection = False
        Me.lvDirDer.Location = New System.Drawing.Point(6, 28)
        Me.lvDirDer.Name = "lvDirDer"
        Me.lvDirDer.ShowItemToolTips = True
        Me.lvDirDer.Size = New System.Drawing.Size(505, 474)
        Me.lvDirDer.TabIndex = 4
        Me.lvDirDer.UseCompatibleStateImageBehavior = False
        Me.lvDirDer.View = System.Windows.Forms.View.Details
        '
        'chInfoDer
        '
        Me.chInfoDer.Text = "Info"
        Me.chInfoDer.Width = 36
        '
        'chNombreDer
        '
        Me.chNombreDer.Text = "Nombre"
        Me.chNombreDer.Width = 230
        '
        'chTamañoDer
        '
        Me.chTamañoDer.Text = "Tamaño bytes"
        Me.chTamañoDer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chTamañoDer.Width = 80
        '
        'chFechaDer
        '
        Me.chFechaDer.Text = "Fecha Modificación"
        Me.chFechaDer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.chFechaDer.Width = 120
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
        Me.btnAbrirDirDer.Size = New System.Drawing.Size(62, 22)
        Me.btnAbrirDirDer.Text = "Abrir..."
        Me.btnAbrirDirDer.ToolTipText = "Seleccionar el directorio a abrir en el panel derecho"
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
        Me.ToolStripComparar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnComparar, Me.ToolStripSeparator3, Me.btnLimpiar, Me.ToolStripSeparator4, Me.btnMostrar, Me.ToolStripSeparator5, Me.btnNuevoFichero, Me.btnCopiar, Me.btnMover, Me.btnBorrar, Me.ToolStripSeparator6, Me.btnMkDir, Me.btnCopiarDir, Me.btnMoverDir, Me.btnBorrarDir})
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
        Me.btnMostrar.ToolTipText = "Abrir en el Notepad el primer fichero seleccionado del panel activo"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnNuevoFichero
        '
        Me.btnNuevoFichero.AutoToolTip = False
        Me.btnNuevoFichero.Image = CType(resources.GetObject("btnNuevoFichero.Image"), System.Drawing.Image)
        Me.btnNuevoFichero.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevoFichero.Name = "btnNuevoFichero"
        Me.btnNuevoFichero.Size = New System.Drawing.Size(62, 22)
        Me.btnNuevoFichero.Text = "Nuevo"
        Me.btnNuevoFichero.ToolTipText = "Crear un nuevo fichero en el panel (directorio) activo"
        '
        'btnCopiar
        '
        Me.btnCopiar.AutoToolTip = False
        Me.btnCopiar.Image = CType(resources.GetObject("btnCopiar.Image"), System.Drawing.Image)
        Me.btnCopiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(62, 22)
        Me.btnCopiar.Text = "Copiar"
        Me.btnCopiar.ToolTipText = "Copiar el primer fichero seleccionado del panel activo al otro panel (directorio)" &
    ""
        '
        'btnMover
        '
        Me.btnMover.AutoToolTip = False
        Me.btnMover.Image = CType(resources.GetObject("btnMover.Image"), System.Drawing.Image)
        Me.btnMover.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMover.Name = "btnMover"
        Me.btnMover.Size = New System.Drawing.Size(61, 22)
        Me.btnMover.Text = "Mover"
        Me.btnMover.ToolTipText = "Mover el fichero seleccionado del panel activo al otro panel (directorio)"
        '
        'btnBorrar
        '
        Me.btnBorrar.AutoToolTip = False
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Image)
        Me.btnBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(70, 22)
        Me.btnBorrar.Text = "Eliminar"
        Me.btnBorrar.ToolTipText = "Eliminar el primer fichero seleccionado del panel activo"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'btnMkDir
        '
        Me.btnMkDir.AutoToolTip = False
        Me.btnMkDir.Image = CType(resources.GetObject("btnMkDir.Image"), System.Drawing.Image)
        Me.btnMkDir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMkDir.Name = "btnMkDir"
        Me.btnMkDir.Size = New System.Drawing.Size(62, 22)
        Me.btnMkDir.Text = "Nuevo"
        Me.btnMkDir.ToolTipText = "Crear un nuevo directorio en el panel activo"
        '
        'btnCopiarDir
        '
        Me.btnCopiarDir.AutoToolTip = False
        Me.btnCopiarDir.Image = CType(resources.GetObject("btnCopiarDir.Image"), System.Drawing.Image)
        Me.btnCopiarDir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopiarDir.Name = "btnCopiarDir"
        Me.btnCopiarDir.Size = New System.Drawing.Size(62, 22)
        Me.btnCopiarDir.Text = "Copiar"
        Me.btnCopiarDir.ToolTipText = "Copiar el directorio seleccionado del panel activo al otro panel (directorio)"
        '
        'btnMoverDir
        '
        Me.btnMoverDir.AutoToolTip = False
        Me.btnMoverDir.Image = CType(resources.GetObject("btnMoverDir.Image"), System.Drawing.Image)
        Me.btnMoverDir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMoverDir.Name = "btnMoverDir"
        Me.btnMoverDir.Size = New System.Drawing.Size(61, 22)
        Me.btnMoverDir.Text = "Mover"
        Me.btnMoverDir.ToolTipText = "Mover el directorio seleccionado del panel activo al otro panel (directorio)"
        '
        'btnBorrarDir
        '
        Me.btnBorrarDir.AutoToolTip = False
        Me.btnBorrarDir.Image = CType(resources.GetObject("btnBorrarDir.Image"), System.Drawing.Image)
        Me.btnBorrarDir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBorrarDir.Name = "btnBorrarDir"
        Me.btnBorrarDir.Size = New System.Drawing.Size(70, 22)
        Me.btnBorrarDir.Text = "Eliminar"
        Me.btnBorrarDir.ToolTipText = "Eliminar el directorio seleccionado"
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
    Private WithEvents chInfoIzq As ColumnHeader
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
    Private WithEvents chInfoDer As ColumnHeader
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
    Private WithEvents btnMover As ToolStripButton
    Private WithEvents ToolStripSeparator6 As ToolStripSeparator
    Private WithEvents btnMkDir As ToolStripButton
    Private WithEvents btnCopiarDir As ToolStripButton
    Private WithEvents btnMoverDir As ToolStripButton
    Private WithEvents btnBorrarDir As ToolStripButton
    Private WithEvents btnNuevoFichero As ToolStripButton
End Class