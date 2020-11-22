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
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"--", "generarClaveSHA1.sln", "4.906.213", "19/11/2020 21:16:30"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lvDirIzq = New System.Windows.Forms.ListView()
        Me.chInfoIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNombreIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTamañoIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFechaIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStripIzq = New System.Windows.Forms.ToolStrip()
        Me.btnAbrirDirIzq = New System.Windows.Forms.ToolStripButton()
        Me.BtnAbrirDirIzqDropDown = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelDirIzq = New System.Windows.Forms.ToolStripLabel()
        Me.lvDirDer = New System.Windows.Forms.ListView()
        Me.chInfoDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNombreDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTamañoDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFechaDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStripDer = New System.Windows.Forms.ToolStrip()
        Me.btnAbrirDirDer = New System.Windows.Forms.ToolStripButton()
        Me.BtnAbrirDirDerDropDown = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelDirDer = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComparar = New System.Windows.Forms.ToolStrip()
        Me.btnComparar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnActualizarMasRecientes = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnCambiarNombre = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnVer = New System.Windows.Forms.ToolStripDropDownButton()
        Me.MnuVerEnNotepad = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuVerEnElVisor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuTemas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTemaPredeterminado = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTemaOscuro = New System.Windows.Forms.ToolStripMenuItem()
        Me.NortonCommanderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnCopiarSplit = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnMoverSplit = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnNuevoDropDown = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnEliminarSplit = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnIntercambiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnMover = New System.Windows.Forms.ToolStripButton()
        Me.btnMoverDir = New System.Windows.Forms.ToolStripButton()
        Me.btnCopiar = New System.Windows.Forms.ToolStripButton()
        Me.btnCopiarDir = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminarDir = New System.Windows.Forms.ToolStripButton()
        Me.btnNuevoFichero = New System.Windows.Forms.ToolStripButton()
        Me.BtnNuevoDir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripInfo = New System.Windows.Forms.StatusStrip()
        Me.LabelInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
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
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 38)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(1088, 495)
        Me.SplitContainer1.SplitterDistance = 541
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
        Me.lvDirIzq.HideSelection = False
        ListViewItem2.StateImageIndex = 0
        Me.lvDirIzq.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem2})
        Me.lvDirIzq.Location = New System.Drawing.Point(6, 28)
        Me.lvDirIzq.Name = "lvDirIzq"
        Me.lvDirIzq.ShowItemToolTips = True
        Me.lvDirIzq.Size = New System.Drawing.Size(530, 464)
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
        Me.chNombreIzq.Width = 250
        '
        'chTamañoIzq
        '
        Me.chTamañoIzq.Text = "Tamaño bytes"
        Me.chTamañoIzq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chTamañoIzq.Width = 100
        '
        'chFechaIzq
        '
        Me.chFechaIzq.Text = "Fecha Modificación"
        Me.chFechaIzq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.chFechaIzq.Width = 120
        '
        'ToolStripIzq
        '
        Me.ToolStripIzq.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripIzq.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAbrirDirIzq, Me.BtnAbrirDirIzqDropDown, Me.ToolStripSeparator1, Me.LabelDirIzq})
        Me.ToolStripIzq.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripIzq.Name = "ToolStripIzq"
        Me.ToolStripIzq.Size = New System.Drawing.Size(541, 25)
        Me.ToolStripIzq.TabIndex = 0
        Me.ToolStripIzq.Text = "ToolStrip2"
        '
        'btnAbrirDirIzq
        '
        Me.btnAbrirDirIzq.AutoToolTip = False
        Me.btnAbrirDirIzq.Image = CType(resources.GetObject("btnAbrirDirIzq.Image"), System.Drawing.Image)
        Me.btnAbrirDirIzq.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrirDirIzq.Name = "btnAbrirDirIzq"
        Me.btnAbrirDirIzq.Size = New System.Drawing.Size(53, 22)
        Me.btnAbrirDirIzq.Text = "Abrir"
        Me.btnAbrirDirIzq.ToolTipText = "Seleccionar el directorio a abrir en el panel izquierdo"
        '
        'BtnAbrirDirIzqDropDown
        '
        Me.BtnAbrirDirIzqDropDown.AutoToolTip = False
        Me.BtnAbrirDirIzqDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnAbrirDirIzqDropDown.Image = CType(resources.GetObject("BtnAbrirDirIzqDropDown.Image"), System.Drawing.Image)
        Me.BtnAbrirDirIzqDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAbrirDirIzqDropDown.Name = "BtnAbrirDirIzqDropDown"
        Me.BtnAbrirDirIzqDropDown.Size = New System.Drawing.Size(29, 22)
        Me.BtnAbrirDirIzqDropDown.Text = "..."
        Me.BtnAbrirDirIzqDropDown.ToolTipText = "Seleccionar un directorio de los últimos directorios usados"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'LabelDirIzq
        '
        Me.LabelDirIzq.AutoSize = False
        Me.LabelDirIzq.Name = "LabelDirIzq"
        Me.LabelDirIzq.Size = New System.Drawing.Size(87, 22)
        Me.LabelDirIzq.Text = "LabelDirIzq"
        Me.LabelDirIzq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvDirDer
        '
        Me.lvDirDer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDirDer.BackColor = System.Drawing.SystemColors.Info
        Me.lvDirDer.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chInfoDer, Me.chNombreDer, Me.chTamañoDer, Me.chFechaDer})
        Me.lvDirDer.FullRowSelect = True
        Me.lvDirDer.HideSelection = False
        Me.lvDirDer.Location = New System.Drawing.Point(6, 28)
        Me.lvDirDer.Name = "lvDirDer"
        Me.lvDirDer.ShowItemToolTips = True
        Me.lvDirDer.Size = New System.Drawing.Size(532, 464)
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
        Me.chNombreDer.Width = 250
        '
        'chTamañoDer
        '
        Me.chTamañoDer.Text = "Tamaño bytes"
        Me.chTamañoDer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chTamañoDer.Width = 100
        '
        'chFechaDer
        '
        Me.chFechaDer.Text = "Fecha Modificación"
        Me.chFechaDer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.chFechaDer.Width = 120
        '
        'ToolStripDer
        '
        Me.ToolStripDer.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripDer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAbrirDirDer, Me.BtnAbrirDirDerDropDown, Me.ToolStripSeparator2, Me.LabelDirDer})
        Me.ToolStripDer.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripDer.Name = "ToolStripDer"
        Me.ToolStripDer.Size = New System.Drawing.Size(543, 25)
        Me.ToolStripDer.TabIndex = 1
        Me.ToolStripDer.Text = "ToolStrip1"
        '
        'btnAbrirDirDer
        '
        Me.btnAbrirDirDer.AutoToolTip = False
        Me.btnAbrirDirDer.Image = CType(resources.GetObject("btnAbrirDirDer.Image"), System.Drawing.Image)
        Me.btnAbrirDirDer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrirDirDer.Name = "btnAbrirDirDer"
        Me.btnAbrirDirDer.Size = New System.Drawing.Size(53, 22)
        Me.btnAbrirDirDer.Text = "Abrir"
        Me.btnAbrirDirDer.ToolTipText = "Seleccionar el directorio a abrir en el panel derecho"
        '
        'BtnAbrirDirDerDropDown
        '
        Me.BtnAbrirDirDerDropDown.AutoToolTip = False
        Me.BtnAbrirDirDerDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnAbrirDirDerDropDown.Image = CType(resources.GetObject("BtnAbrirDirDerDropDown.Image"), System.Drawing.Image)
        Me.BtnAbrirDirDerDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAbrirDirDerDropDown.Name = "BtnAbrirDirDerDropDown"
        Me.BtnAbrirDirDerDropDown.Size = New System.Drawing.Size(29, 22)
        Me.BtnAbrirDirDerDropDown.Text = "..."
        Me.BtnAbrirDirDerDropDown.ToolTipText = "Seleccionar un directorio de los últimos directorios usados"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'LabelDirDer
        '
        Me.LabelDirDer.AutoSize = False
        Me.LabelDirDer.Name = "LabelDirDer"
        Me.LabelDirDer.Size = New System.Drawing.Size(87, 22)
        Me.LabelDirDer.Text = "LabelDirDer"
        Me.LabelDirDer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripComparar
        '
        Me.ToolStripComparar.AutoSize = False
        Me.ToolStripComparar.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripComparar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnComparar, Me.ToolStripSeparator3, Me.btnLimpiar, Me.ToolStripSeparator4, Me.BtnActualizarMasRecientes, Me.ToolStripSeparator7, Me.BtnCambiarNombre, Me.ToolStripSeparator10, Me.BtnVer, Me.ToolStripSeparator11, Me.BtnCopiarSplit, Me.ToolStripSeparator9, Me.BtnMoverSplit, Me.ToolStripSeparator6, Me.BtnNuevoDropDown, Me.ToolStripSeparator8, Me.BtnEliminarSplit, Me.ToolStripSeparator13, Me.BtnIntercambiar, Me.ToolStripSeparator5})
        Me.ToolStripComparar.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripComparar.Name = "ToolStripComparar"
        Me.ToolStripComparar.Size = New System.Drawing.Size(1088, 25)
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
        Me.btnComparar.ToolTipText = "Comparar el contenido de los dos directorios" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(es posible que antes debas pulsar " &
    "en Releer)"
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
        'BtnActualizarMasRecientes
        '
        Me.BtnActualizarMasRecientes.AutoToolTip = False
        Me.BtnActualizarMasRecientes.Image = CType(resources.GetObject("BtnActualizarMasRecientes.Image"), System.Drawing.Image)
        Me.BtnActualizarMasRecientes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnActualizarMasRecientes.Name = "BtnActualizarMasRecientes"
        Me.BtnActualizarMasRecientes.Size = New System.Drawing.Size(79, 22)
        Me.BtnActualizarMasRecientes.Text = "Actualizar"
        Me.BtnActualizarMasRecientes.ToolTipText = "Actualiza los ficheros más recientes (o no existentes) del panel izquierdo y los " &
    "copia en el derecho (F9)"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'BtnCambiarNombre
        '
        Me.BtnCambiarNombre.AutoToolTip = False
        Me.BtnCambiarNombre.Image = CType(resources.GetObject("BtnCambiarNombre.Image"), System.Drawing.Image)
        Me.BtnCambiarNombre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCambiarNombre.Name = "BtnCambiarNombre"
        Me.BtnCambiarNombre.Size = New System.Drawing.Size(86, 22)
        Me.BtnCambiarNombre.Text = "Renombrar"
        Me.BtnCambiarNombre.ToolTipText = "Cambiar el nombre del fichero o directorio seleccionado en el panel activo (F2)"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'BtnVer
        '
        Me.BtnVer.AutoToolTip = False
        Me.BtnVer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuVerEnNotepad, Me.MnuVerEnElVisor, Me.ToolStripSeparator12, Me.MnuTemas})
        Me.BtnVer.Image = CType(resources.GetObject("BtnVer.Image"), System.Drawing.Image)
        Me.BtnVer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnVer.Name = "BtnVer"
        Me.BtnVer.Size = New System.Drawing.Size(52, 22)
        Me.BtnVer.Text = "Ver"
        Me.BtnVer.ToolTipText = "Abrir en el visor el primer fichero seleccionado del panel activo (F3)"
        '
        'MnuVerEnNotepad
        '
        Me.MnuVerEnNotepad.Image = CType(resources.GetObject("MnuVerEnNotepad.Image"), System.Drawing.Image)
        Me.MnuVerEnNotepad.Name = "MnuVerEnNotepad"
        Me.MnuVerEnNotepad.Size = New System.Drawing.Size(180, 22)
        Me.MnuVerEnNotepad.Text = "Ver en Notepad"
        Me.MnuVerEnNotepad.ToolTipText = "Al ver en Notepad también se puede editar y guardar"
        '
        'MnuVerEnElVisor
        '
        Me.MnuVerEnElVisor.Image = CType(resources.GetObject("MnuVerEnElVisor.Image"), System.Drawing.Image)
        Me.MnuVerEnElVisor.Name = "MnuVerEnElVisor"
        Me.MnuVerEnElVisor.Size = New System.Drawing.Size(180, 22)
        Me.MnuVerEnElVisor.Text = "Ver en el visor"
        Me.MnuVerEnElVisor.ToolTipText = "Mostrar en el visor integrado" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Permite ver textos, textos enroquecido y HTML"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(177, 6)
        '
        'MnuTemas
        '
        Me.MnuTemas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuTemaPredeterminado, Me.MnuTemaOscuro, Me.NortonCommanderToolStripMenuItem})
        Me.MnuTemas.Image = CType(resources.GetObject("MnuTemas.Image"), System.Drawing.Image)
        Me.MnuTemas.Name = "MnuTemas"
        Me.MnuTemas.Size = New System.Drawing.Size(180, 22)
        Me.MnuTemas.Text = "Temas"
        '
        'MnuTemaPredeterminado
        '
        Me.MnuTemaPredeterminado.Name = "MnuTemaPredeterminado"
        Me.MnuTemaPredeterminado.Size = New System.Drawing.Size(182, 22)
        Me.MnuTemaPredeterminado.Text = "Predeterminado"
        '
        'MnuTemaOscuro
        '
        Me.MnuTemaOscuro.Image = CType(resources.GetObject("MnuTemaOscuro.Image"), System.Drawing.Image)
        Me.MnuTemaOscuro.Name = "MnuTemaOscuro"
        Me.MnuTemaOscuro.Size = New System.Drawing.Size(182, 22)
        Me.MnuTemaOscuro.Text = "Oscuro"
        '
        'NortonCommanderToolStripMenuItem
        '
        Me.NortonCommanderToolStripMenuItem.Image = CType(resources.GetObject("NortonCommanderToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NortonCommanderToolStripMenuItem.Name = "NortonCommanderToolStripMenuItem"
        Me.NortonCommanderToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.NortonCommanderToolStripMenuItem.Text = "Norton Commander"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'BtnCopiarSplit
        '
        Me.BtnCopiarSplit.AutoToolTip = False
        Me.BtnCopiarSplit.Image = CType(resources.GetObject("BtnCopiarSplit.Image"), System.Drawing.Image)
        Me.BtnCopiarSplit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCopiarSplit.Name = "BtnCopiarSplit"
        Me.BtnCopiarSplit.Size = New System.Drawing.Size(74, 22)
        Me.BtnCopiarSplit.Text = "Copiar"
        Me.BtnCopiarSplit.ToolTipText = "Selecciona la opción para copiar ficheros o directorios " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(o pulsa F5 para copiar" &
    " los ficheros y directorios seleccionados)"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'BtnMoverSplit
        '
        Me.BtnMoverSplit.AutoToolTip = False
        Me.BtnMoverSplit.Image = CType(resources.GetObject("BtnMoverSplit.Image"), System.Drawing.Image)
        Me.BtnMoverSplit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnMoverSplit.Name = "BtnMoverSplit"
        Me.BtnMoverSplit.Size = New System.Drawing.Size(73, 22)
        Me.BtnMoverSplit.Text = "Mover"
        Me.BtnMoverSplit.ToolTipText = "Selecciona la opción para mover ficheros o directorios " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(o pulsa F6 para mover l" &
    "os ficheros y directorios seleccionados)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'BtnNuevoDropDown
        '
        Me.BtnNuevoDropDown.AutoToolTip = False
        Me.BtnNuevoDropDown.Image = CType(resources.GetObject("BtnNuevoDropDown.Image"), System.Drawing.Image)
        Me.BtnNuevoDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNuevoDropDown.Name = "BtnNuevoDropDown"
        Me.BtnNuevoDropDown.Size = New System.Drawing.Size(71, 22)
        Me.BtnNuevoDropDown.Text = "Nuevo"
        Me.BtnNuevoDropDown.ToolTipText = "Selecciona la opción para crear un nuevo fichero o un nuevo directorio " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(o pulsa" &
    " F7  para crear un directorio o Ctrl+N para crear un fichero)"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'BtnEliminarSplit
        '
        Me.BtnEliminarSplit.AutoToolTip = False
        Me.BtnEliminarSplit.Image = CType(resources.GetObject("BtnEliminarSplit.Image"), System.Drawing.Image)
        Me.BtnEliminarSplit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEliminarSplit.Name = "BtnEliminarSplit"
        Me.BtnEliminarSplit.Size = New System.Drawing.Size(82, 22)
        Me.BtnEliminarSplit.Text = "Eliminar"
        Me.BtnEliminarSplit.ToolTipText = "Selecciona la opción para eliminar ficheros o directorios " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(o pulsa F8 para elim" &
    "inar los ficheros y directorios seleccionados)"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'BtnIntercambiar
        '
        Me.BtnIntercambiar.AutoToolTip = False
        Me.BtnIntercambiar.Image = CType(resources.GetObject("BtnIntercambiar.Image"), System.Drawing.Image)
        Me.BtnIntercambiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIntercambiar.Name = "BtnIntercambiar"
        Me.BtnIntercambiar.Size = New System.Drawing.Size(94, 22)
        Me.BtnIntercambiar.Text = "Intercambiar"
        Me.BtnIntercambiar.ToolTipText = "Intercambiar los directorios de panel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(por si quieres actualizar, ya que solo ac" &
    "tualiza del izquierdo al derecho)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnMover
        '
        Me.btnMover.AutoToolTip = False
        Me.btnMover.Image = CType(resources.GetObject("btnMover.Image"), System.Drawing.Image)
        Me.btnMover.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMover.Name = "btnMover"
        Me.btnMover.Size = New System.Drawing.Size(61, 22)
        Me.btnMover.Text = "Mover fichero"
        Me.btnMover.ToolTipText = "Mover los ficheros seleccionados del panel activo al otro panel (directorio)"
        '
        'btnMoverDir
        '
        Me.btnMoverDir.AutoToolTip = False
        Me.btnMoverDir.Image = CType(resources.GetObject("btnMoverDir.Image"), System.Drawing.Image)
        Me.btnMoverDir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMoverDir.Name = "btnMoverDir"
        Me.btnMoverDir.Size = New System.Drawing.Size(61, 22)
        Me.btnMoverDir.Text = "Mover directorio"
        Me.btnMoverDir.ToolTipText = "Mover los directorios seleccionados del panel activo al otro panel (directorio)"
        '
        'btnCopiar
        '
        Me.btnCopiar.AutoToolTip = False
        Me.btnCopiar.Image = CType(resources.GetObject("btnCopiar.Image"), System.Drawing.Image)
        Me.btnCopiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(62, 22)
        Me.btnCopiar.Text = "Copiar fichero"
        Me.btnCopiar.ToolTipText = "Copiar los ficheros seleccionados del panel activo al otro panel (directorio)"
        '
        'btnCopiarDir
        '
        Me.btnCopiarDir.AutoToolTip = False
        Me.btnCopiarDir.Image = CType(resources.GetObject("btnCopiarDir.Image"), System.Drawing.Image)
        Me.btnCopiarDir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopiarDir.Name = "btnCopiarDir"
        Me.btnCopiarDir.Size = New System.Drawing.Size(62, 22)
        Me.btnCopiarDir.Text = "Copiar directorio"
        Me.btnCopiarDir.ToolTipText = "Copiar los directorios seleccionados del panel activo al otro panel (directorio)"
        '
        'btnEliminar
        '
        Me.btnEliminar.AutoToolTip = False
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(115, 22)
        Me.btnEliminar.Text = "Eliminar ficheros"
        Me.btnEliminar.ToolTipText = "Eliminar los ficheros seleccionados del panel activo"
        '
        'btnEliminarDir
        '
        Me.btnEliminarDir.AutoToolTip = False
        Me.btnEliminarDir.Image = CType(resources.GetObject("btnEliminarDir.Image"), System.Drawing.Image)
        Me.btnEliminarDir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminarDir.Name = "btnEliminarDir"
        Me.btnEliminarDir.Size = New System.Drawing.Size(129, 22)
        Me.btnEliminarDir.Text = "Eliminar directorios"
        Me.btnEliminarDir.ToolTipText = "Eliminar los directorios seleccionados en el panel activo"
        '
        'btnNuevoFichero
        '
        Me.btnNuevoFichero.AutoToolTip = False
        Me.btnNuevoFichero.Image = CType(resources.GetObject("btnNuevoFichero.Image"), System.Drawing.Image)
        Me.btnNuevoFichero.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevoFichero.Name = "btnNuevoFichero"
        Me.btnNuevoFichero.Size = New System.Drawing.Size(62, 22)
        Me.btnNuevoFichero.Text = "Nuevo fichero"
        Me.btnNuevoFichero.ToolTipText = "Crear un nuevo fichero en el panel (directorio) activo"
        '
        'BtnNuevoDir
        '
        Me.BtnNuevoDir.AutoToolTip = False
        Me.BtnNuevoDir.Image = CType(resources.GetObject("BtnNuevoDir.Image"), System.Drawing.Image)
        Me.BtnNuevoDir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNuevoDir.Name = "BtnNuevoDir"
        Me.BtnNuevoDir.Size = New System.Drawing.Size(62, 22)
        Me.BtnNuevoDir.Text = "Nuevo directorio"
        Me.BtnNuevoDir.ToolTipText = "Crear un nuevo directorio en el panel activo"
        '
        'StatusStripInfo
        '
        Me.StatusStripInfo.BackColor = System.Drawing.Color.Transparent
        Me.StatusStripInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelInfo})
        Me.StatusStripInfo.Location = New System.Drawing.Point(0, 536)
        Me.StatusStripInfo.Name = "StatusStripInfo"
        Me.StatusStripInfo.Size = New System.Drawing.Size(1088, 22)
        Me.StatusStripInfo.TabIndex = 1
        Me.StatusStripInfo.Text = "StatusStrip1"
        '
        'LabelInfo
        '
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(1073, 17)
        Me.LabelInfo.Spring = True
        Me.LabelInfo.Text = "ToolStripStatusLabel1"
        Me.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox13
        '
        Me.TextBox13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox13.Location = New System.Drawing.Point(976, 12)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(100, 20)
        Me.TextBox13.TabIndex = 4
        Me.TextBox13.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1088, 558)
        Me.Controls.Add(Me.TextBox13)
        Me.Controls.Add(Me.ToolStripComparar)
        Me.Controls.Add(Me.StatusStripInfo)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1040, 500)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comparar directorios - Mostrar el contenido de 2 directorios y gestionarlos"
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
    Private WithEvents StatusStripInfo As StatusStrip
    Private WithEvents LabelInfo As ToolStripStatusLabel
    Private WithEvents LabelDirIzq As ToolStripLabel
    Private WithEvents LabelDirDer As ToolStripLabel
    Private WithEvents ToolStripSeparator4 As ToolStripSeparator
    Private WithEvents ToolStripSeparator5 As ToolStripSeparator
    Private WithEvents btnCopiar As ToolStripButton
    Private WithEvents ToolStripSeparator1 As ToolStripSeparator
    Private WithEvents ToolStripSeparator2 As ToolStripSeparator
    Private WithEvents btnEliminar As ToolStripButton
    Private WithEvents btnMover As ToolStripButton
    Private WithEvents ToolStripSeparator6 As ToolStripSeparator
    Private WithEvents BtnNuevoDir As ToolStripButton
    Private WithEvents btnCopiarDir As ToolStripButton
    Private WithEvents btnMoverDir As ToolStripButton
    Private WithEvents btnEliminarDir As ToolStripButton
    Private WithEvents btnNuevoFichero As ToolStripButton
    Private WithEvents BtnAbrirDirIzqDropDown As ToolStripDropDownButton
    Private WithEvents BtnAbrirDirDerDropDown As ToolStripDropDownButton
    Private WithEvents ToolStripSeparator7 As ToolStripSeparator
    Private WithEvents BtnActualizarMasRecientes As ToolStripButton
    Private WithEvents ToolStripSeparator10 As ToolStripSeparator
    Private WithEvents ToolStripSeparator8 As ToolStripSeparator
    Private WithEvents ToolStripSeparator9 As ToolStripSeparator
    Private WithEvents BtnNuevoDropDown As ToolStripDropDownButton
    Private WithEvents BtnEliminarSplit As ToolStripSplitButton
    Private WithEvents ToolStripSeparator11 As ToolStripSeparator
    Private WithEvents TextBox13 As TextBox
    Private WithEvents BtnCambiarNombre As ToolStripButton
    Private WithEvents BtnCopiarSplit As ToolStripSplitButton
    Private WithEvents BtnMoverSplit As ToolStripSplitButton
    Private WithEvents BtnVer As ToolStripDropDownButton
    Private WithEvents MnuVerEnNotepad As ToolStripMenuItem
    Private WithEvents MnuVerEnElVisor As ToolStripMenuItem
    Private WithEvents ToolStripSeparator12 As ToolStripSeparator
    Private WithEvents MnuTemas As ToolStripMenuItem
    Private WithEvents MnuTemaPredeterminado As ToolStripMenuItem
    Private WithEvents MnuTemaOscuro As ToolStripMenuItem
    Private WithEvents NortonCommanderToolStripMenuItem As ToolStripMenuItem
    Private WithEvents BtnIntercambiar As ToolStripButton
    Private WithEvents ToolStripSeparator13 As ToolStripSeparator
End Class